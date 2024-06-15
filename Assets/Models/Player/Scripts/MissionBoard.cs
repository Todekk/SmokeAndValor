using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionBoard : MonoBehaviour
{
    public GameObject missionBoard;
    public Text fallenBridgeText;
    public Text forestFireText;
    public Text gasExplosionText;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Level2"))
        {
            bool isBridgeComplete = PlayerPrefs.GetInt("Level2") == 1;
            if (isBridgeComplete)
            {
                fallenBridgeText.text = "- Fallen bridge ✔";
                //PlayerPrefs.SetString("Current_mission", "Fallen_bridge");
            }
            else
            {
                fallenBridgeText.text = "- Fallen bridge";
            }
        }
        else
        {
            PlayerPrefs.SetInt("Level2", 0);
            PlayerPrefs.Save();
            fallenBridgeText.text = "- Fallen bridge";
        }

        if (PlayerPrefs.HasKey("Level4"))
        {
            bool isForestComplete = PlayerPrefs.GetInt("Level4") == 1;
            if (isForestComplete)
            {
                forestFireText.text = "- Forest fire ✔";
                //PlayerPrefs.SetString("Current_mission", "Fallen_bridge");
            }
            else
            {
                forestFireText.text = "- Forest fire";
            }
        }
        else
        {
            PlayerPrefs.SetInt("Level4", 0);
            PlayerPrefs.Save();
            forestFireText.text = "- Forest fire";
        }

        if (PlayerPrefs.HasKey("Level3"))
        {
            bool isGasExplosionComplete = PlayerPrefs.GetInt("Level3") == 1;
            if (isGasExplosionComplete)
            {
                gasExplosionText.text = "- Apartment complex gas explosion ✔";
                //PlayerPrefs.SetString("Current_mission", "Fallen_bridge");
            }
            else
            {
                gasExplosionText.text = "- Apartment complex gas explosion";
            }
        }
        else
        {
            PlayerPrefs.SetInt("Level3", 0);
            PlayerPrefs.Save();
            gasExplosionText.text = "- Apartment complex gas explosion";
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!missionBoard.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                missionBoard.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

        }
    }
}
