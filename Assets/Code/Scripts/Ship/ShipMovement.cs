using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{
    // Variables de configuración
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 100f;

    // Variables internas para el movimiento y la rotación
    private Vector2 _movementInput;
    private PlayerInputActions _playerInputActions;
    private Rigidbody _rb; // Opcional, pero recomendado para movimiento físico

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _rb = GetComponent<Rigidbody>(); // Obtiene el Rigidbody si existe
    }

    private void OnEnable()
    {
        // Habilita el mapa de acciones 'Player'
        _playerInputActions.Player.Enable();

        _playerInputActions.Player.Move.performed += OnMovePerformed;
        _playerInputActions.Player.Move.canceled += OnMoveCanceled;
    }

    private void OnDisable()
    {
        // Desuscribirse y deshabilitar
        _playerInputActions.Player.Move.performed -= OnMovePerformed;
        _playerInputActions.Player.Move.canceled -= OnMoveCanceled;

        _playerInputActions.Player.Disable();
    }

    // Se llama cuando la acción 'Move' se activa
    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
    }

    // Se llama cuando la acción 'Move' se cancela (se sueltan las teclas)
    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        _movementInput = Vector2.zero;
    }

    private void FixedUpdate()
    {
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
