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
        private Point TilePos;
        private Point TileSize;

        private Sprite2D spriteTexture;
        private TextureManager.DUNGEON_SPRITES[] enumSprites;
        private SpriteAnimated2D spriteAnimatedTexture;
        private int frame = 0;
        private int totalFrames;

        private void init(String name, int x, int y)
        {
            Name = name;
            TilePos = new Point(x, y);
        }

        public RoomObjectBase(String name, Sprite2D sprite, int x, int y)
        {
            spriteTexture = sprite;
            if (sprite.texture == GameData.Totem1SpriteSheet)
                TileSize = TextureManager.getTileSize(TextureManager.DUNGEON_SPRITES.TOTEM_1);
            else
                new Exception("TileSize not specified!");
            init(name, x, y);
        }

        public RoomObjectBase(String name, TextureManager.DUNGEON_SPRITES sprite, int x, int y)
        {
            spriteTexture = new Sprite2D(GameData.SpriteSheet, sprite, x * Reference.PIXELS_PER_GRID_SQUARE, y * Reference.PIXELS_PER_GRID_SQUARE);
            TileSize = TextureManager.getTileSize(sprite);
            init(name, x, y);
        }

        public RoomObjectBase(String name, TextureManager.DUNGEON_SPRITES[] sprites, bool animated, int x, int y)
        {
            totalFrames = sprites.Length-1;
            if (animated)
                spriteAnimatedTexture = new SpriteAnimated2D(GameData.SpriteSheet, sprites, x * Reference.PIXELS_PER_GRID_SQUARE, y * Reference.PIXELS_PER_GRID_SQUARE);
            else
            {
                enumSprites = sprites;
                spriteTexture = new Sprite2D(GameData.SpriteSheet, sprites[0], x * Reference.PIXELS_PER_GRID_SQUARE, y * Reference.PIXELS_PER_GRID_SQUARE);
            }
            TileSize = TextureManager.getTileSize(sprites[0]);
            init(name, x, y);
        }

        public String getName()
        {
            return Name;
        }

        public bool isAnimated()
        {
            return spriteAnimatedTexture != null;
        }

        /// <summary>
        /// Returns true if the object can be interacted with directly by the player.
        /// </summary>
        virtual public bool canBeInteractedWith()
        {
            return false;
        }

        public int getCurrentFrame()
        {
            return frame;
        }

        public int getNumSprites()
        {
            return totalFrames;
        }

        public Rectangle getRect()
        {
            Rectangle rect = new Rectangle();
            if (spriteAnimatedTexture != null)
            {
                rect.X = (int) spriteAnimatedTexture.position.X;
                rect.Y = (int) spriteAnimatedTexture.position.Y;
                rect.Width = spriteAnimatedTexture.getSpriteWidth();
                rect.Height = spriteAnimatedTexture.getSpriteHeight();
            }
            else
            {
                rect.X = (int)spriteTexture.position.X;
                rect.Y = (int)spriteTexture.position.Y;
                rect.Width = spriteTexture.getSpriteWidth();
                rect.Height = spriteTexture.getSpriteHeight();
            }
            return rect;
        }

        /// <summary>
        /// Gets the tile position of the object.
        /// </summary>
        /// <returns></returns>
        public Point getTilePosition()
        {
            return TilePos;
        }

        /// <summary>
        /// Gets the postion of the object on the screen.
        /// </summary>
        /// <returns></returns>
        public Point getAbsolutePosition()
        {
            return new Point(TilePos.X * Reference.PIXELS_PER_GRID_SQUARE, TilePos.Y * Reference.PIXELS_PER_GRID_SQUARE);
        }

        /// <summary>
        /// Gets the tile size of the object.
        /// </summary>
        /// <returns></returns>
        public Point getTileSize()
        {
            return TileSize;
        }

        public bool isLastFrame()
        {
            return frame == totalFrames;
        }

        public bool isFirstFrame()
        {
            return frame == 0;
        }

        /// <summary>
        /// Only to be used when this object has many sprites, but is not animated.
        /// </summary>
        /// <param name="spriteNum"></param>
        public void changeSprite(int spriteNum)
        {
            frame = spriteNum;
            spriteTexture.setSprite(enumSprites[frame]);
        }

        public void nextSprite()
        {
            if (spriteTexture != null)
            {
                changeSprite(frame + 1);
                if (frame > totalFrames)
                    frame = 0;
            }
            else if (spriteAnimatedTexture != null)
                spriteAnimatedTexture.nextFrame();
        }

        public void lastSprite()
        {
            if (spriteTexture != null)
            {
                changeSprite(frame - 1);
                if (frame < 0)
                    frame = totalFrames;
            }
        }

        virtual public void Draw(SpriteBatch spriteBatch)
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

        /// <summary>
        /// Call this every update of the Room.
        /// </summary>
        virtual public void Update() { }
    }
}
