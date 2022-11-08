using System;

using System.Collections.Generic;

namespace Lab04.Game.actors
{
    public class fallingObject : Actor
    
    {
        Random random = new Random();
        public fallingObject()
        {
            SetPosition(new Point(random.Next(0,1000),0));

            SetVelocity(new Point(0,10));

            SetText("@");

            SetColor(new Color(20,75,82));

        }

        public void Move(){
           Point _currentP = GetPosition();
           Point _currentV = GetVelocity();
            SetPosition(new Point (_currentP.GetX(), (_currentP.GetY() + _currentV.GetY())));
        }

    }
}