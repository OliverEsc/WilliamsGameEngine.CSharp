using GameEngine;
using SFML.Graphics;
using SFML.System;

namespace MyGame
{
    class MeteorSpawner : GameObject
    {
        private const int SpawnDelay = 1000;

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
                float meteorY = -100; // Spawn the meteor above the screen

                Meteor meteor = new Meteor(new Vector2f(meteorX, meteorY));
                Game.CurrentScene.AddGameObject(meteor);
            }
        }
    }
}
