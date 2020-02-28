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

        int speed = 12;

        public void update(float deltaTime)
        {
            advance(deltaTime);

        }


        private void advance(float deltaTime)
        {
            
            Rondures.Last().Progress += speed * deltaTime;


            for (int i = Rondures.Count - 1; i > 0; i--)
            {
                    Rondures[i].Progress = Rondures.Last().Progress - (7 * ((Rondures.Count - 1) - i));

                if (Rondures[i].Progress >= Thoroughfare.Length - 1.5)
                {
                    destroy(Rondures[i]);
                    Rondures.Last().Mode = RondureMode.HEAD;
                    continue;
                }

                Rondures[i].Position = Thoroughfare.Points[Math.Max((int)Math.Floor(Rondures[i].Progress), 0)];
            }
        }

        private void destroy(Rondure rondure)
        {
            Rondures.Remove(rondure);
        }

        public Callithump()
        {
            //Rondures.First().Mode = RondureMode.TAIL;
        }
    }
}
