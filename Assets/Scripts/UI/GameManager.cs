using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int totalGuildmates = 4; // Total guildmates to collect
    public int collectedGuildmates = 0; // Guildmates collected so far

    private void Awake()
    {
        // Singleton pattern to ensure only one GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddGuildmate()
    {
        // Increment collected guildmates, clamped to the total
        collectedGuildmates = Mathf.Clamp(collectedGuildmates + 1, 0, totalGuildmates);
    }

    public void ResetProgress()
    {
        // Reset guildmate progress (if needed)
        collectedGuildmates = 0;
    }
}
