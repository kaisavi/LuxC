using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuxC.model;
using ConsoleGameEngine;

namespace LuxC
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleEngine graphicsEngine = new ConsoleEngine(240,132,8,8);
            Sprite.setEngine(graphicsEngine);
            graphicsEngine.Borderless();
            graphicsEngine.SetBackground(8);

            Vertibra v = new Vertibra(ConsoleColor.Blue);
            v.Position = new Point(10, 12);
            v.draw();

            v.setColor(ConsoleColor.Red);
            v.Position = new Point(10, 18);
            v.draw();

            v.setColor(ConsoleColor.White);
            v.Position = new Point(16, 12);
            v.draw();

            v.setColor(ConsoleColor.Black);
            v.Position = new Point(16, 18);
            v.draw();

            PaletteSprite palette = new PaletteSprite();
            palette.Position = new Point(0, 0);
            palette.draw();

            graphicsEngine.DisplayBuffer();
            Console.Read();
        }
    }
}
