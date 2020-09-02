using UnityEngine;

public class EnemyComponent : MonoBehaviour, IMovable
{
    private Transform _target;
    private Rigidbody2D _rigidbody2D;


    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(float speed)
    {
        _rigidbody2D.MovePosition(Vector2.MoveTowards(_rigidbody2D.position, _target.position, speed));
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

}
