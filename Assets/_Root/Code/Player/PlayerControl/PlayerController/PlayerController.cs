using System.Collections;
using System.Collections.Generic;
using _Root.Code.InputControls;
using _Root.Code.Interfaces;
using UnityEngine;

public class PlayerController : IExecutable
{
    private PlayerModel _playerModel;
    private IPlayerView _playerView;
    private InputController _inputController;
    private float _horizontalValue;
    private float _vertivalValue;
    private CameraController _cameraController;

    public PlayerController(PlayerModel playerModel, IPlayerView playerView, InputController inputController, CameraController cameraController)
    {
        _playerModel = playerModel;
        _playerView = playerView;
        _inputController = inputController;
        _cameraController = cameraController;
    }
    public void Execute(float deltaTime)
    {
        _inputController.Execute(deltaTime);
        _cameraController.Execute(deltaTime);
        _horizontalValue = _inputController.HorizontalInput;
        _vertivalValue = _inputController.VerticalInput;
        if (_inputController.JumpInput)
        {
            _playerView.Rigidbody.AddForce(Vector3.up * _playerModel.JumpPower);
        }
        if (_playerView.Rigidbody.velocity.magnitude > _playerModel.MovingSpeed)
        {
            return;
        }
        _playerView.Rigidbody.AddRelativeForce(new Vector3(_horizontalValue * _playerModel.MovingSpeed, 0, _vertivalValue * _playerModel.MovingSpeed));
    }
}
