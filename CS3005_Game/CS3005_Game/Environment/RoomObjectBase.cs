using CS3005_Game.Util;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS3005_Game.Environment
{
    /// <summary>
    /// Base class for an object within a room.
    /// </summary>
    abstract class RoomObjectBase
    {
        private int Width, Height, XPos, YPos;
        private String Name, texturePath;
        private Rectangle[] spriteRects;

        public RoomObjectBase(String name, TextureManager.DUNGEON_SPRITES[] sprites, int x, int y)
        {
            Name = name;
            XPos = x;
            YPos = y;
            spriteRects = new Rectangle[sprites.Length];
            for(int i = 0; i < sprites.Length; i++)
            {
                spriteRects[i] = TextureManager.getSpriteRect(sprites[i]);
            }
            //TODO: Finish this room objects!
            Width = sprites[0].Width;
            Height = sprites[0].Height;
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
