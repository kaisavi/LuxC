using System;
using System.Collections.Generic;
using ConsoleGameEngine;
using LuxC.model;

namespace LuxC.control
{
    class Lux : ConsoleGame
    {

        Rondure r = new Rondure(ConsoleColor.Blue);
        //Thoroughfare t = new Thoroughfare(new List<Point> { } );
        Callithump c = new Callithump();

        private double timeScale = 1;
        private double time = 0;

        public override void Create()
        {
            Drawable.setEngine(Engine);
            TargetFramerate = 30;
            Drawable.setEngine(Engine);
            Engine.Borderless();
            Engine.SetBackground(8);

        }

        public override void Render()
        {
            Engine.ClearBuffer();
            
            Engine.WriteText(new Point(224, 0), GetFramerate().ToString(), 0,15);
            Engine.WriteText(new Point(224, 1), time.ToString(), 0,15);
            Engine.WriteText(new Point(224, 2), DeltaTime.ToString(), 0,15);
            
            DrawThoroughfare();
            DrawRondures();

            PaletteSprite palette = new PaletteSprite();
            palette.Position = new Point(236, 128);
            palette.Draw();

            Engine.DisplayBuffer();
        }

        private void DrawThoroughfare()
        {
            //t.Draw();

            c.Thoroughfare.Draw();
        }

        private void DrawRondures()
        {
            //r.Draw();
        
            foreach(Rondure rondure in c.Rondures)
            {
                rondure.Draw();
            }
        }

        public override void Update()
        {
            time += DeltaTime * timeScale;

            //r.Position = new Point((int)(16 * Math.Sin(2*time*Math.PI)) + 32, (int)(16*Math.Cos(2*time*Math.PI) + 32));
            c.update(DeltaTime);
        }
    }
}
