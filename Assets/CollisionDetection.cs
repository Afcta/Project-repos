using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public GameObject HitParticle;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("Hit !" + other.name);
            // play enemy anim
            // other.GetComponent<Animator>().SetTrigger("Hit!");
            //particle
            //Instantiate(HitParticle, new Vector3(other.transform.position.x, ...))


        }
    }
}
