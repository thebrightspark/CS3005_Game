using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using CS3005_Game.Util;

namespace CS3005_Game.Environment.RoomObjects
{
    class RoomObjectGate : RoomObjectBase
    {
        private enum GateState
        {
            CLOSING,
            OPENING,
            CLOSED,
            OPEN
        }
        private GateState state = GateState.OPEN;

        /// <summary>
        /// Automatically makes the gate the exit - positioning it at the top center of the Room.
        /// </summary>
        public RoomObjectGate() : base(Names.Objects.GATE_EXIT, TextureManager.GateSprites, false, 7, 1)
        {
            changeSprite(getNumSprites());
        }

        public RoomObjectGate(String name, int xPos, int yPos) : base(name, TextureManager.GateSprites, false, xPos, yPos)
        {

        }

        /// <summary>
        /// Closes the gate.
        /// </summary>
        public void closeGate()
        {
            if(state == GateState.OPEN || state == GateState.OPENING)
                state = GateState.CLOSING;
        }

        /// <summary>
        /// Opens the gate.
        /// </summary>
        public void openGate()
        {
            if(state == GateState.CLOSED || state == GateState.CLOSING)
                state = GateState.OPENING;
        }

        public bool isOpen()
        {
            return state == GateState.OPEN;
        }

        public override void Update()
        {
            //Console.WriteLine("Gate -> " + state.ToString() + " - " + getCurrentFrame() + "/" + getNumSprites());
            switch(state)
            {
                case GateState.OPENING:
                    //Opening gate
                    if (!isLastFrame())
                        nextSprite();
                    else
                        //Gate is now open
                        state = GateState.OPEN;
                    break;
                case GateState.CLOSING:
                    //Closing gate
                    if (!isFirstFrame())
                        lastSprite();
                    else
                        //Gate is now closed
                        state = GateState.CLOSED;
                    break;
                default:
                    //Do nothing if closed or open.
                    break;
            }
        }
    }
}
