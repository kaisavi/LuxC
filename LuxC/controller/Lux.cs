using System;
using ConsoleGameEngine;
using LuxC.model;

namespace LuxC.Controller
{
    class Lux : ConsoleGame
    {

        Rondure r = new Rondure(ConsoleColor.Blue);

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
            Engine.ClearBuffer();
            DrawOrbs();
            DrawPath();

            Engine.DisplayBuffer();
        }

        private void DrawPath()
        {
            
        }

        private void DrawOrbs()
        {
            r.Draw();
        
            PaletteSprite palette = new PaletteSprite();
            palette.Position = new Point(0, 0);
            palette.Draw();
        }

        public override void Update()
        {
            
        }
    }
}
