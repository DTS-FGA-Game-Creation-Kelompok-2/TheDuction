namespace TheDuction.Interaction{
    public class ClueInteractable : Interactable {
        public delegate void ItemAction(ClueData clueData);
        public static event ItemAction OnItemInteracted;

        public override void Interact()
        {
            base.Interact();
            OnItemInteracted?.Invoke(Data as ClueData);
            // TODO: Set active false after dialogue
            // gameObject.SetActive(false);
        }
    }
}