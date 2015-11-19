using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS3005_Game.Util
{
    class Sprite2D
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

        /// <summary>
        /// Create a 2D sprite using the sprite sheet and a sprite name.
        /// It will use the TextureManager to get a rectangle for the sprite's location on the sheet.
        /// </summary>
        /// <param name="spriteSheet"></param>
        /// <param name="sprite"></param>
        public Sprite2D(Texture2D spriteSheet, TextureManager.DUNGEON_SPRITES sprite, int screenXPos, int screenYPos)
        {
            texture = spriteSheet;
            position = new Vector2(screenXPos * Reference.SCREEN_SCALE, screenYPos * Reference.SCREEN_SCALE);
            spriteRect = TextureManager.getSpriteRect(sprite);
            colour = Color.White;
            rotation = 0f;
            origin = new Vector2(0f);
            scale = new Vector2(Reference.SCREEN_SCALE);
            effect = SpriteEffects.None;
            layerDepth = 0f;
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
