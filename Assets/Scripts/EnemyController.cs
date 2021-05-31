using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState{
    CHASE,
    ATTACK
}

public class EnemyController : MonoBehaviour
{
    private CharacterAnimations enemy_Anim;

    private NavMeshAgent navAgent;
    private Transform playerTarget;
    public float move_Speed = 10f;
    public float attack_Distance = 10f;
    public float chase_Player_After_Attack_Distance = 10f;
    private float wait_Before_Attack_Time = 3f;
    private float attack_Timer;

    private EnemyState enemy_State;

    public GameObject attackPoint;

    void Awake()
    {
        enemy_Anim = GetComponent<CharacterAnimations>();
        navAgent = GetComponent<NavMeshAgent>();

        playerTarget = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        enemy_State = EnemyState.CHASE;

        attack_Timer = wait_Before_Attack_Time;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy_State == EnemyState.CHASE)
        {
            ChasePlayer();
        }

        if (enemy_State == EnemyState.ATTACK)
        {
            AttackPlayer();
        }
        
    }

    void ChasePlayer()
    {
        navAgent.SetDestination(playerTarget.position);
        navAgent.speed = move_Speed;

        if (navAgent.velocity.sqrMagnitude == 0)
        {
            enemy_Anim.NormalWalk(false);
        }
        else
        {
            enemy_Anim.NormalWalk(true);
        }

        if (Vector3.Distance(transform.position, playerTarget.position) <= attack_Distance)
        {
            enemy_State = EnemyState.ATTACK;
        }
    }

    void AttackPlayer()
    {
        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;
        
        enemy_Anim.NormalWalk(false);

        attack_Timer += Time.deltaTime;

        if (attack_Timer > wait_Before_Attack_Time)
        {
            
            enemy_Anim.RoundHouse();
            
            attack_Timer = 0f;
            
        } 
        

        
        if (Vector3.Distance(transform.position, playerTarget.position) >
            attack_Distance + chase_Player_After_Attack_Distance)
        {
            navAgent.isStopped = false;
            enemy_State = EnemyState.CHASE;
        }
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
    
}
