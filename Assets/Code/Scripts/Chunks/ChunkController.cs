using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName ="Chunk", menuName ="SO/Chunk")]
public class ChunkController : ScriptableObject 
{
    [Header("-----Data----")]
    [SerializeField] ChunkModel data;
    public ChunkModel Model => data;

    public void Instanciate(ChunkView view)
    {
        foreach (var item in Model.sites)
        {
            if (item.typeStaticEvents == TypeStaticSite.FishBank)
            {
                view.CreateFishBank(item.position);
            }

            if (item.typeStaticEvents == TypeStaticSite.Port)
            {
                view.CreatePort(item.position);
            }

            if (item.typeStaticEvents == TypeStaticSite.Asteroid)
            {
                view.CreateNoDependencyObject(Constants.pathStormAsteroids,item.position);
            }

            if (item.typeStaticEvents == TypeStaticSite.CombatIncursion)
            {
                view.CreateIncursion(item.position);
            }
        }
    }

    public void ActiveChunk() 
    {
        //Debug.Log("Active");
    }

    public void DeactiveChunk()
    {
        //Debug.Log("Deactive");
    }
}


public static class Constants 
{
    public const string pathStormAsteroids = "Travel/AsteroidStorm";
}