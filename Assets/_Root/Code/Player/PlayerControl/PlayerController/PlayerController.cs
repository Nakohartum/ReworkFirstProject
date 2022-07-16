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
    private bool _isJumping;

    public PlayerController(PlayerModel playerModel, IPlayerView playerView, InputController inputController, CameraController cameraController)
    {
        _playerModel = playerModel;
        _playerView = playerView;
        _inputController = inputController;
        _cameraController = cameraController;
        inputController.HorizontalInputController.OnAxisChange += HorizontalValueChange;
        inputController.VerticalInputController.OnAxisChange += VerticalValueChange;
        inputController.JumpController.OnAxisChange += JumpValueChange;
    }

    private void JumpValueChange(float obj)
    {
        var localPos = _playerView.PlayerObject.transform.localPosition;
        var startRay = new Vector3(localPos.x, localPos.y + 1, localPos.z);
        Ray ray = new Ray(startRay, Vector3.down);
        var canJump = Physics.Raycast(ray, out var hit, 1f);
        _isJumping = obj > 0 && canJump ? true : false;
    }

    private void VerticalValueChange(float obj)
    {
        _vertivalValue = obj;
    }

    private void HorizontalValueChange(float obj)
    {
        _horizontalValue = obj;
    }

    public void Execute(float deltaTime)
    {
        _inputController.Execute(deltaTime);
        _cameraController.Execute(deltaTime);
        if (_isJumping)
        {
            _playerView.Rigidbody.AddRelativeForce(Vector3.up * _playerModel.JumpPower);
        }
        if (_playerView.Rigidbody.velocity.magnitude > _playerModel.MovingSpeed)
        {
            return;
        }
        _playerView.Rigidbody.AddRelativeForce(new Vector3(_horizontalValue * _playerModel.MovingSpeed, 0, _vertivalValue * _playerModel.MovingSpeed));
    }

    public IHealth GetHealth()
    {
        return _playerModel.Health;
    }
}
