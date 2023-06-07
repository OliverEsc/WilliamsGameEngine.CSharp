using GameEngine;
using SFML.Graphics;
using SFML.System;

namespace MyGame
{
    class MeteorSpawner : GameObject
    {
        private const int SpawnDelay = 375;
        private int _timer;

        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            _timer -= msElapsed;

            if (_timer <= 0)
            {
                _timer = SpawnDelay;
                Vector2u size = Game.RenderWindow.Size;

                float meteorX = Game.Random.Next() % size.X;

                float meteorY = -200;

                Meteor meteor = new Meteor(new Vector2f(meteorX, meteorY));
                Game.CurrentScene.AddGameObject(meteor);
            }
        }
    }
}
