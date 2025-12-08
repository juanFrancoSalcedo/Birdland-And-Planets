using B_Extensions.SceneLoader;
using System;
using UnityEngine;
using Zenject;


[RequireComponent(typeof(CallerSceneLoader))]
public class CombatIncurtionStarter : MonoBehaviour
{
    [SerializeField] private TriggerDetector triggerDetector;
    [Inject]
    public void Constructor() 
    {
        
    }

    private void OnEnable() => triggerDetector.OnTriggerEntered += EnterCombat;
    private void OnDisable() => triggerDetector.OnTriggerEntered -= EnterCombat;

    private void EnterCombat(Transform _transform)
    {
        GetComponent<CallerSceneLoader>().LoadScene();
    }


    public class Factory : PlaceholderFactory<CombatIncurtionStarter> { }
}
