using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Snake.UI
{
    public class Window
    {
        private readonly RenderWindow _window;

        public Window(string title, Vector2u size)
        {
            var style = Styles.Default;
            var videoMode = new VideoMode(size.X, size.Y, 32);
            _window = new RenderWindow(videoMode, title, style);

            _window.Closed += (sender, args) => _window.Close();
        }

        public void Render(IDrawableProvider provider)
        {
            _window.Clear();
            foreach (var entry in provider.GetDrawables())
            {
                _window.Draw(entry);
            }
            _window.Display(); 
        }

        public void DispatchEvents()
        {
            _window.DispatchEvents();
        }

        public bool IsOpen => _window.IsOpen;
    }
}