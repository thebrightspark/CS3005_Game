using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS3005_Game.Environment
{
    /// <summary>
    /// Contains methods that Rooms must implement
    /// </summary>
    interface IRoom
    {
        /// <summary>
        /// This is called by the GameUpdate class when this Room is currently loaded.
        /// All code to check and do things should be done within this method.
        /// </summary>
        void update();
    }
}
