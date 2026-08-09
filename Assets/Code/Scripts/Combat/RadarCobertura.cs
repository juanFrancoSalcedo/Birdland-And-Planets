using System;
using System.Linq;
using UnityEngine;


public class RadarCobertura : MonoBehaviour
{
    [SerializeField] float minDistanceWalk =11f;

    public void ActiveRadar() 
    {
        transform.localScale = Vector3.one* minDistanceWalk;
    }

    public void DeactiveRadar()
    {
        transform.localScale = Vector3.one * 0.1f;
    }

    internal bool CanReach(QuadCobertura quadCobertura)
    {
        var searchRaw = FindObjectsByType<QuadCobertura>(FindObjectsSortMode.None);
        var areNear = searchRaw.Where(x => Vector3.Distance(x.transform.position,transform.position)<(minDistanceWalk/2));
        if (areNear.ToArray().Contains(quadCobertura))
        {
            DeactiveRadar();
            return true;
        }
        else
            return false;
    }
}
