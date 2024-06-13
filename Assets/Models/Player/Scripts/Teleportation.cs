using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public Transform destination; // Set this in the Inspector to the destination point

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player or another teleportable object
        if (other.CompareTag("Player"))
        {
            TeleportObject(other.transform);
            //TO DO - Fix teleportation
            // if (Input.GetKeyDown(KeyCode.F))
            // {
            // }
        }
    }

    void TeleportObject(Transform objectToTeleport)
    {
        objectToTeleport.position = destination.position; // Teleport to the destination position
        Debug.Log($"{objectToTeleport.name} teleported to {destination.position}");
    }
}