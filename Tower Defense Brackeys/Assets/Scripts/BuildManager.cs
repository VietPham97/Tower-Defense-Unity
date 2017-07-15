using UnityEngine;

public class BuildManager : MonoBehaviour 
{
    public static BuildManager instance;
    public GameObject buildEffect;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public TurretBlueprint TurretToBuild { get; private set; }
    Node nodeToSelect;
    public NodeUI nodeUI;  // assign the NodeUI object to this field

    public bool HasEnoughMoney
	{
		get
		{
			return PlayerStats.Money >= TurretToBuild.cost;
		}
	}

	public void SelectNode(Node node)
    {
        if (nodeToSelect == node)
        {
            DeselectNode();
            return;
        }

        nodeToSelect = node;
        TurretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        nodeToSelect = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        TurretToBuild = turret;
    }
}
