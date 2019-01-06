using SFML.Window;

namespace Snake.UI
{
    public class MoveEngine : IMoveEngine
    {
        private readonly IMoveCommandFactory _commandFactory;
        private MoveDirection _currentDirection;

        public MoveEngine(IMoveCommandFactory commandFactory, IKeyPressedEventProvider keyPressedEventProvider)
        {
            _commandFactory = commandFactory;
            _currentDirection = MoveDirection.None;
            keyPressedEventProvider.KeyPressed += OnKeyPressed;
        }

        public void Update(IPositionProvider provider)
        {
            provider.Position
                = _commandFactory
                    .Create(_currentDirection)
                    .Execute(provider.Position);
        }

        private void OnKeyPressed(object sender, KeyEventArgs args)
        {
            switch (args.Code)
            {
                case Keyboard.Key.Left:
                    _currentDirection = MoveDirection.Left;
                    break;
                case Keyboard.Key.Right:
                    _currentDirection = MoveDirection.Right;
                    break;
                default:
                    _currentDirection = MoveDirection.None;
                    break;
            } 
        }
    }
}