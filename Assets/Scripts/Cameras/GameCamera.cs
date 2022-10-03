using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuction.Cameras
{
    public class GameCamera : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        [SerializeField] private Transform _target;
        [SerializeField] private float _minX, _maxX, _minZ, _maxZ;

        private void LateUpdate()
        {
            Vector3 desiredPosition = _target.position + _offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.5f);
            transform.position = smoothedPosition;
        
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, _minX, _maxX), 
                transform.position.y, Mathf.Clamp(transform.position.z, _minZ, _maxZ));
        }
    }
}

