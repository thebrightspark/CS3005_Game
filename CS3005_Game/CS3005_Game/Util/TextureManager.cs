using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using CS3005_Game.Util;

namespace CS3005_Game.Util
{
    class TextureManager
    {
        private static int SpriteWidth = 16;
        private static int SpriteHeight = 16;

        private static int NumSpriteWidth = 8;
        private static int NumSpriteHeight = 12;

        /// <summary>
        /// An enum of all the number sprite names.
        /// </summary>
        public enum NUMBER_SPRITES
        {
            N1,
            N2,
            N3,
            N4,
            N5,
            N6,
            N7,
            N8,
            N9,
            N0
        }

        /// <summary>
        /// An enum of all the player sprite names.
        /// </summary>
        public enum PLAYER_SPRITES
        {
            M_UP_1,
            M_UP_2,
            M_UP_3,
            M_DOWN_1,
            M_DOWN_2,
            M_DOWN_3,
            M_LEFT_1,
            M_LEFT_2,
            M_LEFT_3,
            M_RIGHT_1,
            M_RIGHT_2,
            M_RIGHT_3,
            F_UP_1,
            F_UP_2,
            F_UP_3,
            F_DOWN_1,
            F_DOWN_2,
            F_DOWN_3,
            F_LEFT_1,
            F_LEFT_2,
            F_LEFT_3,
            F_RIGHT_1,
            F_RIGHT_2,
            F_RIGHT_3,
        }

        /// <summary>
        /// An enum of all the room sprite names.
        /// Use these in conjunction with getSpriteRect()!
        /// </summary>
        public enum DUNGEON_SPRITES
        {
            NULL,
            PLAIN_GREEN,
            PLAIN_BLACK,
            WALL_TL,
            WALL_T,
            WALL_TR,
            WALL_R,
            WALL_BR,
            WALL_B,
            WALL_BL,
            WALL_L,
            TOTEM_1,
            TOTEM_2,
            TOTEM_3,
            TOTEM_4,
            TOTEM_5,
            TOTEM_6,
            TOTEM_7,
            GATE_1,
            GATE_2,
            GATE_3,
            GATE_4,
            GATE_5,
            BLOCK_1,
            BLOCK_2,
            BLOCK_3,
            BLOCK_4,
            BLOCK_5,
            BLOCK_6,
            BLOCK_7,
            BLOCK_SMALL_1,
            BLOCK_SMALL_2,
            BLOCK_SMALL_3,
            BLOCK_SMALL_4,
            BLOCK_SMALL_5,
            BLOCK_SMALL_6,
            BLOCK_SMALL_7,
            BUTTON_1,
            BUTTON_2,
            BUTTON_3,
            BUTTON_4,
            BUTTON_5,
            BEACON_1,
            BEACON_2,
            BEACON_3,
            BEACON_4,
            BEACON_5,
            SWITCH_1,
            SWITCH_2,
            SWITCH_3,
            SWITCH_4,
            SWITCH_5,
            SWITCH_6,
            SWITCH_7
        }

        /// <summary>
        /// A Dictionary (key value pair list) of all the room sprites' rectangles.
        /// This is populated in the init() method.
        /// </summary>
        private static Dictionary<DUNGEON_SPRITES, Rectangle> RoomSprites = new Dictionary<DUNGEON_SPRITES, Rectangle>();

        /// <summary>
        /// A Dictionary (key value pair list) of all the player sprites' rectangles.
        /// This is populated in the init() method.
        /// </summary>
        private static Dictionary<PLAYER_SPRITES, Rectangle> PlayerSprites = new Dictionary<PLAYER_SPRITES, Rectangle>();

        /// <summary>
        /// A Dictionary (key value pair list) of all the number sprites' rectangles.
        /// This is populated in the init() method.
        /// </summary>
        private static Dictionary<NUMBER_SPRITES, Rectangle> NumberSprites = new Dictionary<NUMBER_SPRITES, Rectangle>();

        /// <summary>
        /// The preset background array for a Room.
        /// Consists of PLAIN_BLACK around the outside, then WALLs with PLAIN_GREEN filling the center.
        /// This is populated in the init() method.
        /// </summary>
        public static DUNGEON_SPRITES[,] PRESET_BG;

        //Dungeon Sprites:
        public static DUNGEON_SPRITES[] GateSprites = {DUNGEON_SPRITES.GATE_1, DUNGEON_SPRITES.GATE_2, DUNGEON_SPRITES.GATE_3, DUNGEON_SPRITES.GATE_4, DUNGEON_SPRITES.GATE_5};
        public static DUNGEON_SPRITES[] SwitchSprites = {DUNGEON_SPRITES.SWITCH_7, DUNGEON_SPRITES.SWITCH_6, DUNGEON_SPRITES.SWITCH_5, DUNGEON_SPRITES.SWITCH_4, DUNGEON_SPRITES.SWITCH_3, DUNGEON_SPRITES.SWITCH_2, DUNGEON_SPRITES.SWITCH_1 };
        //public static DUNGEON_SPRITES[] TotemSprites = {DUNGEON_SPRITES.TOTEM_1, DUNGEON_SPRITES.TOTEM_2, DUNGEON_SPRITES.TOTEM_3, DUNGEON_SPRITES.TOTEM_4, DUNGEON_SPRITES.TOTEM_5, DUNGEON_SPRITES.TOTEM_6, DUNGEON_SPRITES.TOTEM_7};
        //Players sprites:
        public static PLAYER_SPRITES[] MPlayerUpSprites = {PLAYER_SPRITES.M_UP_1, PLAYER_SPRITES.M_UP_2, PLAYER_SPRITES.M_UP_3};
        public static PLAYER_SPRITES[] MPlayerDownSprites = { PLAYER_SPRITES.M_DOWN_1, PLAYER_SPRITES.M_DOWN_2, PLAYER_SPRITES.M_DOWN_3 };
        public static PLAYER_SPRITES[] MPlayerLeftSprites = { PLAYER_SPRITES.M_LEFT_1, PLAYER_SPRITES.M_LEFT_2, PLAYER_SPRITES.M_LEFT_3 };
        public static PLAYER_SPRITES[] MPlayerRightSprites = { PLAYER_SPRITES.M_RIGHT_1, PLAYER_SPRITES.M_RIGHT_2, PLAYER_SPRITES.M_RIGHT_3 };
        public static PLAYER_SPRITES[] FPlayerUpSprites = { PLAYER_SPRITES.F_UP_1, PLAYER_SPRITES.F_UP_2, PLAYER_SPRITES.F_UP_3 };
        public static PLAYER_SPRITES[] FPlayerDownSprites = { PLAYER_SPRITES.F_DOWN_1, PLAYER_SPRITES.F_DOWN_2, PLAYER_SPRITES.F_DOWN_3 };
        public static PLAYER_SPRITES[] FPlayerLeftSprites = { PLAYER_SPRITES.F_LEFT_1, PLAYER_SPRITES.F_LEFT_2, PLAYER_SPRITES.F_LEFT_3 };
        public static PLAYER_SPRITES[] FPlayerRightSprites = { PLAYER_SPRITES.F_RIGHT_1, PLAYER_SPRITES.F_RIGHT_2, PLAYER_SPRITES.F_RIGHT_3 };


        public static Point getTileSize(DUNGEON_SPRITES sprite)
        {
            switch (sprite)
            {
                case DUNGEON_SPRITES.TOTEM_1:
                case DUNGEON_SPRITES.TOTEM_2:
                case DUNGEON_SPRITES.TOTEM_3:
                case DUNGEON_SPRITES.TOTEM_4:
                case DUNGEON_SPRITES.TOTEM_5:
                case DUNGEON_SPRITES.TOTEM_6:
                case DUNGEON_SPRITES.TOTEM_7:
                    //Totems are 2x3
                    return new Point(2, 3);
                case DUNGEON_SPRITES.GATE_1:
                case DUNGEON_SPRITES.GATE_2:
                case DUNGEON_SPRITES.GATE_3:
                case DUNGEON_SPRITES.GATE_4:
                case DUNGEON_SPRITES.GATE_5:
                    //Gates are 3x2
                    return new Point(3, 2);
                case DUNGEON_SPRITES.WALL_TL:
                case DUNGEON_SPRITES.WALL_T:
                case DUNGEON_SPRITES.WALL_TR:
                    //Top Walls are 1x2
                    return new Point(1, 2);
                default:
                    //1x1
                    return new Point(1, 1);
            }
        }

        /// <summary>
        /// Creates and returns a Rectangle for the exact position of a sprite on the spritesheet.
        /// </summary>
        /// <param name="sprite"></param>
        /// <returns></returns>
        private static Rectangle getRoomTextureRect(DUNGEON_SPRITES sprite)
        {
            int rectWidth, rectHeight;
            int rectX = -1;
            int rectY = -1;

            //Make the Rectangle the right size for the sprite to be loaded
            Point tileSize = getTileSize(sprite);
            
            //Get the sprite's location on the spritesheet
            // x
            switch (sprite)
            {
                case DUNGEON_SPRITES.SWITCH_1:
                case DUNGEON_SPRITES.GATE_1:
                    rectX = 0;
                    break;
                case DUNGEON_SPRITES.PLAIN_BLACK:
                case DUNGEON_SPRITES.SWITCH_2:
                    rectX = 1;
                    break;
                case DUNGEON_SPRITES.SWITCH_3:
                    rectX = 2;
                    break;
                case DUNGEON_SPRITES.SWITCH_4:
                case DUNGEON_SPRITES.GATE_2:
                    rectX = 3;
                    break;
                case DUNGEON_SPRITES.SWITCH_5:
                    rectX = 4;
                    break;
                case DUNGEON_SPRITES.WALL_TL:
                case DUNGEON_SPRITES.WALL_L:
                case DUNGEON_SPRITES.WALL_BL:
                case DUNGEON_SPRITES.SWITCH_6:
                case DUNGEON_SPRITES.BLOCK_SMALL_1:
                    rectX = 5;
                    break;
                case DUNGEON_SPRITES.WALL_T:
                case DUNGEON_SPRITES.PLAIN_GREEN:
                case DUNGEON_SPRITES.WALL_B:
                case DUNGEON_SPRITES.SWITCH_7:
                case DUNGEON_SPRITES.BLOCK_SMALL_2:
                case DUNGEON_SPRITES.GATE_3:
                    rectX = 6;
                    break;
                case DUNGEON_SPRITES.WALL_TR:
                case DUNGEON_SPRITES.WALL_R:
                case DUNGEON_SPRITES.WALL_BR:
                case DUNGEON_SPRITES.BLOCK_SMALL_3:
                    rectX = 7;
                    break;
                case DUNGEON_SPRITES.BLOCK_1:
                    rectX = 8;
                    break;
                case DUNGEON_SPRITES.BLOCK_2:
                case DUNGEON_SPRITES.GATE_4:
                    rectX = 9;
                    break;
                case DUNGEON_SPRITES.TOTEM_1:
                case DUNGEON_SPRITES.BLOCK_3:
                    rectX = 10;
                    break;
                case DUNGEON_SPRITES.BLOCK_SMALL_4:
                    rectX = 11;
                    break;
                case DUNGEON_SPRITES.TOTEM_2:
                case DUNGEON_SPRITES.BLOCK_SMALL_5:
                case DUNGEON_SPRITES.GATE_5:
                    rectX = 12;
                    break;
                case DUNGEON_SPRITES.BLOCK_4:
                    rectX = 13;
                    break;
                case DUNGEON_SPRITES.TOTEM_3:
                case DUNGEON_SPRITES.BLOCK_5:
                    rectX = 14;
                    break;
                case DUNGEON_SPRITES.BLOCK_SMALL_6:
                    rectX = 15;
                    break;
                case DUNGEON_SPRITES.TOTEM_4:
                case DUNGEON_SPRITES.BLOCK_SMALL_7:
                    rectX = 16;
                    break;
                case DUNGEON_SPRITES.BLOCK_6:
                    rectX = 17;
                    break;
                case DUNGEON_SPRITES.TOTEM_5:
                case DUNGEON_SPRITES.BLOCK_7:
                    rectX = 18;
                    break;
                case DUNGEON_SPRITES.BUTTON_1:
                case DUNGEON_SPRITES.BEACON_1:
                    rectX = 20;
                    break;
                case DUNGEON_SPRITES.TOTEM_6:
                case DUNGEON_SPRITES.BUTTON_2:
                case DUNGEON_SPRITES.BEACON_2:
                    rectX = 21;
                    break;
                case DUNGEON_SPRITES.BUTTON_3:
                case DUNGEON_SPRITES.BEACON_3:
                    rectX = 22;
                    break;
                case DUNGEON_SPRITES.TOTEM_7:
                case DUNGEON_SPRITES.BUTTON_4:
                case DUNGEON_SPRITES.BEACON_4:
                    rectX = 23;
                    break;
                case DUNGEON_SPRITES.BUTTON_5:
                case DUNGEON_SPRITES.BEACON_5:
                    rectX = 24;
                    break;
            }

            // y
            switch(sprite)
            {
                case DUNGEON_SPRITES.WALL_TL:
                case DUNGEON_SPRITES.WALL_T:
                case DUNGEON_SPRITES.WALL_TR:
                    rectY = 0;
                    break;
                case DUNGEON_SPRITES.PLAIN_BLACK:
                    rectY = 1;
                    break;
                case DUNGEON_SPRITES.WALL_L:
                case DUNGEON_SPRITES.PLAIN_GREEN:
                case DUNGEON_SPRITES.WALL_R:
                    rectY = 2;
                    break;
                case DUNGEON_SPRITES.WALL_BL:
                case DUNGEON_SPRITES.WALL_B:
                case DUNGEON_SPRITES.WALL_BR:
                case DUNGEON_SPRITES.TOTEM_1:
                case DUNGEON_SPRITES.TOTEM_2:
                case DUNGEON_SPRITES.TOTEM_3:
                case DUNGEON_SPRITES.TOTEM_4:
                case DUNGEON_SPRITES.TOTEM_5:
                case DUNGEON_SPRITES.TOTEM_6:
                case DUNGEON_SPRITES.TOTEM_7:
                    rectY = 3;
                    break;
                case DUNGEON_SPRITES.SWITCH_1:
                case DUNGEON_SPRITES.SWITCH_2:
                case DUNGEON_SPRITES.SWITCH_3:
                case DUNGEON_SPRITES.SWITCH_4:
                case DUNGEON_SPRITES.SWITCH_5:
                case DUNGEON_SPRITES.SWITCH_6:
                case DUNGEON_SPRITES.SWITCH_7:
                    rectY = 5;
                    break;
                case DUNGEON_SPRITES.BLOCK_SMALL_1:
                case DUNGEON_SPRITES.BLOCK_SMALL_2:
                case DUNGEON_SPRITES.BLOCK_SMALL_3:
                case DUNGEON_SPRITES.BLOCK_1:
                case DUNGEON_SPRITES.BLOCK_2:
                case DUNGEON_SPRITES.BLOCK_3:
                case DUNGEON_SPRITES.BLOCK_SMALL_4:
                case DUNGEON_SPRITES.BLOCK_SMALL_5:
                case DUNGEON_SPRITES.BLOCK_4:
                case DUNGEON_SPRITES.BLOCK_5:
                case DUNGEON_SPRITES.BLOCK_SMALL_6:
                case DUNGEON_SPRITES.BLOCK_SMALL_7:
                case DUNGEON_SPRITES.BLOCK_6:
                case DUNGEON_SPRITES.BLOCK_7:
                case DUNGEON_SPRITES.BUTTON_1:
                case DUNGEON_SPRITES.BUTTON_2:
                case DUNGEON_SPRITES.BUTTON_3:
                case DUNGEON_SPRITES.BUTTON_4:
                case DUNGEON_SPRITES.BUTTON_5:
                    rectY = 6;
                    break;
                case DUNGEON_SPRITES.BEACON_1:
                case DUNGEON_SPRITES.BEACON_2:
                case DUNGEON_SPRITES.BEACON_3:
                case DUNGEON_SPRITES.BEACON_4:
                case DUNGEON_SPRITES.BEACON_5:
                    rectY = 7;
                    break;
                case DUNGEON_SPRITES.GATE_1:
                case DUNGEON_SPRITES.GATE_2:
                case DUNGEON_SPRITES.GATE_3:
                case DUNGEON_SPRITES.GATE_4:
                case DUNGEON_SPRITES.GATE_5:
                    rectY = 8;
                    break;
            }

            //Incase I missed assigning the sprite a location above
            if(rectX == -1 || rectY == -1)
                throw new Exception("Sprite location has not been specified!");

            return new Rectangle(rectX * SpriteWidth, rectY * SpriteHeight, tileSize.X * SpriteWidth, tileSize.Y * SpriteHeight);
        }


        /// <summary>
        /// Creates and returns a Rectangle for the exact position of a player sprite on the spritesheet.
        /// </summary>
        /// <param name="sprite"></param>
        /// <returns></returns>
        private static Rectangle getPlayerTextureRect(PLAYER_SPRITES sprite)
        {
            int rectWidth = SpriteWidth;
            int rectHeight = SpriteHeight;
            int rectX = -1;
            int rectY = -1;

            //x
            switch (sprite)
            {
                case PLAYER_SPRITES.M_DOWN_1:
                case PLAYER_SPRITES.M_LEFT_1:
                case PLAYER_SPRITES.M_RIGHT_1:
                case PLAYER_SPRITES.M_UP_1:
                    rectX = 0;
                    break;
                case PLAYER_SPRITES.M_DOWN_2:
                case PLAYER_SPRITES.M_LEFT_2:
                case PLAYER_SPRITES.M_RIGHT_2:
                case PLAYER_SPRITES.M_UP_2:
                    rectX = 1;
                    break;
                case PLAYER_SPRITES.M_DOWN_3:
                case PLAYER_SPRITES.M_LEFT_3:
                case PLAYER_SPRITES.M_RIGHT_3:
                case PLAYER_SPRITES.M_UP_3:
                    rectX = 2;
                    break;
                case PLAYER_SPRITES.F_DOWN_1:
                case PLAYER_SPRITES.F_LEFT_1:
                case PLAYER_SPRITES.F_RIGHT_1:
                case PLAYER_SPRITES.F_UP_1:
                    rectX = 3;
                    break;
                case PLAYER_SPRITES.F_DOWN_2:
                case PLAYER_SPRITES.F_LEFT_2:
                case PLAYER_SPRITES.F_RIGHT_2:
                case PLAYER_SPRITES.F_UP_2:
                    rectX = 4;
                    break;
                case PLAYER_SPRITES.F_DOWN_3:
                case PLAYER_SPRITES.F_LEFT_3:
                case PLAYER_SPRITES.F_RIGHT_3:
                case PLAYER_SPRITES.F_UP_3:
                    rectX = 5;
                    break;
            }

            //y
            switch (sprite)
            {
                case PLAYER_SPRITES.M_DOWN_1:
                case PLAYER_SPRITES.M_DOWN_2:
                case PLAYER_SPRITES.M_DOWN_3:
                case PLAYER_SPRITES.F_DOWN_1:
                case PLAYER_SPRITES.F_DOWN_2:
                case PLAYER_SPRITES.F_DOWN_3:
                    rectY = 0;
                    break;
                case PLAYER_SPRITES.M_LEFT_1:
                case PLAYER_SPRITES.M_LEFT_2:
                case PLAYER_SPRITES.M_LEFT_3:
                case PLAYER_SPRITES.F_LEFT_1:
                case PLAYER_SPRITES.F_LEFT_2:
                case PLAYER_SPRITES.F_LEFT_3:
                    rectY = 1;
                    break;
                case PLAYER_SPRITES.M_RIGHT_1:
                case PLAYER_SPRITES.M_RIGHT_2:
                case PLAYER_SPRITES.M_RIGHT_3:
                case PLAYER_SPRITES.F_RIGHT_1:
                case PLAYER_SPRITES.F_RIGHT_2:
                case PLAYER_SPRITES.F_RIGHT_3:
                    rectY = 2;
                    break;
                case PLAYER_SPRITES.M_UP_1:
                case PLAYER_SPRITES.M_UP_2:
                case PLAYER_SPRITES.M_UP_3:
                case PLAYER_SPRITES.F_UP_1:
                case PLAYER_SPRITES.F_UP_2:
                case PLAYER_SPRITES.F_UP_3:
                    rectY = 3;
                    break;
            }

            //Incase I missed assigning the sprite a location above
            if (rectX == -1 || rectY == -1)
                throw new Exception("Sprite location has not been specified!");

            return new Rectangle(rectX * SpriteWidth, rectY * SpriteHeight, rectWidth, rectHeight);
        }

        /// <summary>
        /// Creates and returns a Rectangle for the exact position of a number sprite on the spritesheet.
        /// </summary>
        /// <param name="sprite"></param>
        /// <returns></returns>
        private static Rectangle getNumberTextureRect(NUMBER_SPRITES sprite)
        {
            int rectWidth = NumSpriteWidth;
            int rectHeight = NumSpriteHeight;
            int rectX = -1;
            int rectY = -1;

            //x
            switch (sprite)
            {
                case NUMBER_SPRITES.N1:
                case NUMBER_SPRITES.N6:
                    rectX = 0;
                    break;
                case NUMBER_SPRITES.N2:
                case NUMBER_SPRITES.N7:
                    rectX = 1;
                    break;
                case NUMBER_SPRITES.N3:
                case NUMBER_SPRITES.N8:
                    rectX = 2;
                    break;
                case NUMBER_SPRITES.N4:
                case NUMBER_SPRITES.N9:
                    rectX = 3;
                    break;
                case NUMBER_SPRITES.N5:
                case NUMBER_SPRITES.N0:
                    rectX = 4;
                    break;
            }

            //y
            switch (sprite)
            {
                case NUMBER_SPRITES.N1:
                case NUMBER_SPRITES.N2:
                case NUMBER_SPRITES.N3:
                case NUMBER_SPRITES.N4:
                case NUMBER_SPRITES.N5:
                    rectY = 0;
                    break;
                case NUMBER_SPRITES.N6:
                case NUMBER_SPRITES.N7:
                case NUMBER_SPRITES.N8:
                case NUMBER_SPRITES.N9:
                case NUMBER_SPRITES.N0:
                    rectY = 1;
                    break;
            }

            //Incase I missed assigning the sprite a location above
            if (rectX == -1 || rectY == -1)
                throw new Exception("Sprite location has not been specified!");

            return new Rectangle(rectX * NumSpriteWidth, rectY * NumSpriteHeight, rectWidth, rectHeight);
        }

        /// <summary>
        /// Populates the Dictionary for the sprites.
        /// Run this during the LoadContent() method!
        /// </summary>
        /// <param name="graphics"></param>
        public static void init()
        {
            Console.WriteLine("Initializing Textures!");

            //Goes through the spite names and creates a Texture2D for each.
            //Then adds them to the Dictionary to reference later.
            foreach(DUNGEON_SPRITES s in Enum.GetValues(typeof(DUNGEON_SPRITES)))
            {
                if (s == DUNGEON_SPRITES.NULL)
                    continue;
                RoomSprites.Add(s, getRoomTextureRect(s));
            }

            //Does the same for the player sprites
            foreach (PLAYER_SPRITES s in Enum.GetValues(typeof(PLAYER_SPRITES)))
            {
                PlayerSprites.Add(s, getPlayerTextureRect(s));
            }

            //Does the same for the number sprites
            foreach (NUMBER_SPRITES s in Enum.GetValues(typeof(NUMBER_SPRITES)))
            {
                NumberSprites.Add(s, getNumberSpriteRect(s));
            }

            //Creates the PRESET_BG 2D array.
            PRESET_BG = new DUNGEON_SPRITES[Reference.SCREEN_GRID_WIDTH, Reference.SCREEN_GRID_HEIGHT];
            int BGwidth = PRESET_BG.GetLength(0);
            int BGheight = PRESET_BG.GetLength(1);
            for (int j = 0; j < BGheight; ++j)
            {
                for (int i = 0; i < BGwidth; ++i)
                {
                    //Outer edge -> PLAIN_BLACK
                    if (i == 0 || i == BGwidth - 1 || j == 0 || j == BGheight - 1)
                        PRESET_BG[i, j] = DUNGEON_SPRITES.PLAIN_BLACK;
                    //Wall -> Top Left
                    else if (i == 1 && j == 1)
                        PRESET_BG[i, j] = DUNGEON_SPRITES.WALL_TL;
                    //Wall -> Top Right
                    else if (i == BGwidth - 2 && j == 1)
                        PRESET_BG[i, j] = DUNGEON_SPRITES.WALL_TR;
                    //Wall -> Bottom Left
                    else if (i == 1 && j == BGheight - 2)
                        PRESET_BG[i, j] = DUNGEON_SPRITES.WALL_BL;
                    //Wall -> Bottom Right
                    else if (i == BGwidth - 2 && j == BGheight - 2)
                        PRESET_BG[i, j] = DUNGEON_SPRITES.WALL_BR;
                    //Wall -> Top Side
                    else if (i > 1 && i < BGwidth - 2 && j == 1)
                        PRESET_BG[i, j] = DUNGEON_SPRITES.WALL_T;
                    //Wall -> Left Side
                    else if (i == 1 && j > 2 && j < BGheight - 2)
                        PRESET_BG[i, j] = DUNGEON_SPRITES.WALL_L;
                    //Wall -> Right Side
                    else if (i == BGwidth - 2 && j > 2 && j < BGheight - 2)
                        PRESET_BG[i, j] = DUNGEON_SPRITES.WALL_R;
                    //Wall -> Bottom Side
                    else if (i > 1 && i < BGwidth - 2 && j == BGheight - 2)
                        PRESET_BG[i, j] = DUNGEON_SPRITES.WALL_B;
                    //Inner -> PLAIN_GREEN
                    else
                        PRESET_BG[i, j] = DUNGEON_SPRITES.NULL;
                    //Console.WriteLine("PRESET_BG [" + i + "," + j + "] -> " + PRESET_BG[i,j].ToString());
                }
            }
        }

        /// <summary>
        /// Gets a Rectangle used to specify the exact location of a given sprite on the spritesheet.
        /// Pass this Rectangle into the Sprite2D.Create() method!
        /// </summary>
        /// <param name="sprite">Name of the sprite to get rectangle of</param>
        /// <returns>Returns an empty Rectangle if sprite name not found</returns>
        public static Rectangle getRoomSpriteRect(DUNGEON_SPRITES sprite)
        {
            if (RoomSprites.ContainsKey(sprite))
                return RoomSprites[sprite];
            return new Rectangle();
        }

        /// <summary>
        /// Gets a Rectangle used to specify the exact location of a given player sprite on the spritesheet.
        /// </summary>
        /// <param name="sprite">Name of the sprite to get rectangle of</param>
        /// <returns>Returns an empty Rectangle if sprite name not found</returns>
        public static Rectangle getPlayerSpriteRect(PLAYER_SPRITES sprite)
        {
            if (PlayerSprites.ContainsKey(sprite))
                return PlayerSprites[sprite];
            return new Rectangle();
        }

        /// <summary>
        /// Gets a Rectangle used to specify the exact location of a given number sprite on the spritesheet.
        /// </summary>
        /// <param name="sprite">Name of the sprite to get rectangle of</param>
        /// <returns>Returns an empty Rectangle if sprite name not found</returns>
        public static Rectangle getNumberSpriteRect(NUMBER_SPRITES sprite)
        {
            if (NumberSprites.ContainsKey(sprite))
                return NumberSprites[sprite];
            return new Rectangle();
        }
    }
}
