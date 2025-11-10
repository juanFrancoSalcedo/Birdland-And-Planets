using UnityEngine;
using UnityEngine.Rendering;

public class CanonView : MonoBehaviour
{
    public Cannon Cannon;

    private void Start()
    {
        Cannon.y = transform.position.y;
        Cannon.x = transform.position.x;
        Cannon.z = transform.position.z;
    }

    public void SetPosistion(Cannon cannon) 
    {
    
    }

}
