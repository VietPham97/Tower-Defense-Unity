using UnityEngine;

public class NodeUI : MonoBehaviour 
{
    Node target;

    public void SetTarget(Node targetNode)
    {
        target = targetNode;

        transform.position = target.GetBuildPosition();
    }
}
