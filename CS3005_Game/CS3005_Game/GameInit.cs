using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS3005_Game.Environment.Rooms;
using CS3005_Game.Util;

namespace CS3005_Game
{
    /// <summary>
    /// This class is used to initialise game content
    /// </summary>
    class GameInit
    {
        public static void Init()
        {
            //Use this to initialise all rooms and game objects

            //Initialize textures
            TextureManager.init();

            //Rooms
            GameData.addRoom(new RoomLobby());

            //Set initial Room to the Lobby
            GameData.setCurrentRoom(Names.Rooms.LOBBY);
        }
    }
}
