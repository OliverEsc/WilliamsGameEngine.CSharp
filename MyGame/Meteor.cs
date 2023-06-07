using GameEngine;
using SFML.Graphics;
using SFML.System;

namespace MyGame
{
    class Meteor : GameObject
    {
        private const float Speed = 0.4f;

        private readonly Sprite _sprite = new Sprite();

        public Meteor(Vector2f pos)
        {
            _sprite.Texture = Game.GetTexture("Resources/Car-12-1.png.png");
            _sprite.Position = pos;
            AssignTag("meteor");
            SetCollisionCheckEnabled(true);
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }

        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            Vector2f pos = _sprite.Position;

            if (pos.Y > Game.RenderWindow.Size.Y)
            {
                //GameScene scene = (GameScene)Game.CurrentScene;
                //scene.DecreaseLives();

                MakeDead();
            }
            else
            {
                _sprite.Position = new Vector2f(pos.X, pos.Y + Speed * msElapsed);
            }
        }

        public override FloatRect GetCollisionRect()
        {
            return _sprite.GetGlobalBounds();
        }

        public override void HandleCollision(GameObject otherGameObject)
        {
            if (otherGameObject.HasTag("ship"))
            {
                otherGameObject.MakeDead();
                GameScene scene = (GameScene)Game.CurrentScene;
                scene.IncreaseScore();
            }
            Vector2f pos = _sprite.Position;
            pos.X = pos.X + (float)_sprite.GetGlobalBounds().Width / 0.1f;
            pos.Y = pos.Y + (float)_sprite.GetGlobalBounds().Height / 0.1f;
            Explosion explosion = new Explosion(pos);
            Game.CurrentScene.AddGameObject(explosion);
            MakeDead();
        }
    }
}