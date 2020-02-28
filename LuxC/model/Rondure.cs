using System;
using System.Collections.Generic;
using ConsoleGameEngine;

namespace LuxC.model
{
    public class Rondure : Leprechaun
    {
        
        ConsoleColor color;
        private bool isHead = false;
        private double progress = -1;

        public double Progress { get => progress; set => progress = value; }
        internal RondureMode Mode { get => mode; set => mode = value; }

        private RondureMode mode = RondureMode.NORMAL;

        public int checkNeighbors ()
        {

            return 0;
        }

        public int checkNeighbors(bool left)
        {

            return 0;
        }

        public Rondure(ConsoleColor color)
        {
            this.color = color;
            loadSprite();
        }

        private void loadSprite()
        {
            switch(color)
            {
                case ConsoleColor.Red:
                    pixels = Leprechauns.redVertibra;
                    break;
                case ConsoleColor.Blue:
                    pixels = Leprechauns.blueVertibra;
                    break;
                case ConsoleColor.White:
                    pixels = Leprechauns.whiteVertibra;
                    break;
                case ConsoleColor.Black:
                    pixels = Leprechauns.blackVertibra;
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

        public void setAsHead()
        {
            isHead = true;
        }


        
    }
}