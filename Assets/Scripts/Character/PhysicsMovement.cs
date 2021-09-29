using System;
using UnityEngine;

namespace Movement
{
    public class PhysicsMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private SurfaceSlider _surfaceSlider;
        [SerializeField] private MouseInput _mouseInput;

        [SerializeField] private LevelProgress _levelProgress;
        
        [SerializeField] private float _speed;

        [SerializeField] private float _minimumLimitAmount;
        [SerializeField] private float _maximumLimitAmount;

        public bool IsMoving { get; private set; } = false;

        private void Update()
        {
            ClampMovementX();
            
            if(_levelProgress.LevelComplete == true || _levelProgress.LevelLoss == true) return;
            
            if (_mouseInput.MouseDown == true)
            {
                Move(new Vector3(_mouseInput.MoveFactorX, 0f, 0f));
                Move(Vector3.back);
                IsMoving = true;
            }
            else
            {
                IsMoving = false;
            }
        }

        private void Move(Vector3 direction)
        {
            Vector3 directionAlongSurface = _surfaceSlider.Project(direction.normalized);
            Vector3 offset = directionAlongSurface * _speed;
        
            _rigidbody.MovePosition(_rigidbody.position + offset * Time.deltaTime);
        }

        private void ClampMovementX()
        {
            float clampedPositionX = Mathf.Clamp(transform.position.x, _minimumLimitAmount, _maximumLimitAmount);
            transform.position = new Vector3(clampedPositionX, transform.position.y, transform.position.z);
        }
    }
}
