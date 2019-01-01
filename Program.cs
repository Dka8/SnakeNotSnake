using System;
using System.Drawing;
using System.Timers;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using Color = SFML.Graphics.Color;

namespace ConsoleApp1
{
    class MoveEngine
    {
        public void MoveDown(Transformable entity)
        {
            var current = entity.Position;
            current.Y += 5;
            entity.Position = current;
        }

        public void MoveRight(Transformable entity)
        {
            var current = entity.Position;
            current.X += 10;
            entity.Position = current;
        }

        public void MoveLeft(Transformable entity)
        {
            var current = entity.Position;
            current.X -= 10;
            entity.Position = current;
        }

        public void MoveSpace(Transformable entity)
        {
            var current = entity.Position;
            current.Y = 500;
            entity.Position = current;
        }
        public void MoveStop(Transformable entity)
        {
            var current = entity.Position;
            current.Y = 0;
            entity.Position = current;
        }
    }

    class Field : Drawable
    {
        private readonly List<RectangleShape> _rectangle= new List<RectangleShape>();
        private readonly MoveEngine _moveEngine;

        private void KeyHandler(object sender, KeyEventArgs args)
        {
            if (args.Code == Keyboard.Key.Right || args.Code == Keyboard.Key.D)
            {
                _moveEngine.MoveRight(_rectangle[_rectangle.Count - 1]);
            }
            if (args.Code == Keyboard.Key.Left || args.Code == Keyboard.Key.A)
            {
                _moveEngine.MoveLeft(_rectangle[_rectangle.Count - 1]);
            }
            if (args.Code == Keyboard.Key.Space || args.Code == Keyboard.Key.Down || args.Code == Keyboard.Key.S)
            {
                _moveEngine.MoveSpace(_rectangle[_rectangle.Count - 1]);
            }
           
        }

        public Field(RenderWindow window, Timer timer, MoveEngine moveEngine)
        {
            _moveEngine = moveEngine;
            _rectangle.Add(new RectangleShape(new Vector2f(SizeDefines.SIZE, SizeDefines.SIZE)));
            _rectangle[_rectangle.Count-1].FillColor = Color.Cyan;
            timer.Elapsed += (sender, args) => 
            {
                if (_rectangle[_rectangle.Count - 1].Position.Y >= 500)
                {
                    _rectangle.Add(new RectangleShape(new Vector2f(SizeDefines.SIZE, SizeDefines.SIZE)));
                    _rectangle[_rectangle.Count - 1].FillColor = Color.Cyan;
                }
                else
                {
                    _moveEngine.MoveDown(_rectangle[_rectangle.Count - 1]);
                }
            };
            window.KeyPressed += KeyHandler;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            for (int i = 0; i < _rectangle.Count; i++)
            {
                target.Draw(_rectangle[i]);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            var window = new RenderWindow(new VideoMode(800, 600), "Don't work!");
            var timer = new Timer(200);
            var moveEngine = new MoveEngine();
            var field = new Field(window, timer, moveEngine);
            window.Closed += (s, args) =>
            {
                var win = s as Window;
                win.Close();
            };

            timer.Enabled = true;
            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear(Color.Black);
                window.Draw(field);
                window.Display();
            }
        }
    }

    class SizeDefines
    {
        public const int SIZE = 10;
    }

}