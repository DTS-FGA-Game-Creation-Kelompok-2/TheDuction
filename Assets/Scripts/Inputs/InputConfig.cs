using TheDuction.Interaction;
using UnityEngine;

namespace TheDuction.Inputs
{
    public class InputConfig : MonoBehaviour
    {
        [SerializeField] private InputManager _inputManager;
        
        public delegate void OnInputEvent(Vector3 input);
        public static event OnInputEvent OnInput;

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
        }

        private void OnTriggerStay(Collider other)
        {
            IInteractable interactable = other.GetComponent<IInteractable>();
            if (interactable != null && Input.GetKeyDown(_inputManager.InteractKey))
            {
                interactable.Interact();
            }
        }
    }
}

