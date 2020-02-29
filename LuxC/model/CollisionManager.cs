using System;
using System.Collections.Generic;

namespace LuxC.model
{
    public class CollisionManager
    {
        private List<Collision> collisions = new List<Collision>();
        public void registerForCollision(Orb a,List<Orb> B) {
            
                switch(a.Mode) {
                    case OrbMode.FIRED:
                        collisions.Add(new Collision(a, B));
                        break;
                    case OrbMode.HEAD:
                        collisions.Add(new Collision(a,findStray(B)));
                        break;
                }
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

        private Orb a;
        private List<Orb> B;

        public Collision(Orb a, List<Orb> B) {
            this.a = a;
            this.B = B;
        }

        public void update() {
            a.CollidingBodies.Clear();
            for(int i = 0; i < B.Count; i++) {
                if (Math.Abs(B[i].Position.X - a.Position.X) < 8 && Math.Abs(B[i].Position.Y - a.Position.Y) < 8 && !a.CollidingBodies.Contains(B[i])) {
                    a.CollidingBodies.Add(B[i]);
                }
            }
        }

    }

}