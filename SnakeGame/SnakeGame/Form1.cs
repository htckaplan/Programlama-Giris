using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        private string yon = "sag";
        private int skor = 1;
        private Timer hiz = new Timer();
        private Random rand = new Random();
        private Graphics grafik;
        private Yemek yemek;
        private Yilan yilan;
            
        public Form1()
        {
            InitializeComponent();
            yilan = new Yilan();
            yemek = new Yemek(rand);
            hiz.Interval = 150;
            hiz.Tick += Guncelle;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    if (lblMenu.Visible)
                    {
                        lblMenu.Visible = false;
                        hiz.Start();
                    }
                    break;
                case Keys.Space:
                    if (!lblMenu.Visible)
                    {
                        hiz.Enabled = (hiz.Enabled) ?false :true ;
                    }
                    break;
                case Keys.Right:
                    if (yon != "sol")
                        yon = "sag";
                    break;
                case Keys.Left:
                    if (yon != "sag")
                        yon = "sol";
                    break;
                case Keys.Up:
                    if (yon != "asagi")
                        yon = "yukari";
                    break;
                case Keys.Down:
                    if (yon != "yukari")
                        yon = "asagi";
                    break;
              
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            grafik = CreateGraphics();
            yilan.Cizim(grafik);
            yemek.Cizim(grafik);
        }
        private void Guncelle(object sender,EventArgs e)
        {
            Text = string.Format("Yılan Oyunu - Skor : {0}", skor);
            yilan.Hareket(yon);
            for (int i = 1; i < yilan.Beden.Length; i++)
            {
                if (yilan.Beden[0].IntersectsWith(yilan.Beden[i]))
                {
                    hiz.Enabled = false;
                    MessageBox.Show(string.Format("Oyun Bitti! Skorunuz {0}\n Yeniden Başlamak İçin Enter'a Basın",skor));
                    YenidenBaslat();
                }
            }
            if (yilan.Beden[0].X < 0)
                yilan.Beden[0].X = 290;
            if (yilan.Beden[0].X >290)
                yilan.Beden[0].X = 0;
            if (yilan.Beden[0].Y < 0)
                yilan.Beden[0].Y = 290;
            if (yilan.Beden[0].Y >290)
                yilan.Beden[0].Y = 0;
            if (yilan.Beden[0].IntersectsWith(yemek.Parca))
            {
                skor++;
                hiz.Interval -= 2;
                yilan.Buyume();
                yemek.Olustur(rand);
            }
            Invalidate();
        }
        private void YenidenBaslat()
        {
            hiz.Stop();
            grafik.Clear(SystemColors.Control);
            yilan = new Yilan();
            yemek = new Yemek(rand);
            yon = "sag";
            skor = 1;
            hiz.Interval = 150;
            lblMenu.Visible = true;
        }
    }
}
