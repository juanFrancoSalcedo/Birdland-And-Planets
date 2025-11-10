using B_Extensions;
using UnityEngine;


namespace Combat
{
    public class ButtonCombatDispararHechizo : BaseButtonAttendant
    {
        [SerializeField] CombatManager combatManager;
        private void Update()
        {
            if (combatManager.Current != null)
                buttonComponent.interactable = combatManager.Current.CanAttackDispararHechizo();
        }
    }
}
