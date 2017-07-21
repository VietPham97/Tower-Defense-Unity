using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour 
{
    public GameObject pauseMenuUI;

    public string levelToLoad = "Menu";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Toggle();    
        }
    }

    public void Toggle()
    {
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);

        if (pauseMenuUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneFader.Instance.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneFader.Instance.FadeTo(levelToLoad);
    }
}
