using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMove : MonoBehaviour
{
    public Vector3 mEulerAngleVel;

    public Transform followHand;
    Rigidbody m_Rigidbody;
    public float m_Speed = 5f;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
        mEulerAngleVel = new Vector3(100, 100, 100);
    }

    void FixedUpdate()
    {
        //Store user input as a movement vector
        Vector3 newPos = followHand.position;

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        m_Rigidbody.MovePosition(transform.position + newPos * Time.deltaTime * m_Speed);

        Quaternion deltaRotation = Quaternion.Euler(mEulerAngleVel * Time.fixedDeltaTime);
        //m_Rigidbody.MoveRotation(Transform, m_Rigidbody.rotation * deltaRotation);
        //m_Rigidbody.MoveRotation()
    }
}
