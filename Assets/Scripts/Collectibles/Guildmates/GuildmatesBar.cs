using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuildmatesBar : MonoBehaviour
{
    [Header("Guildmates Bar Components")]
    [SerializeField] private Image totalGuildmatesBar; // Represents the full bar
    [SerializeField] private Image currentGuildmatesBar; // Represents the current progress

    [Header("Guildmates Settings")]
    [SerializeField] private int totalGuildmates = 4; // Total number of guildmates to collect
    private int collectedGuildmates = 0; // Number of guildmates collected so far

    private void Start()
    {
        // Ensure the total bar is visually full at the start (if needed for design)
        if (totalGuildmatesBar != null)
        {
            totalGuildmatesBar.fillAmount = 1.0f; // Full bar represents the maximum capacity
        }

        // Set the current bar to empty at the start
        if (currentGuildmatesBar != null)
        {
            currentGuildmatesBar.fillAmount = 0.0f; // Start with an empty progress bar
        }
    }

    public void AddGuildmate()
    {
        // Increment the collected guildmates
        collectedGuildmates = Mathf.Clamp(collectedGuildmates + 1, 0, totalGuildmates);

        // Calculate the fill amount based on the total number of guildmates
        float fillAmount = (float)collectedGuildmates / totalGuildmates;
        if (currentGuildmatesBar != null)
        {
            currentGuildmatesBar.fillAmount = fillAmount;
        }
    }
}
