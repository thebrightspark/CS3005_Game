using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS3005_Game.Environment;
using CS3005_Game.Util;
using Microsoft.Xna.Framework.Graphics;

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
        /// <summary>
        /// The sprite sheet used to get textures from
        /// </summary>
        public static Texture2D SpriteSheet;
        /// <summary>
        /// Used for titles and other similar large text.
        /// Copperplate Gothic Bold.
        /// </summary>
        public static SpriteFont FontMain;
        public static ScreenText LobbyTitle;

        /// <summary>
        /// The currently loaded Room.
        /// Only 1 Room can be loaded at a time.
        /// </summary>
        private static RoomBase CurrentRoom;

        public static void addRoom(RoomBase room)
        {
            Rooms.Add(room);
        }

        /// <summary>
        /// Gets the specified Room by name.
        /// Returns null if Room isn't found.
        /// </summary>
        /// <param name="roomName"></param>
        /// <returns></returns>
        public static RoomBase getRoom(String roomName)
        {
            //Goes through the Rooms and gets the one matching the name specified
            for (int i = 0; i < Rooms.Count; ++i)
            {
                if (Rooms[i].getName().Equals(roomName))
                    return Rooms[i];
            }
            return null;
        }

        /// <summary>
        /// Returns the currently loaded Room.
        /// </summary>
        /// <returns></returns>
        public static RoomBase getCurrentRoom()
        {
            return CurrentRoom;
        }

        /// <summary>
        /// Sets the current Room to the one given.
        /// </summary>
        /// <param name="room"></param>
        public static void setCurrentRoom(String room)
        {
            RoomBase roomFound = getRoom(room);
            if (roomFound != null)
                CurrentRoom = roomFound;
        }
    }
}
