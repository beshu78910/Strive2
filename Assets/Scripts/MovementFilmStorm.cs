using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFilmStorm : MonoBehaviour
{
    // Start is called before the first frame update
    public float InputX;
    public float InputZ;
    public Vector3 desiredMoveDirection;
    public bool blockRotationPlayer;
    public float desiredRotationSpeed;
    public Animator anim;
    public float Speed;
    public float allowPlayerRotation;
    public CharacterController controller;
    public bool isGrounded;
    private float verticalVel;
    private Vector3 moveVector;
    public Camera cam;
    
    void Start()
    {
        anim = this.GetComponent<Animator>();
        cam = Camera.main;
        controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        InputMagnitude();

        isGrounded = controller.isGrounded;
        if (isGrounded)
        {
            verticalVel -= 0;
        }
        else
        {
            verticalVel -= 2;
        }

        moveVector = new Vector3(InputX, verticalVel, InputZ);
        controller.Move(moveVector);
    }

    void PlayerMoveAndRotation()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");
        var camera = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        desiredMoveDirection = forward * InputZ + right * InputX;

        if (blockRotationPlayer == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
           

        }
    }

    void InputMagnitude()
    {
        //Calculate Input Vectors
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");
        
        anim.SetFloat("InputX", InputZ, 0.0f, Time.deltaTime * 2f);
        anim.SetFloat("InputZ", InputZ, 0.0f, Time.deltaTime * 2f);
        
        //Calculate the Input Magnitude
        Speed = new Vector2(InputX, InputZ).sqrMagnitude;
        
        //Phyically move player
        if (Speed > allowPlayerRotation)
        {
            anim.SetFloat("InputMagnitude", Speed, 0.0f, Time.deltaTime);
            PlayerMoveAndRotation();
        } else if (Speed < allowPlayerRotation)
        {
            anim.SetFloat("InputMagnitude", Speed, 0.0f, Time.deltaTime);
        }
    }
}
