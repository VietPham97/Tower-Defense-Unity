using UnityEngine;

public class Node : MonoBehaviour 
{
    public Color hoverColor;

    Renderer rend;
    Color startColor;


    private void Start()
    {
        rend = GetComponent<Renderer>(); // Always put GetComponent method in Start function for optimization
        startColor = rend.material.color;
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
