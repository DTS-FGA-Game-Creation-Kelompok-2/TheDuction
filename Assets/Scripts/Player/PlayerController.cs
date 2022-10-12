using TheDuction.Inputs;
using UnityEngine;

namespace TheDuction.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 10f;

        [SerializeField] private Animator _animator;
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
        }

        private void Update(){
            Debug.Log(_rb.velocity);
            Debug.Log("X = " + Mathf.Approximately(_rb.velocity.x, 0.0f));
            Debug.Log("Z = " + (_rb.velocity.z == 0.0f));
            if(_rb.velocity.x == 0.0f && _rb.velocity.z == 0.0f){
                _isWalking = false;
            }
            _animator.SetBool(IS_WALKING_PARAMETER, _isWalking);
        }

        private void Move(Vector3 dir)
        {
            Vector3 movement = new Vector3(dir.x, 0, dir.z).normalized;
            Quaternion rotation = Quaternion.LookRotation(movement);

            _rb.velocity = movement * _moveSpeed;
            _rb.MoveRotation(rotation);
            _isWalking = true;
        }
    }
}

