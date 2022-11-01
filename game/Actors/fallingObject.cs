using System;

using System.Collections.Generic;

namespace Lab04.Game
{
    public class fallingObject : Actor
    
    {
         private string _message = "";

        /// <summary>
        /// Constructs a new instance of an Artifact.
        /// </summary>
        public fallingObject()
        {
        }

        /// <summary>
        /// Gets the artifact's message.
        /// </summary>
        /// <returns>The message.</returns>
        public string GetMessage()
        {
            return _message;
        }

        /// <summary>
        /// Sets the artifact's message to the given value.
        /// </summary>
        /// <param name="message">The given message.</param>
        public void SetMessage(string message)
        {
            this._message = message;
        }

    }
}