using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Walker : MonoBehaviour
{
    [SerializeField] private float _walkSpeed = 5f;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Walk(float direction)
    {
        _rigidbody2D.velocity = new Vector2(direction * _walkSpeed, _rigidbody2D.velocity.y);
    }
}