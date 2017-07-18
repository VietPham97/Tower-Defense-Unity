using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour 
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public int moneyReward = 50;

    public GameObject deathEffect;

    [Header("Enemy Health")]
    public Image healthBar;
    public float startHealth = 100f;
    float health;

    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

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
