using B_Extensions;
using UnityEngine;


namespace Combat
{ 
    public class CombatManager : Singleton<CombatManager>
    {
        [SerializeField] TripulanteCombatHandler[] barcoUno;
        [SerializeField] TripulanteCombatHandler[] barcoDos;
        [SerializeField] GameObject panelAttack;

        public TripulanteCombatHandler Current;
        public TripulanteCombatHandler Target;
        private void Start() 
        {

        }

        public void ShowUI() 
        {
            panelAttack.SetActive(true);
        }
    }
}
