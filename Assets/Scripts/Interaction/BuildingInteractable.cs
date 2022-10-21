using System.Collections;
using TheDuction.Dialogue;
using UnityEngine;

namespace TheDuction.Interaction{
    [RequireComponent(typeof(BoxCollider))]
    public class BuildingInteractable : Interactable {
        private void Awake() {
            Particle = GetComponent<ParticleSystem>();
        }

        public override void Interact()
        {
            base.Interact();
            StartCoroutine(DeactivateObject());
        }

        private IEnumerator DeactivateObject(){
            yield return new WaitUntil(() => DialogueManager.Instance.CurrentDialogueState == DialogueState.Stop);

            Particle.Stop();
        } 
    }
}