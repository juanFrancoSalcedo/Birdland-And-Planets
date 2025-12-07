using System.Collections.Generic;
using System.IO;
using UnityEngine;



namespace Reclutamiento 
{
    public class Reclutamiento : MonoBehaviour
    {
        [SerializeField] private TripulantesPool tripulantesPool;
        [SerializeField] private Transform positionInstanciate;
        public event System.Action OnCompleted;
        int index;
        WrapperTripulanteRef listRecluta = null;
        private List<TripulanteController> prospectos = new List<TripulanteController>();
        TripulanteView current;

        private void Start()
        {
            listRecluta = TripulantesDataHandler.LoadData();
            prospectos = tripulantesPool.GetRandomProspectos(4);
            DrawRecluta();
        }
        public void Reclutar()
        {
            prospectos.RemoveAt(index);
            listRecluta.references.Add(prospectos[index].name);
            CheckNext();
        }

        public void Rechazar()
        {
            prospectos.RemoveAt(index);
            CheckNext();
        }

        private void DrawRecluta() 
        {
            if (current != null)
                Destroy(current.gameObject);

            var getData = tripulantesPool.GetTripulanteByNameFile(prospectos[index].name);
            string pathFull = Path.Combine("Crew", getData.PathTripulante);
            var data = Resources.Load<TripulanteView>(pathFull);
            var trasPos = positionInstanciate;
            current = Instantiate<TripulanteView>(data, trasPos.position, trasPos.rotation, trasPos);
        }

        private void CheckNext()
        {
            if (prospectos.Count == 0)
            {
                TripulantesDataHandler.SaveData(listRecluta);
                OnCompleted?.Invoke();
            }
            else
                DrawRecluta();
        }
    }
}
