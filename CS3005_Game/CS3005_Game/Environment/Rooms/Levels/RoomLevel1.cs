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
        private readonly String Totem_1 = "n1";
        private readonly String Totem_2 = "n2";
        private readonly String Totem_Sum = "nTotal";
        private readonly String Button_Add = "bAdd";
        private readonly String Button_Sub = "bSub";

        public RoomLevel1() : base(Names.Rooms.LEVEL_1)
        {
            Random rand = new Random();
            int randSum = rand.Next(6) + 4;
            int randNum = rand.Next(randSum-2) + 1;

            addNewRoomObject(new RoomObjectNumTotem(Totem_1, randNum, 4, 5));
            addNewRoomObject(new RoomObjectNumTotem(Totem_2, 0, 6, 5));
            addNewRoomObject(new RoomObjectNumTotem(Totem_Sum, randSum, 11, 5));

            addNewRoomObject(new RoomObjectButton(Button_Add, TextureManager.DUNGEON_SPRITES.BUTTON_3, 6, 8));
            addNewRoomObject(new RoomObjectButton(Button_Sub, TextureManager.DUNGEON_SPRITES.BUTTON_2, 7, 8));

            addNewTextObject(new ScreenTextWithBG(null, Reference.BG_GREY, GameData.FontInfoS, Names.Text.LEVEL_1_INFO_1, Color.Black, 90, Reference.SCREEN_HEIGHT - 200));
            addNewTextObject(new ScreenTextWithBG(null, Reference.BG_GREY, GameData.FontInfoS, Names.Text.LEVEL_1_INFO_2, Color.Black, 130));

            //((RoomObjectGate)getRoomObject(Names.Objects.GATE_EXIT)).openGate();

            addNewTextObject(new ScreenText("PlayerDist", GameData.FontStats, "", Color.Red, 200, 15));
        }

        public override void Update()
        {
            /*
            RoomObjectBase obj = GameData.player.findClosestObject(this);
            String name;
            if(obj == null)
                name = "null";
            else
                name = obj.getName();
            getTextObject("PlayerDist").setText("Closest -> " + name);
            */

            if (doPlayerAction)
            {
                RoomObjectBase obj = GameData.player.findClosestObject(this);
                if (obj != null)
                {
                    String objName = obj.getName();
                    if (objName == Button_Add || objName == Button_Sub)
                        ((RoomObjectButton)obj).activate();
                }
            }

            if (((RoomObjectButton)getRoomObject(Button_Add)).isActive())
                ((RoomObjectNumTotem)getRoomObject(Totem_2)).increaseNumber();
            if (((RoomObjectButton)getRoomObject(Button_Sub)).isActive())
                ((RoomObjectNumTotem)getRoomObject(Totem_2)).decreaseNumber();

            if ((((RoomObjectNumTotem)getRoomObject(Totem_1)).getNumber() + ((RoomObjectNumTotem)getRoomObject(Totem_2)).getNumber()) == ((RoomObjectNumTotem)getRoomObject(Totem_Sum)).getNumber())
                gateExit.openGate();
            else
                gateExit.closeGate();

            base.Update();

            doPlayerAction = false;
        }
    }
}
