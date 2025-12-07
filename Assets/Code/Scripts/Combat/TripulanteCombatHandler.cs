using System.Collections.Generic;
using UnityEngine;


namespace Combat
{
    public class TripulanteCombatHandler : MonoBehaviour
    {
        [SerializeField] private List<Rasgo> rasgos = new List<Rasgo>();
        [SerializeField] TripulanteCombatStats stats;
        [field:SerializeField] public QuadCobertura QuadOn { get; set; }
        [field: SerializeField] public bool OnCannon { get; set; } = false;

        TripulanteCombatStats inGameStats;
        int effortTurn;
        public TripulanteCombatStats Stats=> inGameStats;

        public event System.Action<int> OnEffortChanged;

        private void Awake()
        {
            inGameStats = stats.Copy();
            effortTurn = inGameStats.Effort;
        }

        public bool aliade = false;
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
            stats.Cobertura = coverNew;
        }

        public bool MakeDamage(int dmg, float precision) 
        {
            print(dmg);
            var upper = 40 * precision;
            var lower = 0.1f+ stats.Cobertura;
            var result = Mathf.Clamp((float)upper / lower,0,100);
            var random = Random.Range(0,100);
            if (random <= result)
            {
                print("entramos con "+random+" de "+result);
                stats.HP -= dmg;
                if (stats.HP <=0)
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

        public bool DebtEffort() 
        {
            bool rsEffort = effortTurn>0;

            if (rsEffort) 
            {
                effortTurn--;
                OnEffortChanged?.Invoke(effortTurn);
            }
            return rsEffort;
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

    public TripulanteCombatStats Copy()
    {
        return (TripulanteCombatStats)this.MemberwiseClone();
    }
}
