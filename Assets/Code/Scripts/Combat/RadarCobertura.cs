using UnityEngine;



[RequireComponent(typeof(TriggerDetector))]
public class RadarCobertura : MonoBehaviour
{
    TriggerDetector detector;
    void Start()
    {
        detector = GetComponent<TriggerDetector>();
    }

    public void ActiveRadar() 
    {
        transform.localScale = Vector3.one*11;
    }

    public void DeactiveRadar()
    {
        transform.localScale = Vector3.one * 0.1f;
    }
}
