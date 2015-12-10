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
        private String MenuBack = "back";

        public RoomLevelSelect() : base(Names.Rooms.LEVEL_SELECT)
        {
            addNewTextObject(new ScreenText(null, GameData.FontMain, Names.Text.GAME_NAME, Reference.WHITE, 10));
            addNewTextObject(new ScreenText(null, GameData.FontMain, Names.Text.LEVELSELECT_TITLE, Color.DarkRed, 115));

            //TODO: Add menu text objects for room numbers


            addNewTextObject(new ScreenTextWithBG(MenuBack, Reference.BG_GREY, GameData.FontInfo, Names.Text.LOBBY_MENU_BACK, Color.Black, Reference.SCREEN_HEIGHT - 120));
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
