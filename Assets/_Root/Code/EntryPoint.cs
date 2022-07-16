using _Root.Code.InputControls;
using _Root.Code.Interfaces;
using _Root.Code.Player;
using Player.Settings.SettingsObjectsCode;
using UnityEngine;

namespace _Root.Code
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private UIController _controller;
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private GameSettings _gameSettings;
        private PlayerController _playerController;

        private void Start()
        {
            IHealth health = new Health.Health(_gameSettings.PlayerCharacteristics.MaxHealth, 
                _gameSettings.PlayerCharacteristics.CurrentHealth);
            PlayerModel playerModel = new PlayerModel(health, _gameSettings.PlayerCharacteristics.MovingSpeed,
                _gameSettings.PlayerCharacteristics.JumpPower);
            var inputController = new InputController();
            var cameraController = new CameraController(_playerView, 5f);
            _playerController = new PlayerController(playerModel, _playerView, inputController, cameraController);
            _controller.Init(health);
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _playerController.Execute(deltaTime);
        }
    }
}