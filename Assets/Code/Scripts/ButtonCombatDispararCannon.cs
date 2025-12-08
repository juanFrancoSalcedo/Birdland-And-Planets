using B_Extensions;
using UnityEngine;


namespace Combat
{
    public class ButtonCombatDispararCannon : BaseButtonAttendant
    {
        [SerializeField] CombatManager combatManager;

        private void Start()
        {
            buttonComponent.onClick.AddListener(Shot);
        }

        private void Shot() 
        {
            if (combatManager.Current != null)
            { 
                var tripula = combatManager.Current;
                var stats = combatManager.Current.Stats;
                combatManager.Target.MakeDamage(3,stats.Precision);
                combatManager.Target.QuadOn.ReduceCobertura(0.1f);
                combatManager.Current.QuadOn.ShotCannon();
                tripula.DebtEffort();
            }
        }

        private void Update()
        {
            if (combatManager.Current != null)
            { 
                buttonComponent.interactable = combatManager.Current.CanAttackDispararCannon() &&
                    combatManager.Current.QuadOn.IsCannonLoaded && combatManager.Current.CanEffortTurn();
            
            }
        }
    }
}
