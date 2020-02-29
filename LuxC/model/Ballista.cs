using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameEngine;
using LuxC.control;

namespace LuxC.model
{
    //TODO: IT'S BROKEN!! (current task) 

    class Ballista : Sprite
    {
        Orb[] ammo = new Orb[2];
        List<Orb> firedOrbs;
        private readonly CollisionManager collisionManager;
        Lux context;
        private bool nextOrbLoaded = true;

        public void Fire() {
            if(nextOrbLoaded) {
                nextOrbLoaded = false;
                firedOrbs.Add(ammo[0]);
                ammo[0] = ammo[1];
                ammo[1] = GenerateNewOrb();
                                
            }

        }

        private Orb GenerateNewOrb() {
            return new Orb(ConsoleColor.Black,collisionManager);
        }

        public Ballista(Lux context, CollisionManager collisionManager)
        {
            this.context = context;

            fragments = Sprites.ballista;
            this.collisionManager = collisionManager;
            for (int i = 0; i < 2; i++)
                ammo[i] = new Orb(ConsoleColor.Blue, collisionManager);
            Position = new Point(120, 128);

            firedOrbs = new List<Orb>();
        }

        public void Update() {
            ammo[0].Position = this.Position - new Point(0, 5);
            if(firedOrbs.Count > 0)
                if (firedOrbs.Last().Position.Y < 110 && !nextOrbLoaded)
                    nextOrbLoaded = true;

            for(int i = 0; i < firedOrbs.Count(); i++) {
                if (firedOrbs[i].Position.Y > 0)
                    firedOrbs[i].Position += new Point(0, -1);
                else
                    destroy(firedOrbs[i]);
            }
        }

        private void destroy(Orb o) {
            firedOrbs.Remove(o);
        }

        public override void Draw() {
            base.Draw();
            if(nextOrbLoaded)
                ammo[0].Draw();
            engine.SetPixel(Position, (int)ammo[0].Color);
            if (firedOrbs.Count > 0)
                foreach (Orb o in firedOrbs)
                    o.Draw();

            engine.WriteText(new Point(0, 0), firedOrbs.Count().ToString(), 15);
            
        }

        internal void Move(int v) {
            if ( (Position.X > 7 && Math.Sign(v) == -1) || (Position.X < 233 && Math.Sign(v) == 1) )
                Position += new Point(v, 0);                
        }
    }
}
