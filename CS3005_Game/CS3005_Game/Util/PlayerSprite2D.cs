using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CS3005_Game.Util
{
    class PlayerSprite2D
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

        public PlayerSprite2D()
        {
            texture = GameData.PlayerSpriteSheet;
            position = new Vector2(-64, -64);
            spriteRect = texture.Bounds; //Sets the rectangle to the size of the spritesheet
            colour = Color.White;
            rotation = 0f;
            origin = new Vector2(0f);
            scale = new Vector2(Config.screenScale);
            effect = SpriteEffects.None;
            layerDepth = 0f;
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
