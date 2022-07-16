using _Root.Code.InputControls;
using _Root.Code.Interfaces;
using Player.Settings.SettingsObjectsCode;
using UnityEngine;

namespace _Root.Code.Player
{
    public class PlayerFactory : IPlayerFactory
    {
        private PlayerCharacteristics _playerCharacteristics;

        public PlayerFactory(PlayerCharacteristics playerCharacteristics)
        {
            _playerCharacteristics = playerCharacteristics;
        }
        
        public PlayerController Create()
        {
            IHealth health = new Health.Health(_playerCharacteristics.MaxHealth, 
                _playerCharacteristics.CurrentHealth);
            PlayerModel playerModel = new PlayerModel(health, _playerCharacteristics.MovingSpeed,
                _playerCharacteristics.JumpPower);
            IPlayerView playerView = Object.Instantiate(_playerCharacteristics.SpawnObject,
                _playerCharacteristics.SpawnPosition, Quaternion.identity).GetComponent<IPlayerView>();
            var inputController = new InputController();
            var cameraController = new CameraController(playerView, 5f);
            var playerController = new PlayerController(playerModel, playerView, inputController, cameraController);
            return playerController;
        }

        
    }
}