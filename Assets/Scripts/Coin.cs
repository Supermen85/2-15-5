using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class Coin : MonoBehaviour
{
    public event Action Collected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collected?.Invoke();        
    }
}