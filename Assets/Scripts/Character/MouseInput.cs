using System;
using UnityEngine;

namespace Movement
{
    public class MouseInput : MonoBehaviour
    {
        [SerializeField] private PhysicsMovement _movement;

        private float _lastFrameMousePositionX;
        private float _moveFactorX;
        private bool _mouseDown;
        
        public float MoveFactorX => _moveFactorX;

        public bool MouseDown => _mouseDown;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _lastFrameMousePositionX = Input.mousePosition.x;
                _mouseDown = true;
            }
            else if (Input.GetMouseButton(0))
            {
                _moveFactorX = Input.mousePosition.x - _lastFrameMousePositionX;
                _lastFrameMousePositionX = Input.mousePosition.x;
                _mouseDown = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _moveFactorX = 0;
                _mouseDown = false;
            }
        }
    }
}
