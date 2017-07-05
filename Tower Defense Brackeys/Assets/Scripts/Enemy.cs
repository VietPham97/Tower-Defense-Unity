using UnityEngine;

public class Enemy : MonoBehaviour 
{
    public float speed = 10f;
    public float health = 100f;

    public int moneyReward = 50;

    Transform target;
    int waypointIndex;

    public GameObject deathEffect;

    private void Start()
    {
        target = Waypoints.points[0];
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
		PlayerStats.Money += moneyReward;
		
        var effect = Instantiate(deathEffect, transform.position, Quaternion.identity) as GameObject;
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

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
