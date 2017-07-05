using UnityEngine;

public class GameManager : MonoBehaviour 
{
    bool gameOver;

    public GameObject gameOverUI; // Assign GameOverUI in the Hirerachy to this field in the Inspector

    private void Update()
    {
        if (gameOver) return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameOver = true;
        gameOverUI.SetActive(true);
    }
}
