using SFML.System;

namespace Snake.UI
{
    public interface IPositionProvider
    {
        Vector2u GetPosition(int index);
    }
}