using System;
using SFML.System;
using Microsoft.Extensions.DependencyInjection;

namespace Snake.UI
{
    public static class WindowServiceCollectionExtention
    {
        public static IServiceCollection AddWindowService(
            this IServiceCollection collection,
            Action<WindowOptions> setupAction)
        {
            collection.Configure(setupAction);
            return collection.AddSingleton<IKeyPressedEventProvider, Window>();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddOptions();
            
            services.AddSingleton<IDrawableProvider, SnakePiecesProvider>();
            services.AddSingleton<IPositionProvider, SimplePositionProvider>();
            services.AddWindowService(options =>
            {
                options.Title = "Snake";
                options.Size = new Vector2u(800,600);
            });
            services.AddSingleton<IKeyPressedEventProvider, Window>();
            
            var provider = services.BuildServiceProvider();

            var window = provider.GetService<IKeyPressedEventProvider>() as Window;
            
            while (window.IsOpen)
            {
                window.DispatchEvents();
                var drProvider = provider.GetService<IDrawableProvider>();
                window.Render(drProvider);
            }
        }
    }
}
