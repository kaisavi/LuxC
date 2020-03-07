using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxC.model {
    struct Paths {
        internal static Path demo => new Path(new List<Point> {
            new Point(-10,10),//Edge 
            new Point(10,10),

        }).Append(new Path(new List<Point> { 
            new Point(10,10), //Corner 
            new Point(20,10),
            new Point(18,23), 
        })).Append(new Path(new List<Point> { 
            new Point(19,23), //Edge 
            new Point(18,92)

        })).Append(new Path(new List<Point> {
            new Point(18,92), //Corner 
            new Point(18,102),
            new Point(28,100)
        })).Append(new Path(new List<Point> {
            new Point(28,100), //Edge 
            new Point(113,101),
            new Point(190,100)

        })).Append(new Path(new List<Point> {
            new Point(190,100), //Corner 
            new Point(200,94),
            new Point(190,85)
        })).Append(new Path(new List<Point> {
            new Point(190,85), //Edge 
            new Point(120,84),
            new Point(46,85)

        })).Append(new Path(new List<Point> {
            new Point(46,84), //Corner 
            new Point(36,83),
            new Point(35,70)
        })).Append(new Path(new List<Point> {
            new Point(35,70), //Edge 
            new Point(35,18)

        })).Append(new Path(new List<Point> {
            new Point(35,18), //Corner 
            new Point(35,5),
            new Point(43,18)
        })).Append(new Path(new List<Point> {
            new Point(43,18), //Edge 
            new Point(77,63)

        })).Append(new Path(new List<Point> {
            new Point(77,63),
            new Point(83,71),
            new Point(90,62)
        })).Append(new Path(new List<Point> {
            new Point(90,62 ),
            new Point(131,10)

        })).Append(new Path(new List<Point> {
            new Point(130,11),
            new Point(178,10)

        })).Append(new Path(new List<Point> {
            new Point(178,10),
            new Point(187,10),
            new Point(188,15)
        })).Append(new Path(new List<Point> {
            new Point(188,15),
            new Point(188,63)

        })).Append(new Path(new List<Point> {
            new Point(188,63),
            new Point(188,70),
            new Point(172,68)
        })).Append(new Path(new List<Point> {
            new Point(172,68),
            new Point(150,69),
            new Point(110,68)

        })).Append(new Path(new List<Point> {
            new Point(110,68),
            new Point(100,69),
            new Point(104,60)

        })).Append(new Path(new List<Point> {
            new Point(104,60),
            new Point(134,22)

        })).Append(new Path(new List<Point> {
            new Point(134,22),
            new Point(178,22)

        })).Append(new Path(new List<Point> {
            new Point(178,-32),
            new Point(198,-32)

        })).Append(new Path(new List<Point> {
            new Point(198,22),
            new Point(250,22)

        }))
            .Cull();
    }
}
