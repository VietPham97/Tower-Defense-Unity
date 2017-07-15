using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour 
{
    public GameObject towerSelectUI;
    public Text upgradeCostText;
    public Button upgradeButton;

    Node target;

    public void SetTarget(Node targetNode)
    {
        target = targetNode;
        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
			upgradeCostText.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCostText.text = "MAX";
            upgradeButton.interactable = false;
        }

        towerSelectUI.SetActive(true);
    }

    public void Hide()
    {
        towerSelectUI.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
}
