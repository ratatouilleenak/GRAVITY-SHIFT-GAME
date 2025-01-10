using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform checkpoint;
    [SerializeField] private List<FallingPlatform> platforms;

    public void RespawnPlayer()
    {
        // Move player to the checkpoint
        player.position = checkpoint.position;

        // Reset all platforms
        foreach (FallingPlatform platform in platforms)
        {
            platform.ResetPlatform();
        }
    }
}
