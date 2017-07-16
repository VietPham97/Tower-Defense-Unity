using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour 
{
    public Color hoverColor;
	public Color notEnoughMoneyColor;
    public Vector3 positionOffset = new Vector3(0f, 0.5f, 0f);

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    public bool isUpgraded;

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

    void BuildTurret(TurretBlueprint turretBP)
    {
        if (PlayerStats.Money < turretBP.cost)
		{
			Debug.LogWarning("Not enough money to build that tower!");
			return;
		}

        PlayerStats.Money -= turretBP.cost;

        GameObject turretGO = Instantiate(turretBP.prefab, GetBuildPosition(), Quaternion.identity) as GameObject;
		turret = turretGO;

        turretBlueprint = turretBP;

        GameObject bEffect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity) as GameObject;
		Destroy(bEffect, 5f);
    }

    public void UpgradeTurret()
    {
		if (PlayerStats.Money < turretBlueprint.upgradeCost)
		{
			Debug.LogWarning("Not enough money to upgrade that tower!");
			return;
		}

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        // Destroy the existing turret
        Destroy(turret);

        // Build the upgraded one
        GameObject turretGO = Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity) as GameObject;
		turret = turretGO;

		GameObject bEffect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity) as GameObject;
		Destroy(bEffect, 5f);

        isUpgraded = true;

        Debug.Log("Turret upgraded!");
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.SellAmount;

		// TODO Spawn a cool effect
		GameObject sEffect = Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity) as GameObject;
		Destroy(sEffect, 5f);

        Destroy(turret);
        turretBlueprint = null;
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
