using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float playerHealth = 100f;
    public Slider playerHealthSlider;

    private bool isDead = false;

     public Text quoteText;

    private string[] quotes = new string[]
    {
        "Greater love hath no man than this, that a man lay down his life for his friends. - John 15:13",
        "Firefighters save hearts and homes. - Anonymous",
        "All men are created equal, then a few become firefighters. - Anonymous",
        "When a man becomes a firefighter, his greatest act of bravery has been accomplished. What he does after that is all in the line of work. - Edward F. Croker",
        "A hero is someone who has given his or her life to something bigger than oneself. - Joseph Campbell"
    };

    public FPSController fPSController;

    public GameObject deathPanel;
    // Start is called before the first frame update
    void Start()
    {
        playerHealthSlider.value = playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthSlider.value = playerHealth;

        if(playerHealth <= 0f && isDead == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            DisplayRandomQuote();
            fPSController.enabled = false;
            deathPanel.SetActive(true);
            isDead = true;
        }
    }

    void DisplayRandomQuote()
    {
        int randomIndex = Random.Range(0, quotes.Length);
        quoteText.text = quotes[randomIndex];
    }

    public void InhaleSmoke()
    {
        playerHealth -= 5f;
    }

    public void CatchFire()
    {
        playerHealth -= 15f;
    }
}
