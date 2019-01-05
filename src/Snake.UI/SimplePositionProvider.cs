using System.Collections.Generic;
using SFML.System;

namespace Snake.UI
{
    public class SimplePositionProvider : IPositionProvider
    {
        public Vector2u GetPosition(int index)
        {
            return new Vector2u(3,3);
        }

        public IEnumerable<Vector2u> GetSnakePosition()
        {
            return new List<Vector2u>()
            {
                new Vector2u(2,2),
                new Vector2u(3,2),
                new Vector2u(4,2)
            };
        }
    }
}