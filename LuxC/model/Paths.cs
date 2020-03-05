using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxC.model {
    struct Paths {
        internal static Path demo => new Path(new List<Point> {

            new Point(-10,32),

            new Point(32,64),
            new Point(64,75),

        }).Append(new Path(new List<Point> {
            new Point(64,75),
            new Point(75,75)
        }));
    }
}
