using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS3005_Game.Environment
{
    /// <summary>
    /// Base class for an object within a room.
    /// </summary>
    class RoomObjectBase
    {
        private int Width, Height, XPos, YPos;
        private String Name, texturePath;

        public RoomObjectBase(String name, int width, int height, int x, int y)
        {
            Name = name;
            Width = width;
            Height = height;
            XPos = x;
            YPos = y;
        }

        public String getName()
        {
            return Name;
        }

        public void setTexturePath(String path)
        {
            texturePath = path;
        }

        public String getTexturePath()
        {
            return texturePath;
        }
    }
}
