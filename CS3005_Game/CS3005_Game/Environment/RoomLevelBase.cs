using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS3005_Game.Util;

namespace CS3005_Game.Environment
{
    abstract class RoomLevelBase : RoomBase
    {
        public RoomLevelBase(String roomName) : base(roomName)
        {
            addNewTextObject(new ScreenText(GameData.FontStats, Names.Rooms.ROOM_TITLE + roomName, Reference.WHITE, 5, 5));
        }
    }
}
