using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame
{
    public class Yemek
    {
        public Rectangle Parca;
        private int x, y, genislik = 10, yukseklik = 10;
        public Yemek(Random random)
        {
            Olustur(random);
            Parca = new Rectangle(x, y, genislik, yukseklik);
        }
        public void Cizim(Graphics graphics)
        {
            Parca.X = x;
            Parca.Y = y;
            graphics.FillRectangle(Brushes.Pink, Parca);
        }
        public void Olustur(Random random)
        {
            x = random.Next(0, 30) * 10;
            y = random.Next(0, 30) * 10;
        }
    }
}
