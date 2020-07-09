using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public string inputStreerAxis = "Horizontal";
    public string inputThrottleAxis = "Vertical";

    public float ThrottelInput { get; private set; }
    public float SteerInput { get; private set; }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SteerInput = Input.GetAxis(inputStreerAxis);
        ThrottelInput = Input.GetAxis(inputThrottleAxis);
    }
}
