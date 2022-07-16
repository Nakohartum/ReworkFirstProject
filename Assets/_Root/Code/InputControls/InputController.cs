using _Root.Code.Interfaces;

namespace _Root.Code.InputControls
{
    public class InputController : IExecutable
    {
        private HorizontalInputController _horizontalInputController;
        private VerticalInputController _verticalInputController;
        private JumpController _jumpController;

        public InputController()
        {
            _horizontalInputController = new HorizontalInputController();
            _verticalInputController = new VerticalInputController();
            _jumpController = new JumpController();
        }
        public float VerticalInput { get; private set; }
        public float HorizontalInput { get; private set; }
        public bool JumpInput { get; private set; }
        
        public void Execute(float deltaTime)
        {
            VerticalInput = _verticalInputController.GetInput();
            HorizontalInput = _horizontalInputController.GetInput();
            var jumpValue = _jumpController.GetInput();
            if (jumpValue > 0.1)
            {
                JumpInput = true;
            }
            else
            {
                JumpInput = false;
            }
        }
    }
}