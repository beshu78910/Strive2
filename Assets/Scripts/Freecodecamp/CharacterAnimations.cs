using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void NormalWalk(bool normalWalk)
    {
        anim.SetBool(AnimationTags.NORMALWALK_PARAMETER,normalWalk);
        
    }
    public void Blocking(bool blocking)
    {
        anim.SetBool(AnimationTags.BLOCKING_PARAMETER,blocking);
    }
    public void LeadJab()
    {
        anim.SetTrigger(AnimationTags.LEADJAB_TRIGGER);
        print("dsd");
    }
    public void BodyJab()
    {
        anim.SetTrigger(AnimationTags.BODYJAB_TRIGGER);
    }

    public void QuadPunch(bool quadpunch)
    {
        anim.SetBool(AnimationTags.QUADPUNCH_TRIGGER,quadpunch);
    }

    public void ElbowUp()
    {
        anim.SetTrigger(AnimationTags.ELBOWUP_TRIGGER);
    }

    public void HookUp()
    {
        anim.SetTrigger(AnimationTags.HOOKUP_TRIGGER);
    }

    public void LegalKnee()
    {
        anim.SetTrigger(AnimationTags.LEGALKNEE_TRIGGER);
    }

    public void LowKick()
    {
        anim.SetTrigger(AnimationTags.LOWKICK_TRIGGER);
    }

    public void RoundHouse()
    {
        anim.SetTrigger(AnimationTags.ROUNDHOUSE_TRIGGER);
    }
    void Update()
    {
        
    }
}
