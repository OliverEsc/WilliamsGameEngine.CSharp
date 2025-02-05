﻿using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Ship : GameObject
    {
        private const float Speed = 0.5f;
        private const int FireDelay = 1;
        private int _fireTimer;

        private readonly Sprite _sprite = new Sprite();
        public Ship()
        {

            _sprite.Texture = Game.GetTexture("Resources/Caar.png");
            _sprite.Position = new Vector2f(100, 105);
           

        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }


        public override void Update(Time elapsed)
        {
            Vector2f pos = _sprite.Position;
            float x = pos.X;
            float y = pos.Y;

            int msElapsed = elapsed.AsMilliseconds();

            if (Keyboard.IsKeyPressed(Keyboard.Key.Up) || Keyboard.IsKeyPressed(Keyboard.Key.W) )   { y -= Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down) || Keyboard.IsKeyPressed(Keyboard.Key.S) ) { y += Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left) || Keyboard.IsKeyPressed(Keyboard.Key.A)) { x -= Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right) || Keyboard.IsKeyPressed(Keyboard.Key.D) ){ x += Speed * msElapsed; }
            _sprite.Position = new Vector2f(x, y);

            if(_fireTimer > 0) { _fireTimer -= msElapsed; }


            //if(Keyboard.IsKeyPressed(Keyboard.Key.Space) && _fireTimer <= 0)
            //{
            //    _fireTimer = FireDelay;
            //    FloatRect bounds = _sprite.GetGlobalBounds();
            //    float laserX = x + bounds.Width;
            //    float laserY = y + bounds.Height / 2.0f;
            //    Laser laser = new Laser(new Vector2f(laserX, laserY));
            ////    Game.CurrentScene.AddGameObject(laser);
            //}
        }

        public override FloatRect GetCollisionRect()
        {
            return _sprite.GetGlobalBounds();
        }

        public override void HandleCollision(GameObject otherGameObject)
        {
            if (otherGameObject.HasTag("meteor"))
            {
                otherGameObject.MakeDead();
                GameScene scene = (GameScene)Game.CurrentScene;
                scene.DecreaseLives();
            }
            Vector2f pos = _sprite.Position;
            pos.X = pos.X + (float)_sprite.GetGlobalBounds().Width / 0.001f;
            pos.Y = pos.Y + (float)_sprite.GetGlobalBounds().Height / 0.01f;
            Explosion explosion = new Explosion(pos);
            Game.CurrentScene.AddGameObject(explosion);
            MakeDead();
        }
    }
}
