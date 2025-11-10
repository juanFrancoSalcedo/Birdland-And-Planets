using UnityEngine;
using Zenject;

public class FishBank : MonoBehaviour
{
    [Inject] FoodMediator mediator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BarcoMio"))
        {
            gameObject.SetActive(false);
            //print("Consumi u pescadito");
            mediator.SumFish(10f);
        }
    }
}
