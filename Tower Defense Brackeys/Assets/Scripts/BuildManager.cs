using UnityEngine;

public class BuildManager : MonoBehaviour 
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

	public GameObject TurretToBuild { get; private set; }
    public GameObject standardTurretPrefab;

    private void Start()
    {
        TurretToBuild = standardTurretPrefab;
    }

}
