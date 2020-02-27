using System;
using ConsoleGameEngine;
using LuxC.model;

namespace LuxC.Controller
{
    class Lux : ConsoleGame
    {

        Rondure r = new Rondure(ConsoleColor.Blue);
        private double timeScale = .1;
        private double time = 0;

        public override void Create()
        {
            Drawable.setEngine(Engine);
            TargetFramerate = 60;
            Drawable.setEngine(Engine);
            Engine.Borderless();
            Engine.SetBackground(8);

        }

        public override void Render()
        {
            Engine.WriteText(new Point(16, 0), GetFramerate().ToString(), 15);
            Engine.ClearBuffer();
            DrawOrbs();
            DrawPath();

            PaletteSprite palette = new PaletteSprite();
            palette.Position = new Point(0, 0);
            palette.Draw();

            Engine.DisplayBuffer();
        }

        private void DrawPath()
        {
            
        }

        private void DrawOrbs()
        {
            r.Draw();
        
      
        }

        public override void Update()
        {
            time += DeltaTime * timeScale;
            r.Position = new Point((int)(16 * Math.Sin(time)) + 32, (int)(16*Math.Cos(time) + 32));
        }
    }
}
