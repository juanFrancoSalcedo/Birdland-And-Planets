using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Combat
{
    public class TripulanteCombatHandler : MonoBehaviour
    {
        [SerializeField] private List<Rasgo> rasgos = new List<Rasgo>();
        [SerializeField] TripulanteCombatStats stats;
        [field:SerializeField] public QuadCobertura QuadOn { get; set; }
        [field: SerializeField] public bool OnCannon { get; set; } = false;
        public bool aliade = false;

        TripulanteCombatStats inGameStats;
        int effortTurn;
        public TripulanteCombatStats Stats=> inGameStats;

        public event System.Action<int,int> OnHpChanged;
        public event System.Action<int,float> OnEffortRechargeChanged;
        public event System.Action<int> OnEffortCompleteChanged;

        private void Awake()
        {
            inGameStats = stats.Copy();
            effortTurn = inGameStats.Effort;
        }

        public void OnMouseUpAsButton()
        {
            if (aliade)
            {
                CombatManager.Instance.Current = this;
            }
            else
            {
                var current = CombatManager.Instance.Current;
                if (current != null && current.aliade)
                {
                    CombatManager.Instance.ShowUI();
                    CombatManager.Instance.Target = this;
                }
            }
        }
        //TODO visitor
        public void ModifyCover(float coverNew) 
        {
            inGameStats.Cobertura = coverNew;
        }

        public bool MakeDamage(int dmg, float precision) 
        {
            var upper = 40 * precision;
            var lower = 0.1f+ inGameStats.Cobertura;
            var result = Mathf.Clamp((float)upper / lower,0,100);
            var random = Random.Range(0,100);
            if (random <= result)
            {
                print("entramos con "+random+" de "+result);
                inGameStats.HP -= dmg;
                OnHpChanged?.Invoke(inGameStats.HP, stats.HP);
                if (inGameStats.HP <=0)
                { 
                    gameObject.SetActive(false);
                }
                return true;
            }
            else
            {
                print("Miss");
                return false;
            }
        }
        public bool CanEffortTurn() => effortTurn > 0;
        Coroutine effortReloadCor = null;
        public bool DebtEffort() 
        {
            bool rsEffort = CanEffortTurn();

            if (rsEffort) 
                effortTurn--;

            if (effortTurn < stats.Effort)
                CheckStartReloadEffort();

            return rsEffort;
        }

        private IEnumerator ReloadEffort() 
        {
            float timeDisered = (float)stats.TimeReloadEffort;
            float startTime = Time.time;
            float t = 0;
            while (Time.time - startTime < timeDisered)
            {
                t = (Time.time - startTime) / timeDisered;
                OnEffortRechargeChanged?.Invoke(effortTurn,t);
                yield return null;
            }
            OnEffortRechargeChanged?.Invoke(effortTurn,t);
            effortReloadCor = null;
            effortTurn++;
            if (effortTurn != stats.Effort)
                CheckStartReloadEffort();

            OnEffortCompleteChanged?.Invoke(effortTurn);
        }

        private void CheckStartReloadEffort()
        {
            if (effortReloadCor == null)
                effortReloadCor = StartCoroutine(ReloadEffort());
            else
            {
                StopCoroutine(effortReloadCor);
                effortReloadCor = StartCoroutine(ReloadEffort());
            }
        }

        public bool CanAttackAbordar() => rasgos.Contains(Rasgo.Abordador);
        public bool CanAttackDisparar() => rasgos.Contains(Rasgo.Arquero) || rasgos.Contains(Rasgo.Hunter);
        public bool CanAttackDispararHechizo() => rasgos.Contains(Rasgo.Energizador);
        public bool CanAttackDispararCannon() => OnCannon;
        public bool CanRecargarCannon() => OnCannon && !QuadOn.IsCannonLoaded;
    }
}

[System.Serializable]
public class TripulanteCombatStats:ICopy<TripulanteCombatStats>
{
    public int HP;
    public int BaseAttack;
    [Range(0,1)]public float Cobertura;
    [Range(0, 1)] public float Precision;
    [Range(0, 5)] public int Effort;
    [Range(6, 50)] public int TimeReloadEffort;

    public TripulanteCombatStats Copy()
    {
        return (TripulanteCombatStats)this.MemberwiseClone();
    }
}
