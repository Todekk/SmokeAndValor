using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isTutorialComplete;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("TutorialComplete"))
        {
            isTutorialComplete = PlayerPrefs.GetInt("TutorialComplete") == 1;
            if (isTutorialComplete)
            {
                StartCoroutine(WaitBeforeScene("MainHub"));
            }
            else
            {
                StartCoroutine(WaitBeforeScene("Level1"));
            }
        }
        else
        {
            isTutorialComplete = false;
            PlayerPrefs.SetInt("TutorialComplete", 0);
            PlayerPrefs.Save();
            StartCoroutine(WaitBeforeScene("Level1"));
        }        
    }

    IEnumerator WaitBeforeScene(string sceneName)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
