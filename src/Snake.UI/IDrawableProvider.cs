using System.Collections.Generic;
using SFML.Graphics;

namespace Snake.UI
{
    public interface IDrawableProvider
    {
        IEnumerable<Drawable> GetDrawables();
    }
}