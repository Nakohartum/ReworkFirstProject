using _Root.Code.Interfaces;
using UnityEngine;

namespace _Root.Code.InputControls
{
    public class VerticalInputController : IInputController
    {
        private float _verticalInput;


        public float GetInput()
        {
            _verticalInput = Input.GetAxis("Vertical");
            return _verticalInput;
        }
    }
}