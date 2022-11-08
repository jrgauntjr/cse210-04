using System;

using System.Collections.Generic;

namespace Lab04.Game.actors
{
    public class Gem : fallingObject
    
    {
        Random random = new Random();
        public Gem()
        {

            SetText("$");

            SetColor(new Color(random.Next(40,255), random.Next(40,255), random.Next(40,255)));

        }

    }
}