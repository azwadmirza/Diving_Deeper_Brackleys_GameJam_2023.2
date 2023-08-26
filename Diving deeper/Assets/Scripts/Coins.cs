using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag=="Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.incrementCoins();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Coins"))
        {
            Destroy(gameObject);
        }
    }
}
