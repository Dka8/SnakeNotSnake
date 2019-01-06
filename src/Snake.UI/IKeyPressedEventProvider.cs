using System;
using SFML.Window;

namespace Snake.UI
{
    public interface IKeyPressedEventProvider
    {
        event EventHandler<KeyEventArgs> KeyPressed;
    }
}