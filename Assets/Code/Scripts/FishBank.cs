using System;
using UnityEngine;
using Zenject;

public class FishBank : MonoBehaviour
{
    [SerializeField] TriggerDetector triggerDetector;
    FoodMediator mediator;

    [Inject]
    public void Construct(FoodMediator mediator) 
    {
        this.mediator = mediator;
    }
    private void OnEnable() => triggerDetector.OnTriggerEntered += CheckCollision;
    private void OnDisable() => triggerDetector.OnTriggerEntered -= CheckCollision;

    private void CheckCollision(Transform transform)
    {
        gameObject.SetActive(false);
        mediator.SumFish(10f);
    }


    public class Factory: PlaceholderFactory<FishBank>{}
}
