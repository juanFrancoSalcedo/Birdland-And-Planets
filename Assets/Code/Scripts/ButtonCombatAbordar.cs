using B_Extensions;
using System;
using UnityEngine;


namespace Combat
{
    public class ButtonCombatAbordar: BaseButtonAttendant
    {
        [SerializeField] CombatManager combatManager;

        private void Start()
        {
            buttonComponent.onClick.AddListener(Attack);
        }

        private void Attack()
        {
            var tripula = combatManager.Current;
            tripula.DebtEffort();
            combatManager.Target.MakeDamage(combatManager.Current.Stats.BaseAttack, 0.1f);
        }

        private void Update()
        {
            if (combatManager.Current != null) 
                buttonComponent.interactable = combatManager.Current.CanAttackAbordar() && combatManager.Current.CanEffortTurn();
        }
    }
}
     
