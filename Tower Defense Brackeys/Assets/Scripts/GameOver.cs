using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour 
{
    public Text roundsSurvivedNumber; // Assign Rounds Survived Number to this field

    private void OnEnable()
    {
        roundsSurvivedNumber.text = PlayerStats.Rounds.ToString();
    }
}
