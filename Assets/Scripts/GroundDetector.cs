using System;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private int _collisionCount = 0;

    public event Action Landed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _collisionCount++;

        Landed?.Invoke();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _collisionCount--;
    }

    public bool IsGrounded()
    {
        return _collisionCount > 0; 
    }    
}
