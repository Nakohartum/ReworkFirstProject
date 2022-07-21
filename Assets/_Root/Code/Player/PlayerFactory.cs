using _Root.Code.InputControls;
using _Root.Code.Interfaces;
using _Root.Code.Player.PlayerControl;
using _Root.Code.Player.PlayerControl.PlayerController;
using Player.Settings.SettingsObjectsCode;
using UnityEngine;

namespace _Root.Code.Player
{
    public class PlayerFactory : IPlayerFactory
    {
        private PlayerCharacteristics _playerCharacteristics;
        private Executables _executables;

        public PlayerFactory(PlayerCharacteristics playerCharacteristics, Executables executables)
        {
            _playerCharacteristics = playerCharacteristics;
            _executables = executables;
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
            var transform = playerView.Eyes.transform;
            var cameraController = new CameraController(playerView, transform, 5f);
            var physicsMover = new PhysicsMover(playerView.Rigidbody, playerModel.MovingSpeed);
            var jumper = new Jumper(playerView.Rigidbody);
            var playerController = new PlayerController(playerModel, playerView, inputController, cameraController,
                transform, physicsMover, jumper, _executables);
            return playerController;
        }

        
    }
}