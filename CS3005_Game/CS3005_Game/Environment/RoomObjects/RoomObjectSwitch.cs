using CS3005_Game.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS3005_Game.Environment.RoomObjects
{
    class RoomObjectSwitch : RoomObjectBase
    {
        private String displayName = Names.Objects.SWITCH;
        private bool active = false;

        public RoomObjectSwitch(String name, int x, int y) : base(name, TextureManager.SwitchSprites, false, x, y)
        {
            //TODO: Finish switch!
        }

        public bool isActive()
        {
            return active;
        }

        public void toggle()
        {
            active = !active;
        }

        public override bool canBeInteractedWith()
        {
            return true;
        }

        public override void Update()
        {
            
        }
    }
}
