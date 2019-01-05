using System.Collections.Generic;
using SFML.Graphics;

namespace Snake.UI
{
    public class SnakePiecesProvider : IDrawableProvider
    {
        private readonly IPositionProvider _positionProvider;

        public SnakePiecesProvider(IPositionProvider positionProvider)
        {
            _positionProvider = positionProvider;
        }

        public IEnumerable<Drawable> GetDrawables()
        {
            return new List<SnakePiece>()
            {
                new SnakePiece(_positionProvider)
            };
        }
    }
}