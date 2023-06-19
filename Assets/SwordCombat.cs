using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwordCombat : MonoBehaviour
{
    [SerializeField] public Transform startHitPoint;
    [SerializeField] public Transform endHitPoint;



    // Update is called once per frame
    void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(startHitPoint.position, endHitPoint.position, out RaycastHit hit, 0);
        if(hasHit)
        {
            GameObject target = hit.transform.gameObject;
            Attack(target);
       }
    }
    void Attack(GameObject target)
    {
        //Play attack anim
        //animation not there yet, but this is the code:
        // animator.SetTrigger("Attack");


    }
}
