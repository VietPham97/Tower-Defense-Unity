using UnityEngine;

public class Bullet : MonoBehaviour 
{
    Transform target;

    public float speed = 70f;
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

    }

    private void HitTarget()
    {
        GameObject effectInstance = Instantiate(impactEffect, transform.position, transform.rotation) as GameObject;
        Destroy(effectInstance, 2f);

        Destroy(gameObject);
    }
}
