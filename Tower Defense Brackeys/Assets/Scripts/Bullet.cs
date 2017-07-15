using UnityEngine;

public class Bullet : MonoBehaviour 
{
    Transform target;

    public float speed = 70f;
	public int damage = 50;
    public float explosionRadius;
    public GameObject impactEffect;

    public void Seek(Transform target_)
    {
        target = target_;
    }


    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    private void HitTarget()
    {
        GameObject effectInstance = Instantiate(impactEffect, transform.position, transform.rotation) as GameObject;
        Destroy(effectInstance, 3f);

        if (explosionRadius > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    private void Explode()
    {
        Collider[] explosionSphere = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (var col in explosionSphere)
        {
            if (col.tag == "Enemy")
            {
                Damage(col.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        var enemyComponent = enemy.GetComponent<Enemy>();

        if (enemyComponent != null)
        {
            enemyComponent.TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
