using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS3005_Game.Environment.RoomObjects.Text;
using CS3005_Game.Util;
using CS3005_Game.Environment.RoomObjects;

namespace CS3005_Game.Environment
{
    abstract class RoomLevelBase : RoomBase
    {
        private RoomObjectGate gateExit = new RoomObjectGate();

        public RoomLevelBase(String roomName) : base(roomName)
        {
            addNewTextObject(new ScreenText(null, GameData.FontStats, Names.Rooms.ROOM_TITLE + roomName, Reference.WHITE, 5, 5));

            addNewRoomObject(gateExit);

            //Change the player location to the start
            GameData.player.setCoords(Reference.PLAYER_START_X, Reference.PLAYER_START_Y);
        }

        public override void update()
        {
            gateExit.update();

            base.update();
        }
    }
}
