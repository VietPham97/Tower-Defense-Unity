using UnityEngine;

public class BuildManager : MonoBehaviour 
{
    public static BuildManager instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    TurretBlueprint turretToBuild;
    public TurretBlueprint TurretToBuild
    {
        get
        {
            return turretToBuild;
        }        
        set
        {
            turretToBuild = value;
        }
    }

    public bool HasEnoughMoney
	{
		get
		{
			return PlayerStats.Money >= turretToBuild.cost;
		}
	}

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.LogWarning("Not enough money to build that tower!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity) as GameObject;
        node.turret = turret;

        Debug.Log("Turret build! Money left: " + PlayerStats.Money);
    }
}
