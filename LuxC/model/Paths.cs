using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxC.model {
    struct Paths {
        internal static Path demo => new Path(new List<Point> {
            new Point(-10,25),
            new Point(28,25),

        }).Append(new Path(new List<Point> {
            new Point(28,25),
            new Point(38,25),
            new Point(36,38),
        })).Append(new Path(new List<Point> {
            new Point(37,38),
            new Point(36,92)
        }).Append(new Path(new List<Point> {
            new Point(36,92),
            new Point(36,102),
            new Point(46,100)
            
        })).Append(new Path(new List<Point> {
            new Point(46,100),
            new Point(113,101),
            new Point(190,100)
        })).Cull());
    }
}
