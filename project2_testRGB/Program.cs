// pt specificatia ca trebuie sa rotim matricea pe loc, elimin by default cazul in care aceasta nu ar fi patratica
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ProiectRGB
{
    class Program
    {
        static int y, x;
        static void Main()
        {
            // Selecteaza imaginea
            Bitmap image = new Bitmap("E:\\C#\\Test_Problema2_RGB_BUNA\\tentacion.png");

            // Ia lungimea si latimea imaginii
            int width = image.Width;
            int height = image.Height;

            // Am creat o matrice de tip pixel
            Pixel[,] matrice = new Pixel[width, height];

            for ( y = 0; y < height; y++)
            {
                for ( x = 0; x < width; x++)
                {
                   
                    // Luam culoarea fiecarui pixel
                    Color pixelColor = image.GetPixel(x, y);

                    // Luam valorile rgb si le asignam fiecarui element din matrice
                    int red = pixelColor.R;
                    int green = pixelColor.G;
                    int blue = pixelColor.B;
                    matrice[y, x] = new Pixel(red, green, blue);

                    
                }
            }

            Pixel.rotatePixel(y, x, matrice, width, height);



            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {

                    // Creezi valori noi RGB si le asignezi obiectului de tip pixel
                    int red = matrice[y, x].r;
                    
                    int green = matrice[y, x].g;
                    
                    int blue = matrice[y, x].b;

                    Color pixelColor = Color.FromArgb(red, green, blue);
                    image.SetPixel(x, y, pixelColor);
                    
                }
            }

            string outputPath = "E:\\C#\\Test_Problema2_RGB_BUNA\\output.png";
            image.Save(outputPath, ImageFormat.Png);



        }
    }



    public class Pixel
    {
        public int r;
        public int g;
        public int b;
        public Pixel(int red, int green, int blue) 
        {
            this.r = red;
            this.g = green;
            this.b = blue;
        }

        public static void rotatePixel(int y, int x, Pixel[,] pixels, int width, int height)
            //E declarata ca static pt a o putea accesa direct (fara o instanta a clasei)
        {
            for ( y = 0; y < height / 2; y++)
            {
                for ( x = y; x < width - y - 1; x++)
                {

                    Pixel top = pixels[y, x];

                    //Muti stanga->sus
                    pixels[y, x] = pixels[width - 1 - x, y];

                    //Muti jos->stanga
                    pixels[width - 1 - x, y] = pixels[width - y - 1, width - 1 - x];

                    //Muti dreapta->sus
                    pixels[width - y - 1, width - 1 - x] = pixels[x, width - y - 1];

                    //Muti sus->dreapta
                    pixels[x, width - 1 - y] = top;
                }
            }
        }

    }
}