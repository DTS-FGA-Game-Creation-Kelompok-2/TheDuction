using TheDuction.Inputs;
using UnityEngine;

namespace TheDuction.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        private Rigidbody _rb;
        
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

        private void Move(Vector3 dir)
        {
            Vector3 movement = new Vector3(dir.x, 0, dir.z).normalized;
            Quaternion rotation = Quaternion.LookRotation(movement);

            _rb.velocity = movement * _moveSpeed;
            _rb.MoveRotation(rotation);
        }
    }
}

