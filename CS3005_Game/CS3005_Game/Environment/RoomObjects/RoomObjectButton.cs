using CS3005_Game.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS3005_Game.Environment.RoomObjects
{
    class RoomObjectButton : RoomObjectBase
    {
        private String displayName = Names.Objects.BUTTON;
        private bool active = false;

        public RoomObjectButton(String name, int x, int y) : base((Names.Objects.BUTTON + name), TextureManager.DUNGEON_SPRITES.BUTTON_1, x, y)
        {
            //TODO: Finish button!
        }

        public void activate()
        {
            active = true;
        }

        public void deactivate()
        {
            active = false;
        }

        public bool isActive()
        {
            return active;
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
