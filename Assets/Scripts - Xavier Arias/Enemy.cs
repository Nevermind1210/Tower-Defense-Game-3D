using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject goal = GameObject.Find("Tree");
        if (goal)
            GetComponent<NavMeshAgent>().destination = goal.transform.position;
    }

    private void OnTriggerEnter(Collider co)
    {
        // if tree 
        if (co.name == "goal")
            co.GetComponentInChildren<Health>().Decrease();
    }
}
