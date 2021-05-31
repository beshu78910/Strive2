using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerMoverment : MonoBehaviour
{
    [SerializeField] private float speed = 6f;

    [SerializeField]  LayerMask aimLayerMask;

    private Animator animator;
    private float m_MySliderValue;
    // public CharacterController controller;
    public Transform cam;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update

    

    // Update is called once per frame
    void Update()
    {
        AimTowardMouse();
        
        // Reading the Input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        

        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;

        if (movement.magnitude >= 0.1f)
        {
            movement.Normalize();
            movement *= speed * Time.deltaTime;
            transform.Translate(movement, Space.World);
        }

        float velocityZ = Vector3.Dot(movement.normalized, transform.forward);
        float velocityX = Vector3.Dot(movement.normalized, transform.right);
        
        animator.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime);
        animator.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);
    


    }

    void AimTowardMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, aimLayerMask))
        {
            var direction = hitInfo.point - transform.position;
            direction.y = 0f;
            direction.Normalize();
            transform.forward = direction;
        }
    }


    
    
}
