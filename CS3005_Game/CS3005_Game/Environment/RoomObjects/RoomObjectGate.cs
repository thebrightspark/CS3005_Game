using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using CS3005_Game.Util;

namespace CS3005_Game.Environment.RoomObjects
{
    class RoomObjectGate : RoomObjectBase
    {
        public RoomObjectGate(String name, int xPos, int yPos) : base(name, TextureManager.GateSprites, 0, 0)
        {

        }
    }
}
