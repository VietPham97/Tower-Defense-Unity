using UnityEngine;

public class MainMenu : MonoBehaviour 
{
    public string levelToLoad = "LevelSelect";

    public void Play()
    {
        SceneFader.Instance.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}
