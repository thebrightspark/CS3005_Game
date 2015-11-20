using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CS3005_Game.Util
{
    class ScreenText
    {
        private SpriteFont Font;
        private String Text;
        private Color Colour;
        private Vector2 Size;
        private Vector2 Position;

        private void init(SpriteFont font, String text, Color colour)
        {
            Font = font;
            Text = text;
            Colour = colour;
            Size = Font.MeasureString(Text);
        }

        /// <summary>
        /// Creates a new text object centered on the screen at the specified 'y' position.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="colour"></param>
        /// <param name="yPos"></param>
        public ScreenText(SpriteFont font, String text, Color colour, int yPos)
        {
            init(font, text, colour);
            Position = new Vector2((Reference.SCREEN_WIDTH / 2) - (Size.X / 2), yPos);
        }

        /// <summary>
        /// Creates a new text object at the specified coordinates.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="colour"></param>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        public ScreenText(SpriteFont font, String text, Color colour, int xPos, int yPos)
        {
            init(font, text, colour);
            Position = new Vector2(xPos, yPos);
        }

        public void setText(String text)
        {
            Text = text;
            Size = Font.MeasureString(Text);
        }

        public float getWidth()
        {
            return Size.X;
        }

        public float getHeight()
        {
            return Size.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                Font,
                Text,
                Position,
                Colour);
        }
    }
}
