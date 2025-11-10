using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName ="Controller Tripulante", menuName ="SO/Tripulantes")]
public class TripulanteController:ScriptableObject
{
    [SerializeField] private Tripulante tripulanteModel;
    [SerializeField] private string pathTripulante;
    public string PathTripulante => pathTripulante;

    
}
