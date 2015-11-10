using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS3005_Game.Util
{
    class Reference
    {
        public static readonly String GAME_NAME = "CS3005 Game!";

        /// <summary>
        /// How many pixels each grid square is by width and height.
        /// </summary>
        public static readonly int PIXELS_PER_GRID_SQUARE = 16;
        /// <summary>
        /// How many grid squares wide the Rooms will be.
        /// </summary>
        public static readonly int SCREEN_GRID_WIDTH = 16;
        /// <summary>
        /// How many grid squares high the Rooms will be.
        /// </summary>
        public static readonly int SCREEN_GRID_HEIGHT = 16;
        public static readonly int SCREEN_WIDTH = PIXELS_PER_GRID_SQUARE * SCREEN_GRID_WIDTH;
        public static readonly int SCREEN_HEIGHT = PIXELS_PER_GRID_SQUARE * SCREEN_GRID_HEIGHT;

        public static readonly String PATH_TEXTURES = "Textures/";
    }
}
