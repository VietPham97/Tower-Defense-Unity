using UnityEngine;

public class Shop : MonoBehaviour 
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;

    BuildManager buildManager;


    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.TurretToBuild = standardTurret;
    }

	public void SelectMissileLauncher()
	{
		Debug.Log("Missile Launcher Selected");
        buildManager.TurretToBuild = missileLauncher;
	}
}
