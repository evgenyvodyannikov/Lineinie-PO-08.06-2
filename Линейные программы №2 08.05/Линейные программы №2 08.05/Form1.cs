using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Линейные_программы__2_08._05
{
    public partial class Form1 : Form
    {
        const int cost = 300;
        const int costsittingdown = 30;
        public bool flag = false;
        public int k = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Такси. В такси одновременно сели три пассажира. Когда вышел первый пассажир, на счетчике было р1 рублей; когда вышел второй — р2 рублей. Сколько должен был заплатить каждый пассажир, если по окончании поездки счетчик показал р3 рублей? Плата за посадку составляет р0 рублей. Тестирование: общая сумма оплаты пассажирами должна совпадать с показанием счетчика по окончании поездки. Рассмотрим крайние ситуации. По справедливости, если все три пассажира вышли одновременно, они должны заплатить по(р0 +р3)/ 3 руб.Если же первый и второй пассажиры «передумали ехать», они платят по р0 / 3 руб., а оставшаяся сумма ложится на счет третьего пассажира\nНажатие на кнопки пассажиров имитирует их выход из такси (если до начала поездки - то считается как передумали ехать)", "Задание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Start();
            flag = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (k != 3)
            {
                try { progressBar1.Value++; }
                catch
                {
                    timer1.Stop();
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    textBox1.Text = Convert.ToString(3 * cost);
                }
            }
            else
            {
                MessageBox.Show("Поездка завершена");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackgroundImage = new Bitmap(Image.FromFile("Resources\\k.png"));
            b.BackgroundImageLayout = ImageLayout.Stretch;
            switch(b.Text)
            {
                case "Пассажир 1":
                    {
                        if (flag == false)
                        { textBox1.Text = Convert.ToString(Int32.Parse(textBox1.Text) + costsittingdown / 3);}
                        else
                        { textBox1.Text = Convert.ToString(Int32.Parse(textBox1.Text) + cost);}
                        k++;
                    }
                    break;
                case "Пассажир 2":
                    {
                        if (flag == false)
                        { textBox1.Text = Convert.ToString(Int32.Parse(textBox1.Text) + costsittingdown / 3); }
                        else
                        { textBox1.Text = Convert.ToString(Int32.Parse(textBox1.Text) + cost); }
                        k++;
                    }
                    break;
                case "Пассажир 3":
                    {
                        if (flag == false)
                        { textBox1.Text = Convert.ToString(Int32.Parse(textBox1.Text) + costsittingdown / 3); }
                        else
                        { textBox1.Text = Convert.ToString(Int32.Parse(textBox1.Text) + cost); }
                        k++;
                    }
                    break;
            }
            b.Text = "";
        }
    }
}
