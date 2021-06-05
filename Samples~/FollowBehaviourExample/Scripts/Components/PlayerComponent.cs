using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerComponent : MonoBehaviour, IMovable
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _direction = context.ReadValue<Vector2>();
        }
        else 
        {
            _direction = Vector2.zero;
        }
    }

    public void Move(float speed)
    {
        _rigidbody2D.MovePosition(Vector2.MoveTowards(_rigidbody2D.position, _rigidbody2D.position + _direction, speed));
    }
}
