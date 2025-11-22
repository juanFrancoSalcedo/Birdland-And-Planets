using Combat;
using UnityEngine;
using UnityEngine.UIElements;

public class QuadCobertura : MonoBehaviour
{
    [SerializeField] float cobertura;
    [SerializeField] private bool isCannon = false;
    [SerializeField] private bool isCannonLoaded = false;
    TripulanteCombatHandler tripulanteHandler;
    public void SetTripulantePlace(TripulanteCombatHandler tripulante) 
    {
        tripulanteHandler = tripulante;
        tripulanteHandler.ModifyCover(cobertura);
        var vector = new Vector3(0, tripulante.transform.localScale.y / 2f, 0);
        tripulanteHandler.transform.position = transform.position + vector;
        SetScale(Vector3.one *2);
        tripulante.OnCannon = isCannon;
        tripulante.QuadOn = this;
    }

    private void SetScale(Vector3 scale) 
    {
        transform.localScale = scale;
    }

    public void ReduceCobertura(float reduction) 
    {
        cobertura -= reduction;
        if (cobertura < 0.1f)
            cobertura = 0.03f;
        if (tripulanteHandler)
            tripulanteHandler.ModifyCover(cobertura);
    }

    private void OnMouseUpAsButton()
    {
        if (CombatManager.Instance.Current)
        {
            SetTripulantePlace(CombatManager.Instance.Current);
        }
    }
}
