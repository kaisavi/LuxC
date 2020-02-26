using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAutomata.model;
using ConsoleGameEngine;

namespace CAutomata
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleEngine graphicsEngine = new ConsoleEngine(240,132,8,8);
            Sprite.setEngine(graphicsEngine);
            graphicsEngine.Borderless();
            graphicsEngine.SetPalette(Palettes.Default);
            graphicsEngine.Line(new Point(0, 0), new Point(239, 131), (int)ConsoleColor.Blue);
            graphicsEngine.SetPixel(new Point(0, 0), (int)ConsoleColor.Red);
            graphicsEngine.SetPixel(new Point(239, 131), (int)ConsoleColor.Red);
            Vertibra v = new Vertibra(ConsoleColor.Blue);
            v.Position = new Point(12, 12);
            v.draw();
            graphicsEngine.DisplayBuffer();
            graphicsEngine.ClearBuffer();
            v.Position = new Point(2, 2);
            v.draw();
            PaletteSprite palette = new PaletteSprite();
            palette.Position = new Point(15, 15);
            palette.draw();
            graphicsEngine.DisplayBuffer();
            Console.Read();
        }
    }
}
