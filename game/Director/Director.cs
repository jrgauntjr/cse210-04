using System.Collections.Generic;
using Lab04.Game.actors;
using Lab04.Game.services;


namespace Lab04.Game.director
{
    /// The responsibility of the Director is to control the sequence of play.
    public class Director
    {
        private KeyboardService _keyboardService = null;
        private VideoService _videoService = null;

        Point point = new Point(15,0);
        Actor score = new Actor();
        int _score = 0;

        /// Constructs a new instance of Director using the given KeyboardService and VideoService.
        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this._keyboardService = keyboardService;
            this._videoService = videoService;
        }

        /// Starts the game by running the main game loop for the given cast.
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

        /// Gets directional input from the keyboard and applies it to the player.
        private void GetInputs(Cast cast)
        {
            Actor player = cast.GetFirstActor("player");
            Point velocity = _keyboardService.GetDirection();
            player.SetVelocity(velocity);     
        }

        // Updates the game, determining if a gem or rock has been hit
        private void DoUpdates(Cast cast)
        {   
            Rock rock = new Rock();
            Gem gem = new Gem();
            

            cast.AddActor("fallingObjects", rock);
            cast.AddActor("fallingObjects", gem);
            cast.AddActor("score", score);
        
            score.SetPosition(point);
            score.SetText("Score: " + _score);
            

            Actor player = cast.GetFirstActor("player");
            List<Actor> _fallingObject_List = cast.GetActors("fallingObjects");
            int maxX = _videoService.GetWidth();
            int maxY = _videoService.GetHeight();
            player.MoveNext(maxX, maxY);

            // If a player hits a rock or gem, add or subtract the score and remove the actor
            foreach (fallingObject actor in _fallingObject_List)
            {
                actor.GetPosition();
                actor.GetVelocity();
                actor.Move();

                if (player.GetPosition().Equals(actor.GetPosition()))
                {
                    _score = _score + actor.GetScore();
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