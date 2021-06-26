using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Waypoints[] waypoints;

    public int wayPointindex;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Waypoints _waypoints = waypoints[wayPointindex];
        agent.SetDestination(_waypoints.transform.position);
    }
}
