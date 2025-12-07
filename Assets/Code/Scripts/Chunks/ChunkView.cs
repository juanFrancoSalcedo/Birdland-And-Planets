using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;

public class ChunkView : MonoBehaviour
{
    [field:SerializeField] public ChunkController controller { get; set; }
    [SerializeField] private bool isActive;
    private FishBank.Factory _fishFactory;
    bool firstInstance;


    [Inject]
    public void Construct(FishBank.Factory factory) 
    {
        this._fishFactory = factory;
    }

    public void CreateFishBank(Vector2 pos2d) 
    {
        FishBank bank = _fishFactory.Create();
        bank.transform.position = transform.position + new Vector3(pos2d.x,0,pos2d.y);
    }

    private void OnEnable()
    {
        ShipMovement.OnMove += CheckWich;
    }

    private void OnDisable()
    {
        ShipMovement.OnMove -= CheckWich;
    }

    internal void CheckWich(Transform player)
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= 50f)
        {
            if (!firstInstance)
            {
                controller.Instanciate(this);
                firstInstance = true;
            }
            controller.ActiveChunk();
            isActive = true;
        }
        else
        {
            controller.DeactiveChunk();
            isActive= false;
        }
    }
}

[System.Serializable]
public class ChunkModel
{
    public List<StaticSite> sites = new List<StaticSite>(); 
}

public enum TypeStaticSite 
{
    FishBank
}

[System.Serializable]
public class StaticSite
{
    public Vector2 position;
    public TypeStaticSite typeStaticEvents;
}
