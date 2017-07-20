using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
    public string levelToLoad = "Game";

    SceneFader fadeEffect;

    private void Start()
    {
        fadeEffect = FindObjectOfType<SceneFader>();
    }

    public void Play()
    {
        fadeEffect.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}
