using UnityEngine;

namespace _Root.Code.Interfaces
{
    public interface IPlayerView
    {
        
        Rigidbody Rigidbody { get; }
        GameObject PlayerObject { get; }
    }
}