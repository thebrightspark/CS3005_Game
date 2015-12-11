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
        public bool doPlayerAction = false;
        protected RoomObjectGate gateExit = new RoomObjectGate();
        //This is true once the player has got through the exit gate.
        protected bool complete = false;

        public RoomLevelBase(String roomName) : base(roomName)
        {
            addNewTextObject(new ScreenText(null, GameData.FontInfo, Names.Rooms.ROOM_TITLE + roomName, Reference.WHITE, 5, 5));
            //addNewTextObject(new ScreenText("PlayerPos", GameData.FontStats, "", Color.Red, 5, 15));
            //addNewTextObject(new ScreenText("PlayerTilePos", GameData.FontStats, "", Color.Red, 200, 5));

            addNewRoomObject(gateExit);
        }

        public bool isCompleted()
        {
            return complete;
        }

        public override void Update()
        {
            //getTextObject("PlayerPos").setText("Player -> X:" + GameData.player.xPos + "  Y:" + GameData.player.yPos + "\n              X2:" + (GameData.player.xPos + 16) + " Y2:" + (GameData.player.yPos + 16));
            //getTextObject("PlayerTilePos").setText("TilePos -> X:" + GameData.player.xTilePos + "  Y:" + GameData.player.yTilePos);

            //If player gets through the gate, then finish level
            if (GameData.player.yTilePos <= 1)
                complete = true;

            if (complete && GameData.keyboard.IsKeyDown(Config.keyAction))
            {
                complete = false;
                GameData.player.resetCoords();
                GameData.setCurrentRoom(Names.Rooms.LOBBY);
            }

            base.Update();
        }

        public override void UpdateLess()
        {
            gateExit.Update();

            base.UpdateLess();
        }
    }
}
