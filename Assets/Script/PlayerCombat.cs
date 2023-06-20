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

    public BotGetAttack enemy;

    public int attackDamage = 40;
    public AudioSource audios;

    CharacterController playerController;

    [SerializeField] InputActionAsset playerControls;
    InputAction blockSword;

    [SerializeField] float isHolding = 0f;

    //i don't really understand this haha 
    //I think a layermask helps make physics area detectors ignore certain gameObjects
    //and youll have to adjust that in the scene, on the layermask component
    public LayerMask enemyLayer;

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
        // detects hit by castin a line
        bool hasHit = Physics.Linecast(startHitPoint.position, endHitPoint.position, out RaycastHit hit, enemyLayer);
        if(hasHit)
        {
            //object that was hit, is given to attack()
            GameObject target = hit.transform.gameObject;
            Attack(target);
       }


        if (isHolding==1f)
        {
            BlockSword();
            audios.Play();
        }
    }

    void Attack(GameObject target)
    {
        //Play attack anim
        //animation not there yet, but this is the code:
        // animator.SetTrigger("Attack");
        target.GetComponent<BotGetAttack>().TakeDamage(attackDamage);
        Debug.Log("Hit!");



    }

    public void OnJoystickButton(InputAction.CallbackContext context)
    {
        isHolding = context.ReadValue<float>();
    }

    void BlockSword()
    {
        Debug.Log("ISBLOCK");
    }
}
