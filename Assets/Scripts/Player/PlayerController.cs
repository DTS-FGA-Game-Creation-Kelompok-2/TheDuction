using TheDuction.Dialogue;
using TheDuction.Global;
using TheDuction.Inputs;
using UnityEngine;

namespace TheDuction.Player
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(InputConfig))]
    public class PlayerController : SingletonBaseClass<PlayerController>
    {
        [SerializeField] private float _moveSpeed = 10f;

        [SerializeField] private Animator _animator;
        private Transform _transform;
        private Rigidbody _rb;
        private bool _isWalking = false;

        private const string IS_WALKING_PARAMETER = "isMoving";

        private void OnEnable()
        {
            InputConfig.OnInput += Move;
        }

        private void OnDisable()
        {
            InputConfig.OnInput -= Move;
        }

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _transform = GetComponent<Transform>();
        }

        private void Update()
        {
            if(_animator)
                _animator.SetBool(IS_WALKING_PARAMETER, _isWalking);
        }

        private void Move(Vector3 dir)
        {
            if(DialogueManager.Instance.CurrentDialogueState == DialogueState.Running) return;

            if(dir == Vector3.zero)
            {
                _isWalking = false;
                return;
            }
            
            Vector3 movement = new Vector3(dir.x, 0, dir.z).normalized;
            Quaternion rotation = Quaternion.LookRotation(movement);
            
            rotation = Quaternion.RotateTowards(transform.rotation, rotation, 360 * Time.deltaTime);

            _rb.velocity = movement * _moveSpeed;
            _rb.MoveRotation(rotation);
            _isWalking = true;
        }
    }
}

