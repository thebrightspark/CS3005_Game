using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS3005_Game.Util;

namespace CS3005_Game.Entity
{
    class EntityBase
    {
        private static String entityName;
        private static String texturePath;

        public EntityBase() : this("Unknown")
        {
            
        }

        public EntityBase(String name)
        {
            entityName = name;
            texturePath = Reference.PATH_TEXTURES + "Unknown";
        }

        public static void setTexture(String path)
        {
            texturePath = path;
        }

        public static String getTexture()
        {
            return texturePath;
        }
    }
}
