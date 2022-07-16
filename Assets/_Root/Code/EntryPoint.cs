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
        [SerializeField] private GameSettings _gameSettings;
        private PlayerController _playerController;

        private void Start()
        {
            IPlayerFactory playerFactory = new PlayerFactory(_gameSettings.PlayerCharacteristics);
            _playerController = playerFactory.Create();
            _controller.Init(_playerController.GetHealth());
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _playerController.Execute(deltaTime);
        }
    }
}