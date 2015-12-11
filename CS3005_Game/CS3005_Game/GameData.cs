using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS3005_Game.Environment;
using CS3005_Game.Util;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CS3005_Game.Entity;

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
        /// The sprite sheet used to get textures from.
        /// </summary>
        public static Texture2D SpriteSheet;
        /// <summary>
        /// The sprite sheet used to get player textures from.
        /// </summary>
        public static Texture2D PlayerSpriteSheet;
        /// <summary>
        /// The sprite sheet used to get number textures from.
        /// </summary>
        public static Texture2D NumberSpriteSheet;
        /// <summary>
        /// The texture for the totem to show 1 digit.
        /// </summary>
        public static Texture2D Totem1SpriteSheet;
        /// <summary>
        /// The texture for the totem to show 2 digits.
        /// </summary>
        public static Texture2D Totem2SpriteSheet;

        public static Texture2D DebugSquareYellow;
        public static Texture2D DebugSquareRed;

        /// <summary>
        /// Plain texture to be used for single-coloured rectangles.
        /// </summary>
        public static Texture2D TexturePlain;
        /// <summary>
        /// Plain texture to be used for single-coloured rectangles which are semi-transparent.
        /// </summary>
        public static Texture2D TexturePlainAlpha;
        public static Texture2D TexturePlainAlphaDarker;
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
        /// Smaller version of FontInfo.
        /// </summary>
        public static SpriteFont FontInfoS;

        /// <summary>
        /// The currently loaded Room.
        /// Only 1 Room can be loaded at a time.
        /// </summary>
        private static RoomBase CurrentRoom;


        public static Player player;

        /// <summary>
        /// The keyboard state.
        /// </summary>
        public static KeyboardState keyboard = Keyboard.GetState();

        /// <summary>
        /// How many Rooms have been completed.
        /// </summary>
        public static int RoomsCleared = 0;

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
        /// Returns the amount of registered Rooms.
        /// </summary>
        /// <returns></returns>
        public static int getNumRooms()
        {
            return Rooms.Count;
        }

        /// <summary>
        /// Counts and returns the amount of registered levels.
        /// </summary>
        /// <returns></returns>
        public static int getNumLevels()
        {
            int numLevels = 0;
            foreach(RoomBase r in Rooms.Values)
            {
                if (r is RoomLevelBase)
                    numLevels++;
            }
            return numLevels;
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
