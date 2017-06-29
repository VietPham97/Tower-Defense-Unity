using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour 
{
    public Color hoverColor;
    public Vector3 positionOffset = new Vector3(0f, 0.5f, 0f);

    GameObject turret;

    Renderer rend;
    Color startColor;

    BuildManager buildManager;


    private void Start()
    {
        rend = GetComponent<Renderer>(); // Always put GetComponent method in Start function for optimization
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }


    private void OnMouseDown()
    {
		if (EventSystem.current.IsPointerOverGameObject())
			return;
        
        if (buildManager.TurretToBuild == null)
            return;
            
        
        if (turret != null)
        {
            Debug.LogWarning("Cannot build there! - TODO: Display on screen.");
            return;
        }

        GameObject turretToBuild = buildManager.TurretToBuild;
        turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation) as GameObject;
    }


    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (buildManager.TurretToBuild == null)
			return;
        
        rend.material.color = hoverColor;
    }


    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
