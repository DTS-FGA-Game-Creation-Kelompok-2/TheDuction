using UnityEngine;

namespace TheDuction.Interaction{
    public class ClueInteractable : Interactable {
        private BoxCollider _collider;
        private ParticleSystem _particle;

        public ParticleSystem Particle => _particle;

        public delegate void ItemAction(ClueData clueData);
        public static event ItemAction OnItemInteracted;

        private void Awake() {
            _particle = GetComponent<ParticleSystem>();
            _collider = GetComponentInParent<BoxCollider>();
        }

        public override void Interact()
        {
            base.Interact();
            ClueData data = Data as ClueData;
            OnItemInteracted?.Invoke(data);
            // Set active false after dialogue
            _collider.gameObject.SetActive(data.KeepObjectAfterInteracting);
        }
    }
}