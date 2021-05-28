using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    
    [SerializeField] private float trapRange = 0f;
    void Detonate()
    {
        //creates a collider around the trap
        Collider[] enemyCollider = Physics.OverlapSphere(transform.position, trapRange);
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
        Gizmos.DrawWireSphere(transform.position, trapRange);
    }
    void Damage(Transform _enemy)
    {
        Destroy(_enemy.gameObject);
    }

    private void Update()
    {
        Detonate();
    }
}
