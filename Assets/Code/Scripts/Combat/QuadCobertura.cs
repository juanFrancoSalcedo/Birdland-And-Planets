using Combat;
using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class QuadCobertura : MonoBehaviour
{
    [SerializeField] float cobertura;
    [SerializeField] private bool isCannon = false;
    [SerializeField] private bool isCannonLoaded = false;
    TripulanteCombatHandler tripulanteHandler;

    public bool IsCannonLoaded => isCannonLoaded;
    public void SetTripulantePlace(TripulanteCombatHandler tripulante) 
    {
        tripulanteHandler = tripulante;
        print("Toodo tenemos que desactivar el click para que no hagan click sobre otro");
        var vector = new Vector3(0, tripulante.transform.localScale.y / 2f, 0);
        tripulante.Move(transform.position + vector, SetPlaceOnTripulante);
        SetScale(Vector3.one *2);
    }

    public void SetPlaceOnTripulante() 
    {
        tripulanteHandler.ModifyCover(cobertura);
        tripulanteHandler.OnCannon = isCannon;
        tripulanteHandler.QuadOn = this;
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
            if (CombatManager.Instance.Current.CanEffortTurn())
            {
                if(CombatManager.Instance.Current.CanMoveToQuad(this))
                {
                    SetTripulantePlace(CombatManager.Instance.Current);
                    tripulanteHandler.DebtEffort();
                }
                    
                
            } 
        }
    }

    internal void ShotCannon() => isCannonLoaded = false;

    internal void ReloadCanon() => isCannonLoaded = true;
}
