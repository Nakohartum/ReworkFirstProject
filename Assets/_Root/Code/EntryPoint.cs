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
            var health = new Health.Health(_gameSettings.PlayerCharacteristics.MaxHealth, 0);
            IPlayerFactory playerFactory = new PlayerFactory(_gameSettings.PlayerCharacteristics, _executables, health);
            var playerController = playerFactory.Create();
            _executables.AddToExecutables(playerController);
            _controller.Init(health);
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _executables.Execute(deltaTime);
        }
    }
}