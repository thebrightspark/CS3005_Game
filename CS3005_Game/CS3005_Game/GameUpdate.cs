using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CS3005_Game.Util;
using Microsoft.Xna.Framework.Input;

namespace CS3005_Game
{
    /// <summary>
    /// This class is used to handle what happens every update
    /// </summary>
    class GameUpdate
    {
        private static int updatesMillis = (int)((1 / (float)Config.updatesPerSecond) * 1000);
        private static short updateCount = 0;
        private static int thisMillis = 0;

        public static void Update(GameTime gameTime)
        {
            thisMillis = gameTime.TotalGameTime.Milliseconds;

            //Console.WriteLine("updateCount: " + updateCount + "   this: " + thisMillis);

            //Updates the Keyboard State
            GameData.keyboard = Keyboard.GetState();

            //Runs the update of the current Room
            GameData.getCurrentRoom().update();

            //This code runs every set interval -> 1/Config.updatesPerSecond
            if (thisMillis >= (updateCount * updatesMillis) && thisMillis < ((updateCount + 1) * updatesMillis))
            {
                GameData.getCurrentRoom().updateSprites();

                //Add to the update counter
                updateCount++;
                if (updateCount >= Config.updatesPerSecond)
                    updateCount = 0;
            }
        }
    }
}
