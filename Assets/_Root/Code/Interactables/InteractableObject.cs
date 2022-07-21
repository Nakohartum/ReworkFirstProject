using _Root.Code.Interfaces;
using UnityEngine;

namespace _Root.Code.Interactables
{
    public class InteractableObject : MonoBehaviour, IInteractable
    {
        [SerializeField] private Animation _animation;
        public void Interact()
        {
            _animation.Play();
        }
    }
}