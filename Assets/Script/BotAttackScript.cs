using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAttackScript : MonoBehaviour
{
    public Transform handTarget;
    Vector3 origPos; //This will save the component values of the handTarget, to return to default position in animating the attacks
    Quaternion origRot;
    public float attackInterval = 3f; //An average of time between attacks
    [SerializeField] float timeToAttack = 2f;
    [SerializeField] float attackEnd;
    [SerializeField] float transition = 1f;

    float r;
    int right;
    public bool attack = true;

    [SerializeField] bool transition1 = false;
    [SerializeField] bool transition2 = false;
    // Start is called before the first frame update
    Vector3 RHighAttack1Position = new Vector3(3.43f, 1.57f, -0.32f);
    Quaternion RHighAttack1Rotation = Quaternion.Euler(-11f, 93f, -13f);
    Vector3 RHighAttack2Position = new Vector3(3.67f, 1.36f, -0.93f);
    Quaternion RHighAttack2Rotation = Quaternion.Euler(-37f, 42f, -110f);

    Vector3[] positions = new Vector3[] { new Vector3(3.43f, 1.57f, -0.32f), new Vector3(3.67f, 1.36f, -0.93f), new Vector3(3.29f, 1.23f, -0.14f), new Vector3(3.74f, 1.23f, -0.71f),
    new Vector3(3.4f, 1.04f, -0.41f), new Vector3(3.67f, 1.08f, -0.77f), new Vector3(4.06f, 1.58f, -0.48f), new Vector3(4.08f, 1.50f, -0.52f), new Vector3(4.09f, 1.41f, -0.53f),
    new Vector3(3.90f, 1.36f, -0.61f), new Vector3(4.01f, 1.07f, -0.50f), new Vector3(3.97f, -0.941f, -0.55f)};

    Quaternion[] rotations = new Quaternion[] { Quaternion.Euler(-11f, 93f, -13f), Quaternion.Euler(-37f, 42f, -110f), Quaternion.Euler(-9.4f, -231f, -82f), Quaternion.Euler(22f, -273f, -121f),
    Quaternion.Euler(-21f, 160f, -140f), Quaternion.Euler(-20f, 54f, -130f), Quaternion.Euler(34f, 120f, 20f), Quaternion.Euler(34f, 120f, -113f), 
    Quaternion.Euler(76f, 100f, -6f), Quaternion.Euler(77f, 118f, -115f), Quaternion.Euler(54f, 219f, 112f), Quaternion.Euler(43f, 257f, 26f)};

    Vector3 RMedAttack1Position = new Vector3(3.29f, 1.23f, -0.14f);
    Quaternion RMedAttack1Rotation = Quaternion.Euler(-9.4f, -231f, -82f);
    Vector3 RMedAttack2Position = new Vector3(3.74f, 1.23f, -0.71f);
    Quaternion RMedAttack2Rotation = Quaternion.Euler(22f, -273f, -121f);

    Vector3 RLowAttack1Position = new Vector3(3.4f, 1.04f, -0.41f);
    Quaternion RLowAttack1Rotation = Quaternion.Euler(-21f, 160f, -140f);
    Vector3 RLowAttack2Position = new Vector3(3.67f, 1.08f, -0.77f);
    Quaternion RLowAttack2Rotation = Quaternion.Euler(-20f, 54f, -130f);

    //Left attacks
    Vector3 LHighAttack1Position = new Vector3(3.43f, 1.57f, -0.32f);
    Quaternion LHighAttack1Rotation = Quaternion.Euler(-11f, 93f, -13f);
    Vector3 LHighAttack2Position = new Vector3(3.67f, 1.36f, -0.93f);
    Quaternion LHighAttack2Rotation = Quaternion.Euler(-37f, 42f, -110f);

    Vector3 LMedAttack1Position = new Vector3(3.29f, 1.23f, -0.14f);
    Quaternion LMedAttack1Rotation = Quaternion.Euler(-9.4f, -231f, -82f);
    Vector3 LMedAttack2Position = new Vector3(3.74f, 1.23f, -0.71f);
    Quaternion LMedAttack2Rotation = Quaternion.Euler(22f, -273f, -121f);

    Vector3 LLowAttack1Position = new Vector3(3.4f, 1.04f, -0.41f);
    Quaternion LLowAttack1Rotation = Quaternion.Euler(-21f, 160f, -140f);
    Vector3 LLowAttack2Position = new Vector3(3.67f, 1.08f, -0.77f);
    Quaternion LLowAttack2Rotation = Quaternion.Euler(-20f, 54f, -130f);

    void Start()
    {
        timeToAttack = Time.time +2f;
        attackEnd = timeToAttack + 2*transition + 1f;
        origPos = handTarget.position;
        origRot = handTarget.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!attack)
        {
            attackPose(origPos, origRot);
            return;
        }

        if (!transition1) 
        { 
            r = UnityEngine.Random.Range(0f, 1f); //float
            right = UnityEngine.Random.Range(0, 2) * 6; //int, if the int is 0, right attack is chosen, if int is 6, left is
        }
        if (Time.time > timeToAttack && Time.time < timeToAttack + transition) //If the time is to attack, and transition 1 has not begun
        {

            if (r < 1/3f) //Right High attack
            {
                attackPose(positions[0+right], rotations[0+right]);
            }
            else if(r >= 1/3 && r < 2/3f)
            {
                attackPose(positions[2 + right], rotations[2 + right]);
            }
            else
            {
                attackPose(positions[4 + right], rotations[4 + right]);
            }
            transition1 = true;
        }
        else if (Time.time >= timeToAttack + transition && Time.time < timeToAttack + 2*transition )
        {
            if (r < 0.33) //Right High attack
            {
                attackPose(positions[1 + right], rotations[1 + right]);
            }
            else if (r >= 0.33)
            {
                attackPose(positions[3 + right], rotations[3 + right]);
            }
            else
            {
                attackPose(positions[5 + right], rotations[5 + right]);
            }

            transition2 = true;
        }
        //else if ( Time.time >= timeToAttack + transition + attackInterval && !transition2 ) { transition1 = true; transition2 = true; }
        else 
        {
            attackPose(origPos, origRot);
            if (Time.time > attackEnd) 
            { 
                timeToAttack = Time.time + attackInterval + UnityEngine.Random.Range(-1f, 1f);
                attackEnd = timeToAttack + 2 * transition + 1f;
                transition1 = false;
                transition2 = false;
            }
        }

    }

    void attackPose(Vector3 pos, Quaternion rot)
    {
        handTarget.position = Vector3.Lerp(handTarget.position, pos, 0.3f);
        handTarget.rotation = Quaternion.Lerp(handTarget.rotation, rot, 0.3f);
    }
}
