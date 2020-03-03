using System;
using System.Collections.Generic;
using ConsoleGameEngine;

namespace LuxC.model
{
    public class Orb : CollisionSprite {
        
        internal OrbColor Color { get; private set; }
        internal void SetColor(OrbColor color) {
            this.Color = color;
            LoadSprite();

        }

        public double Progress { get; set; } = -1;
        public OrbMode Mode { get; set; } = OrbMode.NORMAL;

        internal Orb(OrbColor color){
            SetColor(color);
        }

        private void LoadSprite() {
            switch (Color) {
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


        public void registerCollision(List<Orb> orbs) {
            if(Mode.Equals(OrbMode.FIRED))
                collisionManager.registerCollisions(this, orbs);
            if (Mode.Equals(OrbMode.HEAD))
                collisionManager.registerCollisions(this, orbs.FindAll((Orb o) => o.Mode.Equals(OrbMode.STRAY)));
        }

        public void unregisterCollision() {
            collisionManager.unregisterCollisions(this);
        }
    }
}


internal enum OrbColor {
    RED = 0,
    BLUE = 1,
    WHITE = 2,
    BLACK = 3
}