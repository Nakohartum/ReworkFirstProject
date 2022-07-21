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
        private Executables _executables = new Executables();

        private void Start()
        {
            IPlayerFactory playerFactory = new PlayerFactory(_gameSettings.PlayerCharacteristics, _executables);
            var playerController = playerFactory.Create();
            _executables.AddToExecutables(playerController);
            _controller.Init(playerController.GetHealth());
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _executables.Execute(deltaTime);
        }
    }
}