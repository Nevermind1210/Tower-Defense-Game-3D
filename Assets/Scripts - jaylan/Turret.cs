using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    [Header("Stats")]
    public float range = 15f;
    public float damage = 5f;
    public float firerate = 1f;
    public float fireCountdown = 0f;
    [Header("Setup Stuff")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        //Locates the enemies
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        //Rotates the turret towards the enemy
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / firerate;  
        }
        fireCountdown -= Time.deltaTime;

    }
    void Shoot()
    {
        Debug.Log("Shoot");
        GameObject bulletShoot =(GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletShoot.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }   
    }
    private void OnDrawGizmosSelected()
    {
        //Shows range of tower (will be changed in final just for testing)
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);   
    }
}
            