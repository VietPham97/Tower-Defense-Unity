using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public static bool gameOver;

    public GameObject gameOverUI; // Assign GameOverUI in the Hirerachy to this field in the Inspector

    private void Start()
    {
        gameOver = false;  // reset this to false because it is static and its value true will exist in the entire game
    }

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
