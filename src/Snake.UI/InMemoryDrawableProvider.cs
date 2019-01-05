using System.Collections.Generic;
using SFML.Graphics;

namespace Snake.UI
{
    public class InMemoryDrawableProvider : IDrawableProvider
    {
        public IEnumerable<Drawable> GetDrawables()
        {
            return new List<Drawable>();
        }
    }
}