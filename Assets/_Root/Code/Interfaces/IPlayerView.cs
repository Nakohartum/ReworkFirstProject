using System;
using UnityEngine;

namespace _Root.Code.Interfaces
{
    public interface IPlayerView
    {
        event Action OnPlayerDie;
        Rigidbody Rigidbody { get; }
        GameObject PlayerObject { get; }
        Camera Eyes { get; }
    }
}