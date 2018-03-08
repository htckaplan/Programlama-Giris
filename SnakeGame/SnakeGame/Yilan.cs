using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame
{
    public class Yilan
    {
        public Rectangle[] Beden;
        private int x = 0, y = 0, genislik = 10, yukseklik = 10;
        public Yilan()
        {
            Beden = new Rectangle[1];
            Beden[0] = new Rectangle(x, y, genislik, yukseklik);
        }
        public void Cizim()
        {
            for(int i = Beden.Length - 1; i > 0; i--)
            {
                Beden[i] = Beden[i - 1];
            }
        }
        public void Cizim(Graphics graphics)
        {
            graphics.FillRectangles(Brushes.Turquoise, Beden);
        }
        public void Hareket(string yon)
        {
            Cizim();
            switch (yon)
            {
                case "asagi":
                    Beden[0].Y += 10;
                    break;
                case "yukari":
                    Beden[0].Y -= 10;
                    break;
                case "sag":
                    Beden[0].X += 10;
                    break;
                case "sol":
                    Beden[0].X -= 10;
                    break;
            }
        }
        public void Buyume()
        {
            List<Rectangle> list = Beden.ToList();
            list.Add(new Rectangle(Beden[Beden.Length - 1].X, Beden[Beden.Length - 1].Y, genislik, yukseklik));
            Beden = list.ToArray();
        }
    }
}
