using System;

using System.Collections.Generic;

namespace Lab04.Game.actors
{
    // A falling object, starting from the top of the screen and falls down
    public class fallingObject : Actor
    {
        Random random = new Random();
        public fallingObject()
        {
            int numba = (random.Next(0,60))*15;

            SetPosition(new Point(numba,0));

            SetVelocity(new Point(0,10));

        }
        public void Move(){
           Point _currentP = GetPosition();
           Point _currentV = GetVelocity();
            SetPosition(new Point (_currentP.GetX(), (_currentP.GetY() + _currentV.GetY())));
        }
    }
}