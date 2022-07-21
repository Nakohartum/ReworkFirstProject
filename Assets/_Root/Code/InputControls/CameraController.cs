using _Root.Code.Interfaces;
using UnityEngine;

namespace _Root.Code.InputControls
{
    public class CameraController : IExecutable
    {
        private const string MouseX = "Mouse X";
        private const string MouseY = "Mouse Y";
        private const float MinClamp = -50;
        private const float MaxClamp = 50;
        private Transform _lookTransform;
        private float _xRotation;
        private float _currentXRotation;
        private float _yRotation;
        private float _currentYRotation;
        private IPlayerView _playerView;
        private float _sensitivity;

        public CameraController(IPlayerView playerView, Transform lookTransform, float sensitivity)
        {
            _lookTransform = lookTransform;
            _playerView = playerView;
            _sensitivity = sensitivity;
        }


        public void Execute(float deltaTime)
        {
            _xRotation += Input.GetAxis(MouseX) * _sensitivity;
            _yRotation += Input.GetAxis(MouseY) * _sensitivity;
            _yRotation = Mathf.Clamp(_yRotation, MinClamp, MaxClamp);
            _lookTransform.rotation = Quaternion.Euler(-_yRotation, _xRotation, 0);
            _playerView.PlayerObject.transform.localRotation = Quaternion.Euler(0f, _xRotation, 0f);
        }
    }
}