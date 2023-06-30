using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PlayerControls _input;
    private Vector3 _move;
    private Rigidbody _rb;

    private void Awake()
    {
        _input = new PlayerControls();
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        _rb.velocity = _move * _speed;
    }
    private void OnEnable()
    {
        _input.Enable();
        _input.Player.Move.performed += Move;
    }

    private void onDisable()
    {
        _input.Disable();
        _input.Player.Move.performed -= Move;
    }
    private void Move(InputAction.CallbackContext value)
    {
        _move = value.ReadValue<Vector3>();
    }
}
