using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAttackInput : MonoBehaviour
{
    private CharacterAnimations playerAnimation;

    public GameObject attackPoint;
    public GameObject attackPoint2; //AFR
    public GameObject attackPoint3; //AML
    public GameObject attackPoint4; //AMR
    public GameObject attackPoint5; //FLR
    public GameObject attackPoint6; //FMR
    
    
    
    private CharacterController mainPlayer;
    private Animator anim;
    private Vector3 moveVector;
    private float verticalVel;
   
    private float horizontal; 
    private float vertical;
    private Rigidbody m_Rigidbody;
    private void Awake()
    {
        playerAnimation = GetComponent<CharacterAnimations>();
        mainPlayer = GetComponent<CharacterController>();
       
    }

    void Update()
    {
      
        
       
        // Detect only when GetKeyDown
        if (Input.GetKeyDown(KeyCode.H))
        {
            
            playerAnimation.Blocking(true);
           
           
        }
        // Detect when the key it release
        if (Input.GetKeyUp(KeyCode.H))
        {
            playerAnimation.Blocking(false);
            
            
           
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            // Integer last number does not return
            // Float will include last number also
          playerAnimation.LeadJab();
          print("Jab");
          
          anim.SetBool("isAttacking", true);


        }

        if (Input.GetKey(KeyCode.O))
        {
            if (Input.GetKeyUp(KeyCode.I))
            {
                playerAnimation.ElbowUp();
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            playerAnimation.BodyJab();
            anim.SetBool("isAttacking", true);
            
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            playerAnimation.QuadPunch(true);
        
            
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
           playerAnimation.QuadPunch(false);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            playerAnimation.HookUp();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            playerAnimation.LegalKnee();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            playerAnimation.LowKick();
        }

        // if (Input.GetKeyUp(KeyCode.I) && Input.GetKeyUp(KeyCode.K))
        // {
        //     anim.SetBool("isAttacking", false);
        // }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Activate_AttackPoint()
    {
        attackPoint.SetActive(true);
    }

    void Deactivate_AttackPoint()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
            
    }
    //AFR
    void Activate_AttackPoint2()
    {
        attackPoint2.SetActive(true);
    }
  
    void Deactivate_AttackPoint2()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint2.SetActive(false);
        }
            
    }
    //AML
    void Activate_AttackPoint3()
    {
        attackPoint3.SetActive(true);
    }
    void Deactivate_AttackPoint3()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint3.SetActive(false);
        }
            
    }
    //AMR
    void Activate_AttackPoint4()
    {
        attackPoint4.SetActive(true);
    }
    void Deactivate_AttackPoint4()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint4.SetActive(false);
        }
            
    }
    //FLR
    void Activate_AttackPoint5()
    {
        attackPoint5.SetActive(true);
    }
    void Deactivate_AttackPoint5()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint5.SetActive(false);
        }
            
    }//FMR
    void Activate_AttackPoint6()
    {
        attackPoint6.SetActive(true);
    }
    void Deactivate_AttackPoint6()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint6.SetActive(false);
        }
            
    }

    
 
}
