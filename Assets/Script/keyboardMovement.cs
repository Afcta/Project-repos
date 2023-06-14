using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class keyboardMovement : MonoBehaviour
{
    public float speedX = 4f;
    public float speedZ = 4f;
    Animator animator;
    CharacterController cController;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        float curSpeedX = speedX * inputX;
        float curSpeedZ = speedZ * inputZ;
        Vector3 mov = transform.right * inputX + transform.forward * inputZ;
        mov = mov * Time.deltaTime;
        cController.Move(mov);

        animator.SetFloat("velX", curSpeedX/speedX);
        animator.SetFloat("velZ", curSpeedZ/speedZ);

    }
}
