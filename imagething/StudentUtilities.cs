using System;
using System.Drawing;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;

namespace DigitalImageProcessing
{
    static class StudentUtilities
    {
        const int WHITE = 255;
        const int BLACK = 0;

        static RandomNumberGenerator rand = RandomNumberGenerator.Create();

        #region Ida's programs
        public static Bitmap ToGreyscale(Bitmap image)
        {
            Bitmap bitmap = new Bitmap(image.Width, image.Height);
            for (int i = 0; i < image.Width; i++)
                for (int j = 0; j < image.Height; j++)
                {
                    Color color = image.GetPixel(i, j);
                    double greyscale = color.R * 0.2126 + color.G * 0.7152 + color.B * 0.0722;
                    int integralGrey = (int)Math.Round(greyscale);
                    bitmap.SetPixel(i, j, Color.FromArgb(integralGrey, integralGrey, integralGrey));
                }
            return bitmap;
        }

        public static int[,] BitmapToMatrix(Bitmap image)
        {
            int[,] matrix = new int[image.Width, image.Height];
            for (int i = 0; i < image.Width; i++)
                for (int j = 0; j < image.Height; j++)
                {
                    Color color = image.GetPixel(i, j);
                    double greyscale = color.R * 0.2126 + color.G * 0.7152 + color.B * 0.0722;
                    matrix[i, j] = (int)Math.Round(greyscale);
                }
            return matrix;
        }

        public static Bitmap MatrixToBitmap(int[,] matrix)
        {
            Bitmap bitmap = new Bitmap(matrix.GetLength(0), matrix.GetLength(1));
            for (int i = 0; i < bitmap.Width; i++)
                for (int j = 0; j < bitmap.Height; j++)
                {
                    int grey = matrix[i, j];
                    bitmap.SetPixel(i, j, Color.FromArgb(grey, grey, grey));
                }
            return bitmap;
        }

        public static int[,] MatrixFromFile(string filename)
        {
            return BitmapToMatrix(new Bitmap(Image.FromFile(filename)));
        }

        public static void MatrixToFile(int[,] matrix, string filename)
        {
            MatrixToBitmap(matrix).Save(filename);
        }

        public static int[,] Threshold(int[,] matrix, int threshold)
        {
            int[,] result = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > threshold)
                        result[i, j] = WHITE;
                    else
                        result[i, j] = BLACK;
                }
            return result;
        }

        public static int Bound(double i, int min = BLACK, int max = WHITE)
        {
            return (int)Math.Max(Math.Min(Math.Round(i), max), min);
        }

        public static int[,] LinearCombination(int[,] m1, int[,] m2, double c1, double c2, bool abs = false)
        {
            int[,] result = new int[m1.GetLength(0), m1.GetLength(1)];
            for (int i = 0; i < m1.GetLength(0); i++)
                for (int j = 0; j < m1.GetLength(1); j++)
                {
                    double d = c1 * m1[i, j] + c2 * m2[i, j];
                    result[i, j] = (int)(abs ? Math.Abs(d) : Bound(d));
                }
            return result;
        }

        public static int[,] ApplyFilter(int[,] matrix, double[,] filter)
        {
            int midX = filter.GetLength(0) / 2 + 1;
            int midY = filter.GetLength(1) / 2 + 1;
            int[,] result = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    double r = 0;
                    for (int k1 = 0; k1 < filter.GetLength(0); k1++)
                    {
                        for (int k2 = 0; k2 < filter.GetLength(1); k2++)
                        {
                            if (i - midX + k1 >= 0 && i - midX + k1 < matrix.GetLength(0)
                                && j - midY + k2 >= 0 && j - midY + k2 < matrix.GetLength(1))
                            {
                                r += matrix[i - midX + k1, j - midY + k2] * filter[k1, k2];
                            }
                        }
                    }
                    result[i, j] = Bound(r);
                }
            return result;
        }
        #endregion

        #region myprograms
        /* public static Bitmap NoBlue(Bitmap image)
         {
             Bitmap bitmap = new Bitmap(image.Width, image.Height);
             for (int i = 0; i < image.Width; i++)
                 for (int j = 0; j < image.Height; j++)
                 {
                     Color color = image.GetPixel(i, j);
                     bitmap.SetPixel(i, j, Color.FromArgb(StudentUtilities.Bound(color.R + 150), StudentUtilities.Bound(color.G + 150), StudentUtilities.Bound(color.B + 150)));
                 }
             return bitmap;
         }*/

        public static Bitmap NoColor(Bitmap image, string deletcolor)
        {
            Bitmap bitmap = new Bitmap(image.Width, image.Height);
            switch (deletcolor)
            {
                case "red":
                    for (int i = 0; i < image.Width; i++)
                        for (int j = 0; j < image.Height; j++)
                        {
                            Color color = image.GetPixel(i, j);
                            bitmap.SetPixel(i, j, Color.FromArgb(0, color.G, color.B));
                        }
                    break;
                case "green":
                    for (int i = 0; i < image.Width; i++)
                        for (int j = 0; j < image.Height; j++)
                        {
                            Color color = image.GetPixel(i, j);
                            bitmap.SetPixel(i, j, Color.FromArgb(color.R, 0, color.B));
                        }
                    break;
                case "blue":
                    for (int i = 0; i < image.Width; i++)
                        for (int j = 0; j < image.Height; j++)
                        {
                            Color color = image.GetPixel(i, j);
                            bitmap.SetPixel(i, j, Color.FromArgb(color.R, color.G, 0));
                        }
                    break;
            }

            return bitmap;
        }

        public static Bitmap SwichColors(Bitmap image, string RColor, string GColor, string BColor)
        {
            int R = 0;
            int G = 0;
            int B = 0;
            Bitmap bmp = new Bitmap(image);
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color col = image.GetPixel(i, j);
                    switch (RColor)
                    {
                        case "Red":
                            R = col.R;
                            break;
                        case "Green":
                            R = col.G;
                            break;
                        case "Blue":
                            R = col.B;
                            break;
                    }
                    switch (GColor)
                    {
                        case "Red":
                            G = col.R;
                            break;
                        case "Green":
                            G = col.G;
                            break;
                        case "Blue":
                            G = col.B;
                            break;
                    }
                    switch (BColor)
                    {
                        case "Red":
                            B = col.R;
                            break;
                        case "Green":
                            B = col.G;
                            break;
                        case "Blue":
                            B = col.B;
                            break;
                    }
                    bmp.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }


            return bmp;
        }

        public static Bitmap SpotTheDifference(Bitmap first, Bitmap second)
        {
            Bitmap bitmap = new Bitmap(first.Width, first.Height);
            for (int i = 0; i < first.Width; i++)
            {
                for (int j = 0; j < first.Height; j++)
                {
                    if (first.GetPixel(i, j) != second.GetPixel(i, j))
                    {
                        Color color = first.GetPixel(i, j);
                        bitmap.SetPixel(i, j, Color.FromArgb(color.R, color.G, color.B));
                    }
                }
            }
            return bitmap;
        }

        public static Bitmap LinearCombinationColored(Bitmap bip1, Bitmap bip2, double c1, double c2, bool abs = false)
        {
            //setting the images to the middle
            bip2 = SetMiddle(bip1, bip2);
            if (bip1.Height != bip2.Height || bip1.Width != bip2.Width)
            {
                bip1 = SetMiddle(bip2, bip1);
            }
            Bitmap bitmap = new Bitmap(bip1.Width, bip1.Height);
            for (int i = 0; i < bip1.Width; i++)
                for (int j = 0; j < bip1.Height; j++)
                {
                    Color color1 = bip1.GetPixel(i, j);
                    Color color2 = bip2.GetPixel(i, j);
                    if (IsWhite(color1) && IsWhite(color2))
                    {
                        //make it nothing
                        bitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0, 0));
                    }
                    else if (IsWhite(color1))
                    {
                        bitmap.SetPixel(i, j, Color.FromArgb(color2.R, color2.G, color2.B));
                    }
                    else if (IsWhite(color2))
                    {
                        bitmap.SetPixel(i, j, Color.FromArgb(color1.R, color1.G, color1.B));
                    }
                    else
                    {
                        bitmap.SetPixel(i, j, Color.FromArgb(StudentUtilities.Bound((c1 * color1.R + c2 * color2.R)), StudentUtilities.Bound((c1 * color1.G + c2 * color2.G)), StudentUtilities.Bound((c1 * color1.B + c2 * color2.B))));
                    }
                }
            return bitmap;
        }

        public static bool IsWhite(Color color)
        {
            if (color.A == 0)
            {
                return true;
            }
            if (color.G >= 250 && color.G >= 250 && color.B >= 250)
            {
                return true;
            }
            return false;
        }

        public static Bitmap SetMiddle(Bitmap changeto, Bitmap change)
        {

            Bitmap bitmap;
            bitmap = new Bitmap(Math.Max(change.Width, changeto.Width), Math.Max(change.Height, changeto.Height));

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {//אם בגבול של הרוחב
                    if (i > (changeto.Width - change.Width) / 2 && i - (changeto.Width - change.Width) / 2 < change.Width)
                    {//אם בגבול של האורך
                        if (j > (changeto.Height - change.Height) / 2 && j - (changeto.Height - change.Height) / 2 < change.Height)
                        {//הכנסה בתמונה החדשה את הפיקסלים המתאימים של התמונה שמשנים
                         //Console.WriteLine((i - (changeto.Width - change.Width) / 2) + " - " + (j - (changeto.Height - change.Height) / 2));
                            if (Color.FromArgb(255, 255, 255) != change.GetPixel((i - (changeto.Width - change.Width) / 2), (j - (changeto.Height - change.Height) / 2)) || Color.FromArgb(0, 0, 0) != change.GetPixel((i - (changeto.Width - change.Width) / 2), (j - (changeto.Height - change.Height) / 2)))
                            {
                                bitmap.SetPixel(i, j, change.GetPixel((i - (changeto.Width - change.Width) / 2), (j - (changeto.Height - change.Height) / 2)));
                            }
                        }
                        /* else
                         {
                             bitmap.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                         }
                     }
                     else
                     {
                         bitmap.SetPixel(i, j, Color.FromArgb( 255, 255, 255));*/
                    }

                }
            }

            return bitmap;
        }

        public static Bitmap Nobackground(Bitmap bmp)
        {
            Bitmap returnbit = new Bitmap(bmp.Width, bmp.Height);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    if (!IsWhite(bmp.GetPixel(i, j)))
                    {
                        returnbit.SetPixel(i, j, bmp.GetPixel(i, j));
                    }
                }
            }
            return returnbit;
        }

        public static Bitmap bluer(Bitmap bmp)
        {
            Color pixl = new Color();
            Bitmap filterd = new Bitmap(bmp);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    if (i < bmp.Width - 1 && i > 0 && j < bmp.Height - 1 && j > 0)
                    {
                        /*
                      i-1,j-2|i-1,j|i-1,j+1
                      i  ,j-1|i  ,j|i  ,j+1
                      i+1,j-1|i+1,j|i+1,j+1
                        */
                        pixl = Color.FromArgb(
                            (bmp.GetPixel(i - 1, j - 1).R + bmp.GetPixel(i - 1, j).R + bmp.GetPixel(i + 1, j).R + bmp.GetPixel(i, j - 1).R + bmp.GetPixel(i, j + 1).R + bmp.GetPixel(i + 1, j + 1).R + bmp.GetPixel(i + 1, j - 1).R + bmp.GetPixel(i - 1, j + 1).R) / 8,
                            (bmp.GetPixel(i - 1, j - 1).G + bmp.GetPixel(i - 1, j).G + bmp.GetPixel(i + 1, j).G + bmp.GetPixel(i, j - 1).G + bmp.GetPixel(i, j + 1).G + bmp.GetPixel(i + 1, j + 1).G + bmp.GetPixel(i + 1, j - 1).G + bmp.GetPixel(i - 1, j + 1).G) / 8,
                            (bmp.GetPixel(i - 1, j - 1).B + bmp.GetPixel(i - 1, j).B + bmp.GetPixel(i + 1, j).B + bmp.GetPixel(i, j - 1).B + bmp.GetPixel(i, j + 1).B + bmp.GetPixel(i + 1, j + 1).B + bmp.GetPixel(i + 1, j - 1).B + bmp.GetPixel(i - 1, j + 1).B) / 8);
                        filterd.SetPixel(i, j, pixl);
                    }
                }
            }
            return filterd;
        }
        public static Bitmap bluerExept(Bitmap bmp, Point pnt1, Point pnt2)
        {
            Color pixl = new Color();
            Bitmap filterd = new Bitmap(bmp);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    if (i < bmp.Width - 1 && i > 0 && j < bmp.Height - 1 && j > 0)
                    {
                        if (!(i > Math.Min(pnt1.X, pnt2.X) && i < Math.Max(pnt1.X, pnt2.X) && j > Math.Min(pnt1.Y, pnt2.Y) && j < Math.Max(pnt1.Y, pnt2.Y)))
                        {
                            /*
                          i-1,j-2|i-1,j|i-1,j+1
                          i  ,j-1|i  ,j|i  ,j+1
                          i+1,j-1|i+1,j|i+1,j+1
                            */
                            pixl = Color.FromArgb(
                                (bmp.GetPixel(i - 1, j - 1).R + bmp.GetPixel(i - 1, j).R + bmp.GetPixel(i + 1, j).R + bmp.GetPixel(i, j - 1).R + bmp.GetPixel(i, j + 1).R + bmp.GetPixel(i + 1, j + 1).R + bmp.GetPixel(i + 1, j - 1).R + bmp.GetPixel(i - 1, j + 1).R) / 8,
                                (bmp.GetPixel(i - 1, j - 1).G + bmp.GetPixel(i - 1, j).G + bmp.GetPixel(i + 1, j).G + bmp.GetPixel(i, j - 1).G + bmp.GetPixel(i, j + 1).G + bmp.GetPixel(i + 1, j + 1).G + bmp.GetPixel(i + 1, j - 1).G + bmp.GetPixel(i - 1, j + 1).G) / 8,
                                (bmp.GetPixel(i - 1, j - 1).B + bmp.GetPixel(i - 1, j).B + bmp.GetPixel(i + 1, j).B + bmp.GetPixel(i, j - 1).B + bmp.GetPixel(i, j + 1).B + bmp.GetPixel(i + 1, j + 1).B + bmp.GetPixel(i + 1, j - 1).B + bmp.GetPixel(i - 1, j + 1).B) / 8);
                            filterd.SetPixel(i, j, pixl);
                        }
                    }
                }
            }
            return filterd;
        }
        public static Bitmap bluerJust(Bitmap bmp, Point pnt1, Point pnt2)
        {
            Color pixl = new Color();
            Bitmap filterd = new Bitmap(bmp);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    if (i < bmp.Width - 1 && i > 0 && j < bmp.Height - 1 && j > 0)
                    {
                        if ((i > Math.Min(pnt1.X, pnt2.X) && i < Math.Max(pnt1.X, pnt2.X) && j > Math.Min(pnt1.Y, pnt2.Y) && j < Math.Max(pnt1.Y, pnt2.Y)))
                        {
                            /*
                          i-1,j-2|i-1,j|i-1,j+1
                          i  ,j-1|i  ,j|i  ,j+1
                          i+1,j-1|i+1,j|i+1,j+1
                            */
                            pixl = Color.FromArgb(
                                (bmp.GetPixel(i - 1, j - 1).R + bmp.GetPixel(i - 1, j).R + bmp.GetPixel(i + 1, j).R + bmp.GetPixel(i, j - 1).R + bmp.GetPixel(i, j + 1).R + bmp.GetPixel(i + 1, j + 1).R + bmp.GetPixel(i + 1, j - 1).R + bmp.GetPixel(i - 1, j + 1).R) / 8,
                                (bmp.GetPixel(i - 1, j - 1).G + bmp.GetPixel(i - 1, j).G + bmp.GetPixel(i + 1, j).G + bmp.GetPixel(i, j - 1).G + bmp.GetPixel(i, j + 1).G + bmp.GetPixel(i + 1, j + 1).G + bmp.GetPixel(i + 1, j - 1).G + bmp.GetPixel(i - 1, j + 1).G) / 8,
                                (bmp.GetPixel(i - 1, j - 1).B + bmp.GetPixel(i - 1, j).B + bmp.GetPixel(i + 1, j).B + bmp.GetPixel(i, j - 1).B + bmp.GetPixel(i, j + 1).B + bmp.GetPixel(i + 1, j + 1).B + bmp.GetPixel(i + 1, j - 1).B + bmp.GetPixel(i - 1, j + 1).B) / 8);
                            filterd.SetPixel(i, j, pixl);
                        }
                    }
                }
            }
            return filterd;
        }


        /*  public static void check(Bitmap bit)
          {
              Console.WriteLine(bit.GetPixel(1, 1));
              if (bit.GetPixel(1, 1).A == 0)
                  Console.WriteLine("wow");
              Console.WriteLine(bit.GetPixel(bit.Width / 2, bit.Height / 2));
          }*/

        #endregion
    }
}
