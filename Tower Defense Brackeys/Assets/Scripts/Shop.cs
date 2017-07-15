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
        buildManager.SelectTurretToBuild(standardTurret);
        buildManager.DeselectNode();
    }

	public void SelectMissileLauncher()
	{
        buildManager.SelectTurretToBuild(missileLauncher);
        buildManager.DeselectNode();
	}

	public void SelectLaserBeamer()
	{
        buildManager.SelectTurretToBuild(laserBeamer);
        buildManager.DeselectNode();
	}
}
