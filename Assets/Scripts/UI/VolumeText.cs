using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeText : MonoBehaviour
{
    [SerializeField] private string volumeName;
    [SerializeField] private string textIntro; //Sound:  or Music:
    //private Text txt;  
    private TextMeshProUGUI txt; 
     

    private void Awake()
    {
        txt = GetComponent<TextMeshProUGUI>();       
    }
    private void Update()
    {
        UpdateVolume();
    }
    private void UpdateVolume()
    {
        float volumeValue = PlayerPrefs.GetFloat(volumeName) * 100;
        txt.text = textIntro + volumeValue.ToString();
    }
}
