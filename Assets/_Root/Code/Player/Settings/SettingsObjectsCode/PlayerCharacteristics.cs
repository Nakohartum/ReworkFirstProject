using UnityEngine;

namespace Player.Settings.SettingsObjectsCode
{
    [CreateAssetMenu(fileName = nameof(PlayerCharacteristics), menuName = "Game/"+nameof(PlayerCharacteristics))]
    public class PlayerCharacteristics : ScriptableObject
    {
        [field: SerializeField] public float MaxHealth { get; private set; }
        [field: SerializeField] public float CurrentHealth { get; set; }
        [field: SerializeField] public float MovingSpeed { get; private set; }
        [field: SerializeField] public float JumpPower  { get; private set; }
        [field: SerializeField] public Vector3 SpawnPosition { get; private set; }
        [field: SerializeField] public GameObject SpawnObject { get; private set; }
    }
}
