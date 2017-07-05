using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour 
{
    public Text roundsSurvivedNumber; // Assign Rounds Survived Number to this field

    private void OnEnable()
    {
        roundsSurvivedNumber.text = PlayerStats.Rounds.ToString();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // reload the current scene
    }

    public void MainMenu()
    {
        Debug.Log("Go to Menu.");
    }
}
