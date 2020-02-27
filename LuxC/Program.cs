using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuxC.model;
using ConsoleGameEngine;
using LuxC.Controller;

namespace LuxC
{
    class Program
    {
        static void Main(string[] args)
        {
            Lux lux = new Lux();
            lux.Construct(240, 132, 8, 8, FramerateMode.MaxFps);
        }
    }
}
