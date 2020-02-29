using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameEngine;

namespace LuxC.model
{
    class Ballista : Sprite
    {
        Orb[] ammo = new Orb[2];
        private readonly CollisionManager collisionManager;


        public void Fire() {
            //TODO: Ballista orb firing
        }


        public Ballista(CollisionManager collisionManager)
        {
            fragments = Sprites.ballista;
            this.collisionManager = collisionManager;
            for (int i = 0; i < 2; i++)
                ammo[i] = new Orb(ConsoleColor.Blue, collisionManager);
            Position = new Point(120, 126);

        }

        public void Update() {
            ammo[0].Position = this.Position - new Point(0, 5);
        }

        public override void Draw() {
            base.Draw();
            ammo[0].Draw();
            engine.SetPixel(Position, (int)ammo[0].Color);
        }


    }
}
