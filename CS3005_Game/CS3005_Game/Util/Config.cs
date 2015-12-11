using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS3005_Game.Util
{
    class Config
    {
        public static float screenScale = 2.5f;
        public static int updatesPerSecond = 10;
        public static int playerMoveSpeed = 3;
        public static float soundVolume = 1.0f;

        public static bool debugSquares = false;

        public static Keys keyUp = Keys.Up;
        public static Keys keyDown = Keys.Down;
        public static Keys keyLeft = Keys.Left;
        public static Keys keyRight = Keys.Right;
        public static Keys keyAction = Keys.Space;
    }
}
