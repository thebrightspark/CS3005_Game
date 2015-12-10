using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS3005_Game.Util;
using Microsoft.Xna.Framework.Graphics;
using CS3005_Game.Environment;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using CS3005_Game.Environment.RoomObjects;
using CS3005_Game.Environment.RoomObjects.Text;

namespace CS3005_Game.Entity
{
    class Player
    {
        private String texturePath = Reference.PATH_TEXTURES + "TestCharacter";
        public float xPos, yPos;
        public float lastXPos, lastYPos; //Used in movement collision detection
        public int xTilePos, yTilePos;
        public PlayerSprite2D sprite;
        private ScreenText actionInfoText; //Text popup for action hints
        public enum MoveDir
        {
            UP,
            DOWN,
            LEFT,
            RIGHT
        };
        private MoveDir spriteDir;

        public Player()
        {
            setCoords(-50, -50);
            sprite = new PlayerSprite2D(false);
            actionInfoText = new ScreenText("actionInfo", GameData.FontInfo, "", Reference.WHITE, 0, 0);
        }

        public void setCoords(float x, float y)
        {
            xPos = x;
            yPos = y;
        }

        /// <summary>
        /// Put the player back to it's last coordinates
        /// </summary>
        public void backToLastCoords()
        {
            setCoords(lastXPos, lastYPos);
        }

        /// <summary>
        /// Put the player back to it's last coordinates of the given direction
        /// </summary>
        /// <param name="coordToChange">Either 'x' or 'y'</param>
        public void backToLastCoords(Char coordToChange)
        {
            switch (coordToChange)
            {
                case 'x':
                    setCoords(lastXPos, yPos);
                    break;
                case 'y':
                    setCoords(xPos, lastYPos);
                    break;
                default:
                    new Exception("Input Char must be either 'x' or 'y'");
                    break;
            }
        }

        /// <summary>
        /// Get distance between two points
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        private double getDist(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        /// <summary>
        /// Finds the closest object to the player within reach (Config.playerActionRange) which can be interacted with.
        /// Returns the object or null if none are found.
        /// </summary>
        /// <param name="currentRoom"></param>
        /// <returns></returns>
        public RoomObjectBase findClosestObject(RoomLevelBase currentRoom)
        {
            //Point playerCenter = new Point((int)xPos + (Reference.PIXELS_PER_GRID_SQUARE / 2), (int)yPos + (Reference.PIXELS_PER_GRID_SQUARE / 2));
            Dictionary<String, RoomObjectBase> roomObjects = currentRoom.getRoomObjects();
            RoomObjectBase closestObject = null;
            double distToClosest = double.MaxValue;
            foreach (RoomObjectBase obj in roomObjects.Values)
            {
                if (obj.canBeInteractedWith())
                {
                    Point objPos = obj.getAbsolutePosition();
                    if (closestObject == null)
                    {
                        closestObject = obj;
                        distToClosest = getDist(new Point((int)xPos, (int)yPos), objPos);
                    }
                    else
                    {
                        //Check if obj is closer than current closest
                        Point closestPos = closestObject.getTilePosition();
                        double thisDist = getDist(new Point((int)xPos, (int)yPos), objPos);
                        if (thisDist < distToClosest)
                        {
                            closestObject = obj;
                            distToClosest = thisDist;
                        }
                    }
                }
            }
            if (distToClosest < Reference.playerActionRange)
                return closestObject;
            else
                return null;
        }

        /// <summary>
        /// Causes the player to interact with the closest object within reach.
        /// </summary>
        /// <param name="currentRoom"></param>
        public void action(RoomLevelBase currentRoom)
        {
            RoomObjectBase obj = findClosestObject(currentRoom);
            //TODO: Finish player-object interaction
            //if(obj is RoomObjectButton)
                //((RoomObjectButton)obj).
        }

        /// <summary>
        /// Returns true if the player is about to walk into an object
        /// </summary>
        /// <param name="roomObjects"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        private bool checkForObject(Dictionary<String, RoomObjectBase> roomObjects, MoveDir dir)
        {
            Point tileToCheck = new Point((int)Math.Floor(xPos / Reference.PIXELS_PER_GRID_SQUARE), (int)Math.Floor(yPos / Reference.PIXELS_PER_GRID_SQUARE));
            Point tile2ToCheck = new Point((int)Math.Floor((decimal)((int)xPos + Reference.PIXELS_PER_GRID_SQUARE)) / Reference.PIXELS_PER_GRID_SQUARE, (int)Math.Floor((decimal)((int)yPos + Reference.PIXELS_PER_GRID_SQUARE)) / Reference.PIXELS_PER_GRID_SQUARE);

            switch (dir)
            {
                case MoveDir.UP:
                    tile2ToCheck.Y -= 1;
                    break;
                case MoveDir.DOWN:
                    tileToCheck.Y += 1;
                    break;
                case MoveDir.LEFT:
                    tile2ToCheck.X -= 1;
                    break;
                case MoveDir.RIGHT:
                    tileToCheck.X += 1;
                    break;
            }

            foreach (RoomObjectBase obj in roomObjects.Values)
            {
                Point objPos = obj.getTilePosition();
                Point objSize = obj.getTileSize();
                Point objMaxPos = new Point(objPos.X + objSize.X - 1, objPos.Y + objSize.Y - 1);

                //If tile coords are the same as the space taken by an object
                if ((tileToCheck.X >= objPos.X && tileToCheck.X <= objMaxPos.X && tileToCheck.Y >= objPos.Y && tileToCheck.Y <= objMaxPos.Y) ||
                    (tile2ToCheck.X >= objPos.X && tile2ToCheck.X <= objMaxPos.X && tile2ToCheck.Y >= objPos.Y && tile2ToCheck.Y <= objMaxPos.Y))
                {
                    //If object is a closed gate or any other object, do not player move through
                    if (obj is RoomObjectGate)
                    {
                        if (!((RoomObjectGate)obj).isOpen())
                            return true;
                    }
                    else
                        return true;
                }
            }
            return false;
        }

        public void Update(KeyboardState keyboard, RoomLevelBase currentRoom)
        {
            //Save last position
            lastXPos = xPos;
            lastYPos = yPos;

            //Player movement / action
            if (keyboard.IsKeyDown(Reference.keyLeft))
            {
                xPos -= Reference.playerMoveSpeed;
                //move(Player.MoveDir.LEFT);
            }
            if (keyboard.IsKeyDown(Reference.keyRight))
            {
                xPos += Reference.playerMoveSpeed;
                //move(Player.MoveDir.RIGHT);
            }
            if (keyboard.IsKeyDown(Reference.keyUp))
            {
                yPos -= Reference.playerMoveSpeed;
                //move(Player.MoveDir.UP);
            }
            if (keyboard.IsKeyDown(Reference.keyDown))
            {
                yPos += Reference.playerMoveSpeed;
                //move(Player.MoveDir.DOWN);
            }

            if (keyboard.IsKeyDown(Reference.keyAction))
            {
                //action(currentRoom);
            }

            //Determines the texture of the player depending on movement
            if (xPos != lastXPos || yPos != lastYPos)
            {
                //If player has moved
                if (xPos < lastXPos)
                {
                    //Moving Left
                    spriteDir = MoveDir.LEFT;
                }
                else if (xPos > lastXPos)
                {
                    //Moving Right
                    spriteDir = MoveDir.RIGHT;
                }

                if (yPos < lastYPos)
                {
                    //Moving Up
                    spriteDir = MoveDir.UP;
                }
                else if (yPos > lastYPos)
                {
                    //Moving Down
                    spriteDir = MoveDir.DOWN;
                }

                sprite.setMoveDir(spriteDir);
            }
            else
            {
                //If player has not moved
                sprite.setMoveDir(spriteDir);
                sprite.setNotMoving();
            }

            //Get Room objects
            Dictionary<String, RoomObjectBase> roomObjects = currentRoom.getRoomObjects();
            //Get exit gate position and size
            RoomObjectGate exitGate = (RoomObjectGate) roomObjects[Names.Objects.GATE_EXIT];
            Point exitGateTilePos = exitGate.getTilePosition();
            exitGateTilePos.X += 1; //Gate size is manually adjusted to make more realistic collisions to get through it
            Point exitGateTileMaxPos = new Point(exitGateTilePos.X + exitGate.getTileSize().X - 3, exitGateTilePos.Y + exitGate.getTileSize().Y - 1);
            
            //Get background sprites
            TextureManager.DUNGEON_SPRITES[,] bgSprites = currentRoom.getBackgroundTexture();
            //Get player tile position
            int halfTileSize = Reference.PIXELS_PER_GRID_SQUARE / 2;
            xTilePos = (int) Math.Floor((xPos + halfTileSize) / Reference.PIXELS_PER_GRID_SQUARE);
            yTilePos = (int) Math.Floor((yPos + halfTileSize) / Reference.PIXELS_PER_GRID_SQUARE);
            //Check tile in direction of movement for wall, unless the gate is there
            if (xPos < lastXPos)
            {
                //Moving Left
                if (xPos <= (xTilePos * Reference.PIXELS_PER_GRID_SQUARE))
                {
                    if (bgSprites[xTilePos - 1, yTilePos] == TextureManager.DUNGEON_SPRITES.WALL_L || bgSprites[xTilePos - 1, yTilePos] == TextureManager.DUNGEON_SPRITES.WALL_TL || bgSprites[xTilePos - 1, yTilePos] == TextureManager.DUNGEON_SPRITES.WALL_BL)
                        //If there's a WALL_L, WALL_TL, or WALL_BL to the left of the player
                        backToLastCoords('x');
                    //Check for object here
                    if (checkForObject(roomObjects, MoveDir.LEFT))
                        backToLastCoords('x');
                }

            }
            else if (xPos > lastXPos)
            {
                //Moving Right
                if (xPos >= (xTilePos * Reference.PIXELS_PER_GRID_SQUARE))
                {
                    if (bgSprites[xTilePos + 1, yTilePos] == TextureManager.DUNGEON_SPRITES.WALL_R || bgSprites[xTilePos + 1, yTilePos] == TextureManager.DUNGEON_SPRITES.WALL_TR || bgSprites[xTilePos + 1, yTilePos] == TextureManager.DUNGEON_SPRITES.WALL_BR)
                        //If there's a WALL_R, WALL_TR, or WALL_BR to the right of the player
                        backToLastCoords('x');
                    if (checkForObject(roomObjects, MoveDir.RIGHT))
                        backToLastCoords('x');
                }
            }
            if (yPos < lastYPos)
            {
                //Moving Up
                if (yPos <= (yTilePos * Reference.PIXELS_PER_GRID_SQUARE))
                {
                    if (bgSprites[xTilePos, yTilePos - 2] == TextureManager.DUNGEON_SPRITES.WALL_T || bgSprites[xTilePos, yTilePos - 2] == TextureManager.DUNGEON_SPRITES.WALL_TL || bgSprites[xTilePos, yTilePos - 2] == TextureManager.DUNGEON_SPRITES.WALL_TR)
                    {
                        if (!((xTilePos >= exitGateTilePos.X && xTilePos <= exitGateTileMaxPos.X) && (yTilePos - 1 >= exitGateTilePos.Y && yTilePos - 1 <= exitGateTileMaxPos.Y)))
                        {
                            //If there's a WALL_T, WALL_TL, or WALL_TR above the player and there's no gate
                            backToLastCoords('y');
                            Console.WriteLine("Stopping player at top!");
                        }
                    }
                    if (checkForObject(roomObjects, MoveDir.UP))
                        backToLastCoords('y');
                }
            }
            else if (yPos > lastYPos)
            {
                //Moving Down
                if (yPos >= (yTilePos * Reference.PIXELS_PER_GRID_SQUARE))
                {
                    if (bgSprites[xTilePos, yTilePos + 1] == TextureManager.DUNGEON_SPRITES.WALL_B || bgSprites[xTilePos, yTilePos + 1] == TextureManager.DUNGEON_SPRITES.WALL_BL || bgSprites[xTilePos, yTilePos + 1] == TextureManager.DUNGEON_SPRITES.WALL_BR)
                        //If there's a WALL_B, WALL_BL, or WALL_BR below the player
                        backToLastCoords('y');
                    if (checkForObject(roomObjects, MoveDir.DOWN))
                        backToLastCoords('y');
                }
            }
        }

        /// <summary>
        /// Using this function to update the sprite
        /// </summary>
        public void UpdateLess()
        {
            sprite.nextSprite();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, (int) xPos, (int) yPos);
        }
    }
}
