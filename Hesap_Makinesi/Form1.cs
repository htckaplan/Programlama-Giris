using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hesap_Makinesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)//Sayı yazılı butonlara erişme
        {
            if ((txtCikti.Text == "0") || (islemeBasıldıMı))
                txtCikti.Text = "";

            islemeBasıldıMı = false;
            Button b = (Button)sender;
            if ((!txtCikti.Text.Contains(".") || b.Text != ","))//Birden fazla virgül kullanımını engelleme
            {
                if (txtCikti.Text == "" && b.Text==",")
                    txtCikti.Text = "0" + b.Text;
                else
                txtCikti.Text += b.Text;
            }
        }
        string islem = "";
        double deger = 0;
        bool islemeBasıldıMı = false;
        private void btn_islem(object sender, EventArgs e)//4 farklı işlemin hangisi olduğunu yakalama
        {
            islemeBasıldıMı = true;
            Button b = (Button)sender;
            islem = b.Text;
            deger = Convert.ToDouble(txtCikti.Text);
            label1.Text = deger + islem;
            btnEsittir.Enabled = true;
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtCikti.Text = "0";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            txtCikti.Text = "0";
            deger = 0;
            
        }

        private void btnEsittir_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            switch (islem)
            {
                case "+":
                    txtCikti.Text = (deger + Double.Parse(txtCikti.Text)).ToString();
                    break;
                case "-":
                    txtCikti.Text = (deger - Double.Parse(txtCikti.Text)).ToString();
                    break;
                case "*":
                    txtCikti.Text = (deger * Double.Parse(txtCikti.Text)).ToString();
                    break;
                case "/":
                    txtCikti.Text = (deger / Double.Parse(txtCikti.Text)).ToString();
                    break;
                default:
                    break;
            }
            btnEsittir.Enabled = false;
        }
    }
}

