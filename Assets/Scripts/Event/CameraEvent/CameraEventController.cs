using Cinemachine;
using TheDuction.Global.Attributes;
using UnityEngine;
using UnityEngine.Playables;

namespace TheDuction.Event.CameraEvent{
    public class CameraEventController : EventController {
        [Header("Virtual Camera")]
        [SerializeField] private CinemachineVirtualCamera _targetVirtualCamera;
        [SerializeField] private PlayableDirector _cutsceneTimeline;

        [Header("Target")]
        [SerializeField] private bool _useTarget;
        [DrawIf("useTarget", true)]
        // [SerializeField] private NavigationMovement _targetCharacter;
        [DrawIf("useTarget", true)]
        [SerializeField] private Transform _targetPosition;
        [DrawIf("useTarget", true)]
        [SerializeField] private Transform _lookAtTarget;

        public CinemachineVirtualCamera TargetVirtualCamera => _targetVirtualCamera;
        public PlayableDirector CutsceneTimeline => _cutsceneTimeline;
        // public NavigationMovement TargetCharacter => _targetCharacter;
        public Transform TargetPosition => _targetPosition;
        public Transform LookAtTarget => _lookAtTarget;
        public bool UseTarget => _useTarget;

        private void Start() {
            SetFinishCondition();
        }
    }
}