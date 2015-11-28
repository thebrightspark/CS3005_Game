using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS3005_Game.Util;
using Microsoft.Xna.Framework.Graphics;

namespace CS3005_Game.Entity
{
    class Player
    {
        private String texturePath = Reference.PATH_TEXTURES + "TestCharacter";
        public float xPos, yPos;
        public PlayerSprite2D sprite;

        public Player()
        {
            xPos = -50;
            yPos = -50;
            sprite = new PlayerSprite2D();
        }

        public Player(float x, float y)
        {
            xPos = x;
            yPos = y;
        }

        public void setCoords(float x, float y)
        {
            xPos = x;
            yPos = y;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
    }
}
