using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Snake.UI
{

    public class Window
    {
        private RenderWindow _window;

        public Window(string title, Vector2u size)
        {
            var style = Styles.Default;
            var videoMode = new VideoMode(size.X, size.Y, 32);
            _window = new RenderWindow(videoMode, title, style);

            _window.Closed += (sender, args) => _window.Close();
        }

        public void Clear()
        {
            _window.Clear(Color.Black); 
        }

        public void Display()
        {
            _window.Display(); 
        }

        public void Draw(Drawable drawable)
        {
            _window.Draw(drawable);
        }

        public void DispatchEvents()
        {
            _window.DispatchEvents();
        }

        public bool IsOpen => _window.IsOpen;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var window = new Window("Snake", new Vector2u(800,600));
            while (window.IsOpen)
            {
                window.Clear();
                window.DispatchEvents();
                window.Display();
            }
        }
    }
}
