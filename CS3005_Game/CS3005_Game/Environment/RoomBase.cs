using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CS3005_Game.Environment
{
    class RoomBase
    {
        private String Name;
        private String TexturePath;
        private List<RoomObjectBase> RoomObjects = new List<RoomObjectBase>();

        public RoomBase(String name)
        {
            Name = name;
        }

        public void setBackgroundTexture(String path)
        {
            TexturePath = path;
        }

        public String getBackgroundTexture()
        {
            return TexturePath;
        }

        /// <summary>
        /// Adds a new object to the room
        /// </summary>
        /// <param name="obj">The room object</param>
        public void addNewObject(RoomObjectBase obj)
        {
            RoomObjects.Add(obj);
        }

        /// <summary>
        /// Removes the named object from the objects in the room if it exists.
        /// Returns whether it was successful or not.
        /// </summary>
        /// <param name="name">Name of the object</param>
        /// <returns>Success</returns>
        public bool removeObject(String name)
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
