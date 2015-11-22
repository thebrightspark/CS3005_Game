using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS3005_Game.Environment;
using CS3005_Game.Util;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        private static Dictionary<String, RoomBase> Rooms = new Dictionary<String, RoomBase>();
        //public static List<RoomBase> Rooms = new List<RoomBase>();
        /// <summary>
        /// The sprite sheet used to get textures from
        /// </summary>
        public static Texture2D SpriteSheet;
        /// <summary>
        /// Plain texture to be used for single-coloured rectangles.
        /// </summary>
        public static Texture2D TexturePlain;
        /// <summary>
        /// Plain texture to be used for single-coloured rectangles which are semi-transparent.
        /// </summary>
        public static Texture2D TexturePlainAlpha;
        /// <summary>
        /// Used for titles and other similar large text.
        /// Copperplate Gothic Bold.
        /// </summary>
        public static SpriteFont FontMain;
        /// <summary>
        /// Used for game info around the edge of the screen.
        /// Copperplate Gothic Light.
        /// </summary>
        public static SpriteFont FontStats;
        /// <summary>
        /// Used for in-game text.
        /// Century Gothic (Bold)
        /// </summary>
        public static SpriteFont FontInfo;

        /// <summary>
        /// The currently loaded Room.
        /// Only 1 Room can be loaded at a time.
        /// </summary>
        private static RoomBase CurrentRoom;

        /// <summary>
        /// The keyboard state.
        /// </summary>
        public static KeyboardState keyboard = Keyboard.GetState();

        public static void addRoom(RoomBase room)
        {
            Rooms.Add(room.getName(), room);
            //Rooms.Add(room);
        }

        /// <summary>
        /// Gets the specified Room by name.
        /// Returns null if Room isn't found.
        /// </summary>
        /// <param name="roomName"></param>
        /// <returns></returns>
        public static RoomBase getRoom(String roomName)
        {
            if (Rooms.ContainsKey(roomName))
                return Rooms[roomName];
            else
                return null;

            //Goes through the Rooms and gets the one matching the name specified
            /*
            for (int i = 0; i < Rooms.Count; ++i)
            {
                if (Rooms[i].getName().Equals(roomName))
                    return Rooms[i];
            }
            return null;
            */
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
            else
                new Exception("Room " + room + " does not exist!");
        }
    }
}
