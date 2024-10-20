using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 500f;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _rigidbody2D.AddForce(new Vector2(0, _jumpForce));
    }

}
