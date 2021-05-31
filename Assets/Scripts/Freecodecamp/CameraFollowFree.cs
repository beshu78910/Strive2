using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    
    private Transform target;
    
    [SerializeField]
    private Vector3 offsetPos;
    
    
    // Start is called before the first frame update
     void Awake()
    {
        target = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
    }


    // Update is called once per frame
    // LateUpdate is happens after update
    private void Update()
    {
        
    }

    void LateUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        // transform refer to the transform object in this class
        // which is the camera 
        transform.position = target.TransformPoint(offsetPos);
        // we set the transform.rotation of the camera relative to the player position
        transform.rotation = target.rotation;
    }
    
} //class
