
using System.Collections.Generic;
using UnityEngine;


namespace Combat
{
    public class TripulanteCombatHandler : MonoBehaviour
    {
        [field: SerializeField] public bool OnCannon { get; set; } = false;
        [SerializeField] private List<Rasgo> rasgos = new List<Rasgo>();
        [SerializeField] TripulanteCombatStats stats;
        [field:SerializeField] public QuadCobertura QuadOn { get; set; }

        public TripulanteCombatStats Stats=>stats;

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
                print("2ntramos con "+random+" de "+result);
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

        public bool CanAttackAbordar() => rasgos.Contains(Rasgo.Abordador);
        public bool CanAttackDisparar() => rasgos.Contains(Rasgo.Arquero) || rasgos.Contains(Rasgo.Hunter);
        public bool CanAttackDispararHechizo() => rasgos.Contains(Rasgo.Energizador);
        public bool CanAttackDispararCannon() => OnCannon;
        public bool CanRecargarCannon() => false;
    }
}

[System.Serializable]
public class TripulanteCombatStats 
{
    public int HP;
    public int BaseAttack;
    [Range(0,1)]public float Cobertura;
    [Range(0, 1)] public float Precision;
}
