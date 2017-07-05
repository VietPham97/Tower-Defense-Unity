using UnityEngine;

public class Shop : MonoBehaviour 
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;

    BuildManager buildManager;


    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        buildManager.TurretToBuild = standardTurret;
        buildManager.ResetSelectedNode();
    }

	public void SelectMissileLauncher()
	{
        buildManager.TurretToBuild = missileLauncher;
        buildManager.ResetSelectedNode();
	}

	public void SelectLaserBeamer()
	{
        buildManager.TurretToBuild = laserBeamer;
        buildManager.ResetSelectedNode();
	}
}
