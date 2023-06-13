using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
 
    void Update()
    {
    }
    public void LaunchBall(Vector3 direction, float force)
    {
    rb.AddForce(direction.normalized * force);
    }
    public void Freeze()
    {
        rb.isKinematic = true;
    }
    public void Unfreeze()
    {
        rb.isKinematic = false;
    }
}