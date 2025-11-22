using UnityEditor;
using UnityEngine;

public class Puerto : MonoBehaviour
{

    [SerializeField] TriggerDetector triggerDetector;


    private void OnEnable()
    {
        triggerDetector.OnTriggerEntered += Show;
        triggerDetector.OnTriggerExited += Hide;
    }

    private void Show(Transform transform)
    {
        ShipUIFacade.Instance.ShowPort();
    }

    private void Hide(Transform transform)
    {
        ShipUIFacade.Instance.HidePort();
    }

    private void OnDisable()
    {
        triggerDetector.OnTriggerEntered -= Show;
        triggerDetector.OnTriggerExited -= Hide;
    }
}
