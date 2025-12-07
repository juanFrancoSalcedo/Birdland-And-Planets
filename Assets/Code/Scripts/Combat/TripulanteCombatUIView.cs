using Combat;
using System;
using UnityEngine;



namespace Combat
{
    public class TripulanteCombatUIView : MonoBehaviour
    {
        [SerializeField] GameObject[] effortBars;
        [SerializeField] TripulanteCombatHandler tripulanteController;
        void Start()
        {
            DrawEffort(tripulanteController.Stats.Effort);
        }

        private void OnEnable()
        {
            tripulanteController.OnEffortChanged += DrawEffort;
        }
        private void OnDisable()
        {
            tripulanteController.OnEffortChanged -= DrawEffort;
        }

        private void DrawEffort(int obj)
        {
            for (int i = 0; i < effortBars.Length; i++)
            {
                if (i < tripulanteController.Stats.Effort)
                    effortBars[i].SetActive(true);
                else
                    effortBars[i].SetActive(false);
            }
        }


    }

}