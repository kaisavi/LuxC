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
        private int activeHead;

        public void update(float deltaTime) {

            if (Orbs.Count > 0) {
                checkForHeadCollision();
                advance(deltaTime);
            }
        }

        private void checkForHeadCollision() {
            //TODO: fix bug where parade jumps forward on recombination 

            if(Orbs[activeHead].CollidingBodies.Count > 0) {
                Orbs[activeHead].Mode = OrbMode.NORMAL;
                Orbs[activeHead].unregisterCollision();
                Orbs[activeHead + 1].Mode = OrbMode.NORMAL;
                activeHead = Orbs.FindIndex((Orb o) => { return o.isHead(); });
            }
                
        }

        private void advance(float deltaTime) {

            Orbs[activeHead].Progress += speed * deltaTime;

            for (int i = activeHead; i >= 0; i--)
            {
                if(i != activeHead)
                    Orbs[i].Progress = Orbs[activeHead].Progress - (7 * ((activeHead) - i));

                if (Orbs[i].Progress >= Path.Length - 1)
                {
                    DestroyAtEnd(Orbs[i]);

                    if(Orbs.Count != 0)
                        Orbs.Last().Mode = Orbs.Last().Mode != OrbMode.TAIL ? OrbMode.HEAD:OrbMode.TAIL;
                                                         

                    break;
                }

                Orbs[i].Position = Path.Points[Math.Max((int)Math.Floor(Orbs[i].Progress), 0)];
            }
        }

        private void DestroyAtEnd(Orb rondure)
        {
            if (activeHead == Orbs.Count - 1) {
                activeHead--;
            }
            Orbs.Remove(rondure);
             
        }

        private void DestroyRange(int index, int range) {
            if(index == 0 && range == Orbs.Count) {
                Orbs.Clear();
            }
            else {

                if (index + range >= Orbs.Count - 1)
                    Orbs[index - 1].Mode = OrbMode.HEAD;
                else if (index == 0) {
                    Orbs[index + range].Mode = OrbMode.TAIL;

                }
                else {
                    Orbs[index + range].Mode = OrbMode.STRAY;
                    Orbs[index - 1].Mode = OrbMode.HEAD;
                    Orbs[index - 1].registerCollision(Orbs);

                }
                Orbs.RemoveRange(index, range);
                activeHead = Orbs.FindIndex((Orb o) => { return o.isHead(); });
            }
            //TODO: Recursive Destruction 
        }

        public override void Draw() {
            DrawPath();
            DrawOrbs();

            for (int i = Orbs.Count - 1; i >= 0; i--) {
                engine.WriteText(new Point(0, Orbs.Count - i),
                    $"{i}. {Orbs[i].Color.ToString()} {Orbs[i].Mode.ToString()} + {Orbs[i].Progress}",
                    i == activeHead ? 7 : 15
                    ) ;
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
            o.unregisterCollision();
            insert(o, Orbs.IndexOf(c) + (o.Position.X > c.Position.X ? 1:0));

        }

        private void insert(Orb o, int i) {
            if(i == Orbs.Count) {
                o.Mode = OrbMode.HEAD;
                Orbs[i-1].Mode = OrbMode.NORMAL;
                o.Progress = Orbs[i - 1].Progress + 6;
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
            activeHead++;
            checkForConsecutives(o);
        }

        public Parade() {
            Orbs = new List<Orb> {
            new Orb(OrbColor.BLUE),
            new Orb(OrbColor.BLUE),
            new Orb(OrbColor.BLUE),
            new Orb(OrbColor.BLACK),
            new Orb(OrbColor.BLACK),
            new Orb(OrbColor.BLACK),
            new Orb(OrbColor.BLACK),
            new Orb(OrbColor.BLUE),
            new Orb(OrbColor.BLUE),
            new Orb(OrbColor.BLUE)

            };
           // Orbs.Last().Progress = 60;
            //Orbs[4].Mode = OrbMode.STRAY;
            Orbs.Last().Mode = OrbMode.HEAD;
            Orbs.First().Mode = OrbMode.TAIL;

            activeHead = Orbs.FindIndex((Orb o) => { return o.isHead(); });
        }


        public void checkForConsecutives(Orb o) {
            OrbColor color = o.Color;
            bool backSearching = true;
            int consecutives = 1;
            int consecutivesStart = 0;
            int i = Orbs.IndexOf(o)-1;
            while (backSearching) {
                if (i < 0) {
                    backSearching = false;
                    break;
                }
                if (Orbs[i].Color.Equals(color)) {
                    consecutives++;
                    i--;
                }
                else {
                    consecutivesStart = i + 1;
                    backSearching = false;
                }
                    
            }

            bool forwardSearching = true;
            i = Orbs.IndexOf(o)+1;
            
            while (forwardSearching) {
                if (i >= Orbs.Count()) {
                    forwardSearching = false;
                    break;
                }
                if(Orbs[i].Color.Equals(color)) {
                    consecutives++;
                    i++;
                }
                else {
                    forwardSearching = false;
                }
            }

            if(consecutives >= 3) {
                DestroyRange(consecutivesStart, consecutives);
            }
        }

    }

}
