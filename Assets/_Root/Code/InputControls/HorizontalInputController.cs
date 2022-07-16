using _Root.Code.Interfaces;
using UnityEngine;

namespace _Root.Code.InputControls
{
    public class HorizontalInputController : IInputController
    {
        private float _horizontalInput;
        public float GetInput()
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            return _horizontalInput;
        }
    }
}