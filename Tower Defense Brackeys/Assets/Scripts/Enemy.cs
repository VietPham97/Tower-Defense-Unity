using UnityEngine;

public class Enemy : MonoBehaviour 
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float health = 100f;

    public int moneyReward = 50;

	public GameObject deathEffect;

    private void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

	public void Slow(float slowPercentage)
	{
        speed = startSpeed * (1f - slowPercentage);
	}
 
    private void Die()
    {
        PlayerStats.Money += moneyReward;
        
        var effect = Instantiate(deathEffect, transform.position, Quaternion.identity) as GameObject;
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

}
