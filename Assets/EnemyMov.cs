using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMov : MonoBehaviour
{
    public Transform player;
    Animator animator;

    public float speed = 10f;

    NavMeshAgent nma;

    // Start is called before the first frame update
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        nma.SetDestination(player.position);
        float curSpeed = nma.velocity.magnitude;
        animator.SetFloat("velZ", curSpeed / speed);
    }
}
