using _Root.Code.Interfaces;

namespace _Root.Code.InputControls
{
    public class InputController : IExecutable
    {
        public HorizontalInputController HorizontalInputController { get; private set; }
        public VerticalInputController VerticalInputController { get; private set; }
        public JumpController JumpController { get; private set; }

        public InputController()
        {
            HorizontalInputController = new HorizontalInputController();
            VerticalInputController = new VerticalInputController();
            JumpController = new JumpController();
        }
       
        
        public void Execute(float deltaTime)
        {
            HorizontalInputController.GetInput();
            VerticalInputController.GetInput();
            JumpController.GetInput();
        }
    }
}