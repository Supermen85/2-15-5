using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Coin : MonoBehaviour 
{
    public event Action Collected;

    public int Value {  get; private set; }

    private void Start()
    {
        Value = 1;
    }

    public void Collect()
    {
        Collected?.Invoke();
    }
}