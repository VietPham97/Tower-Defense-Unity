using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour 
{
	Transform target;
	int waypointIndex;

    Enemy enemy;

	private void Start()
	{
        enemy = GetComponent<Enemy>();
		target = Waypoints.points[0];
	}

	private void Update()
	{
		Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}
	}


	private void GetNextWaypoint()
	{
		if (waypointIndex >= Waypoints.points.Length - 1)
		{
			EndPath();
			return;
		}

		waypointIndex++;
		target = Waypoints.points[waypointIndex];
	}

	void EndPath()
	{
		PlayerStats.Lives--;
		Destroy(gameObject);
	}
}
