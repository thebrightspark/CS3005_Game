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
        private int selectionMax = 2;
        private bool isKeyDown = false;

        private String MenuContinue = "continue";
        private String MenuCharacter = "character";
        private String InfoGender = "infoGender";
        private String MenuSelect = "select";

        private List<ScreenTextWithBG> MenuObjects = new List<ScreenTextWithBG>();

        public RoomLobby() : base(Names.Rooms.LOBBY)
        {
            addNewTextObject(new ScreenText(null, GameData.FontMain, Names.Text.GAME_NAME, Reference.WHITE, 10));
            addNewTextObject(new ScreenText(null, GameData.FontMain, Names.Text.LOBBY_TITLE, Color.DarkRed, 115));
            addNewTextObject(new ScreenText(null, GameData.FontStats, Names.Text.LOBBY_CREDITS, Reference.WHITE, 5, Reference.SCREEN_HEIGHT - 40));
            
            addNewTextObject(new ScreenTextWithBG(MenuContinue, Reference.BG_GREY, GameData.FontInfo, Names.Text.LOBBY_MENU_PLAY, Color.Black, (Reference.SCREEN_HEIGHT / 2) - 50));
            addNewTextObject(new ScreenTextWithBG(MenuCharacter, Reference.BG_GREY, GameData.FontInfo, Names.Text.LOBBY_MENU_CHARACTER, Color.Black, (Reference.SCREEN_HEIGHT / 2) + 50));
            addNewTextObject(new ScreenText(InfoGender, GameData.FontInfoS, "", Color.Black, (Reference.SCREEN_HEIGHT / 2) + 90));
            //addNewTextObject(new ScreenTextWithBG(MenuSelect, Reference.BG_GREY, GameData.FontInfo, Names.Text.LOBBY_MENU_LEVEL_SELECT, Color.Black, (Reference.SCREEN_HEIGHT / 2) + 50));

            addNewTextObject(new ScreenText(null, GameData.FontInfoS, "Made by Mark Passey", Color.Black, Reference.SCREEN_HEIGHT - 100));

            //Save the menu objects to a private list for use later
            foreach (ScreenText s in getTextObjects().Values)
            {
                if (s is ScreenTextWithBG)
                    MenuObjects.Add((ScreenTextWithBG)s);
            }

            //Set all menu objects to not draw a background other than the top one
            foreach (ScreenTextWithBG s in MenuObjects)
            {
                if (s.getName() == MenuContinue)
                    continue;
                s.shouldDrawBG(false);
            }
        }

        public override void Update()
        {
            getTextObject(InfoGender).setText(Names.Text.LOBBY_INFO_GENDER + GameData.player.sprite.getGender());

            if (!GameData.keyboard.IsKeyDown(Config.keyUp) && !GameData.keyboard.IsKeyDown(Config.keyDown) && !GameData.keyboard.IsKeyDown(Config.keyAction))
                isKeyDown = false;

            if(!isKeyDown)
            {
                if (GameData.keyboard.IsKeyDown(Config.keyDown) && selection < selectionMax)
                {
                    //Down
                    selection++;
                    isKeyDown = true;
                    //Console.WriteLine("DOWN");
                }
                else if (GameData.keyboard.IsKeyDown(Config.keyUp) && selection > 1)
                {
                    //Up
                    selection--;
                    isKeyDown = true;
                    //Console.WriteLine("UP");
                }

                if (isKeyDown)
                {
                    //Console.WriteLine("Key Pressed");
                    for (int i = 0; i < MenuObjects.Count; ++i)
                    {
                        if (i+1 == selection)
                            MenuObjects[i].shouldDrawBG(true);
                        else
                            MenuObjects[i].shouldDrawBG(false);
                    }
                }
            }

            if (!isKeyDown && GameData.keyboard.IsKeyDown(Config.keyAction))
            {
                isKeyDown = true;
                //Enter
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Picking room...");
                        //Continue - Automatically plays the next uncompleted room
                        if (GameData.RoomsCleared < GameData.getNumLevels())
                        {
                            Console.WriteLine("Playing Room " + (GameData.RoomsCleared + 1));
                            GameData.setCurrentRoom((GameData.RoomsCleared + 1).ToString());
                        }
                        else
                        {
                            Console.WriteLine("All Rooms cleared! Playing last room: " + GameData.getNumLevels());
                            //If all rooms cleared, then play last level again
                            GameData.setCurrentRoom(GameData.getNumLevels().ToString());
                        }
                        break;
                    case 2:
                        //Toggle Gender
                        GameData.player.sprite.toggleGender();

                        //Level Select
                        //GameData.setCurrentRoom(Names.Rooms.LEVEL_SELECT);
                        break;
                    default:
                        //Nothing
                        break;
                }
            }

            base.Update();
        }
    }
}
