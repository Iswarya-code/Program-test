using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public CharacterController controller;  // controls the player movements
   
    public float speed = 10f;         // Player movement speed

    public float turnSmoothTime = 0.1f;    // add smoothing to the player turning time

    float turnSmoothVelocity;               // smoothing the player turning speed

    public Transform cam;          // to travel the player in the direction that the camera is facing
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");        // getting axis for the user input values for horizontal direction (A, D)
        float vertical = Input.GetAxisRaw("Vertical");            // getting axis for the user input values for vertical direction (W, S)

        Vector3 direction = new Vector3(horizontal, 0f , vertical).normalized;   //Unity to pass 3D positions and directions around


        if (direction.magnitude >= 0.1f)
        {

             // using a mathematical function to face the player in his direction and Atan2 returns the angle in radians
            float targetAngle = Mathf.Atan2(direction.x, direction.z)* Mathf.Rad2Deg + cam.eulerAngles.y;  

            //smoothing the player rotations
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            //setting the rotations
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //this give us the direction we want to move in  where camera roatates
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;


            controller.Move(moveDir.normalized * speed * Time.deltaTime);    // move towards x and z direction at a constant speed
        }



    }
}
