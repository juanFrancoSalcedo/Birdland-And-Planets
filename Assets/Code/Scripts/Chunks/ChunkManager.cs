using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [SerializeField] List<ChunkView> pool = new List<ChunkView>();
    [SerializeField] Transform PlayerShip = null;

    ChunkView controllerChunk;
}
