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
        Orb firedOrb;
        private readonly CollisionManager collisionManager;
        Lux context;
        private bool nextOrbLoaded = true;

        public void Fire() {
            if(nextOrbLoaded) {
                nextOrbLoaded = false;
                firedOrb = ammo[0];
                firedOrb.Mode = OrbMode.FIRED;
                ammo[0] = ammo[1];
                ammo[1] = GenerateNewOrb();

                collisionManager.registerForCollision(firedOrb, context.Parade.Orbs);
                                
            }

        }

        private Orb GenerateNewOrb() {
            return new Orb(OrbColor.BLACK,collisionManager);
        }

        public Ballista(Lux context, CollisionManager collisionManager)
        {
            this.context = context;

            fragments = Sprites.ballista;
            this.collisionManager = collisionManager;
            for (int i = 0; i < 2; i++)
                ammo[i] = new Orb(OrbColor.BLUE, collisionManager);
            firedOrb = new Orb(OrbColor.RED, collisionManager);
            Position = new Point(120, 128);
        }

        public void Update() {
            ammo[0].Position = this.Position - new Point(0, 5);
                    

                if (firedOrb.Position.Y > 0 && firedOrb.CollidingBodies.Count < 1) {
                    firedOrb.Position += new Point(0, -3);
                } 
                else
                    nextOrbLoaded = true;

        }

        public override void Draw() {
            base.Draw();
            if(nextOrbLoaded)
                ammo[0].Draw();
            engine.SetPixel(Position, getHoldColor(ammo[1].Color));
            firedOrb.Draw();
            engine.WriteText(firedOrb.Position + new Point(5, 0), firedOrb.CollidingBodies.Count().ToString(),15);
            
        }

        internal void Move(int v) {
            if ( (Position.X > 7 && Math.Sign(v) == -1) || (Position.X < 233 && Math.Sign(v) == 1) )
                Position += new Point(v, 0);          
        }

        private int getHoldColor(OrbColor color) {
            switch(color) {
                case OrbColor.RED:
                    return (int)ConsoleColor.DarkRed;
                case OrbColor.BLUE:
                    return (int)ConsoleColor.Blue;
                case OrbColor.WHITE:
                    return (int)ConsoleColor.White;
                case OrbColor.BLACK:
                    return (int)ConsoleColor.Black;
                default:
                    return 0;
            }
                
        }
    }
}
