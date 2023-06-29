using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PlayerControls _input;
    private Vector3 _direction;
    private Rigidbody _rb;

    private void Awake()
    {
        _input = new PlayerControls();
        _input.Enable();
    }
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        _direction = _input.Player.Move.ReadValue<Vector3>();
        Move(_direction);
    }
    public void Move(Vector3 direction)
    {
        if (direction.sqrMagnitude > 0.1)
            return;

        float move = Input.GetAxis("Horizontal");
        transform.position += new Vector3(move, 0,0) * _speed * Time.deltaTime;
    }
}
