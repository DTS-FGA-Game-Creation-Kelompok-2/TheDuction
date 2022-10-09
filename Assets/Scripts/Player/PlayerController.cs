using System;
using System.Collections;
using System.Collections.Generic;
using TheDuction.Inputs;
using TheDuction.Interaction;
using UnityEngine;

namespace TheDuction.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        private Rigidbody _rb;
        
        private void OnEnable()
        {
            InputConfig.OnInput += Move;
        }

        private void OnDisable()
        {
            InputConfig.OnInput -= Move;
        }

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Move(Vector3 dir)
        {
            _rb.velocity = dir * _moveSpeed;
        }
    }
}

