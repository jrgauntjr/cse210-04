using System;
using System.Collections.Generic;

namespace Lab04.Game
{
    public class Director
    {
        public Director()
        {
        }
        bool isPlaying = true;
        public void StartGame()
        {
            while (isPlaying == true)
            {
                getInputs();
                doUpdates();
                doOutputs();
            }
        }
        public void getInputs()
        {
            // getKeyboard();
        }

        public void doUpdates()
        {
            //fallingObject.move;
            //player.move;
        }

        public void doOutputs()
        {
            //getVideoService;
        }
    }
}