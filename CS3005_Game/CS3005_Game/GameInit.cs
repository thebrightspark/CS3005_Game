using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS3005_Game.Environment.Rooms;
using CS3005_Game.Util;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CS3005_Game.Environment.Rooms.Levels;
using CS3005_Game.Entity;

namespace CS3005_Game
{
    /// <summary>
    /// This class is used to initialise game content
    /// </summary>
    class GameInit
    {
        public static void Init(ContentManager Content, GraphicsDeviceManager graphics)
        {
            graphics.PreferredBackBufferWidth = Reference.SCREEN_WIDTH;
            graphics.PreferredBackBufferHeight = Reference.SCREEN_HEIGHT;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

            //Loads the spritesheets
            GameData.SpriteSheet = Content.Load<Texture2D>(Reference.SPRITESHEET);
            GameData.PlayerSpriteSheet = Content.Load<Texture2D>(Reference.SPRITE_PLAYER);
            GameData.Totem1SpriteSheet = Content.Load<Texture2D>(Reference.SPRITE_TOTEMNUM1);
            GameData.Totem2SpriteSheet = Content.Load<Texture2D>(Reference.SPRITE_TOTEMNUM2);
            GameData.DebugSquareYellow = Content.Load<Texture2D>(Reference.SPRITE_DEBUGSQUARE_YELLOW);
            GameData.DebugSquareRed = Content.Load<Texture2D>(Reference.SPRITE_DEBUGSQUARE_RED);
            //Creates the fonts
            GameData.FontMain = Content.Load<SpriteFont>(Reference.PATH_FONTS + "FontMain");
            GameData.FontStats = Content.Load<SpriteFont>(Reference.PATH_FONTS + "FontStats");
            GameData.FontInfo = Content.Load<SpriteFont>(Reference.PATH_FONTS + "FontInfo");
            //Creates the plain textures
            GameData.TexturePlain = new Texture2D(graphics.GraphicsDevice, 1, 1);
            GameData.TexturePlain.SetData(new Color[] { Color.White });
            GameData.TexturePlainAlpha = new Texture2D(graphics.GraphicsDevice, 1, 1);
            GameData.TexturePlainAlpha.SetData(new Color[] { new Color(255, 255, 255, 32) });

            //Initialize textures
            TextureManager.init();

            //Initialize Player
            GameData.player = new Player();

            //Rooms
            GameData.addRoom(new RoomLobby());
            GameData.addRoom(new RoomLevelSelect());
            GameData.addRoom(new RoomLevel1());

            //Set initial Room to the Lobby
            GameData.setCurrentRoom(Names.Rooms.LOBBY);
        }
    }
}
