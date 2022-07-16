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
        private Camera _camera;
        private float _xRotation;
        private float _currentXRotation;
        private float _yRotation;
        private float _currentYRotation;
        private IPlayerView _playerView;
        private float _sensitivity;

        public CameraController(IPlayerView playerView, float sensitivity)
        {
            _camera = Camera.main;
            _playerView = playerView;
            _sensitivity = sensitivity;
        }


        public void Execute(float deltaTime)
        {
            _xRotation += Input.GetAxis(MouseX) * _sensitivity;
            _yRotation += Input.GetAxis(MouseY) * _sensitivity;
            _yRotation = Mathf.Clamp(_yRotation, MinClamp, MaxClamp);
            _camera.transform.rotation = Quaternion.Euler(-_yRotation, _xRotation, 0);
            _playerView.PlayerObject.transform.localRotation = Quaternion.Euler(0f, _xRotation, 0f);
        }
    }
}