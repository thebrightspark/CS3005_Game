using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using CS3005_Game.Util;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CS3005_Game.Environment.RoomObjects.Text;

namespace CS3005_Game.Environment
{
    /// <summary>
    /// Extend this class to create a Room
    /// </summary>
    abstract class RoomBase
    {
        private static int iNull = 0;
        //Room name
        private String Name;
        //Background texture (usually the PRESET_BG with black, walls and green)
        private TextureManager.DUNGEON_SPRITES[,] TextureBG;
        //List of all the objects in the room
        protected Dictionary<String, RoomObjectBase> RoomObjects = new Dictionary<String, RoomObjectBase>();
        //protected List<RoomObjectBase> RoomObjects = new List<RoomObjectBase>();
        //List of all the text objects in the room
        protected Dictionary<String, ScreenText> RoomTextObjects = new Dictionary<String, ScreenText>();
        //protected List<ScreenText> RoomTextObjects = new List<ScreenText>();

        public RoomBase(String name)
        {
            Name = name;
            TextureBG = TextureManager.PRESET_BG;
        }

        /// <summary>
        /// This is called by the GameUpdate class when this Room is currently loaded.
        /// All code to check and do things should be done within this method.
        /// </summary>
        virtual public void update() { }

        /// <summary>
        /// This is called by the GameUpdate class when this Room is currently loaded.
        /// By default, this class will tell it's Room Objects to change to their next sprite if they're animated.
        /// </summary>
        virtual public void updateSprites()
        {
            foreach (RoomObjectBase obj in RoomObjects.Values)
            {
                if(obj.isAnimated())
                    obj.nextSprite();
            }
        }

        /// <summary>
        /// Sets the background of the Room to an enum DUNGEON_SPRITES 2D array.
        /// </summary>
        /// <param name="textureArray"></param>
        public void setBackgroundTexture(TextureManager.DUNGEON_SPRITES[,] textureArray)
        {
            TextureBG = textureArray;
        }

        /// <summary>
        /// Gets the background texture of the Room.
        /// Background is represented as a 2D array of enum DUNGEON_SPRITES.
        /// </summary>
        /// <returns></returns>
        public TextureManager.DUNGEON_SPRITES[,] getBackgroundTexture()
        {
            return TextureBG;
        }

        /// <summary>
        /// Gets the name of the Room.
        /// </summary>
        /// <returns></returns>
        public String getName()
        {
            return Name;
        }

        /// <summary>
        /// Adds a new object to the Room.
        /// All objects are drawn ontop of the background.
        /// </summary>
        /// <param name="obj">The Room object</param>
        protected void addNewRoomObject(RoomObjectBase obj)
        {
            if (obj.getName() == null)
            {
                RoomObjects.Add(iNull.ToString(), obj);
                iNull++;
            }
            else
                RoomObjects.Add(obj.getName(), obj);
        }

        /// <summary>
        /// Returns the Room objects with the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public RoomObjectBase getRoomObject(String name)
        {
            return RoomObjects[name];
        }

        /// <summary>
        /// Returns all of the Room's room objects.
        /// </summary>
        /// <returns></returns>
        public Dictionary<String, RoomObjectBase> getRoomObjects()
        {
            return RoomObjects;
        }

        /// <summary>
        /// Adds a new piece of text to the Room.
        /// </summary>
        /// <param name="textObj"></param>
        protected void addNewTextObject(ScreenText textObj)
        {
            if (textObj.getName() == null)
            {
                RoomTextObjects.Add(iNull.ToString(), textObj);
                iNull++;
            }
            else
                RoomTextObjects.Add(textObj.getName(), textObj);
        }

        /// <summary>
        /// Returns the Room text object with the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ScreenText getTextObject(String name)
        {
            return RoomTextObjects[name];
        }

        /// <summary>
        /// Returns all of the Room's text objects.
        /// </summary>
        /// <returns></returns>
        public Dictionary<String, ScreenText> getTextObjects()
        {
            return RoomTextObjects;
        }
    }
}
