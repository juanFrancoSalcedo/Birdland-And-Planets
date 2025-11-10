
using B_Extensions;
using UnityEngine;



namespace Reclutamiento 
{
    public class ButtonReclutar : BaseButtonAttendant
    {
        [SerializeField] Reclutamiento reclutamiento;
        private void Start() => buttonComponent.onClick.AddListener(Accept);
        private void OnEnable() => reclutamiento.OnCompleted += Completado;
        private void OnDisable() => reclutamiento.OnCompleted -= Completado;

        private void Completado() => buttonComponent.interactable = false;
        private void Accept() => reclutamiento.Reclutar();
    }
}
