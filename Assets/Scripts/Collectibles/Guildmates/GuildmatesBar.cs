using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuildmatesBar : MonoBehaviour
{
    public Slider slider; // Reference to the slider UI component

    private void Start()
    {
        // Initialize the slider based on GameManager's data
        SetMaxGuildmates(GameManager.Instance.totalGuildmates);
        UpdateGuildmatesUI();
    }

    private void Update()
    {
        // Continuously sync the slider with GameManager's data
        UpdateGuildmatesUI();
    }

    public void SetMaxGuildmates(int guildmates)
    {
        slider.maxValue = guildmates;
    }

    public void UpdateGuildmatesUI()
    {
        slider.value = GameManager.Instance.collectedGuildmates;
    } 
}
