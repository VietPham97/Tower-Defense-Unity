using UnityEngine;

public class BuildManager : MonoBehaviour 
{
    public static BuildManager instance;
	public GameObject standardTurretPrefab, missileLauncherPrefab, laserTurretPrefab;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    GameObject turretToBuild;
    public GameObject TurretToBuild
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


}
