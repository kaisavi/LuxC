using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameEngine;

namespace LuxC.model
{
    public abstract class Sprite : Drawable
    {
        Point position;
        protected List<Fragment> fragments = Sprites.palette;

        public Point Position { get => position; set => position = value; }

        
        public override void Draw()
        {
            foreach(Fragment frag in fragments)
            {
                engine.SetPixel(frag.Position + position, (int)frag.Color, frag.Character);
            }
        }

    }
}
