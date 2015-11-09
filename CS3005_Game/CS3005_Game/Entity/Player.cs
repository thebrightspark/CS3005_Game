using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS3005_Game.Util;

namespace CS3005_Game.Entity
{
    class Player : EntityBase
    {
        public Player() : base("player")
        {
            setTexture(Reference.PATH_TEXTURES + "TestCharacter");
        }
    }
}
