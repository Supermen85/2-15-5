using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode JumpKey = KeyCode.Space;
    private const string Horizontal = nameof(Horizontal);

    public event Action JumpKeyPressed;

    public float Direction => Input.GetAxis(Horizontal);

    private void Update()
    {
        if (Input.GetKeyDown(JumpKey))
            JumpKeyPressed?.Invoke();
    }
}