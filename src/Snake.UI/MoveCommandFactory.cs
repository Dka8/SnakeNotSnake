using System;

namespace Snake.UI
{
    public class MoveCommandFactory : IMoveCommandFactory
    {
        public IMoveCommand Create(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.None:
                    return new MoveNoneCommand();
                case MoveDirection.Right:
                    return new MoveRightCommand();
                case MoveDirection.Left:
                    return new MoveLeftCommand();
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }        
        }
    }
}