using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameEngine;

namespace CAutomata.model
{
    public struct Sprites
    {
        public static readonly List<Pixel> redVertibra = new List<Pixel> {
            new Pixel(new Point(-1,-2),ConsoleColor.Red,ConsoleCharacter.Light),
            new Pixel(new Point(0,-2),ConsoleColor.White,ConsoleCharacter.Light),
            new Pixel(new Point(1,-2),ConsoleColor.Red,ConsoleCharacter.Light),

            new Pixel(new Point(-2,-1),ConsoleColor.Red,ConsoleCharacter.Light),
            new Pixel(new Point(-1,-1),ConsoleColor.DarkRed,ConsoleCharacter.Medium),
            new Pixel(new Point(0,-1),ConsoleColor.Magenta,ConsoleCharacter.Dark),
            new Pixel(new Point(1,-1),ConsoleColor.DarkRed,ConsoleCharacter.Medium),
            new Pixel(new Point(2,-1),ConsoleColor.Red,ConsoleCharacter.Light),
            
            new Pixel(new Point(-2,0),ConsoleColor.White,ConsoleCharacter.Light),
            new Pixel(new Point(-1,0),ConsoleColor.Magenta,ConsoleCharacter.Medium),
            new Pixel(new Point(0,0),ConsoleColor.DarkYellow,ConsoleCharacter.Dark),
            new Pixel(new Point(1,0),ConsoleColor.Magenta,ConsoleCharacter.Medium),
            new Pixel(new Point(2,0),ConsoleColor.White,ConsoleCharacter.Light),
            
            new Pixel(new Point(-2,1),ConsoleColor.Red,ConsoleCharacter.Light),
            new Pixel(new Point(-1,1),ConsoleColor.DarkRed,ConsoleCharacter.Medium),
            new Pixel(new Point(0,1),ConsoleColor.Magenta,ConsoleCharacter.Medium),
            new Pixel(new Point(1,1),ConsoleColor.DarkRed,ConsoleCharacter.Medium),
            new Pixel(new Point(2,1),ConsoleColor.Red,ConsoleCharacter.Light),
            
            new Pixel(new Point(-1,2),ConsoleColor.Red,ConsoleCharacter.Light),
            new Pixel(new Point(0,2),ConsoleColor.White,ConsoleCharacter.Light),
            new Pixel(new Point(1,2),ConsoleColor.Red,ConsoleCharacter.Light)
        };

        public static readonly List<Pixel> blueVertibra = new List<Pixel> {
            new Pixel(new Point(-1,-2),ConsoleColor.Cyan),
            new Pixel(new Point(0,-2),ConsoleColor.White),
            new Pixel(new Point(1,-2),ConsoleColor.Cyan),

            new Pixel(new Point(-2,-1),ConsoleColor.Cyan),
            new Pixel(new Point(-1,-1),ConsoleColor.DarkCyan),
            new Pixel(new Point(0,-1),ConsoleColor.Blue),
            new Pixel(new Point(1,-1),ConsoleColor.DarkCyan),
            new Pixel(new Point(2,-1),ConsoleColor.Cyan),

            new Pixel(new Point(-2,0),ConsoleColor.White),
            new Pixel(new Point(-1,0),ConsoleColor.Blue),
            new Pixel(new Point(0,0),ConsoleColor.DarkBlue),
            new Pixel(new Point(1,0),ConsoleColor.Blue),
            new Pixel(new Point(2,0),ConsoleColor.White),

            new Pixel(new Point(-2,1),ConsoleColor.Cyan),
            new Pixel(new Point(-1,1),ConsoleColor.DarkCyan),
            new Pixel(new Point(0,1),ConsoleColor.Blue),
            new Pixel(new Point(1,1),ConsoleColor.DarkCyan),
            new Pixel(new Point(2,1),ConsoleColor.Cyan),

            new Pixel(new Point(-1,2),ConsoleColor.Cyan),
            new Pixel(new Point(0,2),ConsoleColor.White),
            new Pixel(new Point(1,2),ConsoleColor.Cyan)
        };

        public static readonly List<Pixel> palette = new List<Pixel> { 
            new Pixel(new Point(0, 0)),
            new Pixel(new Point(0, 1),ConsoleColor.Yellow),
            new Pixel(new Point(0, 2), ConsoleColor.Magenta),
            new Pixel(new Point(0, 3), ConsoleColor.Red),
            new Pixel(new Point(1, 0), ConsoleColor.Cyan),
            new Pixel(new Point(1, 1), ConsoleColor.Green),
            new Pixel(new Point(1, 2), ConsoleColor.Blue),
            new Pixel(new Point(1, 3), ConsoleColor.DarkGray),
            new Pixel(new Point(2, 0), ConsoleColor.Gray),
            new Pixel(new Point(2, 1), ConsoleColor.DarkYellow),
            new Pixel(new Point(2, 2), ConsoleColor.DarkMagenta),
            new Pixel(new Point(2, 3), ConsoleColor.DarkRed),
            new Pixel(new Point(3, 0), ConsoleColor.DarkCyan),
            new Pixel(new Point(3, 1), ConsoleColor.DarkGreen),
            new Pixel(new Point(3, 2), ConsoleColor.DarkBlue),
            new Pixel(new Point(3, 3), ConsoleColor.Black)


        };
        

        
    }
}
