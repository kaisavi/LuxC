using System;
using System.Collections.Generic;
using ConsoleGameEngine;

namespace LuxC.model
{
    public class Orb : CollisionSprite
    {

        public ConsoleColor Color { get; private set; }
        internal void SetColor(ConsoleColor color) {
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

        public Orb(ConsoleColor color, CollisionManager collisionManager) : base(collisionManager) {
            SetColor(color);
        }

        private void LoadSprite() {
            switch(Color)
            {
                case ConsoleColor.Red:
                    fragments = Sprites.redVertibra;
                    break;
                case ConsoleColor.Blue:
                    fragments = Sprites.blueVertibra;
                    break;
                case ConsoleColor.White:
                    fragments = Sprites.whiteVertibra;
                    break;
                case ConsoleColor.Black:
                    fragments = Sprites.blackVertibra;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid color for orb");
            }
        }

        



       
    }
}