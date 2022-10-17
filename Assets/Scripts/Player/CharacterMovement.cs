using TheDuction.Global.Attributes;
using UnityEngine;
using UnityEngine.AI;

namespace TheDuction.Player{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]
    public class CharacterMovement : MonoBehaviour {
        [SerializeField] private bool _isCharacterWalking = false;
        
        [Header("Walking")]
        [DrawIf("_isCharacterWalking", true)]
        [SerializeField] private float _moveSpeed = 10f;
        [DrawIf("_isCharacterWalking", true)]
        [SerializeField] private Animator _animator;
        private NavMeshAgent _navAgent;
        private bool _isWalking = false, _isWalkingExist = false;
        private const string IS_WALKING_PARAMETER = "isMoving";

        public bool IsWalking => _isWalking;

        private void Start() {
            if(!_isCharacterWalking) return;
            
            _navAgent = GetComponent<NavMeshAgent>();

            _navAgent.updateRotation = false;
            _navAgent.speed = _moveSpeed;

            // Check is walking parameter
            foreach(AnimatorControllerParameter param in _animator.parameters){
                if(IS_WALKING_PARAMETER == param.name){
                    _isWalkingExist = true;
                } else{
                    _isWalkingExist = false;
                }
            }
        }

        private void Update() {
            if(!_isCharacterWalking) return;

            _isWalking = !(_navAgent.remainingDistance <= _navAgent.stoppingDistance);

            if(_isWalkingExist){
                _animator.SetBool(IS_WALKING_PARAMETER, _isWalking);
            }
        }

        /// <summary>
        /// Move by teleporting
        /// </summary>
        /// <param name="targetTransform"></param>
        public void Move(Transform targetTransform){
            transform.SetPositionAndRotation(targetTransform.position, targetTransform.rotation);
        }

        /// <summary>
        /// Move by walking
        /// </summary>
        /// <param name="targetPosition"></param>
        public void Move(Vector3 targetPosition){
            _navAgent.SetDestination(targetPosition);
        }
    }
}