using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CS3005_Game
{
    /// <summary>
    /// This class is used to handle what happens every update
    /// </summary>
    class GameUpdate
    {
        public static void Update(GameTime gameTime)
        {
            //Runs the update of the current Room
            GameData.getCurrentRoom().update();
        }
    }
}
