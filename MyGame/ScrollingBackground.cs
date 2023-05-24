using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.ComponentModel;
using System.Threading;
using static System.Formats.Asn1.AsnWriter;

namespace MyGame
{
    class scrollingbackground : GameObject
    {
        public readonly Sprite _sprite = new Sprite();
        public readonly Sprite _sprite2 = new Sprite();
        private float Speed = 0.4f;

        public uint currentX = 0;
        public uint currentY = 0;

        public scrollingbackground()
        {
            _sprite.Texture = Game.GetTexture("Resources/background2-1.png.png");
            _sprite.Position = new Vector2f(0, 0);
            _sprite2.Texture = Game.GetTexture("Resources/Background2.png");
            _sprite2.Position = new Vector2f(0, -600);


        }
        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
            Game.RenderWindow.Draw(_sprite2);
        }

        public override void Update(Time elapsed)
        {


            Vector2f pos = _sprite.Position;
            Vector2f pos1 = _sprite2.Position;

            float y = pos.Y;
            float y1 = pos1.Y;
            int msElapsed = elapsed.AsMilliseconds();

            y += Speed * msElapsed;
            y1 += Speed * msElapsed;

            if (y >= 600)
            {
                y -= 1200;
            }
            if (y1 >= 600)
            {
                y1 -= 1200;
            }


            _sprite.Position = new Vector2f(0, y);
            _sprite2.Position = new Vector2f(0, y1);
        }



    }
}

