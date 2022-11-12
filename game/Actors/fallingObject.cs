using System;

using System.Collections.Generic;

namespace Lab04.Game.actors
{
    public class fallingObject : Actor
    
    {
        Random random = new Random();
        public fallingObject()
        {
            int numba = (random.Next(0,60))*15;

            SetPosition(new Point(numba,0));

            SetVelocity(new Point(0,2));

        }

        public void Move(){
           Point _currentP = GetPosition();
           Point _currentV = GetVelocity();
            SetPosition(new Point (_currentP.GetX(), (_currentP.GetY() + _currentV.GetY())));
        }
        

    }
}