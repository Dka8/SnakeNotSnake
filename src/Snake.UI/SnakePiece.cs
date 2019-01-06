using SFML.Graphics;
using SFML.System;

namespace Snake.UI
{
    public class SnakePiece : Drawable
    {
        private readonly RectangleShape _piece;
        private readonly IPositionProvider _positionProvider;

        public SnakePiece(IPositionProvider provider)
        {
            _piece = new RectangleShape(new Vector2f(20, 20));
            _piece.FillColor = Color.Cyan;
            _positionProvider = provider;
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (var position in _positionProvider.Position)
            {
                _piece.Position = new Vector2f(position.X * 20, position.Y * 20);
                target.Draw(_piece);
            }
        }
    }
}