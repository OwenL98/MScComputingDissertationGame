using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

/******************************************************************************/

//Author: NowWeWake 2020.
//Title: An Easy Tutorial for the New Unity Input System.
//Available at: https://www.youtube.com/watch?v=kGykP7VZCvg
//Accessed: 2 October 2021

/******************************************************************************/
//Author NowWeWake (2020)
[Serializable] public class MoveInputEvent : UnityEvent<float, float> {}
[Serializable] public class jumpInputEvent : UnityEvent {}

public class InputController : MonoBehaviour
{
    public MoveInputEvent moveInputEvent;
    PlayerInput controls;

    public jumpInputEvent jumpInput;

    private void Awake(){
        controls = new PlayerInput();
    }

    private void OnEnable(){
        controls.Player.Enable();
        controls.Player.Move.performed += OnMovePerformed;
        controls.Player.Move.canceled += OnMovePerformed;
//end of code used

        controls.Player.Jump.performed += _ => onJumpPerformed();

    }


    //Author NowWeWake (2020)
    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        moveInputEvent.Invoke(moveInput.y, moveInput.x);
    }
    //end of code used

    private void onJumpPerformed()
    {
        jumpInput.Invoke();
    }

    private void OnDisable()
    {
        controls.Disable();
    }



}
