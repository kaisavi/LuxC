using ConsoleGameEngine;
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
            new Point(125,75),
            new Point(200,75),
            
            new Point(250,75),
            
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
                        Orbs.Last().Mode = OrbMode.HEAD;

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
            if (o.Position.X > o.CollidingBodies[0].Position.X)
                ((Orb)o.CollidingBodies[0]).SetColor(OrbColor.RED);
            else
                ((Orb)o.CollidingBodies[0]).SetColor(OrbColor.BLACK);
        }


        public Parade(CollisionManager collisionManager) {
            this.collisionManager = collisionManager;
            Orbs = new List<Orb> {
            new Orb(OrbColor.BLUE,collisionManager),
            new Orb(OrbColor.BLUE,collisionManager),
            new Orb(OrbColor.BLUE,collisionManager),
            new Orb(OrbColor.BLUE,collisionManager),
            new Orb(OrbColor.BLUE,collisionManager),
            new Orb(OrbColor.BLUE,collisionManager),
            new Orb(OrbColor.BLUE,collisionManager),
            new Orb(OrbColor.BLUE,collisionManager),
            new Orb(OrbColor.BLUE,collisionManager),
            new Orb(OrbColor.BLUE,collisionManager),
            new Orb(OrbColor.BLUE,collisionManager),
            new Orb(OrbColor.BLUE,collisionManager),
            new Orb(OrbColor.BLUE,collisionManager),
            new Orb(OrbColor.BLUE,collisionManager),
            new Orb(OrbColor.BLUE,collisionManager),
            new Orb(OrbColor.BLUE,collisionManager)

            };
        }

    }

}
