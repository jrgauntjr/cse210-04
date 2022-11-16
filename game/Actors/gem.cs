using System;

using System.Collections.Generic;

namespace Lab04.Game.actors
{
    // The shape, score and color of Gem
    public class Gem : fallingObject
    {
        Random random = new Random();
        public Gem()
        {
            SetText("$");
            setScore(1);
            SetColor(new Color(random.Next(40,255), random.Next(40,255), random.Next(40,255)));
        }

    }
}