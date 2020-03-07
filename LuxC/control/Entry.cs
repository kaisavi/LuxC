using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuxC.model;
using ConsoleGameEngine;
using LuxC.control;

namespace LuxC.control
{
    class Entry
    {
        static void Main(string[] args)
        {
            Lux lux = new Lux();
            if (args.Length > 0)
                if (args[0].Equals("-demo")) {
                while(true) {
                        lux = new Lux();
                        lux.demo = true;
                        lux.Construct(240, 132, 8, 8, FramerateMode.Unlimited);
                }
            }
            lux.Construct(240, 132, 8, 8, FramerateMode.Unlimited);
        }
    }
}
