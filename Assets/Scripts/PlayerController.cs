using UnityEngine;

/******************************************************************************/

//Author: NowWeWake 2020.
//Title: An Easy Tutorial for the New Unity Input System.
//Available at: https://www.youtube.com/watch?v=kGykP7VZCvg
//Accessed: 2 October 2021

/******************************************************************************/

public class PlayerController : MonoBehaviour
{
    //Author NowWeWake (2020)
    public float moveSpeed = 15f;
    float horizontal;
    float vertical;
    //end of code used


    Vector3 verticalVelocity = Vector3.zero;
    public float jumpHeight = 5f;
    public float gravity = -9.81f;
    bool jumpPressed;
    CharacterController controller;


    //Author NowWeWake (2020)
    public void OnMoveInput (float vertical, float horizontal){
        this.vertical = vertical;
        this.horizontal = horizontal;
    //end of code used
    }



    public void onJump()
    {
        jumpPressed = true;
    }


    //Author NowWeWake (2020)
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }
    //end of code used
    private void Update() {


        if (controller.isGrounded.Equals(true))
        {
            verticalVelocity.y = 0;
            if (jumpPressed.Equals(true))
            {
                verticalVelocity.y += Mathf.Sqrt(-2f * jumpHeight * gravity);
            }
            jumpPressed = false;
        }




        //Author NowWeWake (2020)
        Vector3 moveDirection = Vector3.forward * vertical + Vector3.right * horizontal;
        
        Vector3 projectCameraForward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up);
        Quaternion rotationtoCamera = Quaternion.LookRotation(projectCameraForward, Vector3.up);

        moveDirection = rotationtoCamera * moveDirection;

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        //end of code used

        verticalVelocity.y += gravity * Time.deltaTime; //the effect of gravity
        moveDirection.y = verticalVelocity.y;
        moveDirection.x *= moveSpeed;
        moveDirection.z *= moveSpeed;
        controller.Move(moveDirection * Time.deltaTime);

    }
}
