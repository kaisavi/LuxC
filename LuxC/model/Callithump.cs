using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxC.model
{
    class Callithump
    {
        private Thoroughfare thoroughfare = new Thoroughfare(new List<Point>
        {
            new Point(-10,16),

            new Point(15,16),
            new Point(15,16),
            new Point(18,14),
            new Point(16,17),
            new Point(16,17),

            new Point(16,99),
            new Point(16,99),
            new Point(14,102),
            new Point(17,100),
            new Point(17,100),

            new Point(24,98),

            new Point(31,100),
            new Point(31,100),
            new Point(34,102),
            new Point(32,99),
            new Point(32,99),

            new Point(32,16),
            new Point(30,14),
            new Point(34,16),
        });
        public Thoroughfare Thoroughfare { get => thoroughfare; }

        private List<Rondure> rondures = new List<Rondure> { new Rondure(ConsoleColor.Black) };
        public List<Rondure> Rondures { get => rondures; }

        int speed = 6;

        public void update(float deltaTime)
        {
            
            if (rondures[0].Progress < thoroughfare.Length)
            {
                destroy(0);
            }

            Point nextPosition = rondures[0].Position;
            rondures[0].Progress += speed * deltaTime;
            rondures[0].Position = thoroughfare.Points[(int) Math.Floor(rondures[0].Progress + 1)];

            foreach(Rondure r in rondures)
            {
                
            }
        }


        private void destroy(int index)
        {
            
        }

        public Callithump()
        {

        }
    }
}
