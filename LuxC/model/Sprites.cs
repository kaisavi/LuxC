using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameEngine;

namespace LuxC.model
{
    public struct Sprites
    {
        public static readonly List<Fragment> redOrb = new List<Fragment> {
            new Fragment(new Point(-1,-2),ConsoleColor.Red,ConsoleCharacter.Light),
            new Fragment(new Point(0,-2),ConsoleColor.White,ConsoleCharacter.Dark),
            new Fragment(new Point(1,-2),ConsoleColor.Red,ConsoleCharacter.Light),

            new Fragment(new Point(-2,-1),ConsoleColor.Red,ConsoleCharacter.Light),
            new Fragment(new Point(-1,-1),ConsoleColor.DarkRed,ConsoleCharacter.Medium),
            new Fragment(new Point(0,-1),ConsoleColor.Magenta,ConsoleCharacter.Dark),
            new Fragment(new Point(1,-1),ConsoleColor.DarkRed,ConsoleCharacter.Medium),
            new Fragment(new Point(2,-1),ConsoleColor.Red,ConsoleCharacter.Light),
            
            new Fragment(new Point(-2,0),ConsoleColor.White,ConsoleCharacter.Dark),
            new Fragment(new Point(-1,0),ConsoleColor.Magenta,ConsoleCharacter.Dark),
            new Fragment(new Point(0,0),ConsoleColor.Yellow,ConsoleCharacter.Full),
            new Fragment(new Point(1,0),ConsoleColor.Magenta,ConsoleCharacter.Dark),
            new Fragment(new Point(2,0),ConsoleColor.White,ConsoleCharacter.Dark),
            
            new Fragment(new Point(-2,1),ConsoleColor.Red,ConsoleCharacter.Light),
            new Fragment(new Point(-1,1),ConsoleColor.DarkRed,ConsoleCharacter.Medium),
            new Fragment(new Point(0,1),ConsoleColor.Magenta,ConsoleCharacter.Dark),
            new Fragment(new Point(1,1),ConsoleColor.DarkRed,ConsoleCharacter.Medium),
            new Fragment(new Point(2,1),ConsoleColor.Red,ConsoleCharacter.Light),
            
            new Fragment(new Point(-1,2),ConsoleColor.Red,ConsoleCharacter.Light),
            new Fragment(new Point(0,2),ConsoleColor.White,ConsoleCharacter.Dark),
            new Fragment(new Point(1,2),ConsoleColor.Red,ConsoleCharacter.Light)
        };

        public static readonly List<Fragment> blueOrb = new List<Fragment> {
            new Fragment(new Point(-1,-2),ConsoleColor.Cyan,ConsoleCharacter.Medium),
            new Fragment(new Point(0,-2),ConsoleColor.White,ConsoleCharacter.Dark),
            new Fragment(new Point(1,-2),ConsoleColor.Cyan,ConsoleCharacter.Medium),

            new Fragment(new Point(-2,-1),ConsoleColor.Cyan,ConsoleCharacter.Medium),
            new Fragment(new Point(-1,-1),ConsoleColor.DarkCyan,ConsoleCharacter.Medium),
            new Fragment(new Point(0,-1),ConsoleColor.Blue,ConsoleCharacter.Dark),
            new Fragment(new Point(1,-1),ConsoleColor.DarkCyan,ConsoleCharacter.Medium),
            new Fragment(new Point(2,-1),ConsoleColor.Cyan,ConsoleCharacter.Medium),

            new Fragment(new Point(-2,0),ConsoleColor.White,ConsoleCharacter.Dark),
            new Fragment(new Point(-1,0),ConsoleColor.Blue,ConsoleCharacter.Dark),
            new Fragment(new Point(0,0),ConsoleColor.DarkBlue,ConsoleCharacter.Full),
            new Fragment(new Point(1,0),ConsoleColor.Blue,ConsoleCharacter.Dark),
            new Fragment(new Point(2,0),ConsoleColor.White,ConsoleCharacter.Dark),

            new Fragment(new Point(-2,1),ConsoleColor.Cyan,ConsoleCharacter.Medium),
            new Fragment(new Point(-1,1),ConsoleColor.DarkCyan,ConsoleCharacter.Medium),
            new Fragment(new Point(0,1),ConsoleColor.Blue,ConsoleCharacter.Dark),
            new Fragment(new Point(1,1),ConsoleColor.DarkCyan,ConsoleCharacter.Medium),
            new Fragment(new Point(2,1),ConsoleColor.Cyan,ConsoleCharacter.Medium),

            new Fragment(new Point(-1,2),ConsoleColor.Cyan,ConsoleCharacter.Medium),
            new Fragment(new Point(0,2),ConsoleColor.White,ConsoleCharacter.Dark),
            new Fragment(new Point(1,2),ConsoleColor.Cyan,ConsoleCharacter.Medium)
        };

        public static readonly List<Fragment> whiteOrb = new List<Fragment> {
            new Fragment(new Point(-1,-2),ConsoleColor.White,ConsoleCharacter.Medium),
            new Fragment(new Point(0,-2),ConsoleColor.White,ConsoleCharacter.Dark),
            new Fragment(new Point(1,-2),ConsoleColor.White,ConsoleCharacter.Medium),

            new Fragment(new Point(-2,-1),ConsoleColor.White,ConsoleCharacter.Medium),
            new Fragment(new Point(-1,-1),ConsoleColor.Gray,ConsoleCharacter.Medium),
            new Fragment(new Point(0,-1),ConsoleColor.Yellow,ConsoleCharacter.Dark),
            new Fragment(new Point(1,-1),ConsoleColor.Gray,ConsoleCharacter.Medium),
            new Fragment(new Point(2,-1),ConsoleColor.White,ConsoleCharacter.Medium),

            new Fragment(new Point(-2,0),ConsoleColor.White,ConsoleCharacter.Dark),
            new Fragment(new Point(-1,0),ConsoleColor.Yellow,ConsoleCharacter.Dark),
            new Fragment(new Point(0,0),ConsoleColor.White,ConsoleCharacter.Full),
            new Fragment(new Point(1,0),ConsoleColor.Yellow,ConsoleCharacter.Dark),
            new Fragment(new Point(2,0),ConsoleColor.White,ConsoleCharacter.Dark),

            new Fragment(new Point(-2,1),ConsoleColor.White,ConsoleCharacter.Medium),
            new Fragment(new Point(-1,1),ConsoleColor.Gray,ConsoleCharacter.Medium),
            new Fragment(new Point(0,1),ConsoleColor.Yellow,ConsoleCharacter.Dark),
            new Fragment(new Point(1,1),ConsoleColor.Gray,ConsoleCharacter.Medium),
            new Fragment(new Point(2,1),ConsoleColor.White,ConsoleCharacter.Medium),

            new Fragment(new Point(-1,2),ConsoleColor.White,ConsoleCharacter.Medium),
            new Fragment(new Point(0,2),ConsoleColor.White,ConsoleCharacter.Dark),
            new Fragment(new Point(1,2),ConsoleColor.White,ConsoleCharacter.Medium)
        };

        public static readonly List<Fragment> blackOrb = new List<Fragment> {
            new Fragment(new Point(-1,-2),ConsoleColor.Black,ConsoleCharacter.Light),
            new Fragment(new Point(0,-2),ConsoleColor.White,ConsoleCharacter.Light),
            new Fragment(new Point(1,-2),ConsoleColor.Black,ConsoleCharacter.Light),

            new Fragment(new Point(-2,-1),ConsoleColor.Black,ConsoleCharacter.Light),
            new Fragment(new Point(-1,-1),ConsoleColor.Black,ConsoleCharacter.Medium),
            new Fragment(new Point(0,-1),ConsoleColor.DarkRed,ConsoleCharacter.Dark),
            new Fragment(new Point(1,-1),ConsoleColor.Black,ConsoleCharacter.Medium),
            new Fragment(new Point(2,-1),ConsoleColor.Black,ConsoleCharacter.Light),

            new Fragment(new Point(-2,0),ConsoleColor.White,ConsoleCharacter.Light),
            new Fragment(new Point(-1,0),ConsoleColor.DarkRed,ConsoleCharacter.Dark),
            new Fragment(new Point(0,0),ConsoleColor.Black,ConsoleCharacter.Full),
            new Fragment(new Point(1,0),ConsoleColor.DarkRed,ConsoleCharacter.Dark),
            new Fragment(new Point(2,0),ConsoleColor.White,ConsoleCharacter.Light),

            new Fragment(new Point(-2,1),ConsoleColor.Black,ConsoleCharacter.Light),
            new Fragment(new Point(-1,1),ConsoleColor.Black,ConsoleCharacter.Medium),
            new Fragment(new Point(0,1),ConsoleColor.DarkRed,ConsoleCharacter.Dark),
            new Fragment(new Point(1,1),ConsoleColor.Black,ConsoleCharacter.Medium),
            new Fragment(new Point(2,1),ConsoleColor.Black,ConsoleCharacter.Light),

            new Fragment(new Point(-1,2),ConsoleColor.Black,ConsoleCharacter.Light),
            new Fragment(new Point(0,2),ConsoleColor.White,ConsoleCharacter.Light),
            new Fragment(new Point(1,2),ConsoleColor.Black,ConsoleCharacter.Light)
        };

        public static readonly List<Fragment> palette = new List<Fragment> { 
            new Fragment(new Point(0, 0)),
            new Fragment(new Point(0, 1),ConsoleColor.Yellow),
            new Fragment(new Point(0, 2), ConsoleColor.Magenta),
            new Fragment(new Point(0, 3), ConsoleColor.Red),
            new Fragment(new Point(1, 0), ConsoleColor.Cyan),
            new Fragment(new Point(1, 1), ConsoleColor.Green),
            new Fragment(new Point(1, 2), ConsoleColor.Blue),
            new Fragment(new Point(1, 3), ConsoleColor.DarkGray),
            new Fragment(new Point(2, 0), ConsoleColor.Gray),
            new Fragment(new Point(2, 1), ConsoleColor.DarkYellow),
            new Fragment(new Point(2, 2), ConsoleColor.DarkMagenta),
            new Fragment(new Point(2, 3), ConsoleColor.DarkRed),
            new Fragment(new Point(3, 0), ConsoleColor.DarkCyan),
            new Fragment(new Point(3, 1), ConsoleColor.DarkGreen),
            new Fragment(new Point(3, 2), ConsoleColor.DarkBlue),
            new Fragment(new Point(3, 3), ConsoleColor.Black)
        };

        public static readonly List<Fragment> ballista = new List<Fragment> {
            new Fragment(new Point(-4,-3),ConsoleColor.DarkYellow,ConsoleCharacter.Dark),
            new Fragment(new Point( 4,-3),ConsoleColor.DarkYellow,ConsoleCharacter.Dark),
            
            new Fragment(new Point(-5,-2),ConsoleColor.DarkYellow,ConsoleCharacter.Dark),
            new Fragment(new Point(-4,-2),ConsoleColor.DarkYellow,ConsoleCharacter.Dark),
            new Fragment(new Point(-3,-2),ConsoleColor.DarkYellow,ConsoleCharacter.Dark),
            new Fragment(new Point( 3,-2),ConsoleColor.DarkYellow,ConsoleCharacter.Dark),
            new Fragment(new Point( 4,-2),ConsoleColor.DarkYellow,ConsoleCharacter.Dark),
            new Fragment(new Point( 5,-2),ConsoleColor.DarkYellow,ConsoleCharacter.Dark),
            
            new Fragment(new Point(-4,-1),ConsoleColor.DarkYellow,ConsoleCharacter.Dark),
            new Fragment(new Point(-3,-1),ConsoleColor.DarkGreen,ConsoleCharacter.Full),
            new Fragment(new Point(-2,-1),ConsoleColor.DarkYellow,ConsoleCharacter.Dark),
            new Fragment(new Point(-1,-1),ConsoleColor.DarkYellow,ConsoleCharacter.Dark),
            new Fragment(new Point( 0,-1),ConsoleColor.DarkYellow,ConsoleCharacter.Dark),
            new Fragment(new Point( 1,-1),ConsoleColor.DarkYellow,ConsoleCharacter.Dark),
            new Fragment(new Point( 2,-1),ConsoleColor.DarkYellow,ConsoleCharacter.Dark),
            new Fragment(new Point( 3,-1),ConsoleColor.DarkGreen,ConsoleCharacter.Full),
            new Fragment(new Point( 4,-1),ConsoleColor.DarkYellow,ConsoleCharacter.Dark),
            
            new Fragment(new Point(-3, 0),ConsoleColor.DarkYellow,ConsoleCharacter.Medium),
            new Fragment(new Point(-2, 0),ConsoleColor.DarkMagenta,ConsoleCharacter.Full),
            new Fragment(new Point(-1, 0),ConsoleColor.DarkYellow,ConsoleCharacter.Dark),
            new Fragment(new Point( 1, 0),ConsoleColor.DarkYellow,ConsoleCharacter.Dark),
            new Fragment(new Point( 2, 0),ConsoleColor.DarkMagenta,ConsoleCharacter.Full),
            new Fragment(new Point( 3, 0),ConsoleColor.DarkYellow,ConsoleCharacter.Medium),
            
            new Fragment(new Point(-2, 1),ConsoleColor.DarkYellow,ConsoleCharacter.Medium),
            new Fragment(new Point( 0, 1),ConsoleColor.DarkYellow,ConsoleCharacter.Medium),
            new Fragment(new Point( 2, 1),ConsoleColor.DarkYellow,ConsoleCharacter.Medium),
        };
        
    }
}
