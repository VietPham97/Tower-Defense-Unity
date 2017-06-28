using UnityEngine;

public class Enemy : MonoBehaviour 
{
    public float speed = 10f;

    Transform target;
    int wavepointIndex;


    private void Start()
    {
        target = Waypoints.points[0];
    }


    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    }
}
