using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CS3005_Game.Util;

namespace CS3005_Game.Environment.RoomObjects.Text
{
    class ScreenText
    {
        private String Name;
        private SpriteFont Font;
        private String Text;
        private Color Colour;
        protected Vector2 Size;
        protected Vector2 Position;

        private void init(String name, SpriteFont font, String text, Color colour)
        {
            Name = name;
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
        public ScreenText(String name, SpriteFont font, String text, Color colour, int yPos)
        {
            init(name, font, text, colour);
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
        public ScreenText(String name, SpriteFont font, String text, Color colour, int xPos, int yPos)
        {
            init(name, font, text, colour);
            Position = new Vector2(xPos, yPos);
        }

        public String getName()
        {
            return Name;
        }

        public void setText(String text)
        {
            Text = text;
            Size = Font.MeasureString(Text);
            Position = new Vector2((Reference.SCREEN_WIDTH / 2) - (Size.X / 2), Position.Y);
        }

        public float getWidth()
        {
            return Size.X;
        }

        public float getHeight()
        {
            return Size.Y;
        }

        virtual public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                Font,
                Text,
                Position,
                Colour);
        }
    }
}
