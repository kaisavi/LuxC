using System;
using System.Collections.Generic;
using ConsoleGameEngine;

namespace LuxC.model
{
    public class Orb : CollisionSprite
    {

        ConsoleColor color;
        private double progress = -1;

        public double Progress { get => progress; set => progress = value; }
        internal OrbMode Mode { get; set; } = OrbMode.NORMAL;

        public int checkNeighbors()
        {

            return 0;
        }

        public int checkNeighbors(bool left)
        {

            return 0;
        }

        public Orb(ConsoleColor color, CollisionManager collisionManager) : base(collisionManager){
            setColor(color);
        }

        private void loadSprite()
        {
            switch(color)
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
                    throw new ArgumentOutOfRangeException("Invalid color for vertabrate");
            }
        }

        

        internal void setColor(ConsoleColor color)
        {
            this.color = color;
            loadSprite();
        }

       
    }
}