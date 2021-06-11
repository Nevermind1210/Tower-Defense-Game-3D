using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float speed = 70;
    [SerializeField] private float explosionRadius = 0f;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
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
        //makes the bullet move
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        //checks if the bullet has AOE damage or not, will run corresponding code
        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Debug.Log("Hit");
        Destroy(gameObject);
    }
    void Damage(Transform _enemy)
    {
        Destroy(_enemy.gameObject);
    }
    void Explode()
    {
        //creates a collider for explosion radius of the missile
        Collider[] enemyCollider = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in enemyCollider)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        //shows collider as gizmo 
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
