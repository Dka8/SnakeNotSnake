using System;
using Microsoft.Extensions.Options;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Snake.UI
{
    public class WindowOptions
    {
        public string Title { get; set; }
        public Vector2u Size { get; set; }
    }
    
    public class Window : IKeyPressedEventProvider
    {
        private readonly RenderWindow _window;

        public Window(IOptions<WindowOptions> options)
        {
            var style = Styles.Default;
            var videoMode = new VideoMode(options.Value.Size.X,options.Value.Size.Y, 32);
            _window = new RenderWindow(videoMode, options.Value.Title, style);

            _window.Closed += (sender, args) => _window.Close();
            _window.KeyPressed += OnKeyPressed;
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

        public event EventHandler<KeyEventArgs> KeyPressed;

        private void OnKeyPressed(object sender, KeyEventArgs args)
        {
            KeyPressed?.Invoke(sender, args);
        }
    }
}