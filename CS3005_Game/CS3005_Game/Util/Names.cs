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
            public static readonly String LEVEL_SELECT = "Level Select";
            public static readonly String LEVEL_1 = "1";
        }

        public static class Objects
        {
            public static readonly String GATE_EXIT = "Exit";
            public static readonly String BUTTON = "Button";
            public static readonly String SWITCH = "Switch";
        }

        public static class Text
        {
            public static readonly String GAME_NAME = "Dungeon Solvers";
            public static readonly String FPS = "FPS: ";

            public static readonly String PLAYER_ACTION_INFO = "Press " + Config.keyAction.ToString() + " To Use";

            public static readonly String LOBBY_TITLE = "Main Menu";
            public static readonly String LOBBY_MENU_PLAY = "Play!";
            public static readonly String LOBBY_MENU_CONTINUE = "Continue";
            public static readonly String LOBBY_MENU_CHARACTER = "Change Character";
            public static readonly String LOBBY_MENU_LEVEL_SELECT = "Level Selection";
            public static readonly String LOBBY_MENU_BACK = "<- Back <-";
            public static readonly String LOBBY_INFO_GENDER = "Current Player Gender: ";
            public static readonly String LOBBY_CREDITS = "Thanks to Lanea Zimmerman for the player textures -> opengameart.org/content/tiny-16-basic \nAnd thanks to Buch for all the other textures -> opengameart.org/users/buch";

            public static readonly String LEVELSELECT_TITLE = Rooms.LEVEL_SELECT;

            public static readonly String LEVEL_COMPLETE = "Well Done!\n\nYou completed the demo level\nof this game!\n\nPress " + Config.keyAction.ToString() + " to go back to\nthe main menu.";

            public static readonly String LEVEL_1_INFO_1 = "To get through the exit gate,\n"+
                                                            "use the buttons to make the\n"+
                                                            "first two numbers equal the\n"+
                                                            "third when added together.";
            public static readonly String LEVEL_1_INFO_2 = "Exit Gate";
        }
    }
}
