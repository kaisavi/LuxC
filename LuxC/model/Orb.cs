using System;
using System.Collections.Generic;
using ConsoleGameEngine;

namespace LuxC.model
{
    public class Orb : CollisionSprite
    {

        internal OrbColor Color { get; private set; }
        internal void SetColor(OrbColor color) {
            this.Color = color;
            LoadSprite();
        }

        public double Progress { get; set; } = -1;
        public OrbMode Mode { get; set; } = OrbMode.NORMAL;

        public int CheckNeighbors() {
            //TODO: Orb nieghbor checks
            return 0;
        }

        public int CheckNeighbors(bool left) {
            //TODO: Orb directional checks
            return 0;
        }

        internal Orb(OrbColor color, CollisionManager collisionManager) : base(collisionManager) {
            SetColor(color);
        }

        private void LoadSprite() {
            switch(Color)
            {
                case OrbColor.RED:
                    fragments = Sprites.redOrb;
                    break;
                case OrbColor.BLUE:
                    fragments = Sprites.blueOrb;
                    break;
                case OrbColor.WHITE:
                    fragments = Sprites.whiteOrb;
                    break;
                case OrbColor.BLACK:
                    fragments = Sprites.blackOrb;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid color for orb");
            }
        }    
                            
    }
}

internal enum OrbColor {
    //
    // Summary:
    //     Red Orb
    RED = 0,
    BLUE = 1,
    WHITE = 2,
    BLACK = 3
}