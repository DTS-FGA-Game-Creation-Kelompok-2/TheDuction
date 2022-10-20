using TheDuction.Player;
using UnityEngine;
using UnityEngine.UI;

namespace TheDuction.Event.MovementEvent{
    public class MovementEventController: EventController{
        [SerializeField] private CharacterMovement _targetCharacter;
        [SerializeField] private Transform _targetTransform;

        public Image BlackScreen;
        public CharacterMovement TargetCharacter => _targetCharacter;
        public Transform TargetTransform => _targetTransform;
    }
}