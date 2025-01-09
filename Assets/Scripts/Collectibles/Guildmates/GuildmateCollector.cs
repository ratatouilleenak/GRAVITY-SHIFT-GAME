using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuildmateCollector : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private GuildmatesBar guildmatesBar;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the tag "Guildmate"
        if (other.CompareTag("Guildmate"))
        {
            // Update the guildmates bar
            if (guildmatesBar != null)
            {
                guildmatesBar.AddGuildmate();
            }

            // Set the collected Guildmate GameObject inactive
            other.gameObject.SetActive(false);
        }
    }
}
