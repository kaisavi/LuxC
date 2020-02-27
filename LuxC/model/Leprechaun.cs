using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameEngine;

namespace LuxC.model
{
    public abstract class Leprechaun : Drawable
    {
        Point position;
        protected List<Fragment> pixels = Sprites.palette;

        public Point Position { get => position; set => position = value; }

        
        public override void Draw()
        {
            foreach(Fragment pixel in pixels)
            {
                engine.SetPixel(pixel.Position + position, (int)pixel.Color, pixel.Character);
            }
        }

    }
}
