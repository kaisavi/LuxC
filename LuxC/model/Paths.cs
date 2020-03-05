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

            new Point(100,32),

        }).Append(new Path(new List<Point> {
            new Point(100,32),
            new Point(32,75),
            new Point(-10,75),
        })).Cull();
    }
}
