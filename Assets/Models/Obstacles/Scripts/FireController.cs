using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public float fireHealth = 100f;
    public bool isExtinguished = false;
    public ParticleSystem fireParticles;
    public ParticleSystem smokeParticles;

    public PlayerHealth playerHealth;

    private bool damageCoroutineRunning = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fireHealth <= 0f && isExtinguished == false)
        {
            StartCoroutine(RemoveFire());
        }

    }

    IEnumerator RemoveFire()
    {
        isExtinguished = true;
        fireParticles.Stop();
        smokeParticles.Play();
        yield return new WaitForSeconds(2);
        ObjectiveController objectiveController = FindObjectOfType<ObjectiveController>();
        objectiveController.FireExtinguished();
        Destroy(gameObject);

    }

    public void ExtinguishFire()
    {
        fireHealth -= 40f;
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
        yield return new WaitForSeconds(.5f);

        // Check conditions to inflict damage
        if (other.CompareTag("Player"))
        {
            playerHealth.CatchFire();
        }

        damageCoroutineRunning = false; // Reset flag after coroutine completes
    }
}
