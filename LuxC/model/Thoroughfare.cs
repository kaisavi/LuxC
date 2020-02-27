using System;
using System.Collections.Generic;
using ConsoleGameEngine;
namespace LuxC.model
{
    public class Thoroughfare : Drawable
    {
        List<Point> points = new List<Point>();
        public Thoroughfare(List<Point> controlPoints) {
            points = new BezierCurve().Bezier2D(controlPoints);
        }


        public override void Draw()
        {                                      
            foreach(Point p in points) {
                engine.SetPixel(p, (int)ConsoleColor.DarkBlue,ConsoleCharacter.Light);
            }
        }
    }
}