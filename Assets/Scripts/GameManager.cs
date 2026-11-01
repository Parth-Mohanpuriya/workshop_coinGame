using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text gameOverText;

    public int score = 0;
    public int lives = 3;
    public bool isGameOver = false;

    void Start()
    {
        gameOverText.text = "";
        UpdateTexts();
    }

    void Update()
    {
        if (isGameOver == true)
        {
            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    public void AddScore()
    {
        score = score + 1;
        UpdateTexts();
    }

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

    void UpdateTexts()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
    }
}
