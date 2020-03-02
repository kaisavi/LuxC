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
        public static readonly CollisionManager collisionManager = new CollisionManager();

        public Parade Parade { get; private set; }
        Ballista ballista;

        PaletteSprite palette = new PaletteSprite();

        float time = 0;
        public override void Create() {
            Drawable.setEngine(Engine);
            Engine.Borderless();
            Engine.SetBackground(8);

            Parade = new Parade(collisionManager);
            ballista = new Ballista(Parade, collisionManager);

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
           
        }


        public override void Update() {
            time += DeltaTime;

            if (Engine.GetKey(ConsoleKey.LeftArrow))
                ballista.Move(-1);
            if (Engine.GetKey(ConsoleKey.RightArrow))
                ballista.Move(1);
            if (Engine.GetKey(ConsoleKey.Spacebar))
                ballista.Fire();

            CheckCollisions();
            Parade.update(DeltaTime);
            ballista.Update();
        }

        private void CheckCollisions() {
            collisionManager.updateCollisions();
        }


    }
}
