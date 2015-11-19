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

        public ScreenText(SpriteFont font, String text, Color colour)
        {
            Font = font;
            Text = text;
            Colour = colour;
            Size = Font.MeasureString(Text);
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

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.DrawString(
                Font,
                Text,
                position,
                Colour);
        }

        public void DrawCentered(SpriteBatch spriteBatch, float yPos)
        {
            Draw(spriteBatch, new Vector2((Reference.SCREEN_WIDTH / 2) - (Size.X / 2), yPos));
        }
    }
}
