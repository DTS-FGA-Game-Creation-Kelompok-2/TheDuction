using TheDuction.Dialogue;
using UnityEngine;

namespace TheDuction.Interaction{
    public enum InteractableMode{ DialogueMode, NormalMode }

    public class Interactable : MonoBehaviour, IInteractable
    {
        [SerializeField] private InteractableData _data;
        [SerializeField] private InteractableMode _mode = InteractableMode.NormalMode;
        [SerializeField] private TextAsset _currentDialogue;

        public InteractableData Data => _data;

        public InteractableMode Mode{
            set{ _mode = value; }
            get { return _mode; }
        }

        public TextAsset CurrentDialogue{
            set{ _currentDialogue = value; }
            get { return _currentDialogue; }
        }
        
        public virtual void Interact()
        {
            switch(_mode){
                case InteractableMode.DialogueMode:
                    HandleDialogue();
                    break;
                case InteractableMode.NormalMode:
                    break;
                default:
                    Debug.LogError("Item mode belum dimasukkan ke dalam switch case");
                    break;
            }
        }

        private void HandleDialogue()
        {
            if(_currentDialogue)
                DialogueManager.Instance.SetDialogue(_currentDialogue);
        }
    }
}