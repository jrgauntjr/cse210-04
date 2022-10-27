using System;
using System.Collections.Generic;

namespace test.Game
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
        }

        public void doUpdates()
        {
        }

        public void doOutputs()
        {
        }
    }
}