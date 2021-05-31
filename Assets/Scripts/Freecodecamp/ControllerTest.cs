using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ControllerTest : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController char_Controller;
    private CharacterAnimations playerAnimations;

    public float movement_Speed = 5f;
    public float gravity = 9.8f;
    public float rotantion_Speed = 0.15f;
    public float rotateDegreesPerSecond = 180f;
    public bool canMove = true;

    // 1st function that is called
    void Awake()
    {
        char_Controller = GetComponent<CharacterController>();
        playerAnimations = GetComponent<CharacterAnimations>();
    }
    
    // 2nd Function that is called

    void Move()
    {
        if (Input.GetAxis(Axis.VERTICAL_AXIS) > 0)
        {
            Vector3 moveDirection = transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;
            char_Controller.Move(moveDirection * movement_Speed * Time.deltaTime);

        } else if (Input.GetAxis(Axis.VERTICAL_AXIS) < 0)
        {
            Vector3 moveDirection = -transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;
            char_Controller.Move(moveDirection * movement_Speed * Time.deltaTime);
            
        }
        else 
        {
            char_Controller.Move(Vector3.zero);
        }
    }

    void Rotate()
    {
        Vector3 rotation_Direction = Vector3.zero;

        if (Input.GetAxis(Axis.HORIZONTAL_AXIS) < 0)
        {
            rotation_Direction = transform.TransformDirection(Vector3.left);
        } 
        if (Input.GetAxis(Axis.HORIZONTAL_AXIS) > 0)
        {
            rotation_Direction = transform.TransformDirection(Vector3.right);
        }

        if (rotation_Direction != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, Quaternion.LookRotation(rotation_Direction),
                rotateDegreesPerSecond * Time.deltaTime);
        }
    }
    
    void Start()
    {
        
    }

    void AnimateWalk()
    
    {
        // if we are moving convert value to 1 by using sqrMaginute 
        // => != 0 
        if (char_Controller.velocity.sqrMagnitude != 0)
        {
            
            playerAnimations.NormalWalk(true);
        }

        // if (char_Controller.velocity.sqrMagnitude < 0)
        // {
        //     playerAnimations.Walk(true);
        // }
        else
        {
            playerAnimations.NormalWalk(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        AnimateWalk();
    }
}
