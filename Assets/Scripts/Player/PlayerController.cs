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
        private Vector3 _horizontal;
        private Vector3 _vertical;
        
        private void OnEnable()
        {
            InputConfig.OnInput += Move;
            InputConfig.OnInteract += Interact;
        }

        private void OnDisable()
        {
            InputConfig.OnInput -= Move;
            InputConfig.OnInteract -= Interact;
        }

        private void Start()
        {
            _vertical = Camera.main.transform.forward;
            _vertical.y = 0;
            _vertical = Vector3.Normalize(_vertical);
            _horizontal = Quaternion.Euler(0, 90, 0) * _vertical;
        }

        private void Move(Vector3 direction)
        {
            Vector3 horizontalMove = _horizontal * _moveSpeed * Time.deltaTime * direction.x;
            Vector3 verticalMove = _vertical * _moveSpeed * Time.deltaTime * direction.z;
            Vector3 heading = Vector3.Normalize(horizontalMove + verticalMove);
            transform.forward = heading;
            transform.position += horizontalMove;
            transform.position += verticalMove;
        }

        private void Interact()
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10f))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable == null)
                {
                    return;
                }
                interactable.Interact();
            }
        }
    }
}

