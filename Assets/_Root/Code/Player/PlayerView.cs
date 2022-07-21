using System;
using _Root.Code.Interfaces;
using UnityEngine;

namespace _Root.Code.Player
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
        [field: SerializeField] public GameObject PlayerObject { get; private set; }
        [field: SerializeField] public Camera Eyes { get; private set; }
        public event Action OnPlayerDie = () => { };

        private void OnValidate()
        {
            PlayerObject = gameObject;
            Rigidbody = gameObject.GetComponent<Rigidbody>();
            Eyes = gameObject.GetComponentInChildren<Camera>();
        }

        private void OnDestroy()
        {
            OnPlayerDie.Invoke();
        }
    }
}