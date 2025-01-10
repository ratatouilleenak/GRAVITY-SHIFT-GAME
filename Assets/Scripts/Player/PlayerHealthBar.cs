using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;


    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 50;
    }

    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 50;
    }
}
