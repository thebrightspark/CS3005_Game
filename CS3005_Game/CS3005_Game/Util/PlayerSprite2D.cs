using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CS3005_Game.Entity;

namespace CS3005_Game.Util
{
    class PlayerSprite2D
    {
        private int spriteWidth = 16;
        private int spriteHeight = 16;
        private bool genderIsMale;
        private Player.MoveDir lastDir = Player.MoveDir.UP;
        private bool isMoving = false;
        private int spriteFrameNum = 0; //TODO: Finish using this =P

        public Texture2D texture;
        public Vector2 position;
        private Rectangle spriteRect;
        private TextureManager.PLAYER_SPRITES[] currentMovementSprites;
        private Color colour;
        public float rotation;
        private Vector2 origin;
        public Vector2 scale;
        private SpriteEffects effect;
        private float layerDepth;

        private void init(bool isMale)
        {
            texture = GameData.PlayerSpriteSheet;
            position = new Vector2(-64, -64);
            spriteRect = new Rectangle(0, 0, spriteWidth, spriteHeight);
            colour = Color.White;
            rotation = 0f;
            origin = new Vector2(0f);
            scale = new Vector2(Reference.screenScale);
            effect = SpriteEffects.None;
            layerDepth = 0f;
            genderIsMale = isMale;
            if(isMale)
                currentMovementSprites = TextureManager.MPlayerUpSprites;
            else
                currentMovementSprites = TextureManager.FPlayerUpSprites;
            setNotMoving();
        }

        public PlayerSprite2D(bool isMale)
        {
            init(isMale);
        }

        public PlayerSprite2D()
        {
            init(true);
        }

        /// <summary>
        /// Returns the width of the sprite.
        /// </summary>
        /// <returns></returns>
        public int getSpriteWidth()
        {
            return spriteRect.Width;
        }

        /// <summary>
        /// Returns the height of the sprite.
        /// </summary>
        /// <returns></returns>
        public int getSpriteHeight()
        {
            return spriteRect.Height;
        }

        /// <summary>
        /// Sets the gender of the player.
        /// If input is false, then player is female.
        /// </summary>
        /// <param name="male"></param>
        public void setGender(bool male)
        {
            genderIsMale = male;
        }

        /// <summary>
        /// Sets the current sprite set to the movement direction
        /// </summary>
        /// <param name="moveDir"></param>
        public void setMoveDir(Player.MoveDir moveDir)
        {
            isMoving = true;

            //Only need to run this if the direction has changed
            if (moveDir != lastDir)
            {
                if (genderIsMale)
                {
                    switch (moveDir)
                    {
                        case Player.MoveDir.UP:
                            currentMovementSprites = TextureManager.MPlayerUpSprites;
                            break;
                        case Player.MoveDir.DOWN:
                            currentMovementSprites = TextureManager.MPlayerDownSprites;
                            break;
                        case Player.MoveDir.LEFT:
                            currentMovementSprites = TextureManager.MPlayerLeftSprites;
                            break;
                        case Player.MoveDir.RIGHT:
                            currentMovementSprites = TextureManager.MPlayerRightSprites;
                            break;
                        default:
                            //Shouldn't get here.
                            new Exception("Invalid move direction!");
                            break;
                    }
                }
                else
                {
                    switch (moveDir)
                    {
                        case Player.MoveDir.UP:
                            currentMovementSprites = TextureManager.FPlayerUpSprites;
                            break;
                        case Player.MoveDir.DOWN:
                            currentMovementSprites = TextureManager.FPlayerDownSprites;
                            break;
                        case Player.MoveDir.LEFT:
                            currentMovementSprites = TextureManager.FPlayerLeftSprites;
                            break;
                        case Player.MoveDir.RIGHT:
                            currentMovementSprites = TextureManager.FPlayerRightSprites;
                            break;
                        default:
                            //Shouldn't get here.
                            new Exception("Invalid move direction!");
                            break;
                    }
                }
                lastDir = moveDir;
            }
        }

        /// <summary>
        /// Sets the sprite to the standing sprite of the last movement direction
        /// </summary>
        public void setNotMoving()
        {
            isMoving = false;
            spriteFrameNum = 1;
        }

        /// <summary>
        /// Will change the next sprite in the sprite set if moving
        /// </summary>
        public void nextSprite()
        {
            if (isMoving)
            {
                spriteFrameNum++;
                if (spriteFrameNum >= currentMovementSprites.Count())
                {
                    spriteFrameNum = 0;
                }
            }
        }

        /// <summary>
        /// Draws the sprite on the screen with it's own defined variables.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            position = new Vector2(x, y);
            spriteRect = TextureManager.getPlayerSpriteRect(currentMovementSprites[spriteFrameNum]);

            spriteBatch.Draw(
                texture,
                position,
                spriteRect,
                colour,
                rotation,
                origin,
                scale,
                effect,
                layerDepth);
        }
    }
}
