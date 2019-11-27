using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

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

    #region quadratic curve
    [Serializable]
    public class QuadraticCurve
    {
        private List<Tuple<Point, Point>> quadraticPoints;
        public List<Tuple<Point, Point>> QuadraticPoints
        {
            get
            {
                return quadraticPoints ?? (quadraticPoints = new List<Tuple<Point, Point>>()) ;
            }
        }
    }
    #endregion

    #region serializable wrapper of Android.Graphics.Path
    [Serializable]
    public class SerializablePath
    {

        [NonSerialized]
        private Path path;
        public Path AndroidGraphicsPath
        {
            get
            {
                return path ?? (path = BuildPathFromSerializablePath());
            }
        }

        private Point lineToPoint;
        public Point LineToPoint
        {
            get
            {
                return lineToPoint;
            }

            set
            {
                lineToPoint = value;
                path.LineTo(value.X, value.Y);
            }
        }

        private Point moveToPoint;
        public Point MoveToPoint
        {
            get 
            {
                return moveToPoint;
            }

            set
            {
                moveToPoint = value;
                path.MoveTo(value.X, value.Y);
            }
        }

        private QuadraticCurve quadraticCurve;
        public QuadraticCurve QuadraticCurve
        {
            get
            {
                return quadraticCurve ?? (quadraticCurve = new QuadraticCurve());
            }
        }

        public SerializablePath()
        {
            path = new Path();
        }

        public void QuadTo(Point firstPoint, Point secondPoint)
        {
            QuadraticCurve.QuadraticPoints.Add(new Tuple<Point, Point>(firstPoint, secondPoint));
            path.QuadTo(firstPoint.X, firstPoint.Y, secondPoint.X, secondPoint.Y);
        }

        private Path BuildPathFromSerializablePath()
        {
            Path newPath = new Path();
            newPath.MoveTo(MoveToPoint.X, MoveToPoint.Y);
            foreach(Tuple<Point, Point> quadraticPoint in QuadraticCurve.QuadraticPoints)
            {
                Point firstQuadPoint = quadraticPoint.Item1;
                Point secondQuadPoint = quadraticPoint.Item2;
                newPath.QuadTo(firstQuadPoint.X, firstQuadPoint.Y, secondQuadPoint.X, secondQuadPoint.Y);
            }
            newPath.LineTo(LineToPoint.X, LineToPoint.Y);

            return newPath;
        }
    }
    #endregion
}