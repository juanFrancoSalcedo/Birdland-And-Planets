using System;
using UnityEngine;
using Zenject;

public class FishBank : MonoBehaviour
{
    FoodMediator mediator;
    [SerializeField] TriggerDetector triggerDetector;

    [Inject]
    public void Construct(FoodMediator mediator) 
    {
        this.mediator = mediator;
    }


    private void OnEnable()
    {
        triggerDetector.OnTriggerEntered += CheckCollision;
    }

    private void CheckCollision(Transform transform)
    {
        gameObject.SetActive(false);
        mediator.SumFish(10f);
    }

    private void OnDisable()
    {
        triggerDetector.OnTriggerEntered -= CheckCollision;
    }

    public class Factory: PlaceholderFactory<FishBank>{}
}
