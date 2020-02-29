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
        CollisionManager collisionManager = new CollisionManager();

        Parade parade;
        Ballista ballista = new Ballista();
        Orb o;

        PaletteSprite palette = new PaletteSprite();

        float time = 0;
        public override void Create()
        {
            Drawable.setEngine(Engine);
            Engine.Borderless();
            Engine.SetBackground(8);

            parade = new Parade(collisionManager);

            o = new Orb(ConsoleColor.White, collisionManager);
            o.Mode = OrbMode.FIRED;
            o.Position = new Point(120, 16);
            
            collisionManager.registerForCollision(o, parade.Orbs);

            palette.Position = new Point(236, 128);




        }

        public override void Render()
        {
            Engine.ClearBuffer();

            o.Draw();
            parade.Draw();

            DrawDebug();

            Engine.DisplayBuffer();
        }

        private void DrawDebug() {

            palette.Draw();
            Engine.WriteText(new Point(224, 0), GetFramerate().ToString(), 0,15);
            Engine.WriteText(new Point(224, 1), time.ToString(), 0,15);
            Engine.WriteText(new Point(224, 2), DeltaTime.ToString(), 0,15);
           
        }


        public override void Update()
        {
            time += DeltaTime;
            checkCollisions();
            parade.update(DeltaTime);
        }

        private void checkCollisions()
        {
            collisionManager.updateCollisions();
        }

    }
}
