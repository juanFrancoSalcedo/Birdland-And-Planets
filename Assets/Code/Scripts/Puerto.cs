using UnityEditor;
using UnityEngine;

public class Puerto : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BarcoMio"))
        {
            ShipUIFacade.Instance.ShowPort();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BarcoMio"))
        {
            ShipUIFacade.Instance.HidePort();
        }
    }
}
