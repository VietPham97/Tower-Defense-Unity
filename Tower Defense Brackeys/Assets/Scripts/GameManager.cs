using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public static bool gameOver;

    public GameObject gameOverUI; // Assign GameOverUI in the Hirerachy to this field in the Inspector

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

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

    public void WinLevel()
    {
        Debug.LogWarning("LEVEL WON");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        SceneFader.Instance.FadeTo(nextLevel);
    }
}
