using _Root.Code.Interfaces;

namespace _Root.Code.InputControls
{
    public class InputController : IExecutable
    {
        public HorizontalInputController HorizontalInputController { get; private set; }
        public VerticalInputController VerticalInputController { get; private set; }
        public JumpInputController JumpInputController { get; private set; }

        public InputController()
        {
            HorizontalInputController = new HorizontalInputController();
            VerticalInputController = new VerticalInputController();
            JumpInputController = new JumpInputController();
        }
       
        
        public void Execute(float deltaTime)
        {
            HorizontalInputController.GetInput();
            VerticalInputController.GetInput();
            JumpInputController.GetInput();
        }
    }
}