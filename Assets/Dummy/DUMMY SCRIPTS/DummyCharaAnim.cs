using System;
using System.Collections;
using System.Collections.Generic;
using TheDuction.Animations;
using UnityEngine;

public class DummyCharaAnim : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public bool isMoving = false;
    public bool isTalking = false;
    
    private void Update()
    {
        BaseAnimation idleAnimate = new IdleAnim();
        idleAnimate.PlayAnim(_animator);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            BaseAnimation anim = new MoveAnim();
            anim.PlayAnim(_animator);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            BaseAnimation anim = new TalkAnim();
            anim.PlayAnim(_animator);
        }
        
        _animator.SetBool("isMoving", isMoving);
        _animator.SetBool("isTalking", isTalking);
    }
}
