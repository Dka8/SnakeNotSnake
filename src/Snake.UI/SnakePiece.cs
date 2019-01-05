using SFML.Graphics;
using SFML.System;

namespace Snake.UI
{
    public class SnakePiece : Drawable
    {
        private readonly RectangleShape _piece;
        private readonly int _index;
        private readonly IPositionProvider _positionProvider;

        public SnakePiece(IPositionProvider provider)
        {
            _piece = new RectangleShape(new Vector2f(20, 20));
            _piece.FillColor = Color.Cyan;
            _index = 0;
            _positionProvider = provider;
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            var temp = _positionProvider.GetPosition(_index);
            _piece.Position = new Vector2f(temp.X * 20, temp.Y * 20);
            target.Draw(_piece);
        }
    }
}