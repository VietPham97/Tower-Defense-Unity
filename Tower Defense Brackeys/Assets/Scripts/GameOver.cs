using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour 
{
    public Text roundsSurvivedNumber; // Assign Rounds Survived Number to this field

    public string menuScene = "Menu";

    private void OnEnable()
    {
        roundsSurvivedNumber.text = PlayerStats.Rounds.ToString();
    }

    public void PlayAgain()
    {
        SceneFader.Instance.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneFader.Instance.FadeTo(menuScene);
    }
}
