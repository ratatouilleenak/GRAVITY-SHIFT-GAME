using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guildmate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Update the guildmate count in GameManager
            GameManager.Instance.AddGuildmate();

            // Destroy the guildmate object
            Destroy(gameObject);
        }
    }
}
