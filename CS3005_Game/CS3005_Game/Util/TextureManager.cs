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

        /// <summary>
        /// An enum of all the sprite names.
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
        /// A Dictionary (key value pair list) of all the sprites' rectangles.
        /// This is populated in the init() method.
        /// </summary>
        private static Dictionary<DUNGEON_SPRITES, Rectangle> Sprites = new Dictionary<DUNGEON_SPRITES, Rectangle>();

        /// <summary>
        /// The preset background array for a Room.
        /// Consists of PLAIN_BLACK around the outside, then WALLs with PLAIN_GREEN filling the center.
        /// This is populated in the init() method.
        /// </summary>
        public static DUNGEON_SPRITES[,] PRESET_BG;

        public static DUNGEON_SPRITES[] GateSprites = {DUNGEON_SPRITES.GATE_1, DUNGEON_SPRITES.GATE_2, DUNGEON_SPRITES.GATE_3, DUNGEON_SPRITES.GATE_4, DUNGEON_SPRITES.GATE_5};

        /// <summary>
        /// Creates and returns a Rectangle for the exact position of a sprite on the spritesheet.
        /// </summary>
        /// <param name="sprite"></param>
        /// <returns></returns>
        private static Rectangle getTextureRect(DUNGEON_SPRITES sprite)
        {
            int rectWidth, rectHeight;
            int rectX = -1;
            int rectY = -1;

            //Make the Rectangle the right size for the sprite to be loaded
            switch(sprite)
            {
                case DUNGEON_SPRITES.TOTEM_1:
                case DUNGEON_SPRITES.TOTEM_2:
                case DUNGEON_SPRITES.TOTEM_3:
                case DUNGEON_SPRITES.TOTEM_4:
                case DUNGEON_SPRITES.TOTEM_5:
                case DUNGEON_SPRITES.TOTEM_6:
                case DUNGEON_SPRITES.TOTEM_7:
                    //Totems are 2x3
                    rectWidth = SpriteWidth * 2;
                    rectHeight = SpriteHeight * 3;
                    break;
                case DUNGEON_SPRITES.GATE_1:
                case DUNGEON_SPRITES.GATE_2:
                case DUNGEON_SPRITES.GATE_3:
                case DUNGEON_SPRITES.GATE_4:
                case DUNGEON_SPRITES.GATE_5:
                    //Gates are 3x2
                    rectWidth = SpriteWidth * 3;
                    rectHeight = SpriteHeight * 2;
                    break;
                case DUNGEON_SPRITES.WALL_TL:
                case DUNGEON_SPRITES.WALL_T:
                case DUNGEON_SPRITES.WALL_TR:
                    //Top Walls are 1x2
                    rectWidth = SpriteWidth;
                    rectHeight = SpriteHeight * 2;
                    break;
                default:
                    //1x1
                    rectWidth = SpriteWidth;
                    rectHeight = SpriteHeight;
                    break;
            }
            
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

            return new Rectangle(rectX * SpriteWidth, rectY * SpriteHeight, rectWidth, rectHeight);
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
                Sprites.Add(s, getTextureRect(s));
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
                    Console.WriteLine("PRESET_BG [" + i + "," + j + "] -> " + PRESET_BG[i,j].ToString());
                }
            }
        }

        /// <summary>
        /// Gets a Rectangle used to specify the exact location of a given sprite on the spritesheet.
        /// Pass this Rectangle into the Sprite2D.Create() method!
        /// </summary>
        /// <param name="sprite">Name of the sprite to get rectangle of</param>
        /// <returns>Returns an empty Rectangle if sprite name not found</returns>
        public static Rectangle getSpriteRect(DUNGEON_SPRITES sprite)
        {
            if (Sprites.ContainsKey(sprite))
                return Sprites[sprite];
            return new Rectangle();
        }
    }
}
