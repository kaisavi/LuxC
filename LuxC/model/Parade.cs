﻿using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxC.model
{
    //Console size: 240x132
    class Parade : Drawable {

        private CollisionManager collisionManager;
        public Path Path { get; } = new Path(new List<Point> {
            
            new Point(-10,75),
            
            new Point(75,76),
            new Point(200,75),
            new Point(100,12),
            new Point(125,12),
            new Point(125,12),
            new Point(200,12),
            
            new Point(250,12),
            
        });
        public List<Orb> Orbs { get; }

        private int speed = 12;

        public void update(float deltaTime) {
            if(Orbs.Count > 0)
                advance(deltaTime);
        }


        private void advance(float deltaTime) {
            
            Orbs.Last().Progress += speed * deltaTime;

            for (int i = Orbs.Count - 1; i >= 0; i--)
            {
                if(i != Orbs.Count - 1)
                    Orbs[i].Progress = Orbs.Last().Progress - (7 * ((Orbs.Count - 1) - i));

                if (Orbs[i].Progress >= Path.Length - 1)
                {
                    destroy(Orbs[i]);

                    if(Orbs.Count != 0)
                        Orbs.Last().Mode = Orbs.Last().Mode != OrbMode.TAIL ? OrbMode.HEAD:OrbMode.TAIL;
                                                         

                    break;
                }

                Orbs[i].Position = Path.Points[Math.Max((int)Math.Floor(Orbs[i].Progress), 0)];
            }
        }

        private void destroy(Orb rondure)
        {
            Orbs.Remove(rondure);
        }

        public override void Draw() {
            DrawPath();
            DrawOrbs();

            for (int i = Orbs.Count - 1; i >= 0; i--) {
                engine.WriteText(new Point(0, Orbs.Count - i),$"{i}. {Orbs[i].Color.ToString()} {Orbs[i].Mode.ToString()}", 15);
            }
        }

        private void DrawPath() {
            Path.Draw();
        }

        private void DrawOrbs() {
            foreach (Orb orb in Orbs) {
                orb.Draw();
            }
        }

        public void insert(Orb o) {
            Orb c = (Orb)o.CollidingBodies[0];
            insert(o, Orbs.IndexOf(c) + (o.Position.X > c.Position.X ? 1:0));

        }

        private void insert(Orb o, int i) {
            if(i == Orbs.Count) {
                o.Mode = OrbMode.HEAD;
                Orbs[i-1].Mode = OrbMode.NORMAL;
                Orbs.Add(o);
            }
            else if(i == 0) {
                o.Mode = OrbMode.TAIL;
                Orbs[0].Mode = OrbMode.NORMAL;
                Orbs.Insert(0, o);
            }
            else {
                o.Progress = Orbs[i].Progress;
                o.Mode = OrbMode.NORMAL;
                Orbs.Last().Progress += i == 0 ? 0 : 7;
                Orbs.Insert(i, o);
            }
            
        }

        public Parade(CollisionManager collisionManager) {
            this.collisionManager = collisionManager;
            Orbs = new List<Orb> {
            new Orb(OrbColor.BLUE,collisionManager),
            new Orb(OrbColor.BLACK,collisionManager),
            new Orb(OrbColor.BLACK,collisionManager),
            new Orb(OrbColor.BLUE,collisionManager),
            new Orb(OrbColor.BLUE,collisionManager),
            new Orb(OrbColor.BLUE,collisionManager)

            };

            Orbs.Last().Mode = OrbMode.HEAD;
            Orbs.First().Mode = OrbMode.TAIL;
        }

    }

}
