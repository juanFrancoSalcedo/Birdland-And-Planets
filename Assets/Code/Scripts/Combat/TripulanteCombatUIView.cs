using Combat;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



namespace Combat
{
    public class TripulanteCombatUIView : MonoBehaviour
    {
        [SerializeField] Image[] effortBars;
        [SerializeField] TripulanteCombatHandler tripulanteController;
        [SerializeField] TMP_Text textHP;
        Color colRecharge = Color.cadetBlue;
        Color colDone = Color.peachPuff;

        void Start()
        {
            DrawEffort(tripulanteController.Stats.Effort);
            DrawHP(tripulanteController.Stats.HP, tripulanteController.Stats.HP);
        }

        private void OnEnable()
        {
            tripulanteController.OnEffortCompleteChanged += DrawEffort;
            tripulanteController.OnHpChanged += DrawHP;
            tripulanteController.OnEffortRechargeChanged += DrawEffortTime;
        }

        private void OnDisable()
        {
            tripulanteController.OnEffortCompleteChanged -= DrawEffort;
            tripulanteController.OnHpChanged -= DrawHP;
            tripulanteController.OnEffortRechargeChanged -= DrawEffortTime;
        }

        private void DrawHP(int arg1, int arg2)
        {
            textHP.text = $"{arg1} / {arg2}";
        }

        private void DrawEffort(int obj)
        {

            for (int i = 0; i < effortBars.Length; i++)
            {
                if (i < obj)
                { 
                    effortBars[i].fillAmount = 1f;
                    effortBars[i].color = colDone;
                }
                else
                    effortBars[i].fillAmount = 0f;
            }
        }

        private void DrawEffortTime(int index,float t) 
        {
            effortBars[index].color = colDone;
            print(index+" "+effortBars.Length);
            if (index < effortBars.Length)
            { 
                effortBars[index].fillAmount = Mathf.Lerp(0, 1, t);
                effortBars[index].color = colRecharge;
            }
        }
    }

}