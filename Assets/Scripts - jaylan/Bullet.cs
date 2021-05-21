using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    [SerializeField]private float speed = 70;
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

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        Debug.Log("Hit"); 
    }
}
