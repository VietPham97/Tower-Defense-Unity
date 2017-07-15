﻿using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour 
{
    public Color hoverColor;
	public Color notEnoughMoneyColor;
    public Vector3 positionOffset = new Vector3(0f, 0.5f, 0f);

    [Header("Optional")]
    public GameObject turret;

    Renderer rend;
    Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>(); // Always put GetComponent method in Start function for optimization
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }


    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }


    private void OnMouseDown()
    {
		if (EventSystem.current.IsPointerOverGameObject())
			return;
        
        if (turret != null)
        {
			buildManager.SelectNode(this);
            return;
        }
		
		if (buildManager.TurretToBuild == null)
			return;

        BuildTurret(buildManager.TurretToBuild);
    }

    void BuildTurret(TurretBlueprint turretBlueprint)
    {
        if (PlayerStats.Money < turretBlueprint.cost)
		{
			Debug.LogWarning("Not enough money to build that tower!");
			return;
		}

        PlayerStats.Money -= turretBlueprint.cost;

        GameObject turretGO = Instantiate(turretBlueprint.prefab, GetBuildPosition(), Quaternion.identity) as GameObject;
		turret = turretGO;

        GameObject bEffect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity) as GameObject;
		Destroy(bEffect, 5f);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (buildManager.TurretToBuild == null)
			return;

        if (buildManager.HasEnoughMoney)
        {
			rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

    }


    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
