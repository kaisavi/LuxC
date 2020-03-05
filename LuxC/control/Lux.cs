using System;
using System.Collections.Generic;
using ConsoleGameEngine;
using LuxC.model;
using System.Threading;

namespace LuxC.control
{

    //Console size: 240x132 
    class Lux : ConsoleGame
    {

        public Parade Parade { get; private set; }
        Ballista ballista;

        PaletteSprite palette = new PaletteSprite();

        float time = 0;
        private Point cursorPos = new Point(0,0);

        public override void Create() {
            Drawable.setEngine(Engine);
            CollisionSprite.Init(new CollisionManager());
            Engine.Borderless();
            Engine.SetBackground(8);

            Parade = new Parade();
            ballista = new Ballista(Parade);

            palette.Position = new Point(236, 128);


        }

        public override void Render()
        {
            Engine.ClearBuffer();

            Parade.Draw();
            ballista.Draw();

            DrawDebug();

            Engine.DisplayBuffer();
        }

        private void DrawDebug() {

            palette.Draw();
            Engine.WriteText(new Point(224, 0), GetFramerate().ToString(), 0,15);
            Engine.WriteText(new Point(224, 1), time.ToString(), 0,15);
            Engine.WriteText(new Point(224, 2), DeltaTime.ToString(), 0,15);

            Engine.SetPixel(cursorPos, (int)ConsoleColor.Green);
            Engine.WriteText(new Point(224, 4), cursorPos.ToString(),15);
           
        }


        public override void Update() {
            time += DeltaTime;

            if (Engine.GetKey(ConsoleKey.LeftArrow))
                ballista.Move(-48,DeltaTime);
            if (Engine.GetKey(ConsoleKey.RightArrow))
                ballista.Move(48,DeltaTime);
            if (Engine.GetKey(ConsoleKey.Spacebar))
                ballista.Fire();

            if (Engine.GetKey(ConsoleKey.K))
                cursorPos.Y++;
            if (Engine.GetKey(ConsoleKey.I))
                cursorPos.Y--;
            if (Engine.GetKey(ConsoleKey.J))
                cursorPos.X--;
            if (Engine.GetKey(ConsoleKey.L))
                cursorPos.X++;

            CheckCollisions();
            Parade.update(DeltaTime);
            ballista.Update(DeltaTime);
        }

        private void CheckCollisions() {
            CollisionSprite.collisionManager.updateCollisions();
        }


    }
}
