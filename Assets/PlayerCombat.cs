using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    //is at beginning of sword
    [SerializeField] public Transform startHitPoint;
    // at the end of sword
    [SerializeField] public Transform endHitPoint;

    public int attackDamage = 40;

    //i don't really understand this haha
    public LayerMask enemyLayer;



    // Update is called once per frame
    void FixedUpdate()
    {
        // detects hit by castin a line
        bool hasHit = Physics.Linecast(startHitPoint.position, endHitPoint.position, out RaycastHit hit, enemyLayer);
        if(hasHit)
        {
            //object that was hit, is given to attack()
            GameObject target = hit.transform.gameObject;
            Attack(target);
       }
    }

    void Attack(GameObject target)
    {
        //Play attack anim
        //animation not there yet, but this is the code:
        // animator.SetTrigger("Attack");
        target.GetComponent<Enemy>().TakeDamage(attackDamage);
        Debug.Log("Hit!");



    }
}
