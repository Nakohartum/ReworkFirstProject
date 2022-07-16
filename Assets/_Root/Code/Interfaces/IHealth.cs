using System;

namespace _Root.Code.Interfaces
{
    public interface IHealth
    {
        float MaxHealth { get; }
        float CurrentHealth { get; }
        event Action OnHpChanged;
        void ChangeHealthPoints(float value);
    }
}