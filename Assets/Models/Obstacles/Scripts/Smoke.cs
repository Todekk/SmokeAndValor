using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    public GameObject gasMask;
    public PlayerHealth playerHealth;

    private bool damageCoroutineRunning = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        // Check if the object staying in the trigger is the player
        if (other.CompareTag("Player") && !damageCoroutineRunning)
        {
            StartCoroutine(DamagePlayer(other));
        }
    }

    IEnumerator DamagePlayer(Collider other)
    {
        damageCoroutineRunning = true; // Set flag to true when coroutine starts
        yield return new WaitForSeconds(1.5f);

        // Check conditions to inflict damage
        if (other.CompareTag("Player") && !gasMask.activeSelf)
        {
            playerHealth.InhaleSmoke();
        }

        damageCoroutineRunning = false; // Reset flag after coroutine completes
    }
}
