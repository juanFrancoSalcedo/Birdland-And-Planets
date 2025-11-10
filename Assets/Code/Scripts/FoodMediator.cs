using System;
using UnityEngine;
using Zenject;

public class FoodMediator : MonoBehaviour
{
    [Inject] GameClock clock;
    [SerializeField] private float fish;
    public float FishAmout => fish;
    public void SumFish(float newAmout)
    {
        fish += newAmout;
    }

    private void OnEnable()
    {
        clock.OnHourPass += PassHour;
    }
    private void OnDisable() 
    {
        if(clock)
            clock.OnHourPass -= PassHour;
    }

    int hoursPassed =0;
    private void PassHour()
    {
        hoursPassed++;
        if (hoursPassed >= 3)
        {
            Eat();
            hoursPassed = 0;
        }
    }

    private void Eat()
    {
        fish--;
    }
}
