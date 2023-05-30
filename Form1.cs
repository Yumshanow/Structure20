using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание_20
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        struct TC
        {
            public string name;
            public int q;
            public double price;
            public int time;
            public double priceAfter;
            public double TotalDo;
            public double TotalPosle;

            public void srok(int n, int m)
            {
                if (time >= n)
                    priceAfter = price / 2;
                else if (time > m && time < n)
                    priceAfter = price /1.5;
                else
                    priceAfter = price;

                TotalDo = q * price;
                TotalPosle = q * priceAfter;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Создание списка
            TC[] tc = new TC[6];
            tc[0].name = "Молоко";
            tc[1].name = "Хлеб";
            tc[2].name = "Сыр";
            tc[3].name = "Масло";
            tc[4].name = "Шоколад";
            tc[5].name = "Мороженое";

            tc[0].q = 60;
            tc[1].q = 100;
            tc[2].q = 30;
            tc[3].q = 50;
            tc[4].q = 200;
            tc[5].q = 250;

            tc[0].price = 35.5;
            tc[1].price = 20.5;
            tc[2].price = 120;
            tc[3].price = 90.5;
            tc[4].price = 50;
            tc[5].price = 40.5;

            tc[0].time = 1;
            tc[1].time = 3;
            tc[2].time = 2;
            tc[3].time = 6;
            tc[4].time = 12;
            tc[5].time = 9;

            int m = Convert.ToInt32(textBox1.Text);
            int n = Convert.ToInt32(textBox2.Text);

            double Min = double.MinValue;
            double Max = double.MaxValue;
            foreach (var TC in tc)
            {
                if (TC.time > Max)
                {
                    Max = TC.time;
                }
                if (TC.time < Min)
                {
                    Min = TC.time;
                }
            }

            double MaxCena = double.MinValue;
            double MinCena = double.MaxValue;

            foreach (var TC in tc)
            {
                if (TC.price > MaxCena)
                {
                    MaxCena = TC.price;
                }
                if (TC.price < MinCena)
                {
                    MinCena = TC.price;
                }
            }

            foreach (TC p in tc)
            {
                p.srok(n, m);
                MessageBox.Show($"Продукт: {p.name} \nКол-во: {p.q} \nЦена до уценки одного товара: {p.price} \nЦена после уценки одного товара: {p.priceAfter} \nСрок хранения: {p.time} мес.\n \n\nЦена до уценки всего товара: {p.TotalDo} \nЦена после уценки всего товара: {p.TotalPosle}", "Информация");
            }
        }
    }
}
