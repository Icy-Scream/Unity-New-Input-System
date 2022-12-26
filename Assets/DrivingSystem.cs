using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingSystem : MonoBehaviour
{
    UserInputActions _input;
    private void Awake()
    {
        _input = new UserInputActions();
    }

    private void Update()
    {
        Drive();
    }
    
    private void Drive() 
    {
        var value = _input.Drive.Drive.ReadValue<Vector2>();
        transform.Translate(value * 3f * Time.deltaTime);
    }
}
