using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode JumpKey = KeyCode.Space;
    private const string Horizontal = nameof(Horizontal);

    public event Action JumpKeyPressed;

    public float Direction { get; private set; }

    private bool _isJumping = false;

    private void FixedUpdate()
    {
        if (_isJumping)
        {
            JumpKeyPressed?.Invoke();
            _isJumping = false;
        }
    }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(JumpKey))
            _isJumping = true;
    }
}