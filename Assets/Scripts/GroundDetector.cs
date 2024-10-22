using System;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private int _collisionCount = 0;

    public event Action Landed;

    public bool IsGrounded => _collisionCount > 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _collisionCount++;
        
        if (_collisionCount == 1)
            Landed?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _collisionCount--;
    }
}
