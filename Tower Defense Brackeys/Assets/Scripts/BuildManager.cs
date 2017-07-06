﻿using UnityEngine;

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

    public TurretBlueprint TurretToBuild { get; set; }
    Node nodeToSelect;
    public NodeUI nodeUI;  // assign the NodeUI object to this field

    public bool HasEnoughMoney
	{
		get
		{
			return PlayerStats.Money >= TurretToBuild.cost;
		}
	}

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < TurretToBuild.cost)
        {
            Debug.LogWarning("Not enough money to build that tower!");
            return;
        }

        PlayerStats.Money -= TurretToBuild.cost;

        GameObject turret = Instantiate(TurretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity) as GameObject;
        node.turret = turret;

        GameObject bEffect = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity) as GameObject;
        Destroy(bEffect, 5f);

        //Debug.Log("Turret build! Money left: " + PlayerStats.Money);
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
}
