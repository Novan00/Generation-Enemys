
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    public Vector2 Direction => _direction;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _direction;
    private float _moveDirectionCoefficient = 0.5f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_speed * Time.deltaTime * _direction.x, _rigidbody2D.velocity.y);
    }

    public void SetRandomDirection()
    {
        var moveDirection = Random.value;

        if (moveDirection <= _moveDirectionCoefficient)
        {
            _direction = Vector2.left;
            _spriteRenderer.flipX = true;
        }
        else
        {
            _direction = Vector2.right;
        }
    }
}
