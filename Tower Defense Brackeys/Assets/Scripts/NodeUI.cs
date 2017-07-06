using UnityEngine;

public class NodeUI : MonoBehaviour 
{
    public GameObject towerSelectUI;
    Node target;

    public void SetTarget(Node targetNode)
    {
        target = targetNode;

        transform.position = target.GetBuildPosition();

        towerSelectUI.SetActive(true);
    }

    public void Hide()
    {
        towerSelectUI.SetActive(false);
    }
}
