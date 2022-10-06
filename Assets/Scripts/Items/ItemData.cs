using TheDuction.Dialogue;
using UnityEngine;

namespace TheDuction.Items{
    public class ItemData: MonoBehaviour{
        public enum ItemMode{ DialogueMode, NormalMode }

        public ItemMode itemMode = ItemMode.NormalMode;
        public TextAsset currentDialogue;

        public virtual void HandleInteraction(){
            switch(itemMode){
                case ItemMode.DialogueMode:
                    HandleDialogue();
                    break;
                case ItemMode.NormalMode:
                    break;
                default:
                    Debug.LogError("Item mode belum dimasukkan ke dalam switch case");
                    break;
            }
        }

        protected virtual void HandleDialogue(){
            if(currentDialogue)
                DialogueManager.Instance.SetDialogue(currentDialogue);
        }
    }
}