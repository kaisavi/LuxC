using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxC.model
{
    class Ballista : Sprite
    {
        Orb[] ammo = new Orb[3];


        public void fire() {
            //TODO: Ballista orb firing
        }


        public Ballista()
        {
            fragments = Sprites.ballista;
        }

        public override void Draw() {
            base.Draw();
            foreach(Orb orb in ammo) {
                orb.Draw();
            }
        }
    }
}
