using GameEngine;
using SFML.System;

namespace MyGame
{
    class GameScene : Scene
    {
        private int _lives = 1;
        private int _score;

        public GameScene()
        {
            scrollingbackground background = new scrollingbackground();
            AddGameObject(background);

            Ship ship = new Ship();
            AddGameObject(ship);

<<<<<<< HEAD
            MeteorSpawner meteorSpawner= new MeteorSpawner();
=======
            MeteorSpawner meteorSpawner = new MeteorSpawner();
>>>>>>> b7684be90041c61ec777ff8b7f815a6f7bf38184
            AddGameObject(meteorSpawner);

            Score score = new Score(new Vector2f(10.0f, 10.0f));
            AddGameObject(score);
        }

        public int GetScore()
        {
            return _score;
        }

        public void IncreaseScore()
        {
            _score++;
        }

        public int GetLives()
        {
            return _lives;
        }

        public void DecreaseLives()
        {
            _lives--;
            if (_lives == 0)
            {
                GameOverScene gameOverScene = new GameOverScene(_score);
                Game.SetScene(gameOverScene);
            }
        }
    }
}