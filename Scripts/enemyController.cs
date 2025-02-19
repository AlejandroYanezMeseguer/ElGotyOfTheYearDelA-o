using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{
    private NavMeshAgent pathFinder;
    private Transform target;



    void Start()
    {
        pathFinder = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").transform;
    }
    void Update()
    {
        pathFinder.SetDestination(target.position);
        Debug.Log(target.position);

               
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().ApplyKnockback();
        }
    }

}