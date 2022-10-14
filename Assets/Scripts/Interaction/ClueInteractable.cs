using UnityEngine;

namespace TheDuction.Interaction{
    public class ClueInteractable : Interactable {
        [SerializeField] private ClueData _clueData;
        public delegate void ItemAction(ClueData clueData);
        public static event ItemAction OnItemInteracted;

        public override void Interact()
        {
            base.Interact();
            OnItemInteracted?.Invoke(_clueData);
            // TODO: Set active false after dialogue
            // gameObject.SetActive(false);
        }
    }
}