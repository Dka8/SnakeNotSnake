using SFML.System;

namespace Snake.UI
{
    public class SimplePositionProvider : IPositionProvider
    {
        public Vector2u GetPosition(int index)
        {
            return new Vector2u(3,3);
        }
    }
}