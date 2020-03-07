using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxC.model {
    class OrbGenerator {
        private Random rng = new Random();

        public List<Orb> GenerateOrbs(int count) {
            List<Orb> orbs = new List<Orb>();
            orbs.Add(new Orb(OrbColor.NONE));
            while(count > 0) {
                List<Orb> sequence = getOrbSequence();
                orbs.AddRange(sequence);
                count -= sequence.Count;
            }
            while(count < 0) {
                orbs.Remove(orbs.Last());
                count++;
            }
            return orbs;
        }


        private List<Orb> getOrbSequence() {
            List<Orb> orbs = new List<Orb>();
            for (int i = rng.Next(200); i > 0; i--)
                rng.Next();
            OrbColor color = (OrbColor)(rng.Next(0, 400)/100);
            int count = 0;
            if(rng.Next(0,600) >= 550) {
                count = rng.Next(1, 2);
            } else {
                count = rng.Next(1, 2);
            }
            while(count >= 0) {
                orbs.Add(new Orb(color));
                count--;
            }

            return orbs;
        }
    }
}
