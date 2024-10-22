using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public event Action<int> CoinCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            CoinCollected?.Invoke(coin.Value);
            coin.Collect();
        }
    }
}
