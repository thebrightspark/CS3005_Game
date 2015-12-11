using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS3005_Game.Util;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CS3005_Game.Environment.RoomObjects
{
    class RoomObjectNumTotem : RoomObjectBase
    {
        private static Point numberPos = new Point((int)(11 * Config.screenScale), (int)(21 * Config.screenScale));
        private NumberSprite2D number;

        public RoomObjectNumTotem(String name, int numberToDisplay, int x, int y) : base(name, new Sprite2D(GameData.Totem1SpriteSheet, x * Reference.PIXELS_PER_GRID_SQUARE, y * Reference.PIXELS_PER_GRID_SQUARE), x, y)
        {
            number = new NumberSprite2D(GameData.NumberSpriteSheet, numberToDisplay, (x * Reference.PIXELS_PER_GRID_SQUARE) + numberPos.X, (y * Reference.PIXELS_PER_GRID_SQUARE) + numberPos.Y);
        }

        public void setNumber(int n)
        {
            number.setSprite(n);
        }

        public int getNumber()
        {
            return number.getSprite();
        }

        public void increaseNumber()
        {
            int curNum = number.getSprite();
            curNum++;
            if (curNum > 9)
                curNum = 0;
            number.setSprite(curNum);
        }

        public void decreaseNumber()
        {
            int curNum = number.getSprite();
            curNum--;
            if (curNum < 0)
                curNum = 9;
            number.setSprite(curNum);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            //Draw number
            number.Draw(spriteBatch);
        }
    }
}
