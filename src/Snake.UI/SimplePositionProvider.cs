using System.Collections.Generic;
using System.Linq;
using SFML.System;
using SFML.Window;

namespace Snake.UI
{
    public class SimplePositionProvider : IPositionProvider
    {
        private List<Vector2u> _snakePosition;

        public SimplePositionProvider(IKeyPressedEventProvider keyPressedEventProvider)
        {
            keyPressedEventProvider.KeyPressed += KeyPressedEventHandler; 
            _snakePosition = new List<Vector2u>()
            {
                new Vector2u(2,2),
                new Vector2u(3,2),
                new Vector2u(4,2)
            };
        }

        public IEnumerable<Vector2u> GetSnakePosition()
        {
            return _snakePosition;
        }

        private void KeyPressedEventHandler(object sender, KeyEventArgs args)
        {
            switch (args.Code)
            {
                case Keyboard.Key.Right:
                {
                    _snakePosition 
                        = _snakePosition.Select((pos) => new Vector2u(pos.X + 1, pos.Y)).ToList();
                    break;
                }
            } 
        }
    }
}