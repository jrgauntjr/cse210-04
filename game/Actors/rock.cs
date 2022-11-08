using System;

using System.Collections.Generic;

namespace Lab04.Game.actors
{
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