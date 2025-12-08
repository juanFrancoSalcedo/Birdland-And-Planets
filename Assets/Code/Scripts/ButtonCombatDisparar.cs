using B_Extensions;
using UnityEngine;


namespace Combat
{
    public class ButtonCombatDisparar : BaseButtonAttendant
    {
        [SerializeField] CombatManager combatManager;

        private void Start()
        {
            buttonComponent.onClick.AddListener(Attack);
        }

        private void Update()
        {
            if (combatManager.Current != null)
                buttonComponent.interactable = combatManager.Current.CanAttackDisparar();
        }

        private void Attack()
        {
            var tripula = combatManager.Current;
            var stats = combatManager.Current.Stats;
            combatManager.Target.MakeDamage(stats.BaseAttack, stats.Precision);
            tripula.DebtEffort();
        }
    }
}
