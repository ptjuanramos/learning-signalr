using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using XamarinLearningSignalR.Models;

namespace XamarinLearningSignalR.Widgets
{
    public class DrawCanvas : View
    {
        private Paint mPaint;
        private readonly Paint mBitmapPaint = new Paint(PaintFlags.Dither);
        private SerializablePath serializablePath;
        private readonly int currentColor = Color.Black.ToArgb();
        private float mX, mY;
        private Bitmap mBitmap;
        private Canvas mCanvas;

        public List<DrawPath> DrawPaths = new List<DrawPath>();

        public DrawCanvas(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
            
        }

        public DrawCanvas(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {

        }

        public void Initialize(DisplayMetrics displayMetrics)
        {
            mPaint = new Paint
            {
                Color = Color.Black //Default color
            };

            int height = displayMetrics.HeightPixels;
            int width = displayMetrics.WidthPixels;
            mBitmap = Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888);
            mCanvas = new Canvas(mBitmap);
        }

        private void TouchStart(float x, float y)
        {
            serializablePath = new SerializablePath();
            DrawPath newDrawPath = new DrawPath(currentColor, serializablePath);
            DrawPaths.Add(newDrawPath);

            serializablePath.MoveToPoint = new Models.Point(x, y);

            mX = x;
            mY = y;
        }

        private void TouchMove(float x, float y)
        {
            float dx = Math.Abs(x - mX);
            float dy = Math.Abs(y - mY);

            if (dx >= 4 || dy >= 4)
            {
                Models.Point point1 = new Models.Point(x, y);
                Models.Point point2 = new Models.Point((x + mX) / 2, (y + mY) / 2);
                serializablePath.QuadTo(point1, point2);

                mX = x;
                mY = y;
            }
        }

        private void TouchUp()
        {
            serializablePath.LineToPoint = new Models.Point(mX, mY);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            float touchX = e.GetX();
            float touchY = e.GetY();

            switch(e.Action)
            {
                case MotionEventActions.Down:
                    TouchStart(touchX, touchY);
                    Invalidate();
                    break;
                case MotionEventActions.Move:
                    TouchMove(touchX, touchY);
                    Invalidate();
                    break;
                case MotionEventActions.Up:
                    TouchUp();
                    Invalidate();
                    break;
            }

            return true;
        }

        public void ClearDraw()
        {
            DrawPaths.Clear();
            Invalidate();
        }

        private void DrawOnCanvas(Canvas canvas)
        {
            foreach (DrawPath drawPath in DrawPaths)
            {
                mPaint.Color = new Color(drawPath.Color);
                mPaint.StrokeWidth = 20;
                mPaint.SetStyle(Paint.Style.Stroke);
                mPaint.Dither = true;
                mPaint.StrokeJoin = Paint.Join.Round;
                mPaint.StrokeCap = Paint.Cap.Round;
                mPaint.SetMaskFilter(null);
                mPaint.AntiAlias = true;
                mPaint.SetXfermode(null);

                Path pathToDraw = drawPath.Path.AndroidGraphicsPath;
                mCanvas.DrawPath(pathToDraw, mPaint);
                
                canvas.DrawBitmap(mBitmap, 0, 0, mBitmapPaint);
            }
        }

        public void MakeNewDraw(List<DrawPath> newDrawPaths)
        {
            ClearDraw();
            DrawPaths = newDrawPaths;
            Invalidate();
        }

        protected override void OnDraw(Canvas canvas)
        {
            canvas.Save();
            mCanvas.DrawColor(Color.White); //default color
            DrawOnCanvas(canvas);
        }
    }
}