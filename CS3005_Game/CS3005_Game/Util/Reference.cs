using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CS3005_Game.Util
{
    class Reference
    {
        /// <summary>
        /// How many pixels each grid square is by width and height.
        /// </summary>
        public static readonly int PIXELS_PER_GRID_SQUARE = (int)(16 * Config.screenScale);

        /// <summary>
        /// The action range of the player
        /// </summary>
        public static readonly float playerActionRange = PIXELS_PER_GRID_SQUARE * 1.5f;
        /// <summary>
        /// How many grid squares wide the Rooms will be.
        /// </summary>
        public static readonly int SCREEN_GRID_WIDTH = 17;
        /// <summary>
        /// How many grid squares high the Rooms will be.
        /// </summary>
        public static readonly int SCREEN_GRID_HEIGHT = 16;

        public static readonly int SCREEN_WIDTH = PIXELS_PER_GRID_SQUARE * SCREEN_GRID_WIDTH;
        public static readonly int SCREEN_HEIGHT = PIXELS_PER_GRID_SQUARE * SCREEN_GRID_HEIGHT;

        public static readonly String PATH_TEXTURES = "Textures/";
        public static readonly String PATH_FONTS = "Fonts/";
        public static readonly String PATH_SOUNDS = "Sounds/";
        public static readonly String SPRITESHEET = PATH_TEXTURES + "dungeon_sheet";
        public static readonly String SPRITE_PLAYER = PATH_TEXTURES + "players";
        public static readonly String SPRITE_NUMBER = PATH_TEXTURES + "NumFont";
        public static readonly String SPRITE_TOTEMNUM1 = PATH_TEXTURES + "NumDisplay_1";
        public static readonly String SPRITE_TOTEMNUM2 = PATH_TEXTURES + "NumDisplay_2";
        public static readonly String SPRITE_DEBUGSQUARE_YELLOW = PATH_TEXTURES + "squareYellow";
        public static readonly String SPRITE_DEBUGSQUARE_RED = PATH_TEXTURES + "squareRed";

        public static readonly Color WHITE = Color.White;
        public static readonly Color GREEN = new Color(145,176,154);
        public static readonly Color BG_GREY = new Color(64, 64, 64);

        public static readonly int PLAYER_START_X = ((int)Math.Floor(((double)SCREEN_GRID_WIDTH-1)/2)) * PIXELS_PER_GRID_SQUARE;
        public static readonly int PLAYER_START_Y = (SCREEN_GRID_HEIGHT - 4) * PIXELS_PER_GRID_SQUARE;
    }
}
