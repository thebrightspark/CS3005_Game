using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS3005_Game.Util;
using CS3005_Game.Environment.RoomObjects.Text;
using Microsoft.Xna.Framework;

namespace CS3005_Game.Environment.Rooms
{
    class RoomLevelSelect : RoomBase
    {
        public RoomLevelSelect() : base(Names.Rooms.LEVEL_SELECT)
        {
            addNewTextObject(new ScreenText(null, GameData.FontMain, Names.Text.GAME_NAME, Reference.WHITE, 10));
            addNewTextObject(new ScreenText(null, GameData.FontMain, Names.Text.LOBBY_TITLE, Color.DarkRed, 115));

        }

        public override void update()
        {
            base.update();
        }
    }
}
