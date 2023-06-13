using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GameController : MonoBehaviour
{
    [SerializeField]
    InputData inputData;
    // Don't forget to get a reference for the ball to reset position
    [SerializeField]
    GameObject ball;
    void Start()
    {
        // Get InputData Component
        inputData = GetComponent<InputData>();
    }
    void Update()
    {
        // Read input
        if (inputData._rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool input))
        {
            if (input)
            {
                // Reset ball position
                ball.transform.position = new Vector3(0f, 0.5f, 1f);
            }
        }
    }
}