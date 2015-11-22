using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS3005_Game.Util;
using CS3005_Game.Environment.RoomObjects;
using CS3005_Game.Environment.RoomObjects.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CS3005_Game.Environment.Rooms
{
    class RoomLobby : RoomBase
    {
        private int selection = 1;
        private int selectionMax;
        private bool isKeyDown = false;

        private String MenuContinue = "continue";
        private String MenuSelect = "select";

        public RoomLobby() : base(Names.Rooms.LOBBY)
        {
            addNewTextObject(new ScreenText(null, GameData.FontMain, Names.Text.GAME_NAME, Reference.WHITE, 10));
            
            //addNewTextObject(new ScreenTextWithBG(MenuPlay, Reference.BG_GREY, GameData.FontInfo, Names.Text.MENU_PLAY, Color.Black, Reference.SCREEN_GRID_HEIGHT / 2));
            addNewTextObject(new ScreenTextWithBG(MenuContinue, Reference.BG_GREY, GameData.FontInfo, Names.Text.MENU_CONTINUE, Color.Black, (Reference.SCREEN_HEIGHT / 2) - 50));
            addNewTextObject(new ScreenTextWithBG(MenuSelect, Reference.BG_GREY, GameData.FontInfo, Names.Text.MENU_LEVEL_SELECT, Color.Black, (Reference.SCREEN_HEIGHT / 2) + 50));
            //addNewTextObject(new ScreenTextWithBG(MenuBack, Reference.BG_GREY, GameData.FontInfo, Names.Text.MENU_BACK, Color.Black, Reference.SCREEN_GRID_HEIGHT / 2));

            ((ScreenTextWithBG)getTextObject(MenuSelect)).shouldDrawBG(false);

            selectionMax = getTextObjects().Count;
        }

        public override void update()
        {
            //TODO: Finish lobby with menu, and move exit gate to a level.

            if(!isKeyDown)
            {
                if (GameData.keyboard.IsKeyDown(Keys.Down)) //&& selection < selectionMax)
                {
                    //Down
                    selection++;
                    isKeyDown = true;
                    Console.WriteLine("DOWN");
                }
                else if (GameData.keyboard.IsKeyDown(Keys.Up)) //&& selection > 0)
                {
                    //Up
                    selection--;
                    isKeyDown = true;
                    Console.WriteLine("UP");
                }

                if (isKeyDown)
                {
                    Console.WriteLine("Key Pressed");
                    Dictionary<String, ScreenText> textObjects = getTextObjects();
                    foreach (ScreenText s in textObjects.Values)
                    {
                        if (s is ScreenTextWithBG)
                        {
                            ScreenTextWithBG screenText = (ScreenTextWithBG)s;
                            //ScreenText screenTextSelected = textObjects.ElementAt(selection).Value;
                            if (((ScreenText)(textObjects.ElementAt(selection).Value)).getName().Equals(s.getName()))
                                screenText.shouldDrawBG(true);
                            else
                                screenText.shouldDrawBG(false);
                        }
                    }
                }
            }

            base.update();
        }
    }
}
