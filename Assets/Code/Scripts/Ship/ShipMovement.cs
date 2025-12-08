using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private bool isMobile;
    [Header("MobileSettings")]
    [SerializeField] private Timon timon;
    [SerializeField] private ToggleSails sails;
    private Vector2 _movementInput;
    private Rigidbody _rb;
    public static event System.Action<Transform> OnMove;
    IInputShip currentInput;
    private void Awake()
    {

        if (isMobile)
            currentInput = new ShipScreenMobileMovementAdapter(timon, sails);
        else
        { 
            timon.gameObject.SetActive(false);
            sails.gameObject.SetActive(false);
            currentInput = new ShipKeyboardMovementAdapter(OnMove,transform);
        }
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _movementInput = currentInput.GetDirection();
        if (_movementInput.y < 0)
            return;

        var fullSpeed = _movementInput.x != 0? moveSpeed*1.5f:moveSpeed;

        Vector3 moveDirection = transform.forward * _movementInput.y * fullSpeed *Time.fixedDeltaTime;

        if (_rb != null)
        {
            _rb.MovePosition(_rb.position + moveDirection);
        }

        float rotationAmount = _movementInput.x * rotationSpeed * Time.fixedDeltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
    }
}