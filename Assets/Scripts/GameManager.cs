using UnityEngine;
using UnityEngine.SceneManagement;   // needed to reload the scene
using UnityEngine.InputSystem;       // needed to read the R key
using TMPro;                         // needed for TextMeshPro text

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;       // drag the score text here
    public TMP_Text livesText;       // drag the lives text here
    public TMP_Text gameOverText;    // drag the game over text here

    public int score = 0;            // how many coins were caught
    public int lives = 3;            // starting lives
    public bool isGameOver = false;  // becomes true when lives reach 0

    void Start()
    {
        gameOverText.text = "";      // empty text = nothing shown
        UpdateTexts();               // show "Score: 0" and "Lives: 3"
    }

    void Update()
    {
        // if the game is over, wait for the R key to restart
        if (isGameOver == true)
        {
            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    // called by the Catcher when a coin is caught
    public void AddScore()
    {
        score = score + 1;
        UpdateTexts();
    }

    // called by the Catcher when a bomb is caught
    public void LoseLife()
    {
        lives = lives - 1;
        UpdateTexts();

        if (lives <= 0)
        {
            isGameOver = true;
            gameOverText.text = "GAME OVER - Press R to restart";
        }
    }

    // puts the current numbers into the UI texts
    void UpdateTexts()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
    }
}
