using System.Collections.Generic;
using System.Linq;
using SFML.System;

namespace Snake.UI
{
    public interface IMoveCommand
    {
        IEnumerable<Vector2u> Execute(IEnumerable<Vector2u> position);
    }
    
    public class MoveNoneCommand : IMoveCommand
    {
        public IEnumerable<Vector2u> Execute(IEnumerable<Vector2u> position)
        {
            return position;
        }
    }
    
    public class MoveRightCommand : IMoveCommand
    {
        public IEnumerable<Vector2u> Execute(IEnumerable<Vector2u> position)
        {
            return position.Select((pos) => new Vector2u(pos.X + 1, pos.Y));
        }
    }
    
    public class MoveLeftCommand : IMoveCommand
    {
        public IEnumerable<Vector2u> Execute(IEnumerable<Vector2u> position)
        {
            return position.Select((pos) => new Vector2u(pos.X - 1, pos.Y));
        }
    }
}