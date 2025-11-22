using System.Collections;
using UnityEngine;


namespace Combat
{
    public class AutomaticSetIA : MonoBehaviour
    {
        [SerializeField] private TripulanteCombatHandler combatiente;
        [SerializeField] private QuadCobertura quadCobertura;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(2);
            quadCobertura.SetTripulantePlace(combatiente);
        }
    }
}
