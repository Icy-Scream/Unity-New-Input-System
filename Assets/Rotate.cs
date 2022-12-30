using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rotate : MonoBehaviour
{
    private UserInputActions _input;
    private void Awake()
    {
        _input = new UserInputActions();
    }

    private void OnEnable()
    {
        _input.Player.Enable();
        _input.Player.DrivingState.performed += SwitchDrive_performed; 
    }

    private void SwitchDrive_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("T");
        _input.Player.Disable();
        _input.Drive.Enable();
    }

    private void Update()
    {
        RotateObject();
        Drive();
    }

    private void RotateObject()
    {
        var value = _input.Player.Rotate.ReadValue<Vector2>();
        
        transform.Rotate(Vector3.up * 50f * value.x * Time.deltaTime);
    }

    private void Drive()
    {
        var value = _input.Drive.Drive.ReadValue<Vector2>();
        transform.Translate(value * 3f * Time.deltaTime);
    }
}
