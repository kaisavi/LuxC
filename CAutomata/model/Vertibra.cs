using System;
using System.Collections.Generic;
using ConsoleGameEngine;

namespace CAutomata.model
{
    public class Vertibra : Sprite
    {
        
        
        Point nextPosition;
        ConsoleColor color;
        bool isHead;

        public int checkNeighbors ()
        {

            return 0;
        }

        public int checkNeighbors(bool left)
        {

            return 0;
        }

        public Vertibra(ConsoleColor color)
        {
            this.color = color;
            loadSprite();
        }

        private void loadSprite()
        {
            switch(color)
            {
                case ConsoleColor.Red:
                    pixels = Sprites.redVertibra;
                    break;
                case ConsoleColor.Blue:
                    pixels = Sprites.blueVertibra;
                    break;
            }
        }
    }
}