using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Transform centerOfMas;
    public float motorTorque = 1500f;
    public float maxSteer = 20f;

    public float Steer { get; set; }
    public float Thorttle { get; set; }
    private Rigidbody _rigidbody;

    public Wheel[] wheels;

    private void Start()
    {
        wheels = GetComponentsInChildren<Wheel>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerOfMas.localPosition;
    }

    private void Update()
    {
        Steer = GameManager.Instance.InputController.SteerInput;
        Thorttle = GameManager.Instance.InputController.ThrottelInput;

        foreach (var wheel in wheels)
        {
            wheel.SteerAngle = Steer * maxSteer;
            wheel.Torque = Thorttle * motorTorque;
        }
    }
}
