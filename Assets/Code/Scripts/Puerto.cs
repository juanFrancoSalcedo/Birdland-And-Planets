using UnityEditor;
using UnityEngine;
using Zenject;

public class Puerto : MonoBehaviour
{
    [SerializeField] TriggerDetector triggerDetector;

    [Inject]
    public void Construct(FoodMediator mediator)
    {
        //this.mediator = mediator;
    }
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

    public class Factory : PlaceholderFactory<Puerto> { }

}
