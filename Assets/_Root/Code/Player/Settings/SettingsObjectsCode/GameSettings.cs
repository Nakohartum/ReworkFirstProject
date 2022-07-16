using UnityEngine;

namespace Player.Settings.SettingsObjectsCode
{
    [CreateAssetMenu(fileName = nameof(GameSettings), menuName = "Game/"+nameof(GameSettings), order = 0)]
    public class GameSettings : ScriptableObject
    {
        public PlayerCharacteristics PlayerCharacteristics;
    }
}