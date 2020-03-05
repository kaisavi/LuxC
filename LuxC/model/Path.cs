using System;
using System.Collections.Generic;
using ConsoleGameEngine;
namespace LuxC.model
{
    public class Path : Drawable
    {

        public List<Point> Points { get; }

        public int Length { get => Points.Count; }

        public Path(List<Point> controlPoints) {
            Points = new BezierCurve().Bezier2D(controlPoints);
        }

        public Path Append(Path p) {
            this.Points.AddRange(p.Points);
            return this;
        }

        public override void Draw()
        {                                      
            foreach(Point p in Points) {
                engine.SetPixel(p, (int)ConsoleColor.DarkBlue,ConsoleCharacter.Light);
            }
        }
    }
}