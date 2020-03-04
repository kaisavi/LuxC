using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameEngine;
using LuxC.control;

namespace LuxC.model
{

    class Ballista : Sprite
    {
        Orb[] ammo = new Orb[2];
        Orb firedOrb;
        Parade parade;
        private bool nextOrbLoaded = true;

        float xPos = 120;
        float orbPos;

        public void Fire() {
            if(nextOrbLoaded) {
                nextOrbLoaded = false;
                firedOrb = ammo[0];
                orbPos = firedOrb.Position.Y;
                firedOrb.Mode = OrbMode.FIRED;
                ammo[0] = ammo[1];
                ammo[1] = GenerateNewOrb();

                firedOrb.registerCollision(parade.Orbs);

            }

        }

        private Orb GenerateNewOrb() {
            return new Orb((OrbColor)new Random().Next(0,4));
        }

        public Ballista(Parade parade)
        {
            this.parade = parade;

            fragments = Sprites.ballista;
            for (int i = 0; i < 2; i++)
                ammo[i] = new Orb(OrbColor.BLUE);
            firedOrb = new Orb(OrbColor.RED);
            Position = new Point(120, 128);
        }

        public void Update(float deltaTime) {
            ammo[0].Position = this.Position - new Point(0, 5);
            orbPos -= 256f * deltaTime;
            if (firedOrb != null) {
                if (firedOrb.Position.Y > -16) {
                    firedOrb.Position = new Point(firedOrb.Position.X, (int)orbPos);
                }
                else
                    nextOrbLoaded = true;
                if (firedOrb.CollidingBodies.Count() > 0) {
                    parade.insert(firedOrb);
                    firedOrb = null;
                    nextOrbLoaded = true;
                }
            }

        }

        public override void Draw() {
            base.Draw();
            if(nextOrbLoaded)
                ammo[0].Draw();
            engine.SetPixel(Position, getHoldColor(ammo[1].Color));
            if(firedOrb != null) {
                firedOrb.Draw();
                engine.WriteText(new Point(224, 4), firedOrb.CollidingBodies.Count().ToString(), 15);
            }
                
            
        }

        internal void Move(int v, float deltaTime) {

            if ((Position.X > 7 && Math.Sign(v) == -1) || (Position.X < 233 && Math.Sign(v) == 1))
                xPos += v * deltaTime;
            Position = new Point((int)xPos, Position.Y);          
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
