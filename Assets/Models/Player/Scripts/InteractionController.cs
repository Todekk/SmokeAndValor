using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public GameObject carryingVictim;
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
        if (Input.GetKeyDown(KeyCode.F))
        {

            if (other.CompareTag("victim"))
            {

                if (carryingVictim != null)
                {
                    if (!carryingVictim.activeSelf)
                    {
                        other.gameObject.SetActive(false); // Deactivate the victim
                        carryingVictim.SetActive(true);    // Show carrying victim
                    }
                    // else
                    // {
                    //     carryingVictim.SetActive(false);   // Drop the victim
                    // }
                }
                else
                {
                    Debug.LogError("carryingVictim is not assigned!");
                }
            }
            else if (other.CompareTag("ambulance"))
            {

                if (carryingVictim != null)
                {
                    if (carryingVictim.activeSelf)
                    {
                        carryingVictim.SetActive(false);
                        ObjectiveController objectiveController = FindObjectOfType<ObjectiveController>();
                        objectiveController.VictimSaved();
                    }
                }
                else
                {
                    Debug.LogError("carryingVictim is not assigned!");
                }
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("victim"))
        {
            if (carryingVictim.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    carryingVictim.SetActive(false);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    other.gameObject.SetActive(false);
                    carryingVictim.SetActive(true);
                }
            }
        }
        if (other.CompareTag("ambulance"))
        {
            if (carryingVictim.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    carryingVictim.SetActive(true);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    carryingVictim.SetActive(false);
                }
            }
        }
    }
}
