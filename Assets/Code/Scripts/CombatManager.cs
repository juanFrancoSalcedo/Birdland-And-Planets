using B_Extensions;
using UnityEngine;


namespace Combat
{ 
    public class CombatManager : Singleton<CombatManager>
    {
        [SerializeField] CombatCharacterTripulante[] barcoUno;
        [SerializeField] CombatCharacterTripulante[] barcoDos;
        [SerializeField] GameObject panelAttack;

        public CombatCharacterTripulante Current;
        private void Start() 
        {

        }

        public void ShowUI() 
        {
            panelAttack.SetActive(true);
        }
    }
}
