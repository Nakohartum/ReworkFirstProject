using System;
using UnityEngine.Events;

namespace _Root.Code.Interfaces
{
    public interface IInputController
    {
        void GetInput();
        event Action<float> OnAxisChange;
    }
}