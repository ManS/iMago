using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.Sharping
{
    public class LineSharpening : I2DConvolution
    {
        public FilterDirection Direction { get; set; }
        
        public LineSharpening(int width, int height, FilterDirection filterDirection) 
            : base(width, height) 
        {
            this.Direction = filterDirection;
            this.ConstructFilter();
        }

        protected override Bitmap ApplyWithPostProcessing(Bitmap paddedImage, int origWidth, int origHeight)
        {
            RGB[,] filteredImage = base.ApplyFilter(paddedImage, origWidth, origHeight);
            return PostProcessing.CutOff(filteredImage, 255, 0);
        }

        protected override void ConstructFilter()
        {
            int x = Width / 2;
            int y = Height / 2;
            bool mid = false;
            switch (this.Direction)
            {
                case FilterDirection.Vertical:
                    for (int i = 0; i < Width; i++)
                        {
                           mid = i > (Width / 2);
                           this.FilterValues[i, y] = mid ? -1 : 1;
                        }
                    break;
                case FilterDirection.Horizontal:
                    for (int i = 0; i < Height; i++)
                        {
                            mid = i > (Height / 2);
                            this.FilterValues[x, i] = mid ? -1 : 1;
                        }
                    break;
                case FilterDirection.RightDiagonal:
                    for (int i = 0, j = 0; i < Width; i++, j++)
                        {
                            this.FilterValues[i, j] = j > x ? -1 : 1;
                        }
                    break;
                case FilterDirection.LeftDiagonal:
                    for (int i = 0, j= Width-1; i < Width; i++, j--)
                        {
                            this.FilterValues[i, j] = i > x ? -1 : 1;
                        }
                    break;
                default:
                    break;
            }
        }
    }
}