using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS3005_Game.Util;
using CS3005_Game.Environment.RoomObjects;
using Microsoft.Xna.Framework;
using CS3005_Game.Environment.RoomObjects.Text;

namespace CS3005_Game.Environment.Rooms.Levels
{
    class RoomLevel1 : RoomLevelBase
    {
        public RoomLevel1() : base(Names.Rooms.LEVEL_1)
        {
            //TODO: Create first level!
            addNewRoomObject(new RoomObjectButton("1", 7, 7));
            addNewRoomObject(new RoomObjectButton("2", 12, 7));

            ((RoomObjectGate)getRoomObject(Names.Objects.GATE_EXIT)).openGate();

            addNewTextObject(new ScreenText("PlayerDist", GameData.FontStats, "", Color.Red, 200, 15));
        }

        public override void Update()
        {
            Point buttonPos = getRoomObject("Button1").getTilePosition();
            Point playerPos = new Point((int)GameData.player.xPos, (int)GameData.player.yPos);
            //getTextObject("PlayerDist").setText("Player Dist To Button -> " + Math.Sqrt(Math.Pow(playerPos.X - (buttonPos.X * Reference.PIXELS_PER_GRID_SQUARE), 2) + Math.Pow(playerPos.Y - (buttonPos.Y * Reference.PIXELS_PER_GRID_SQUARE), 2)));
            RoomObjectBase obj = GameData.player.findClosestObject(this);
            String name;
            if(obj == null)
                name = "null";
            else
                name = obj.getName();
            getTextObject("PlayerDist").setText("Closest Button -> " + name);

            base.Update();
        }
    }
}
