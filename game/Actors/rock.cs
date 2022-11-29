using System;

using System.Collections.Generic;

namespace Lab04.Game.actors
{
    // The shape, score and color of Rock
    public class Rock : fallingObject    
    {
        public Rock()
        {
            SetText("@");
            setScore(-1);
            SetColor(new Color(20,75,82));
        }
    }
}