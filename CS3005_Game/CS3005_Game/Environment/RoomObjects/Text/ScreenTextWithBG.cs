using CS3005_Game.Environment.RoomObjects.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS3005_Game.Environment.RoomObjects.Text
{
    class ScreenTextWithBG : ScreenText
    {
        private int margin = 5;

        private Color bgColour;
        private Rectangle rectBG;
        private bool drawBG = true;

        public void init(Color colourBG)
        {
            bgColour = colourBG;
            rectBG = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
            rectBG.Inflate(margin * 2, margin);
        }

        public ScreenTextWithBG(String name, Color colourBG, SpriteFont font, String text, Color colour, int yPos) : base(name, font, text, colour, yPos)
        {
            init(colourBG);
        }

        public ScreenTextWithBG(String name, Color colourBG, SpriteFont font, String text, Color colour, int xPos, int yPos) : base(name, font, text, colour, xPos, yPos)
        {
            init(colourBG);
        }

        /// <summary>
        /// Whether the background should be drawn.
        /// </summary>
        /// <param name="b"></param>
        public void shouldDrawBG(bool b)
        {
            drawBG = b;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (drawBG)
                spriteBatch.Draw(GameData.TexturePlainAlpha, rectBG, bgColour);

            base.Draw(spriteBatch);
        }
    }
}
