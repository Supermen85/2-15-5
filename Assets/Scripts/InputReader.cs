using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode JumpKey = KeyCode.Space;
    private const string Horizontal = nameof(Horizontal);

    public event Action JumpKeyPressed;

    public float Direction { get; private set; }

    private void FixedUpdate()
    {
        Direction = Input.GetAxis(Horizontal);
    }

    private void Update()
    {
        if (Input.GetKeyDown(JumpKey))
            JumpKeyPressed?.Invoke();
    }
}