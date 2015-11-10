﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using CS3005_Game.Util;

namespace CS3005_Game.Environment
{
    /// <summary>
    /// Extend this class to create a Room
    /// </summary>
    class RoomBase : IRoom
    {
        //Room name
        private String Name;
        //Background texture (usually the PRESET_BG with black, walls and green)
        private TextureManager.DUNGEON_SPRITES[,] TextureBG;
        //List of all the objects in the room
        private List<RoomObjectBase> RoomObjects = new List<RoomObjectBase>();

        public RoomBase(String name)
        {
            Name = name;
            TextureBG = TextureManager.PRESET_BG;
        }

        /// <summary>
        /// Sets the background of the Room to an enum DUNGEON_SPRITES 2D array.
        /// </summary>
        /// <param name="textureArray"></param>
        public void setBackgroundTexture(TextureManager.DUNGEON_SPRITES[,] textureArray)
        {
            TextureBG = textureArray;
        }

        public TextureManager.DUNGEON_SPRITES[,] getBackgroundTexture()
        {
            return TextureBG;
        }

        /// <summary>
        /// Adds a new object to the room.
        /// All objects are drawn ontop of the background.
        /// </summary>
        /// <param name="obj">The room object</param>
        protected void addNewObject(RoomObjectBase obj)
        {
            RoomObjects.Add(obj);
        }

        /// <summary>
        /// Removes the named object from the objects in the room if it exists.
        /// Returns whether it was successful or not.
        /// </summary>
        /// <param name="name">Name of the object</param>
        /// <returns>Success</returns>
        protected bool removeObject(String name)
        {
            for(int i = 0; i < RoomObjects.Count; i++)
            {
                RoomObjectBase obj = RoomObjects[i];
                if(obj.getName().Equals(name))
                {
                    RoomObjects.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
