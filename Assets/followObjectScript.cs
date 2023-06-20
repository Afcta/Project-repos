using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followObjectScript : MonoBehaviour
{
    public Transform rHandCont;
    public float rotOffsetX = 90f;
    public float zOffset = 0.1f;

    // Update is called once per frame
    void Update()
    {
        transform.position = rHandCont.position - Vector3.forward*zOffset;
        transform.rotation = Quaternion.Euler(rHandCont.rotation.x+rotOffsetX, rHandCont.rotation.y, rHandCont.rotation.z);
    }
}
