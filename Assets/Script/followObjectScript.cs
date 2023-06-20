using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followObjectScript : MonoBehaviour
{
    public Transform rHandCont;
    public Quaternion rotOffset = Quaternion.Euler(90f, 0f, 0f);
    public float rotOffsetX = 0f;
    public float rotOffsetY = 0f;
    public float rotOffsetZ = 0f;

    //Change these values for the sword to reach the hand
    public float xOffset = 0f;
    public float yOffset = 0f;
    public float zOffset = 0.07f;

    // Update is called once per frame
    void Update()
    {
        Vector3 Offset = new Vector3(xOffset, yOffset, zOffset);

        transform.position = rHandCont.position + Offset;
        //transform.rotation = Quaternion.Euler(rHandCont.rotation.eulerAngles.normalized.x +rotOffsetX, rHandCont.rotation.normalized.eulerAngles.y, rHandCont.rotation.normalized.eulerAngles.z);

        // Update the rotation
        transform.rotation = rHandCont.rotation * rotOffset;
    }
}
