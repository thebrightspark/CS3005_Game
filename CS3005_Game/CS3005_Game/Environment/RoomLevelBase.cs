using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS3005_Game.Environment.RoomObjects.Text;
using CS3005_Game.Util;
using CS3005_Game.Environment.RoomObjects;
using Microsoft.Xna.Framework;

namespace CS3005_Game.Environment
{
    abstract class RoomLevelBase : RoomBase
    {
        private RoomObjectGate gateExit = new RoomObjectGate();

        public RoomLevelBase(String roomName) : base(roomName)
        {
            addNewTextObject(new ScreenText(null, GameData.FontStats, Names.Rooms.ROOM_TITLE + roomName, Color.Red, 5, 5));
            addNewTextObject(new ScreenText("PlayerPos", GameData.FontStats, "", Color.Red, 5, 15));
            addNewTextObject(new ScreenText("PlayerTilePos", GameData.FontStats, "", Color.Red, 200, 5));

            addNewRoomObject(gateExit);
        }

        public override void Update()
        {
            getTextObject("PlayerPos").setText("Player -> X:" + GameData.player.xPos + "  Y:" + GameData.player.yPos + "\n              X2:" + (GameData.player.xPos + 16) + " Y2:" + (GameData.player.yPos + 16));
            getTextObject("PlayerTilePos").setText("TilePos -> X:" + GameData.player.xTilePos + "  Y:" + GameData.player.yTilePos);

            base.Update();
        }

        public override void UpdateLess()
        {
            gateExit.Update();

            base.UpdateLess();
        }
    }
}
