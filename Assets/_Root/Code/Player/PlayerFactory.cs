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
        private Health.Health _health;

        public PlayerFactory(PlayerCharacteristics playerCharacteristics, Executables executables, Health.Health health)
        {
            _playerCharacteristics = playerCharacteristics;
            _executables = executables;
            _health = health;
        }
        
        public PlayerController Create()
        {
            PlayerModel playerModel = new PlayerModel(_health, _playerCharacteristics.MovingSpeed,
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