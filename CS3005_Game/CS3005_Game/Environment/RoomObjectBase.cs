using CS3005_Game.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS3005_Game.Environment
{
    /// <summary>
    /// Base class for an object within a room.
    /// </summary>
    abstract class RoomObjectBase
    {
        //private int XPos, YPos;
        private String Name;

        private Sprite2D spriteTexture;
        private TextureManager.DUNGEON_SPRITES[] enumSprites;
        private SpriteAnimated2D spriteAnimatedTexture;
        private int frame = 0;
        private int totalFrames;

        private void init(String name, int x, int y)
        {
            Name = name;
            //XPos = x;
            //YPos = y;
        }

        public RoomObjectBase(String name, TextureManager.DUNGEON_SPRITES sprite, int x, int y)
        {
            init(name, x, y);
            spriteTexture = new Sprite2D(GameData.SpriteSheet, sprite, x * Reference.PIXELS_PER_GRID_SQUARE, y * Reference.PIXELS_PER_GRID_SQUARE);
        }

        public RoomObjectBase(String name, TextureManager.DUNGEON_SPRITES[] sprites, bool animated, int x, int y)
        {
            init(name, x, y);
            totalFrames = sprites.Length-1;
            if (animated)
                spriteAnimatedTexture = new SpriteAnimated2D(GameData.SpriteSheet, sprites, x * Reference.PIXELS_PER_GRID_SQUARE, y * Reference.PIXELS_PER_GRID_SQUARE);
            else
            {
                enumSprites = sprites;
                spriteTexture = new Sprite2D(GameData.SpriteSheet, sprites[0], x * Reference.PIXELS_PER_GRID_SQUARE, y * Reference.PIXELS_PER_GRID_SQUARE);
            }
        }

        public String getName()
        {
            return Name;
        }

        public bool isAnimated()
        {
            return spriteAnimatedTexture != null;
        }

        public int getNumSprites()
        {
            if (spriteAnimatedTexture == null)
                return 1;
            else
                return totalFrames;
        }

        /// <summary>
        /// Only to be used when this object has many sprites, but is not animated.
        /// </summary>
        /// <param name="spriteNum"></param>
        public void changeSprite(int spriteNum)
        {
            frame = spriteNum;
        }

        public void nextSprite()
        {
            if (spriteTexture != null)
                changeSprite(frame + 1);
            else if (spriteAnimatedTexture != null)
                spriteAnimatedTexture.nextFrame();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (spriteTexture != null)
                //Normal texture
                spriteTexture.Draw(spriteBatch);
            else if (spriteAnimatedTexture != null)
                //Animated texture
                spriteAnimatedTexture.Draw(spriteBatch);
            else
                //Shouldn't get here...
                throw new Exception("RoomObject " + this.Name + " has neither a spriteTexture or spriteAnimatedTexture!");
        }
    }
}
