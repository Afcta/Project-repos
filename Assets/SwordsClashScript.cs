using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsClashScript : MonoBehaviour
{
    public Animator charAnimator;
    [SerializeField] Collider swordHitbox;
    public LayerMask swordMask;
    public BotAttackScript attackScript;
    public float swordClashTime = 2f;


    // Start is called before the first frame update
    void Start()
    {    
        swordHitbox = GetComponentInChildren<Collider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapBox(swordHitbox.bounds.center, swordHitbox.bounds.extents*4, swordHitbox.transform.rotation, swordMask);
        //for (int i=0; i<colliders.Length; i++){
        //    colliders[i].gameObject.GetComponent<MeshRenderer>().enabled = true;
        //}
        
        if(colliders.Length > 0 )
        {
            StartCoroutine(swordRecoil(swordClashTime));
        }
    }

    IEnumerator swordRecoil(float recoilTime)
    {
        Debug.Log("swordRecoil");
        attackScript.attack = false;
        charAnimator.SetBool("swordClash", true);
        yield return new WaitForSeconds(recoilTime);
        attackScript.attack = true;
        charAnimator.SetBool("swordClash", false);
    }
}
