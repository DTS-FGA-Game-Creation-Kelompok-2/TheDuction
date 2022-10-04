using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuction.Inputs
{
    public class InputConfig : MonoBehaviour
    {
        [SerializeField] private InputManager _inputManager;
        
        public delegate void OnInputEvent(Vector3 input);
        public delegate void OnInteractEvent();
        public static event OnInputEvent OnInput;
        public static event OnInteractEvent OnInteract;

        private void Update()
        {
            if (Input.GetKey(_inputManager.UpKey))
            {
                OnInput?.Invoke(Vector3.forward);
            }
            if (Input.GetKey(_inputManager.DownKey))
            {
                OnInput?.Invoke(Vector3.back);
            }
            if (Input.GetKey(_inputManager.LeftKey))
            {
                OnInput?.Invoke(Vector3.left);
            }
            if (Input.GetKey(_inputManager.RightKey))
            {
                OnInput?.Invoke(Vector3.right);
            }
            if(Input.GetKey(_inputManager.InteractKey))
            {
                OnInteract?.Invoke();
            }
        }
    }
}

