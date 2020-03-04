using ConsoleGameEngine;
using System;
using System.Collections.Generic;

namespace LuxC.model
{
    public class CollisionManager
    {
        private List<Collision> collisions = new List<Collision>();
        public void registerCollisions(Orb a,List<Orb> B) {
            
                switch(a.Mode) {
                    case OrbMode.FIRED:
                        collisions.Add(new Collision(a, B));
                        break;
                    case OrbMode.HEAD:
                        collisions.Add(new Collision(a,findStray(B)));
                        break;
                }
            }

        public void unregisterCollisions(Orb a) {
            a.CollidingBodies.Clear();
            collisions.RemoveAll((Collision c) => { return c.a.Equals(a); });
        }

        public void updateCollisions() {
            foreach(Collision c in collisions) {
                c.update();
            }
        }

        private List<Orb> findStray(List<Orb> B) {

            foreach (Orb b in B) {
                if(b is Orb) {
                    if (((Orb)b).Mode.Equals(OrbMode.STRAY))
                        return new List<Orb> { b };
                }
            }
                return null;
        }
    }


    internal class Collision {

        public readonly Orb a;
        private List<Orb> B;

        public Collision(Orb a, List<Orb> B) {
            this.a = a;
            this.B = B;
        }

        public void update() {
            a.CollidingBodies.Clear();
            for(int i = 0; i < B.Count; i++) {
                if (Point.Distance(a.Position,B[i].Position) < 7) {  
              //if (Math.Abs(B[i].Position.X - a.Position.X) < 7 && Math.Abs(B[i].Position.Y - a.Position.Y) < 7 && !a.CollidingBodies.Contains(B[i])) {
                    a.CollidingBodies.Add(B[i]);
                }
            }
        }

    }

}