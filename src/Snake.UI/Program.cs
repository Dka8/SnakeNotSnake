using SFML.System;
using Microsoft.Extensions.DependencyInjection;

namespace Snake.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddScoped<IDrawableProvider, InMemoryDrawableProvider>();
            var provider = services.BuildServiceProvider();
            
            var window = new Window("Snake", new Vector2u(800,600));
            
            while (window.IsOpen)
            {
                window.DispatchEvents();
                var drProvider = provider.GetService<IDrawableProvider>();
                window.Render(drProvider);
            }
        }
    }
}
