using UnityEngine;

public class Enemy : MonoBehaviour 
{
    public float speed = 10f;
    public float health = 100f;

    public int moneyReward = 50;

	public GameObject deathEffect;

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
}
