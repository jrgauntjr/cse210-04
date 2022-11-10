using System.Collections.Generic;
using Lab04.Game.actors;
using Lab04.Game.services;


namespace Lab04.Game.director
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private KeyboardService _keyboardService = null;
        private VideoService _videoService = null;

        Point point = new Point(15,0);

        int _score = 0;

        /// <summary>
        /// Constructs a new instance of Director using the given KeyboardService and VideoService.
        /// </summary>
        /// <param name="keyboardService">The given KeyboardService.</param>
        /// <param name="videoService">The given VideoService.</param>
        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this._keyboardService = keyboardService;
            this._videoService = videoService;
        }

        /// <summary>
        /// Starts the game by running the main game loop for the given cast.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void StartGame(Cast cast)
        {
            _videoService.OpenWindow();
            while (_videoService.IsWindowOpen())
            {
                GetInputs(cast);
                DoUpdates(cast);
                DoOutputs(cast);
            }
            _videoService.CloseWindow();
        }

        /// <summary>
        /// Gets directional input from the keyboard and applies it to the robot.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void GetInputs(Cast cast)
        {
            Actor player = cast.GetFirstActor("player");
            Point velocity = _keyboardService.GetDirection();
            player.SetVelocity(velocity);     
        }

        /// <summary>
        /// Updates the robot's position and resolves any collisions with artifacts.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void DoUpdates(Cast cast)
        {   
            Rock rock = new Rock();
            Gem gem = new Gem();
            Actor score = new Actor();

            cast.AddActor("fallingObjects",rock);
            cast.AddActor("fallingObjects", gem);
            cast.AddActor("score", score);
        
            score.SetPosition(point);
            score.SetText("Score: " + _score);

            Actor player = cast.GetFirstActor("player");
            List<Actor> _fallingObject_List = cast.GetActors("fallingObjects");
            int maxX = _videoService.GetWidth();
            int maxY = _videoService.GetHeight();
            player.MoveNext(maxX, maxY);

            foreach (fallingObject actor in _fallingObject_List)
            {
                actor.GetPosition();
                actor.GetVelocity();
                actor.Move();

                if (player.GetPosition().Equals(actor.GetPosition()))
                {
                    // fallingObject _collisions = (fallingObject) actor;
                    _score = actor.GetScore();
                    cast.RemoveActor("fallingObjects", actor);

                }
            }
        }

        // Draws the actors on the screen.
        public void DoOutputs(Cast cast)
        {
            List<Actor> actors = cast.GetAllActors();
            _videoService.ClearBuffer();
            _videoService.DrawActors(actors);
            _videoService.FlushBuffer();
        }

    }
}