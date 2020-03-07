using System;
using System.Collections.Generic;
using ConsoleGameEngine;
using LuxC.model;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace LuxC.control
{

    //Console size: 240x132 
    class Lux : ConsoleGame
    {
        FigletFont fig = FigletFont.Load("caligraphy.flf");
        public Parade Parade { get; private set; }
        Ballista ballista;

        PaletteSprite palette = new PaletteSprite();

        private float time = 0;
        private float timeScale = 1;
        private Point cursorPos = new Point(0,0);
        private bool running = true;
        public bool demo = false;
        private string playState = "title";

        public override void Create() {
            Drawable.setEngine(Engine);
            CollisionSprite.Init(new CollisionManager());
            if (!demo) {
                Engine.Borderless();
                Console.Title = "LuxC";
            }
            else
                Console.Title = "LuxC Demo";
                
            Engine.SetBackground(8);

            Parade = new Parade();
            ballista = new Ballista(Parade);

            palette.Position = new Point(236, 128);            

        }

        public override void Render()
        {
            Engine.ClearBuffer();
            switch (playState) {
                case "title":
                    Engine.WriteFiglet(new Point(86, 54), "LuxC", fig, (int)ConsoleColor.DarkBlue,(int)ConsoleColor.DarkCyan);
                    Engine.WriteText(new Point(112, 72), "Press Start", 15,0);
                    break;
                case "paused":
                    Engine.WriteFiglet(new Point(78, 54), "Paused", fig, 15, 0);
                    break;
                case "play":
                    Parade.Draw();
                    ballista.Draw();
                    break;

            }
            

       

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
            DeltaTime *= timeScale;

            switch (playState) {
                case "title":
                    if (Engine.GetKeyDown(ConsoleKey.Enter))
                        playState = "play";
                    break;
                case"paused":
                case "play":
                    gamePlay();
                    break;
            }


  

            if (Engine.GetKey(ConsoleKey.K))
                cursorPos.Y++;
            if (Engine.GetKey(ConsoleKey.I))
                cursorPos.Y--;
            if (Engine.GetKey(ConsoleKey.J))
                cursorPos.X--;
            if (Engine.GetKey(ConsoleKey.L))
                cursorPos.X++;
            if (Engine.GetKey(ConsoleKey.OemComma))
                timeScale -= .1f;
            if (Engine.GetKey(ConsoleKey.OemPeriod))
                timeScale += .1f;
            if (Engine.GetKey(ConsoleKey.M))
                timeScale = 1;
        }

        private void gamePlay() {
            if (Engine.GetKeyDown(ConsoleKey.Escape)) {
                running = !running;
                playState = playState == "play" ? "paused" : "play";
            }


            if (running) {
                time += DeltaTime;

                if (Engine.GetKey(ConsoleKey.LeftArrow))
                    ballista.Move(-48, DeltaTime);
                if (Engine.GetKey(ConsoleKey.RightArrow))
                    ballista.Move(48, DeltaTime);
                if (Engine.GetKeyDown(ConsoleKey.Spacebar))
                    ballista.Fire();

                CheckCollisions();
                Parade.update(DeltaTime);
                ballista.Update(DeltaTime);
            }

        }

        private void CheckCollisions() {
            CollisionSprite.collisionManager.updateCollisions();
        }


    }
}
