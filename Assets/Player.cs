using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private InputActionMaps _input;
    private float timer;
    [SerializeField] private Slider _playerSlider; 
    void Awake() 
    {
        _input = new InputActionMaps();
    }

    private void OnEnable()
    {
        _input.Player.Enable();
        _input.Player.ResetSlider.performed += ResetSlider_performed;
    }

    private void ResetSlider_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _playerSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSlider();
    }


    private void UpdateSlider()
    {

        if(_input.Player.Slider.inProgress && Time.time > timer)
        {
            _playerSlider.value += (1f * Time.deltaTime)/5f;
           
        }
        else if (_playerSlider.value > 0 && !_input.Player.Slider.inProgress && Time.time > timer) 
        { 
            _playerSlider.value -= 1f * Time.deltaTime;
             
        }
        
    }

}
