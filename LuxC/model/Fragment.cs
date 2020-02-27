using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameEngine;

namespace LuxC.model
{
    public class Fragment
    {
        private Point position;
        private ConsoleColor color;
        private ConsoleCharacter character;

        public Point Position { get => position; set => position = value; }
        public ConsoleColor Color { get => color; set => color = value; }
        public ConsoleCharacter Character { get => character; set => character = value; }

        public Fragment(Point position, ConsoleColor color = ConsoleColor.White, ConsoleCharacter character = ConsoleCharacter.Full)
        {
            this.position = position;
            this.color = color;
            this.character = character;
        }
    }
}
