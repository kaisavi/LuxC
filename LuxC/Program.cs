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
            Drawable.setEngine(graphicsEngine);
            //graphicsEngine.Borderless();
            graphicsEngine.SetBackground(8);

            Rondure v = new Rondure(ConsoleColor.Blue);
            v.Position = new Point(10, 12);
            v.Draw();

            v.setColor(ConsoleColor.Red);
            v.Position = new Point(10, 18);
            v.Draw();

            v.setColor(ConsoleColor.White);
            v.Position = new Point(16, 12);
            v.Draw();

            v.setColor(ConsoleColor.Black);
            v.Position = new Point(16, 18);
            v.Draw();

            PaletteSprite palette = new PaletteSprite();
            palette.Position = new Point(0, 0);
            palette.Draw();

            Path path = new Path();
            path.Draw();
            Console.Read();
            graphicsEngine.DisplayBuffer();
            Console.Read();
        }
    }
}
