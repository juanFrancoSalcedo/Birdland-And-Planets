using System.Collections.Generic;
using UnityEngine;

public class TripulantesPool : MonoBehaviour
{ 
    public List<TripulanteController> prospectos = new List<TripulanteController>();

    public TripulanteController GetTripulanteByNameFile(string nameFile) 
    {
        var result = prospectos.Find( p=> p.name.Equals(nameFile));
        return result;
    }

    public List<TripulanteController> GetRandomProspectos(int length) 
    {
        List<TripulanteController> prospects = new List<TripulanteController>();

        for (int i = 0; i < length; i++)
        {
            var ran = prospectos[Random.Range(0, prospectos.Count)];
            prospects.Add(ran);
        }
        return prospects;
    }
}
