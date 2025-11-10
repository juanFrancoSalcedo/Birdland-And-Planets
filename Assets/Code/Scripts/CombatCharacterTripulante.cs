using UnityEngine;


namespace Combat
{
    public class CombatCharacterTripulante : MonoBehaviour
    {
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
                    print("TODO");
                }
            }
        }

        public bool CanAttackAbordar() => true;

        public bool CanAttackDisparar() => true;

        public bool CanAttackDispararHechizo() => true;

        public bool CanAttackDispararCannon() => true;

        public bool CanRecargarCannon() => true;
    }
}
