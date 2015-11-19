using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CS3005_Game.Environment;
using CS3005_Game.Util;

namespace CS3005_Game
{
    /// <summary>
    /// This class is used to draw everything on the screen
    /// </summary>
    class GameDraw
    {
        /// <summary>
        /// Local Room name for this class to know when the Room has been changed
        /// </summary>
        private static String roomName = null;
        private static Sprite2D[,] roomBgSprites;

        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);

            RoomBase curRoom = GameData.getCurrentRoom();

            //Create the Rectangles for the current Room if the Room has changed
            if (curRoom != null && !curRoom.getName().Equals(roomName))
            {
                //Set local Room name to new Room name
                roomName = curRoom.getName();
                //Create new Rectangle array
                roomBgSprites = new Sprite2D[Reference.SCREEN_GRID_WIDTH, Reference.SCREEN_GRID_HEIGHT];

                //Populate the Sprite2D array
                TextureManager.DUNGEON_SPRITES[,] curRoomTexture = curRoom.getBackgroundTexture();
                int arrayWidth = curRoomTexture.GetLength(1);
                int arrayHeight = curRoomTexture.GetLength(0);
                for (int y = 0; y < arrayHeight; y++)
                {
                    for (int x = 0; x < arrayWidth; x++)
                    {
                        Sprite2D sprite = new Sprite2D(GameData.SpriteSheet, curRoomTexture[x,y], x * Reference.SCREEN_GRID_WIDTH, y * Reference.SCREEN_GRID_HEIGHT);
                        roomBgSprites[x, y] = sprite;

                        int spriteWidth = sprite.getSpriteWidth() / Reference.PIXELS_PER_GRID_SQUARE;
                        //If the width takes up more than on grid square in width, then skip the next squares
                        if(spriteWidth > 1)
                            x += spriteWidth - 1;
                    }
                }
            }

            //Draw the background
            for (int y = 0; y < roomBgSprites.GetLength(1); y++)
            {
                for (int x = 0; x < roomBgSprites.GetLength(0); x++)
                {
                    roomBgSprites[x, y].Draw(spriteBatch);
                }
            }

            //Draw the text
            GameData.LobbyTitle.DrawCentered(spriteBatch, 10);

            spriteBatch.End();
        }
    }
}
