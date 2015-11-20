using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CS3005_Game.Util
{
    class SpriteAnimated2D
    {
        public Texture2D texture;
        public Vector2 position;
        private TextureManager.DUNGEON_SPRITES[] sprites;
        private Rectangle spriteRect;
        private Color colour;
        public float rotation;
        private Vector2 origin;
        public Vector2 scale;
        private SpriteEffects effect;
        private float layerDepth;
        private int curFrame;
        private int totalFrames;

        /// <summary>
        /// Create a 2D sprite using the sprite sheet and a sprite name.
        /// It will use the TextureManager to get a rectangle for the sprite's location on the sheet.
        /// </summary>
        /// <param name="spriteSheet"></param>
        /// <param name="sprite"></param>
        public SpriteAnimated2D(Texture2D spriteSheet, TextureManager.DUNGEON_SPRITES[] enumSprites, int screenXPos, int screenYPos)
        {
            texture = spriteSheet;
            position = new Vector2(screenXPos, screenYPos);
            sprites = enumSprites;
            colour = Color.White;
            rotation = 0f;
            origin = new Vector2(0f);
            scale = new Vector2(Config.screenScale);
            effect = SpriteEffects.None;
            layerDepth = 0f;
            totalFrames = enumSprites.Length-1;
            curFrame = 0;
            spriteRect = TextureManager.getSpriteRect(sprites[0]);
        }

        /// <summary>
        /// Changes the current sprite to the one given using the TextureManager.
        /// </summary>
        /// <param name="sprite">Sprite name</param>
        public void setSprite(TextureManager.DUNGEON_SPRITES sprite)
        {
            spriteRect = TextureManager.getSpriteRect(sprite);
        }

        /// <summary>
        /// Returns the width of the sprite.
        /// </summary>
        /// <returns></returns>
        public int getSpriteWidth()
        {
            return spriteRect.Width;
        }

        /// <summary>
        /// Returns the height of the sprite.
        /// </summary>
        /// <returns></returns>
        public int getSpriteHeight()
        {
            return spriteRect.Height;
        }

        public void nextFrame()
        {
            curFrame++;
            if (curFrame > totalFrames)
                curFrame = 0;
            spriteRect = TextureManager.getSpriteRect(sprites[curFrame]);
        }

        /// <summary>
        /// Draws the sprite on the screen with it's own defined variables.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture,
                position,
                spriteRect,
                colour,
                rotation,
                origin,
                scale,
                effect,
                layerDepth);
        }
    }
}
