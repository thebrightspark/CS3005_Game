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
        /// <summary>
        /// Automatically makes the gate the exit - positioning it at the top center of the Room.
        /// </summary>
        public RoomObjectGate() : base(Names.Objects.GATE_EXIT, TextureManager.GateSprites, true, 7, 1)
        {

        }

        public RoomObjectGate(String name, int xPos, int yPos) : base(name, TextureManager.GateSprites, false, xPos, yPos)
        {

        }
    }
}
