using SFML.System;

namespace Snake.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var window = new Window("Snake", new Vector2u(800,600));
            var provider = new InMemoryDrawableProvider();
            
            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Render(provider);
            }
        }
    }
}
