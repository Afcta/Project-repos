using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwordCombat : MonoBehaviour
{
    [SerializeField] public Transform startHitPoint;
    [SerializeField] public Transform endHitPoint;
    CharacterController playerController;

    [SerializeField] InputActionAsset playerControls;
    InputAction blockSword;

    [SerializeField] bool isHolding = false;

    private void Start()
    {
        var gameplayActionMap = playerControls.FindActionMap("Default");

        blockSword = gameplayActionMap.FindAction("BlockSword");

        blockSword.performed += OnJoystickButton;
        blockSword.canceled += OnJoystickButton;

        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(startHitPoint.position, endHitPoint.position, out RaycastHit hit, 0);
        if (hasHit)
        {
            GameObject target = hit.transform.gameObject;
            Attack(target);
        }

        if (isHolding)
        {
            BlockSword();
        }
    }

    void Attack(GameObject target)
    {
        // Play attack anim
        // animator.SetTrigger("Attack");
    }

    public void OnJoystickButton(InputAction.CallbackContext context)
    {
        isHolding = context.ReadValue<bool>();
    }

    void BlockSword()
    {
        Debug.Log("ISBLOCK");
    }
}
