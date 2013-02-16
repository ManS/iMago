using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Utilities
{
    public unsafe class UnsafeBitmap
    {
        #region Attributes
        
        private Bitmap m_bitmap;
        private int m_bitmapWidth;
        private BitmapData m_bitmapData = null;
        private Byte* m_pBase = null;
        
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="UnsafeBitmap"/> class.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        public UnsafeBitmap(Bitmap bitmap)
        {
            this.m_bitmap = new Bitmap(bitmap);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="UnsafeBitmap"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public UnsafeBitmap(int width, int height)
        {
            this.m_bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
        }
        #endregion

        #region Properties
        private Point PixelSize
        {
            get
            {
                GraphicsUnit unit = GraphicsUnit.Pixel;
                RectangleF bounds = m_bitmap.GetBounds(ref unit);

                return new Point((int)bounds.Width, (int)bounds.Height);
            }
        }
        public Bitmap Bitmap
        {
            get
            {
                return (m_bitmap);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        public void Dispose()
        {
            m_bitmap.Dispose();
        }

        /// <summary>
        /// Locks the bitmap.
        /// </summary>
        public void LockBitmap()
        {
            GraphicsUnit unit = GraphicsUnit.Pixel;
            RectangleF boundsF = m_bitmap.GetBounds(ref unit);
            Rectangle bounds = new Rectangle((int)boundsF.X,
           (int)boundsF.Y,
           (int)boundsF.Width,
           (int)boundsF.Height);

            // Figure out the number of bytes in a row
            // This is rounded up to be a multiple of 4
            // bytes, since a scan line in an image must always be a multiple of 4 bytes
            // in length. 
            m_bitmapWidth = (int)boundsF.Width * sizeof(PixelData);
            if (m_bitmapWidth % 4 != 0)
            {
                m_bitmapWidth = 4 * (m_bitmapWidth / 4 + 1);
            }
            m_bitmapData = m_bitmap.LockBits(bounds, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            
            m_pBase = (Byte*)m_bitmapData.Scan0.ToPointer();
        }

        /// <summary>
        /// Gets the pixel.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public PixelData GetPixel(int x, int y)
        {
            PixelData returnValue = *PixelAt(x, y);
            return returnValue;
        }

        /// <summary>
        /// Sets the pixel.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="colour">The colour.</param>
        public void SetPixel(int x, int y, PixelData colour)
        {
            PixelData* pixel = PixelAt(x, y);
            *pixel = colour;
        }

        /// <summary>
        /// Unlocks the bitmap.
        /// </summary>
        public void UnlockBitmap()
        {
            m_bitmap.UnlockBits(m_bitmapData);
            m_bitmapData = null;
            m_pBase = null;
        }

        /// <summary>
        /// Get Pixels at.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public PixelData* PixelAt(int x, int y)
        {
            return (PixelData*)(m_pBase + y * m_bitmapWidth + x * sizeof(PixelData));
        }

        #endregion
    }
}
