using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameEngine;

namespace LuxC.model
{
    public abstract class Sprite
    {
        Point position;
        private static ConsoleEngine engine;
        protected List<Pixel> pixels = Sprites.palette;

        public Point Position { get => position; set => position = value; }

        public void draw()
        {
            foreach(Pixel pixel in pixels)
            {
                engine.SetPixel(pixel.Position + position, (int)pixel.Color, pixel.Character);
            }
        }

        public static void setEngine(ConsoleEngine e)
        {
            engine = e;
        }

    }
}
