using System;
using _Root.Code.Interfaces;
using UnityEngine;

namespace _Root.Code.Health
{
    internal sealed class Health : IHealth
    {
        private float _maxHealth;
        private float _currentHealth;
        public float MaxHealth => _maxHealth;
        public float CurrentHealth => _currentHealth;
        public event Action OnHpChanged = () => {};

        public Health(float maxHealth, float currentHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = currentHealth == 0 ? maxHealth : currentHealth;
        }

        public void ChangeHealthPoints(float value)
        {
            _currentHealth -= value;
            OnHpChanged.Invoke();
        }
    }
}