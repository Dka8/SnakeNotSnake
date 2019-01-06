using System;
using SFML.Window;

namespace Snake.UI
{
    public class KeyPressedEventProvider : IKeyPressedEventProvider
    {
        public KeyPressedEventProvider(Window window)
        {
            window.KeyPressed += OnKeyPressed;
        }
        public event EventHandler<KeyEventArgs> KeyPressed;

        private void OnKeyPressed(object sender, KeyEventArgs args)
        {
            KeyPressed?.Invoke(sender, args);
        }
    }
}