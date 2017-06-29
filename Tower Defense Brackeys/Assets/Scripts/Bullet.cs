using UnityEngine;

public class Bullet : MonoBehaviour 
{
    Transform target;

    public float speed = 70f;


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
        // Debug.Log("We hit something");
        Destroy(gameObject);
    }
}
