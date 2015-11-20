using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS3005_Game.Util;
using CS3005_Game.Environment.RoomObjects;

namespace CS3005_Game.Environment.Rooms
{
    class RoomLobby : RoomBase
    {
        public RoomLobby() : base(Names.Rooms.LOBBY)
        {
            addNewTextObject(new ScreenText(GameData.FontMain, Names.Text.GAME_NAME, Reference.WHITE, 10));
            addNewTextObject(new ScreenText(GameData.FontInfo, "Here is some info \ntext!", Reference.WHITE, 200, 200));
            addNewRoomObject(new RoomObjectGate()); //TODO: Fix gate
        }

        public override void update()
        {
            base.update();
        }
    }
}
