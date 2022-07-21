using System;
using _Root.Code.InputControls;
using _Root.Code.Interfaces;
using UnityEngine;

namespace _Root.Code.Player.PlayerControl.PlayerController
{
    public class PlayerController : IExecutable
    {
        private PlayerModel _playerModel;
        private IPlayerView _playerView;
        private InputController _inputController;
        private float _horizontalValue;
        private float _verticalValue;
        private CameraController _cameraController;
        private PhysicsMover _physicsMover;
        private Jumper _jumper;
        private Transform _lookDirection;
        private bool _isJumping;
        private Executables _executables;


        public PlayerController(PlayerModel playerModel, IPlayerView playerView, InputController inputController, 
            CameraController cameraController, Transform lookDirection, PhysicsMover physicsMover, Jumper jumper, Executables executables)
        {
            _playerModel = playerModel;
            _playerView = playerView;
            _inputController = inputController;
            _cameraController = cameraController;
            _lookDirection = lookDirection;
            _physicsMover = physicsMover;
            _jumper = jumper;
            _executables = executables;
            _playerView.OnPlayerDie += ControllerDestroyes;
            inputController.HorizontalInputController.OnAxisChange += HorizontalValueChange;
            inputController.VerticalInputController.OnAxisChange += VerticalValueChange;
        }

        private void VerticalValueChange(float obj)
        {
            _verticalValue = obj;
        }

        private void HorizontalValueChange(float obj)
        {
            _horizontalValue = obj;
        }

        public void Execute(float deltaTime)
        {
            _inputController.Execute(deltaTime);
            _cameraController.Execute(deltaTime);
            var movement = new Vector3(_horizontalValue, 0, _verticalValue) * deltaTime;
            _physicsMover.Move(movement, _lookDirection.forward);
            if (Input.GetButtonDown("Jump"))
            {
                _jumper.Jump(_playerView.PlayerObject.transform, _playerModel.JumpPower);
            }
        }

        public IHealth GetHealth()
        {
            return _playerModel.Health;
        }

        public void ControllerDestroyes()
        {
            _executables.RemoveFromExecutables(this);
        }
    }
}