using UnityEngine;

public class LevelSelector : MonoBehaviour 
{
    public void Select(string levelName)
    {
        SceneFader.Instance.FadeTo(levelName);
    }

}
