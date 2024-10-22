using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Walker : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _walkSpeed = 5f;

    private void OnValidate()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

        if (_rigidbody2D != null || _rigidbody2D != rigidbody2D)
            _rigidbody2D = rigidbody2D;
    }

    public void Walk(float direction)
    {
        _rigidbody2D.velocity = new Vector2(direction * _walkSpeed, _rigidbody2D.velocity.y);
    }
}