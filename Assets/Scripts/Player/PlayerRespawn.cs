using UnityEngine;
using UnityEngine.UI;

public class PlayerRespawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip checkpoint;
    [SerializeField] private CheckpointManager checkpointManager;

    private Transform currentCheckpoint;
    private PlayerHealth playerHealth;
    private UIManager uiManager;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void CheckRespawn()
    {
        //To Check if a checkpoint is available
        if (currentCheckpoint == null) 
        {
            uiManager.GameOver();
            
            return;
        }

        playerHealth.Respawn(); //Restore player health and reset animation
        transform.position = currentCheckpoint.position; //Move player to checkpoint location

        // Reset platforms through CheckpointManager
        checkpointManager.RespawnPlayer();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            SoundManager.instance.PlaySound(checkpoint);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
    }
}
