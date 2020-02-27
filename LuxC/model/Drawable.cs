using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameEngine;


namespace LuxC.model
{
    public abstract class Drawable
    {
        protected static ConsoleEngine engine;
        public abstract void Draw();

        public static void setEngine(ConsoleEngine e)
        {
            engine = e;
        }
    }
}
