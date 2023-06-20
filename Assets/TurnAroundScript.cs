using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurnAroundScript : MonoBehaviour
{
    public InputActionAsset playerControls;
    InputAction moveLJoystick;

    Vector3 rotationVec;
    public float speed = 5f;

    CharacterController playerController;

    // Start is called before the first frame update
    void Start()
    {
        var gameplayActionMap = playerControls.FindActionMap("Default");

        moveLJoystick = gameplayActionMap.FindAction("Move");

        moveLJoystick.performed += OnJoystickLmove;
        moveLJoystick.canceled += OnJoystickLmove;

        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationVec);
    }

    void OnJoystickLmove(InputAction.CallbackContext context)
    {
        Vector2 movement2d = context.ReadValue<Vector2>();
        rotationVec = new Vector3(-movement2d.y, movement2d.x, 0);
    }
}
