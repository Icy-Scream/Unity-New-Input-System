using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    UserInputActions _input;
    Rigidbody _rigidbody;
    private void Awake()
    {
        _input = new UserInputActions();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _input.JumpMap.Enable();
        _input.JumpMap.Jump.canceled += Jump_canceled;
        _input.JumpMap.Jump.performed += Jump_performed;
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _rigidbody.AddForce(Vector3.up * 10f, ForceMode.Impulse);
    }

    private void Jump_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        var jumpOverTime = context.duration;
        if (jumpOverTime > 1) return;
        if(jumpOverTime > .2f)
        _rigidbody.AddForce(Vector3.up * (10f * (float) jumpOverTime), ForceMode.Impulse);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
