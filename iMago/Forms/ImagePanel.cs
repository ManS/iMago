using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using Clifton.Tools.Events;

namespace iMago
{
    public partial class ImagePanel : UserControl 
    {
        MouseHelper mh;
        bool FLAG;
        public ImagePanel()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            FLAG = false;
             mh = new MouseHelper(this);
             mh.AddControl(this);
             mh.WheelBackward += new MouseEventHandler(OnWheelBackward);
             mh.WheelForward += new MouseEventHandler(OnWheelForward);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
              ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }

        #region private properties
        Rectangle selection = new Rectangle(0, 0, 0, 0);
        Rectangle theRectangle = new Rectangle(0, 0, 0, 0);
        Point startPt, screenStPt;
        bool select = false;
        bool drawSelection = false;
        string Path;
        public bool DoSelection
        {
            set { select = value; Invalidate(); }
        }

        public Rectangle SelectedArea
        {
            get { return selection; }
            set { selection = value; }
        }

        public string ImagePath
        {
            get { return Path; }
            set { Path = value; }
        }

        int viewRectWidth, viewRectHeight; // view window width and height

        float zoom = 1.0f;
        public float Zoom
        {
            get { return zoom; }
            set
            {
                if (value < 0.001f) value = 0.001f;
                zoom = value;

                displayScrollbar();
                setScrollbarValues();
                Invalidate();
            }
        }

        Size canvasSize = new Size(60, 40);
        public Size CanvasSize
        {
            get { return canvasSize; }
            set
            {
                canvasSize = value;
                displayScrollbar();
                setScrollbarValues();
                Invalidate();
            }
        }

        Bitmap image;
        public Bitmap Image
        {
            get { return image; }
            set
            {
                image = value;
                displayScrollbar();
                setScrollbarValues();
                Invalidate();
            }
        }

        InterpolationMode interMode = InterpolationMode.HighQualityBicubic;
        public InterpolationMode InterpolationMode
        {
            get { return interMode; }
            set { interMode = value; }
        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            displayScrollbar();
            setScrollbarValues();
            base.OnLoad(e);
        }

        protected override void OnResize(EventArgs e)
        {
            displayScrollbar();
            setScrollbarValues();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.InterpolationMode = interMode;
            float xOffset = viewRectWidth > canvasSize.Width * zoom ? (viewRectWidth - canvasSize.Width * zoom) / 2f :
                -hScrollBar.Value;
            float yOffset = viewRectHeight > canvasSize.Height * zoom ? (viewRectHeight - canvasSize.Height * zoom) / 2f :
                -vScrollBar.Value;
            Matrix mxCanvastoContol = new Matrix();
            mxCanvastoContol.Scale(zoom, zoom);
            mxCanvastoContol.Translate(xOffset, yOffset, MatrixOrder.Append);
            g.Transform = mxCanvastoContol;
            if (image != null)
            {
                Rectangle srcRect;
                Point pt = new Point((int)(hScrollBar.Value / zoom), (int)(vScrollBar.Value / zoom));
                if (canvasSize.Width * zoom < viewRectWidth && canvasSize.Height * zoom < viewRectHeight)
                    srcRect = new Rectangle(0, 0, canvasSize.Width, canvasSize.Height);
                else srcRect = new Rectangle(pt, new Size((int)(viewRectWidth / zoom), (int)(viewRectHeight / zoom))); 
                g.DrawImage(image, srcRect, srcRect, GraphicsUnit.Pixel);
            }
            Pen p = new Pen(Color.White, 1f);
            p.DashStyle = DashStyle.DashDot;
            g.DrawRectangle(p, selection);
            p.Dispose();
        }

        private void displayScrollbar()
        {
            viewRectWidth = this.Width;
            viewRectHeight = this.Height;

            if (image != null) canvasSize = image.Size;

            if (viewRectWidth > canvasSize.Width * zoom)
            {
                hScrollBar.Visible = false;
                viewRectHeight = Height;
            }
            else
            {
                hScrollBar.Visible = true;
                viewRectHeight = Height - hScrollBar.Height;
            }
            if (viewRectHeight > canvasSize.Height * zoom)
            {
                vScrollBar.Visible = false;
                viewRectWidth = Width;
            }
            else
            {
                vScrollBar.Visible = true;
                viewRectWidth = Width - vScrollBar.Width;
            }
            hScrollBar.Location = new Point(0, Height - hScrollBar.Height);
            hScrollBar.Width = viewRectWidth;
            vScrollBar.Location = new Point(Width - vScrollBar.Width, 0);
            vScrollBar.Height = viewRectHeight;

            labelCover.Size = new Size(vScrollBar.Width, hScrollBar.Height);
            labelCover.Location = new Point(Width - vScrollBar.Width, Height - hScrollBar.Height);
            if (vScrollBar.Visible && hScrollBar.Visible)
                labelCover.Visible = true;
            else labelCover.Visible = false;
        }

        private void setScrollbarValues()
        {
            this.vScrollBar.Minimum = 0;
            this.hScrollBar.Minimum = 0;
            if ((canvasSize.Width * zoom - viewRectWidth) > 0)
            {
                this.hScrollBar.Maximum = (int)(canvasSize.Width * zoom) - viewRectWidth;
            } 
            if (this.vScrollBar.Visible)
            {
                this.hScrollBar.Maximum += this.vScrollBar.Width;
            }
            this.hScrollBar.LargeChange = this.hScrollBar.Maximum / 10;
            this.hScrollBar.SmallChange = this.hScrollBar.Maximum / 20;
            this.hScrollBar.Maximum += this.hScrollBar.LargeChange;   
            if ((canvasSize.Height * zoom - viewRectHeight) > 0)
            {
                this.vScrollBar.Maximum = (int)(canvasSize.Height * zoom) - viewRectHeight;
            }
            if (this.hScrollBar.Visible)
            {
                this.vScrollBar.Maximum += this.hScrollBar.Height;
            }
            this.vScrollBar.LargeChange = this.vScrollBar.Maximum / 10;
            this.vScrollBar.SmallChange = this.vScrollBar.Maximum / 20;
            this.vScrollBar.Maximum += this.vScrollBar.LargeChange;
        }
        
        private Point PointToCanvas(Point point)
        {
            Point pt = new Point();
            if (viewRectWidth > canvasSize.Width * zoom)
            {
                pt.X = (int)((float)(point.X - viewRectWidth / 2 + canvasSize.Width * zoom / 2f) / zoom);
                pt.X = Math.Min(Math.Max(pt.X, 1), canvasSize.Width - 1);
            }
            else pt.X = (int)((float)(point.X + hScrollBar.Value) / zoom);
            if (viewRectHeight > canvasSize.Height * zoom)
            {
                pt.Y = (int)((float)(point.Y - viewRectHeight / 2 + canvasSize.Height * zoom / 2f) / zoom);
                pt.Y = Math.Max(Math.Min(pt.Y, canvasSize.Height - 1), 1);
            }
            else pt.Y = (int)((float)(point.Y + vScrollBar.Value) / zoom);
            return pt;
        }

        private Point pointToControl(Point point)
        {
            float xOffset = viewRectWidth > canvasSize.Width * zoom ? (viewRectWidth - canvasSize.Width * zoom) / 2f :
                -hScrollBar.Value;
            float yOffset = viewRectHeight > canvasSize.Height * zoom ? (viewRectHeight - canvasSize.Height * zoom) / 2f :
                -vScrollBar.Value;
            Matrix mxCanvastoContol = new Matrix();
            mxCanvastoContol.Scale(zoom, zoom);
            mxCanvastoContol.Translate(xOffset, yOffset, MatrixOrder.Append);
            Point[] pts = new Point[] { point };
            mxCanvastoContol.TransformPoints(pts);
            return pts[0];
        }

        private void ImagePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && select)
            {
                drawSelection = true;
                startPt = PointToCanvas(new Point(e.X, e.Y));
                Control control = (Control)sender;
                screenStPt = control.PointToScreen(pointToControl(startPt));
            }

        }

        private void ImagePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && select && drawSelection)
            {
                ControlPaint.DrawReversibleFrame(theRectangle, Color.White, FrameStyle.Dashed);
                Point endPt = PointToCanvas(new Point(e.X, e.Y));
                Control control = (Control)sender;
                Point screenEndPt = control.PointToScreen(pointToControl(endPt));
                int width = screenEndPt.X - screenStPt.X;
                int height = screenEndPt.Y - screenStPt.Y;
                theRectangle = new Rectangle(screenStPt.X, screenStPt.Y, width, height);
                ControlPaint.DrawReversibleFrame(theRectangle,
                Color.White, FrameStyle.Dashed);
            }
            Invalidate();
        }

        private void ImagePanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && select && drawSelection)
            {
                select = false;
                drawSelection = false;
                ControlPaint.DrawReversibleFrame(theRectangle,
                this.BackColor, FrameStyle.Dashed);
                theRectangle = new Rectangle(0, 0, 0, 0);
                Point endPoint = PointToCanvas(new Point(e.X, e.Y));
                int x = endPoint.X > startPt.X ? startPt.X : endPoint.X;
                int y = endPoint.Y > startPt.Y ? startPt.Y : endPoint.Y;
                int w = Math.Abs(startPt.X - endPoint.X);
                int h = Math.Abs(startPt.Y - endPoint.Y);
                selection = new Rectangle(x, y, w, h);
                Invalidate();
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.Invalidate();
        }

        private void vScrollBar1_Scroll_1(object sender, ScrollEventArgs e)
        {
            this.Invalidate();
        }

        private void OnWheelBackward(object sender, MouseEventArgs e)
        {
            if (FLAG == true)
            {
                this.zoom -= 0.1f;
                displayScrollbar();
                setScrollbarValues();
            }
            else
            {
                vScrollBar.Value += 10;
            }
            this.Invalidate();
            
        }

        private void OnWheelForward(object sender, MouseEventArgs e)
        {
            if (FLAG == true)
            {
                this.zoom += 0.1f;
                displayScrollbar();
                setScrollbarValues();
            }
            else
            {
                vScrollBar.Value -= 10;
            }
            this.Invalidate();
        }

        private void ImagePanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                FLAG = true;
            }
            else
                FLAG = false;
            displayScrollbar();
            this.Invalidate();
        }

        private void ImagePanel_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                FLAG = false;
            }
            displayScrollbar();
            this.Invalidate();

        }
    }
}