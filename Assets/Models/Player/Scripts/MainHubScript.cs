using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHubScript : MonoBehaviour
{
    public GameObject objectToDisable;
    public GameObject currentMission;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!string.IsNullOrEmpty(PlayerPrefs.GetString("current_mission", null)))
        {
            Debug.Log("Level IS ACTIVE");
            currentMission.SetActive(true);            
        }
        else {
            Debug.Log("Level IS INACTIVE");
            currentMission.SetActive(false);
        }
        
    }

    public void DisableObject()
    {
        objectToDisable.SetActive(!objectToDisable.activeSelf);
        Debug.Log("RABOTI BUTONA :)");
    }

    public void SetCurrentMission(string currentMissionName)
    {
        PlayerPrefs.SetString("current_mission", currentMissionName);
        gameObject.SetActive(false);
    }
}
