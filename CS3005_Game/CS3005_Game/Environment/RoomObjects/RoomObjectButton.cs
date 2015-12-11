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

        public RoomObjectButton(String name, TextureManager.DUNGEON_SPRITES buttonSprite, int x, int y) : base(name, buttonSprite, x, y)
        {
            switch (buttonSprite)
            {
                case TextureManager.DUNGEON_SPRITES.BUTTON_1:
                case TextureManager.DUNGEON_SPRITES.BUTTON_2:
                case TextureManager.DUNGEON_SPRITES.BUTTON_3:
                case TextureManager.DUNGEON_SPRITES.BUTTON_4:
                case TextureManager.DUNGEON_SPRITES.BUTTON_5:
                    break;
                default:
                    new Exception("Must give a button sprite!");
                    break;
            }
        }

        public void activate()
        {
            active = true;
            GameData.SoundClick1.Play();
        }

        public void deactivate()
        {
            active = false;
        }

        public bool isActive()
        {
            if (active)
            {
                active = false;
                return true;
            }
            return false;
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
