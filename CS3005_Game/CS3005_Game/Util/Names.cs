using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS3005_Game.Util
{
    /// <summary>
    /// Stores all the names of objects and things.
    /// </summary>
    class Names
    {
        public static class Rooms
        {
            public static readonly String ROOM_TITLE = "Level: ";
            public static readonly String LOBBY = "Lobby";
            public static readonly String LEVEL_1 = "One";
        }

        public static class Objects
        {
            public static readonly String GATE_EXIT = "Exit";
        }

        public static class Text
        {
            public static readonly String GAME_NAME = "Dungeon Solvers";
            public static readonly String LOBBY_TITLE = GAME_NAME;
            public static readonly String FPS = "FPS: ";

            public static readonly String MENU_PLAY = "Play!";
            public static readonly String MENU_CONTINUE = "Continue";
            public static readonly String MENU_LEVEL_SELECT = "Level Selection";
            public static readonly String MENU_BACK = "<- Back <-";
        }
    }
}
