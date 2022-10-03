using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuction.Inputs
{
    [System.Serializable]
    public struct InputManager
    {
        [SerializeField] private KeyCode _upKey;
        [SerializeField] private KeyCode _downKey;
        [SerializeField] private KeyCode _leftKey;
        [SerializeField] private KeyCode _rightKey;
        [SerializeField] private KeyCode _interactKey;
    
        public KeyCode UpKey => _upKey;
        public KeyCode DownKey => _downKey;
        public KeyCode LeftKey => _leftKey;
        public KeyCode RightKey => _rightKey;
        public KeyCode InteractKey => _interactKey;
    }
}

