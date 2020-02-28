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
        public Thoroughfare Thoroughfare { get; } = new Thoroughfare(new List<Point>
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
        public List<Rondure> Rondures { get; } = new List<Rondure> { 
            new Rondure(ConsoleColor.Red),
            new Rondure(ConsoleColor.Red),
            new Rondure(ConsoleColor.Red),
            new Rondure(ConsoleColor.Red),
            new Rondure(ConsoleColor.Red),
            new Rondure(ConsoleColor.Red),
            new Rondure(ConsoleColor.Red),
            new Rondure(ConsoleColor.Red),
            new Rondure(ConsoleColor.Red),
            new Rondure(ConsoleColor.Red),
            new Rondure(ConsoleColor.Red),
            new Rondure(ConsoleColor.Red),
            new Rondure(ConsoleColor.Red),
            new Rondure(ConsoleColor.Red),
            new Rondure(ConsoleColor.Red),
            new Rondure(ConsoleColor.Red) 
        };

        int speed = 6;

        public void update(float deltaTime)
        {
            
            if (Rondures[0].Progress < Thoroughfare.Length)
            {
                destroy(0);
            }

            Point nextPosition = Rondures[0].Position;
            Rondures[0].Progress += speed * deltaTime;
            Rondures[0].Position = Thoroughfare.Points[Math.Max((int) Math.Floor(Rondures[0].Progress), 0)];

            for(int i = 1; i < Rondures.Count; i++)
            {

                Rondures[i].Position = Thoroughfare.Points[Math.Max((int)Math.Floor(Rondures[0].Progress - (8 * i)), 0)];
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
