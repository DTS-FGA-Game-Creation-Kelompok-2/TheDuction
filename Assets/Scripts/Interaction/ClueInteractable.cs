using System.Collections;
using TheDuction.Dialogue;
using UnityEngine;

namespace TheDuction.Interaction{
    public class ClueInteractable : Interactable {
        private BoxCollider _collider;
        private ClueData _clueData;

        public delegate void ItemAction(ClueData clueData);
        public static event ItemAction OnItemInteracted;

        private void Awake() {
            Particle = GetComponent<ParticleSystem>();
            _collider = GetComponentInParent<BoxCollider>();
        }

        public override void Interact()
        {
            base.Interact();
            _clueData = Data as ClueData;
            OnItemInteracted?.Invoke(_clueData);
            // Set active false after dialogue
            StartCoroutine(DeactivateObject());
        }

        private IEnumerator DeactivateObject(){
            yield return new WaitUntil(() => DialogueManager.Instance.CurrentDialogueState == DialogueState.Stop);

            _collider.gameObject.SetActive(_clueData.KeepObjectAfterInteracting);
        } 
    }
}