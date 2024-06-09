using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Text startButton;
    // Start is called before the first frame update
    void Start()
    {
         if (PlayerPrefs.HasKey("TutorialComplete"))
        {
            bool isTutorialComplete = PlayerPrefs.GetInt("TutorialComplete") == 1;
            if (isTutorialComplete)
            {
                startButton.text = "Continue";                
            }
            else
            {
                startButton.text = "Start Game";                
            }
        }
        else
        {
            PlayerPrefs.SetInt("TutorialComplete", 0);
            PlayerPrefs.Save();
            startButton.text = "New Game";
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("LoadingScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
