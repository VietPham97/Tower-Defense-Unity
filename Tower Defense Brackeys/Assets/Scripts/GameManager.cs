using UnityEngine;

public class GameManager : MonoBehaviour 
{
    bool gameOver;

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
        Debug.Log("Game Over!");
    }
}
