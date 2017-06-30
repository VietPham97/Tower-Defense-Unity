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

    public void BuildTurretOn(Node node)
    {
        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity) as GameObject;
        node.turret = turret;
    }
}
