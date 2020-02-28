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
    class OrderOfBusiness
    {
        static void Main(string[] args)
        {
            Lux lux = new Lux();
            lux.Construct(240, 132, 8, 8, FramerateMode.Unlimited);
        }
    }
}
