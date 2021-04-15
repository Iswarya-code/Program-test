using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public CharacterController controller;
   
    public float speed = 6f;
    // public Vector3(float x, float y, float z);

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

         Vector3 direction = new Vector3(horizontal, 0f , vertical).normalized;
        //Vector3 direction = new Vector3(0, 0, 0);

        if(direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }



    }
}
