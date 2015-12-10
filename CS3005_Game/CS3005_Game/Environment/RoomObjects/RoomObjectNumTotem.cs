using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS3005_Game.Util;

namespace CS3005_Game.Environment.RoomObjects
{
    class RoomObjectNumTotem : RoomObjectBase
    {
        private int numToDisplay = 0;

        public RoomObjectNumTotem(String name, int displayNum, int x, int y) : base(name, new Sprite2D(GameData.Totem1SpriteSheet, x * Reference.PIXELS_PER_GRID_SQUARE, y * Reference.PIXELS_PER_GRID_SQUARE), x, y)
        {
            //TODO: Finish this object to use the number sprites and display them on the totem.
            if (displayNum > 9 || displayNum < 0)
                new Exception("Display Number must be between 0 and 9!");
            numToDisplay = displayNum;
        }
    }
}
