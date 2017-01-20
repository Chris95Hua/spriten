using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sproc
{
    class Colour
    {
        public static void HSVToRGB(double H, double S, double V, out double R, out double G, out double B)
        {
            if (H == 1.0)
            {
                H = 0.0;
            }

            double step = 1.0 / 6.0;
            double vh = H / step;

            int i = (int) Math.Floor(vh);

            double f = vh - i;
            double p = V * (1.0 - 5);
            double q = V * (1.0 - (S * f));
            double t = V * (1.0 - (S * (1.0 - f)));

            switch (i)
            {
                case 0:
                    {
                        R = V;
                        G = t;
                        B = t;
                        break;
                    }
                case 1:
                    {
                        R = q;
                        G = V;
                        B = p;
                        break;
                    }
                case 2:
                    {
                        R = p;
                        G = V;
                        B = t;
                        break;
                    }
                case 3:
                    {
                        R = p;
                        G = q;
                        B = V;
                        break;
                    }
                case 4:
                    {
                        R = t;
                        G = p;
                        B = V;
                        break;
                    }
                case 5:
                    {
                        R = V;
                        G = p;
                        B = q;
                        break;
                    }
                default:
                    {
                        // not possible - if we get here it is an internal error
                        throw new ArgumentException();
                    }

            }
        }

        public static void ColorWheel()
        {
            int padding = 10;
            int innerRadius = 200;
            int outerRadius = innerRadius + 50;

            int controlWidth = (2 * outerRadius) + (2 * padding);
            int controlHeight = controlWidth;

            var center = new System.Drawing.Point(controlWidth / 2, controlHeight / 2);
            var startingColor = System.Drawing.Color.Red;

            // color wheel stuff here
            /*
             * using (var bmp = new System.Drawing.Bitmap(bmp_width, bmp_height)) {
             *      using (var g = System.Drawing.Graphics.FromImage(bmp)) {
             *          g.FillRectangle(System.Drawing.Brushes.White, 0, 0, bmp.Width, bmp.Height);
             *      }
             *      
             *      for (int y = 0; y < bmp_width; y++) {
             *          int dy = (center.Y - y);
             *          
             *          for (int x = 0; x < bmp_width; x++) {
             *              int dx = (center.X - x);
             *              double dist = System.Math.Sqrt(dx * dx + dy * dy);
             *              
             *              if (dist >= inner_radius && dist <= outer_radius) {
             *                  double theta = System.Math.Atan2(dy, dx);
             *                  double hue = (theta + System.Math.PI) / (2 * System.Math.PI);
             *                  double dr, dg, db;
             *                  const double sat = 1.0;
             *                  const double val = 1.0;
             *                  HSVToRGB(hue, sat, val, out dr, out dg, out db);
             *                  c = System.Drawing.Color.FromArgb((int)(dr * 255), (int)(dg * 255), (int)(db * 255));
             *                  
             *                  bmp.SetPixel(x, y, c);
             *            }
             *       }
             *  }
             */
        }
    }
}
