using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace iMago
{

    public enum Channel { Red = 2, Green = 1, Blue = 0, All = 3 };

    public partial class ImageCurve : UserControl
    {
        public ImageCurve()
        {
            InitializeComponent();

            //Double buffer this control
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
              ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }

        #region private variables

        Rectangle workSpace;

        Point pt0, pt1, pt2, pt3, pt4, cPt1, cPt2;

        Point[] wLevelPts = new Point[256];

        byte[] LevelValue = new byte[256];

        bool isLblMoving, isCpt1, isCpt2;

        Matrix mxWtoC, mxCtoW;//Transformation between Workspace and this Control

        //Custom Event Part 3. Declare an event, the delegate object.
        public event LevelChangedEventHandler LevelChangedEvent;

        #endregion


        protected virtual void OnLevelChanged(LevelChangedEventArgs e)
        {
            if (LevelChangedEvent != null) // Make sure there are methods to execute.
                LevelChangedEvent(this, e); // Raise the event.
        }

        protected override void OnLoad(EventArgs e)
        {
            SetUp();
            base.OnLoad(e);
        }

        protected override void OnResize(EventArgs e)
        {
            SetUp();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // draw work space rectangle
            e.Graphics.DrawRectangle(new Pen(ForeColor, 2), workSpace);

            //draw level curve
            e.Graphics.Transform = mxWtoC;
            e.Graphics.DrawLines(new Pen(ForeColor, 0.01f), wLevelPts);
            base.OnPaint(e);
        }

        private void SetUp()
        {
            // set up coordinate
            labelY2.Location = new Point(Margin.Left + 2, Margin.Top + 10);
            labelX0.Location = new Point(labelY2.Right + 3, this.Height - Margin.Bottom - labelX0.Height - 10);
            labelX2.Location = new Point(this.Width - Margin.Right - 15 - labelX2.Width, labelX0.Top);
            labelX1.Location = new Point(labelX0.Left / 2 + labelX2.Right / 2 - labelX1.Width / 2, labelX0.Top);
            labelY0.Location = new Point(labelY2.Right - labelY0.Width, labelX0.Top - 5 - labelY0.Height);
            labelY1.Location = new Point(labelY2.Right - labelY1.Width, labelY0.Bottom / 2 + labelY2.Top / 2 - labelY1.Height / 2);

            // setup work space origin
            Point Origin = new Point(labelX0.Left, labelY0.Bottom);

            //Work Space
            Point wsPt = new Point(labelX0.Left - 1, labelY2.Top - 1);//line width was 2:1 inside the rectangle,1 outside
            int wsWidth = labelX2.Right - labelX0.Left + 2;
            int wsHeight = labelY0.Bottom - labelY2.Top + 2;
            workSpace = new Rectangle(wsPt, new Size(wsWidth, wsHeight));

            //transformatiom
            mxWtoC = new Matrix(1, 0, 0, -1, 0, 0);//reflect across x-axis
            mxWtoC.Scale((float)(labelX2.Right - labelX0.Left) / 255f, (float)(labelY0.Bottom - labelY2.Top) / 255f);
            mxWtoC.Translate(Origin.X, Origin.Y, MatrixOrder.Append);

            mxCtoW = mxWtoC.Clone();
            mxCtoW.Invert();

            //pt0,pt1,pt2,pt3,pt4
            pt0 = new Point(0, 0);
            pt1 = new Point(0, 0);
            pt2 = new Point(127, 127);
            pt3 = new Point(255, 255);
            pt4 = new Point(255, 255);
            cPt1 = new Point(127, 127);
            cPt2 = new Point(127, 127);

            Point[] pts = new Point[] { pt1, pt2, pt3 };
            mxWtoC.TransformPoints(pts);
            labelPt1.Location = new Point(pts[0].X - 2, pts[0].Y - 2);
            labelPt2.Location = new Point(pts[1].X - 2, pts[1].Y - 2);
            labelPt3.Location = new Point(pts[2].X - 2, pts[2].Y - 2);
            labelPt1.Cursor = Cursors.Hand;
            labelPt2.Cursor = Cursors.Hand;
            labelPt3.Cursor = Cursors.Hand;

            for (int i = 0; i < 256; i++)
            {
                wLevelPts[i] = new Point(i, i);
            }
            Invalidate();
        }

        private Point WorkspaceToControl(Point p)
        {
            Point[] pt = new Point[] { p };
            mxWtoC.TransformPoints(pt);
            return pt[0];
        }

        private Point ControlToWorkspace(Point p)
        {
            Point[] pt = new Point[] { p };
            mxCtoW.TransformPoints(pt);
            return pt[0];
        }

        // A quadratic Bezier curve is the path traced by the function B(t), given points 
        // P0, P1, and P2,B(t) = (1 - t)^2*p0 + 2t(1 - t)*p1 + t^2*p2, 0=<t=<1;
        // A quadratic Bezier curve is also a parabolic segment.
        private void getBezierPoints(Point sPt, Point cPt, Point ePt)
        {
            wLevelPts[sPt.X].Y = sPt.Y;
            if (ePt.X - sPt.X > 2)
            {
                int aa = ePt.X - sPt.X;
                int k = sPt.X;

                double[] a = new double[3];
                double[] b = new double[3];
                a[0] = sPt.X;
                a[1] = cPt.X;
                a[2] = ePt.X;
                b[0] = sPt.Y;
                b[1] = cPt.Y;
                b[2] = ePt.Y;

                int interpolation = 5 * aa;

                double tUnit = 1.0 / interpolation;
                for (int i = 1; i < interpolation + 1; i++)
                {
                    double t = tUnit * i;
                    int X = (int)((1.0 - t) * (1.0 - t) * a[0] + 2.0 * t * (1 - t) * a[1] + t * t * a[2]);

                    if (X > k && X < ePt.X)
                    {
                        int bb = X - k;
                        double Y = (1.0 - t) * (1.0 - t) * b[0] + 2.0 * t * (1 - t) * b[1] + t * t * b[2];
                        for (int j = 1; j < bb + 1; j++)
                        {
                            double c = (double)wLevelPts[k].Y * (double)(bb - j) / (double)bb + Y * (double)j / (double)bb;
                            if (c < 0) c = 0;
                            if (c > 255) c = 255;
                            wLevelPts[k + j].Y = (int)c;
                        }
                        k = k + bb;
                    }
                }
            }
        }

        private void getLevelPoints(int i)
        {
            switch (i)
            {
                case 1:
                    for (int a = 0; a < pt1.X; a++)
                    {
                        wLevelPts[a].Y = pt1.Y;
                    }
                    getBezierPoints(pt1, cPt1, pt2);
                    break;
                case 2:
                    getBezierPoints(pt1, cPt1, pt2);
                    getBezierPoints(pt2, cPt2, pt3);
                    break;
                case 3:
                    getBezierPoints(pt2, cPt2, pt3);
                    for (int b = pt3.X; b < 256; b++)
                    {
                        wLevelPts[b].Y = pt3.Y;
                    }
                    break;
            }
        }

        private void getLevelbytes()
        {
            for (int i = 0; i < 256; i++)
            {
                LevelValue[i] = (byte)wLevelPts[i].Y;
            }
        }

        #region Move Pt1,Pt2,Pt3...
        private void labelPt3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isLblMoving = true;
                ((Label)sender).Tag = new Point(e.X, e.Y);
            }
        }

        private void labelPt3_MouseMove(object sender, MouseEventArgs e)
        {
            Point[] lblPts = new Point[] { pt0, pt1, pt2, pt3, pt4 };
            mxWtoC.TransformPoints(lblPts);
            if (e.Button == MouseButtons.Left && isLblMoving)
            {
                Label pt = (Label)sender;
                Point p = (Point)pt.Tag;
                int x = pt.Left + e.X - p.X;
                int y = pt.Top + e.Y - p.Y;
                if (y < lblPts[4].Y) y = lblPts[4].Y;
                if (y > lblPts[0].Y) y = lblPts[0].Y;
                if (pt == labelPt1)
                {
                    if (x > lblPts[2].X) x = lblPts[2].X;
                    if (x < lblPts[0].X) x = lblPts[0].X;

                    pt1 = ControlToWorkspace(new Point(x, y));
                    getLevelPoints(1);
                }
                if (pt == labelPt2)
                {
                    if (x < lblPts[1].X) x = lblPts[1].X;
                    if (x > lblPts[3].X) x = lblPts[3].X;

                    pt2 = ControlToWorkspace(new Point(x, y));
                    getLevelPoints(2);
                }
                if (pt == labelPt3)
                {
                    if (x < lblPts[2].X) x = lblPts[2].X;
                    if (x > lblPts[4].X) x = lblPts[4].X;

                    pt3 = ControlToWorkspace(new Point(x, y));
                    getLevelPoints(3);
                }

                pt.Top = y - 2;
                pt.Left = x - 2;

                Invalidate();
            }
        }

        private void labelPt3_MouseUp(object sender, MouseEventArgs e)
        {
            isLblMoving = false;

            getLevelbytes();
            OnLevelChanged(new LevelChangedEventArgs(LevelValue)); // call event
        }
        #endregion

        private void ImageCurve_MouseDown(object sender, MouseEventArgs e)
        {
            Point[] pts = new Point[] { pt0, pt1, pt2, pt3, pt4 };
            mxWtoC.TransformPoints(pts);

            Rectangle r1 = new Rectangle(pts[1].X, pts[4].Y, pts[2].X - pts[1].X, pts[0].Y - pts[4].Y);
            Rectangle r2 = new Rectangle(pts[2].X, pts[4].Y, pts[3].X - pts[2].X, pts[0].Y - pts[4].Y);

            if (e.Button == MouseButtons.Left && (pts[2].X - pts[1].X) > 2 && r1.Contains(new Point(e.X, e.Y)))
            {
                isCpt1 = true;//move cPt1
            }
            if (e.Button == MouseButtons.Left && (pts[3].X - pts[2].X) > 2 && r2.Contains(new Point(e.X, e.Y)))
            {
                isCpt2 = true;//move cPt2
            }
        }

        private void ImageCurve_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                if (isCpt1)
                {
                    cPt1 = ControlToWorkspace(new Point(e.X, e.Y));
                    getBezierPoints(pt1, cPt1, pt2);
                }
                if (isCpt2)
                {
                    cPt2 = ControlToWorkspace(new Point(e.X, e.Y));
                    getBezierPoints(pt2, cPt2, pt3);
                }
            }
            Invalidate();
        }

        private void ImageCurve_MouseUp(object sender, MouseEventArgs e)
        {
            if (isCpt1) isCpt1 = false;
            if (isCpt2) isCpt2 = false;

            getLevelbytes();
            OnLevelChanged(new LevelChangedEventArgs(LevelValue)); // call event
        }

        public static Bitmap ChangeChannelLevel(Bitmap image, Rectangle selectedArea, Channel channel, byte[] Levels)
        {
            Rectangle selectRect;
            if (selectedArea == new Rectangle(0, 0, 0, 0))
                selectRect = new Rectangle(1, 1, image.Width - 2, image.Height - 2);
            else
                selectRect = selectedArea;

            Bitmap bmp = (Bitmap)image.Clone();

            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                bmp.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = bmpData.Stride * bmp.Height;
            byte[] rgbValues = new byte[bytes];
            int bytesStart = 3 * selectRect.Left - 1;
            int bytesEnd = 3 * selectRect.Right + 1;
            int scanStart = selectRect.Top * bmpData.Stride;
            int scanEnd = selectRect.Bottom * bmpData.Stride;

            if (channel == Channel.All)
            {
                // Copy the RGB values into the array.
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

                // I try use for... for... two loops, but it is much slower 
                // than one loop

                for (int i = scanStart; i < scanEnd + 1; i++)//only one loop 
                {
                    int w = i % bmpData.Stride;
                    if (w > bytesStart && w < bytesEnd)
                    {
                        rgbValues[i] = Levels[rgbValues[i]];
                    }
                }
            }
            else
            {
                int integer = (int)channel;

                // Copy the RGB values into the array.
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

                for (int i = scanStart; i < scanEnd + 1; i++)//only one loop 
                {
                    int w = i % bmpData.Stride;
                    int p = w % 3;
                    if (w > bytesStart && w < bytesEnd && p == integer)
                    {
                        rgbValues[i] = Levels[rgbValues[i]];
                    }
                }
            }

            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            // Unlock the bits.
            bmp.UnlockBits(bmpData);

            return bmp;
        }
    }

    //Declare a EventArgs class
    public class LevelChangedEventArgs : EventArgs
    {
        private byte[] levelValue;

        public LevelChangedEventArgs(byte[] LevelValue)
        {
            levelValue = LevelValue;
        }

        public byte[] LevelValue
        {
            get { return levelValue; }
        }
    }

    //Declare a delegate 
    public delegate void LevelChangedEventHandler(object sender, LevelChangedEventArgs e);
}