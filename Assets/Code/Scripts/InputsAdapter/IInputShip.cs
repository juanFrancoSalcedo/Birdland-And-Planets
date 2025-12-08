using System;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IInputShip
{
    Vector2 GetDirection();
}



public class ShipKeyboardMovementAdapter : IInputShip
{
    private PlayerInputActions _playerInputActions;
    Action<Transform> _invocation = null;
    Transform _shipTransform;
    private Vector2 _direction;
    public ShipKeyboardMovementAdapter(Action<Transform> invocation,Transform shipTransform) 
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Move.performed += OnMovePerformed;
        _playerInputActions.Player.Move.canceled += OnMoveCanceled;
        this._invocation = invocation;
        _shipTransform = shipTransform;
    }

    ~ShipKeyboardMovementAdapter() 
    {
        _playerInputActions.Player.Move.performed -= OnMovePerformed;
        _playerInputActions.Player.Move.canceled -= OnMoveCanceled;
        _playerInputActions.Player.Disable();
    }
    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        _direction = Vector2.zero;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
        _invocation?.Invoke(_shipTransform);
    }

    public Vector2 GetDirection()
    {
        return _direction;
    }
}


public class ShipScreenMobileMovementAdapter : IInputShip
{
    private Vector2 _direction;
    Timon timon;
    ToggleSails sails;

    public ShipScreenMobileMovementAdapter(Timon timon, ToggleSails sails)
    {
        this.timon = timon;
        this.sails = sails;
        this.timon.OnRotationNormalized.AddListener(OnMovementWheel);
    }

    ~ShipScreenMobileMovementAdapter() 
    {
        this.timon.OnRotationNormalized.RemoveListener(OnMovementWheel);
    }

    private void OnMovementWheel(float arg0, bool draging)
    {
        _direction.x = arg0;
        _direction.y = sails.SailsOpen?1:0;
    }


    public Vector2 GetDirection()
    {
        return _direction;
    }
}