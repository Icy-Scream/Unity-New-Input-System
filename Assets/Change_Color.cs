using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Color : MonoBehaviour
{
    private UserInputActions _input;
    private void Awake()
    {
        _input = new UserInputActions();

    }

    private void OnEnable()
    {
        _input.Player.Enable();
        _input.Player.ChangeColor.performed += ChangeColor_performed;
    }

    private void ChangeColor_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        this.gameObject.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}
