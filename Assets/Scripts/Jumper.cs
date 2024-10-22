using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _jumpForce = 500f;

    private void OnValidate()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

        if (_rigidbody2D != null || _rigidbody2D != rigidbody2D)
            _rigidbody2D = rigidbody2D;
    }

    public void Jump()
    {
        _rigidbody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
    }
}
