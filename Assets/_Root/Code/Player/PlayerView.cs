using System;
using _Root.Code.Interfaces;
using UnityEngine;

namespace _Root.Code.Player
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
        [field: SerializeField] public GameObject PlayerObject { get; private set; }

        private void OnValidate()
        {
            PlayerObject = gameObject;
        }
    }
}