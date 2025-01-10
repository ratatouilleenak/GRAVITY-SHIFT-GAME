using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tendrils : MonoBehaviour
{
    public int damage = 1; 
    public float lifetime = 5f;
    private Animator anim;

    private void Start()
    {
        StartCoroutine(DestroyAfterLifetime());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Reduce player health
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }

    public void OnAnimationFinish()
    {
        Destroy(gameObject);
    }

    private IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}
