using UnityEngine;

public class Shop : MonoBehaviour 
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.TurretToBuild = buildManager.standardTurretPrefab;
    }

	public void PurchaseLaserTurret()
	{
		Debug.Log("Laser Turret Selected");
        buildManager.TurretToBuild = buildManager.laserTurretPrefab;
	}

	public void PurchaseMissileLauncher()
	{
		Debug.Log("Missile Turrer Selected");
        buildManager.TurretToBuild = buildManager.missileLauncherPrefab;
	}
}
