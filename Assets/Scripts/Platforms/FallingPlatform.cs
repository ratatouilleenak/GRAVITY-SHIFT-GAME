using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    
    [SerializeField] private float fallWait = 0.5f;
    [SerializeField] private float destroyWait = 1f;

    private Vector3 initialPosition; // Store the initial position
    private bool isFalling; // To prevent multiple triggers
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position; // Save the initial position
    }

    // Trigger when the player lands on the platform
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isFalling && collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

     // Coroutine to delay the fall and destroy the platform
    private IEnumerator Fall()
    {
        isFalling = true;
        yield return new WaitForSeconds(fallWait);
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(destroyWait);
        gameObject.SetActive(false);
    }

    public void ResetPlatform()
    {
        StopAllCoroutines();
        rb.bodyType = RigidbodyType2D.Static; // Reset to static body
        transform.position = initialPosition; // Reset position
        gameObject.SetActive(true); // Reactivate the platform
        isFalling = false;
    }
}
