using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectiveController : MonoBehaviour
{
    public string objectiveGrade;
    public float collectedVictims = 0f;
    public float firesExtinguished = 0f;
    public Text objective;
    public Text optionalObjective;
    public Text gradeText;
    public Text savedVictims;
    public Text extinguishedFires;
    public GameObject victoryScreen;
    private GameObject[] victims;
    private GameObject[] fires;

    public Text timerText;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        victims = GameObject.FindGameObjectsWithTag("victim");
        fires = GameObject.FindGameObjectsWithTag("fire");

        objective.text = "Victims: " + collectedVictims + "/" + victims.Length;
        optionalObjective.text = "Fires: " + firesExtinguished + "/" + fires.Length;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);

        timerText.text = "Time spent: " + string.Format("{0:00}:{1:00}", minutes, seconds);

        if (collectedVictims >= victims.Length)
        {
            string activeSceneName = SceneManager.GetActiveScene().name;
            if (activeSceneName == "Level1")
            {
                bool isTutorialComplete = PlayerPrefs.GetInt("TutorialComplete") == 1;
                if (!isTutorialComplete)
                {
                    PlayerPrefs.SetInt("TutorialComplete", 1);
                    PlayerPrefs.Save();
                }
            }
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gradeText.text = "Grade:" + FormGrade();
            savedVictims.text = "Victims saved: " + collectedVictims + "/" + victims.Length;
            extinguishedFires.text = "Bonus objective: " + firesExtinguished + "/" + fires.Length;
            GameObject player = GameObject.FindWithTag("Player");
            player.SetActive(false);
            victoryScreen.SetActive(true);
        }
    }

    public void VictimSaved()
    {
        collectedVictims++;
        if (collectedVictims > victims.Length)
        {
            collectedVictims = victims.Length;
        }
        objective.text = "Victims: " + collectedVictims + "/" + victims.Length;
    }

    public void FireExtinguished()
    {
        firesExtinguished++;
        if (firesExtinguished > fires.Length)
        {
            firesExtinguished = fires.Length;
        }
        optionalObjective.text = "Fires: " + firesExtinguished + "/" + fires.Length;
    }

    float GetPercentage()
    {
        float percentage = ((float)firesExtinguished / (float)fires.Length) * 100f;
        return percentage;
    }

    string FormGrade()
    {
        float grade = 1f;
        float optionalPercentage = GetPercentage();
        if (optionalPercentage > 0 && optionalPercentage <= 30)
        {
            grade += 1;
        }
        if (optionalPercentage >= 31 && optionalPercentage <= 50)
        {
            grade += 2;
        }
        if (optionalPercentage >= 51 && optionalPercentage <= 69)
        {
            grade += 3;
        }
        if (optionalPercentage >= 70 && optionalPercentage <= 99)
        {
            grade += 4;
        }
        if (optionalPercentage == 100)
        {
            grade += 5;
        }

        if (timer <= 240)
        {
            grade += 3;
        }
        if (timer <= 300 && timer >= 241)
        {
            grade += 2;
        }
        if (timer <= 340 && timer >= 301)
        {
            grade += 1;
        }

        switch (grade)
        {
            case 1:
                objectiveGrade = "F";
                break;
            case 2:
                objectiveGrade = "D";
                break;
            case 3:
                objectiveGrade = "C";
                break;
            case 4:
                objectiveGrade = "B";
                break;
            case 5:
                objectiveGrade = "B+";
                break;
            case 6:
                objectiveGrade = "A";
                break;
            case 7:
                objectiveGrade = "A+";
                break;
            case 8:
                objectiveGrade = "S";
                break;
            case 9:
                objectiveGrade = "S+";
                break;
            default:
                objectiveGrade = "F";
                break;
        }

        return objectiveGrade;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void FinishLevel(string levelName)
    {
        PlayerPrefs.SetInt(levelName,1);
        PlayerPrefs.SetString("current_mission",null);
    }


}
