using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS3005_Game.Environment;

namespace CS3005_Game
{
    /// <summary>
    /// Stores all the variable data for the current game session.
    /// </summary>
    class GameData
    {
        /// <summary>
        /// All of the created rooms, ready to be loaded and used.
        /// </summary>
        public static List<RoomBase> Rooms = new List<RoomBase>();
    }
}
