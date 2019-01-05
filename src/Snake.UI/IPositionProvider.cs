using System.Collections.Generic;
using SFML.System;

namespace Snake.UI
{
    public interface IPositionProvider
    {
        IEnumerable<Vector2u> GetSnakePosition();
    }
}