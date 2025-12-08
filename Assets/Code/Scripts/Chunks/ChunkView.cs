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
    private Puerto.Factory _portFactory;
    private CombatIncurtionStarter.Factory _incurtionStarter;
    bool firstInstance;


    [Inject]
    public void Construct(FishBank.Factory factoryFish, Puerto.Factory port, CombatIncurtionStarter.Factory factoryIncursion) 
    {
        this._fishFactory = factoryFish;
        this._portFactory = port;
        this._incurtionStarter = factoryIncursion;
    }

    public void CreateFishBank(Vector2 pos2d)
    {
        FishBank bank = _fishFactory.Create();
        bank.transform.position = RealtivePos(pos2d);
    }


    public void CreatePort(Vector2 pos2d)
    {
        Puerto bank = _portFactory.Create();
        bank.transform.position = RealtivePos(pos2d);
    }

    public void CreateIncursion(Vector2 pos2d)
    {
        var incurtion = _incurtionStarter.Create();
        incurtion.transform.position = RealtivePos(pos2d);
    }

    public void CreateNoDependencyObject(string path, Vector2 pos2d) 
    {
        var reso = Resources.Load<GameObject>(path);
        var obj = Instantiate(reso);
        obj.transform.position = RealtivePos(pos2d);
    }
    private Vector2 RealtivePos(Vector2 pos2d) => transform.position + new Vector3(pos2d.x, 0, pos2d.y);

    private void OnEnable() => ShipMovement.OnMove += CheckWhich;

    private void OnDisable() => ShipMovement.OnMove -= CheckWhich;

    internal void CheckWhich(Transform player)
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
    FishBank,
    Port,
    Asteroid,
    CombatIncursion
}

[System.Serializable]
public class StaticSite
{
    public Vector2 position;
    public TypeStaticSite typeStaticEvents;
}
