using B_Extensions;
using UnityEngine;
using UnityEngine.UI;

public class ShipUIFacade: Singleton<ShipUIFacade>
{
    [SerializeField] private Button buttonReclutar;
    [SerializeField] private Button buttonStore;
    public void ShowPort() 
    {
        buttonReclutar.gameObject.SetActive(true);
        buttonStore.gameObject.SetActive(true);
    }

    public void HidePort()
    {
        buttonReclutar.gameObject.SetActive(false);
        buttonStore.gameObject.SetActive(false);
    }
}