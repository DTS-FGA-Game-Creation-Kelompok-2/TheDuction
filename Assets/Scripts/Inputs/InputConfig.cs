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
            OnInput?.Invoke(Direction());
        }

        private Vector3 Direction()
        {
            if (Input.GetKey(_inputManager.UpKey))
            {
                return Vector3.forward;
            }
            if (Input.GetKey(_inputManager.DownKey))
            {
                return Vector3.back;
            }
            if (Input.GetKey(_inputManager.LeftKey))
            {
                return Vector3.left;
            }
            if (Input.GetKey(_inputManager.RightKey))
            {
                return Vector3.right;
            }

            return Vector3.zero;
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

