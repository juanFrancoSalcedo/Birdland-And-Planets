using B_Extensions;
using System;
using UnityEngine;


namespace Combat
{
    public class ButtonCombatRecargaCannon : BaseButtonAttendant
    {
        [SerializeField] CombatManager combatManager;

        private void Start()
        {
            buttonComponent.onClick.AddListener(ReloadCannon);            
        }

        private void ReloadCannon()
        {
            var tripula = combatManager.Current;
            if (combatManager.Current != null)
            { 
                tripula.DebtEffort();
                combatManager.Current.QuadOn.ReloadCanon();
            }
        }

        private void Update()
        {
            if (combatManager.Current != null)
                buttonComponent.interactable = combatManager.Current.CanRecargarCannon() && combatManager.Current.CanEffortTurn();
        }
    }
}
