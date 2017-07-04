using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
    public Text moneyText;
    public Text livesText;

    private void Update()
    {
        moneyText.text = "$" + PlayerStats.Money.ToString();
        livesText.text = PlayerStats.Lives + " LIVES";
    }
}
