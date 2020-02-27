using System;
using System.Collections.Generic;
using ConsoleGameEngine;
namespace LuxC.model
{
    public class Path : Drawable
    {
        List<Point> points = new List<Point>();
        public Path()
        {
            
        }

        public override void Draw()
        {

            List<Point> ptList = new List<Point> {
                new Point(32,32),
                new Point(64,128),
                new Point(128,64)
            };



            
            
            BezierCurve bc = new BezierCurve();
            

            List<Point> points = bc.Bezier2D(ptList);

            foreach(Point p in points) {
                engine.SetPixel(p, 15);
            }
            
        }
    }
}