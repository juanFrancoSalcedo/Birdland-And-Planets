using System.Collections;
using UnityEngine;


namespace Combat
{
    public class AutomaticSetIA : MonoBehaviour
    {
        [SerializeField] private TripulanteCombatHandler IATripulante;
        [SerializeField] private TripulanteCombatHandler targetPlayer;
        [SerializeField] private QuadCobertura quadCobertura;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(2);
            quadCobertura.SetTripulantePlace(IATripulante);
            IATripulante.DebtEffort();
            while (true) 
            {
                if (IATripulante.CanAttackDisparar())
                    print("Quiere AI Puedo disparar");
                if (IATripulante.CanAttackDispararHechizo())
                    print("Quiere AI Disparar Hechizo");
                if (IATripulante.CanAttackAbordar() && IATripulante.CanEffortTurn())
                {
                    yield return new WaitForSeconds(0.5f);
                    IATripulante.DebtEffort();
                    targetPlayer.MakeDamage(IATripulante.Stats.BaseAttack, 0.1f);
                    print("AI Abordar");
                }
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
