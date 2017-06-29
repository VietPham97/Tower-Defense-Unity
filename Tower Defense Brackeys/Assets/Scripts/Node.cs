using UnityEngine;

public class Node : MonoBehaviour 
{
    public Color hoverColor;

    GameObject turret;

    Renderer rend;
    Color startColor;


    private void Start()
    {
        rend = GetComponent<Renderer>(); // Always put GetComponent method in Start function for optimization
        startColor = rend.material.color;
    }


    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.LogWarning("Cannot build there! - TODO: Display on screen.");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.TurretToBuild;
        turret = Instantiate(turretToBuild, transform.position, transform.rotation) as GameObject;
    }


    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }


    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
