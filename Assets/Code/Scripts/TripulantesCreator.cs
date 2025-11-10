using System.IO;
using UnityEngine;
using Zenject;

public class TripulantesCreator : MonoBehaviour
{
    [SerializeField] private Transform[] transformPositions;
    [SerializeField] private Transform barco;
    [Inject] TripulantesPool pool;
    void Start()
    {
        var data = TripulantesDataHandler.LoadData();
        int pos = 0;
        data.references.ForEach(reference => {

            var getData =  pool.GetTripulanteByNameFile(reference);
            string pathFull = Path.Combine("Crew", getData.PathTripulante);
            var data = Resources.Load<TripulanteView>(pathFull);
            var trasPos = transformPositions[pos];
            var clone = Instantiate<TripulanteView>(data, trasPos.position,trasPos.rotation, barco);
            pos++;
        });
    }
}
