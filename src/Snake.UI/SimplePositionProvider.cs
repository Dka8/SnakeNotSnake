using System;
using System.Collections.Generic;
using System.Linq;
using SFML.System;
using SFML.Window;

namespace Snake.UI
{
    public class SimplePositionProvider : IPositionProvider
    {
        private IEnumerable<Vector2u> _position;
        private readonly IMoveEngine _moveEngine;

        public SimplePositionProvider(IMoveEngine moveEngine, IUpdateEventProvider updateEventProvider)
        {
            _moveEngine = moveEngine;
            updateEventProvider.UpdateEvent += Update;
            
            _position = new List<Vector2u>()
            {
                new Vector2u(2,2),
                new Vector2u(3,2),
                new Vector2u(4,2)
            };
        }
        
        public IEnumerable<Vector2u> Position
        {
            get => _position;
            set => _position = value;
        }

        private void Update(object sender, EventArgs args)
        {
            _moveEngine.Update(this); 
        }
    }
}