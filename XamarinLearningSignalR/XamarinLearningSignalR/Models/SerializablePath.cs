using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinLearningSignalR.Models
{
    #region point representation
    [Serializable]
    public class Point
    {
        private readonly float x;
        public float X
        {
            get
            {
                return x;
            }
        }

        private readonly float y;
        public float Y
        {
            get
            {
                return y;
            }
        }

        public Point(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
    #endregion

    #region serializable Android.Graphics.Path
    [Serializable]
    public class SerializablePath
    {
        private Point lineToPoint;
        public Point LineToPoint
        {
            get
            {
                return lineToPoint;
            }
        }

        private Point moveToPoint;
        public Point MoveToPoint
        {
            get
            {
                return moveToPoint;
            }
        }

        private Tuple<Point, Point> quadraticPoint;
        public Tuple<Point, Point> QuadraticPoint
        {
            get
            {
                return quadraticPoint;
            }
        }

        [NonSerialized]
        private Path nonSerializedPath;
        public Path Path
        {
            get
            {
                return nonSerializedPath ?? (nonSerializedPath = BuildPath());

            }
        }

        private Path BuildPath()
        {

            return null;
        }

        //public override void LineTo(float x, float y)
        //{
        //    lineToPoint = new Point(x, y);
        //    base.LineTo(x, y);
        //}

        //public void LineTo(Point lineToPoint)
        //{
        //    base.LineTo(lineToPoint.X, lineToPoint.Y);
        //}

        //public override void MoveTo(float x, float y)
        //{
        //    moveToPoint = new Point(x, y);
        //    base.MoveTo(x, y);
        //}

        //public void MoveTo(Point moveToPoint)
        //{
        //    base.MoveTo(moveToPoint.X, moveToPoint.Y);
        //}

        //public override void QuadTo(float x1, float y1, float x2, float y2)
        //{
        //    quadraticPoint = new Tuple<Point, Point>(new Point(x1, y1), new Point(x2, y2));
        //    base.QuadTo(x1, y1, x2, y2);
        //}

        //public void QuadTo(Tuple<Point, Point> quadToPoints)
        //{
        //    Point point1 = quadToPoints.Item1;
        //    Point point2 = quadToPoints.Item2;
        //    base.QuadTo(point1.X, point1.Y, point2.X, point2.Y);
        //}
    }
    #endregion
}