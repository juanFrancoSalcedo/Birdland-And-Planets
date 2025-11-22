using System;
using UnityEngine;
using Zenject;

public class FishBank : MonoBehaviour
{
    [Inject] FoodMediator mediator;
    [SerializeField] TriggerDetector triggerDetector;


    private void OnEnable()
    {
        triggerDetector.OnTriggerEntered += CheckCollision;
    }

    private void CheckCollision(Transform transform)
    {
        gameObject.SetActive(false);
        //print("Consumi u pescadito");
        mediator.SumFish(10f);
    }

    private void OnDisable()
    {
        triggerDetector.OnTriggerEntered -= CheckCollision;
    }

}
