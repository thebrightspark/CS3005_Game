using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS3005_Game.Util
{
    class NumberSprite2D
    {
        public Texture2D texture;
        public Vector2 position;
        private Rectangle spriteRect;
        private Color colour;
        public float rotation;
        private Vector2 origin;
        public Vector2 scale;
        private SpriteEffects effect;
        private float layerDepth;
        private int spriteNum;

        /// <summary>
        /// Create a 2D sprite using the sprite sheet and a sprite name.
        /// It will use the TextureManager to get a rectangle for the sprite's location on the sheet.
        /// </summary>
        /// <param name="spriteSheet"></param>
        /// <param name="sprite"></param>
        public NumberSprite2D(Texture2D spriteSheet, int sprite, int screenXPos, int screenYPos)
        {
            texture = spriteSheet;
            position = new Vector2(screenXPos, screenYPos);
            spriteNum = sprite;
            spriteRect = TextureManager.getNumberSpriteRect(sprite);
            colour = Color.White;
            rotation = 0f;
            origin = new Vector2(0f);
            scale = new Vector2(Config.screenScale);
            effect = SpriteEffects.None;
            layerDepth = 0f;
        }

        /// <summary>
        /// Changes the current sprite to the one given using the TextureManager.
        /// </summary>
        /// <param name="sprite">Sprite name</param>
        public void setSprite(int sprite)
        {
            spriteNum = sprite;
            spriteRect = TextureManager.getNumberSpriteRect(sprite);
        }

        /// <summary>
        /// Gets the number sprite.
        /// </summary>
        /// <returns></returns>
        public int getSprite()
        {
            return spriteNum;
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
