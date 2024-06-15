using UnityEngine;
using System.Collections;

public class Teleportation : MonoBehaviour
{
    public Transform destination; // Set this in the Inspector to the destination point
    private bool canTeleport = false; // Flag to track if teleportation is allowed
    public GameObject flashText;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player or another teleportable object
        if (other.CompareTag("Player"))
        {
            canTeleport = true; // Allow teleportation
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Reset the flag when the player exits the trigger
        if (other.CompareTag("Player"))
        {
            canTeleport = false;
        }
    }

    private void Update()
    {
        // Check if teleportation is allowed, the key is pressed, and the "current_mission" player pref is not empty and exists
        if (canTeleport && Input.GetKeyDown(KeyCode.F) && !string.IsNullOrEmpty(PlayerPrefs.GetString("current_mission", null)))
        {
            // Get the player's transform (assuming the player is the only object with the "Player" tag)
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                TeleportObject(player.transform);
            }
        }
        if(canTeleport && Input.GetKeyDown(KeyCode.F) && string.IsNullOrEmpty(PlayerPrefs.GetString("current_mission", null)) && !flashText.activeSelf) {
            StartCoroutine(FlashText());

        }
    }

    IEnumerator FlashText()
    {
        flashText.SetActive(true);
        yield return new WaitForSeconds(1f);
        flashText.SetActive(false);
    }

    void TeleportObject(Transform objectToTeleport)
    {
        objectToTeleport.position = destination.position; // Teleport to the destination position
        Debug.Log($"{objectToTeleport.name} teleported to {destination.position}");
    }
}
