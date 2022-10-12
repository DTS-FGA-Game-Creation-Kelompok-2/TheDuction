using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCharaAnim : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    private void Update()
    {
        _animator.SetBool("isMoving", false);
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            _animator.SetBool("isMoving", true);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            _animator.SetTrigger("Talk");
        }
    }
}
