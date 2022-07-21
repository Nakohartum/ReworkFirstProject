using _Root.Code.Player.PlayerControl.PlayerController;

namespace _Root.Code.Player
{
    public interface IPlayerFactory
    {
        PlayerController Create();
        
    }
}