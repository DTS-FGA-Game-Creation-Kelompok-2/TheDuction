using UnityEngine;

namespace TheDuction.Interaction{
    [RequireComponent(typeof(BoxCollider))]
    public class BuildingInteractable : Interactable {
        private void Awake() {
            Particle = GetComponent<ParticleSystem>();
        }
    }
}