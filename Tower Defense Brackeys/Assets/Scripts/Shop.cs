﻿using UnityEngine;

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
        //Debug.Log("Standard Turret Selected");
        buildManager.TurretToBuild = standardTurret;
    }

	public void SelectMissileLauncher()
	{
		//Debug.Log("Missile Launcher Selected");
        buildManager.TurretToBuild = missileLauncher;
	}

	public void SelectLaserBeamer()
	{
		//Debug.Log("Missile Launcher Selected");
        buildManager.TurretToBuild = laserBeamer;
	}
}
