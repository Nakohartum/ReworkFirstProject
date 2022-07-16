using _Root.Code.Interfaces;
using UnityEngine;

namespace _Root.Code.InputControls
{
    public class JumpController : IInputController
    {
        private float _jumpPower;
        public float GetInput()
        {
            _jumpPower = Input.GetAxis("Jump");
            return _jumpPower;
        }
    }
}