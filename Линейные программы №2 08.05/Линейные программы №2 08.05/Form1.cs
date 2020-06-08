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
        public int cost;
        public int costsittingdown;
        public bool flag = false;
        public int k = 0;
        public int kolvo = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Такси. В такси одновременно сели три пассажира. Когда вышел первый пассажир, на счетчике было р1 рублей; когда вышел второй — р2 рублей. Сколько должен был заплатить каждый пассажир, если по окончании поездки счетчик показал р3 рублей? Плата за посадку составляет р0 рублей. Тестирование: общая сумма оплаты пассажирами должна совпадать с показанием счетчика по окончании поездки. Рассмотрим крайние ситуации. По справедливости, если все три пассажира вышли одновременно, они должны заплатить по(р0 +р3)/ 3 руб.Если же первый и второй пассажиры «передумали ехать», они платят по р0 / 3 руб., а оставшаяся сумма ложится на счет третьего пассажира\nНажатие на кнопки пассажиров имитирует их выход из такси (если до начала поездки - то считается как передумали ехать\nЗалог = 25% стоимости поездки)", "Задание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button2.Enabled) kolvo++;
            if (button3.Enabled) kolvo++;
            if (button4.Enabled) kolvo++;
            if (kolvo != 0)
            {
                timer1.Start();
                flag = true;
                button5.Enabled = false;
                label3.Text = Convert.ToString(costsittingdown / 3);
                label4.Text = Convert.ToString(costsittingdown / 3);
                label5.Text = Convert.ToString(costsittingdown / 3);
                textBox1.Text = costsittingdown.ToString();
            }
            else
            {
                MessageBox.Show("Никто из пассажиров не поехал.", "Поездка завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(k == 3)
            { timer1.Stop(); MessageBox.Show("Пассажиры покинули такси.", "Поездка завершена", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            try { progressBar1.Value++; }
            catch
            {
                timer1.Stop();
                if (button2.Enabled) label3.Text = Convert.ToString(Int32.Parse(label3.Text) + (cost - costsittingdown) / kolvo);
                if (button3.Enabled) label4.Text = Convert.ToString(Int32.Parse(label4.Text) + (cost - costsittingdown) / kolvo);
                if (button4.Enabled) label5.Text = Convert.ToString(Int32.Parse(label5.Text) + (cost - costsittingdown) / kolvo);
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                textBox1.Text = Convert.ToString(cost);
                MessageBox.Show("Такси прибыло в пункт назначения.", "Поездка завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackgroundImage = Properties.Resources.k;
            b.BackgroundImageLayout = ImageLayout.Stretch;
            switch(b.Text)
            {
                case "Пассажир 1":
                    {
                        if (flag == false)
                        { textBox1.Text = Convert.ToString(Int32.Parse(textBox1.Text) + costsittingdown / 3); label3.Text = Convert.ToString(costsittingdown / 3);}
                        else
                        {
                            label3.Text = Convert.ToString(Int32.Parse(label3.Text) + (cost - costsittingdown) / kolvo);
                            textBox1.Text = Convert.ToString(Int32.Parse(textBox1.Text) + (cost - costsittingdown) / kolvo);
                        }
                        k++;
                        b.Enabled = false;
                    }
                    break;
                case "Пассажир 2":
                    {
                        if (flag == false)
                        { textBox1.Text = Convert.ToString(Int32.Parse(textBox1.Text) + costsittingdown / 3); label4.Text = Convert.ToString(costsittingdown / 3);}
                        else
                        {
                            label4.Text = Convert.ToString(Int32.Parse(label4.Text) + (cost - costsittingdown) / kolvo);
                            textBox1.Text = Convert.ToString(Int32.Parse(textBox1.Text) + (cost - costsittingdown) / kolvo);
                        }
                        k++;
                        b.Enabled = false;
                    }
                    break;
                case "Пассажир 3":
                    {
                        if (flag == false)
                        { textBox1.Text = Convert.ToString(Int32.Parse(textBox1.Text) + costsittingdown / 3); label5.Text = Convert.ToString(costsittingdown / 3);}
                        else
                        {
                            label5.Text = Convert.ToString(Int32.Parse(label5.Text) + (cost - costsittingdown) / kolvo);
                            textBox1.Text = Convert.ToString(Int32.Parse(textBox1.Text) + (cost - costsittingdown) / kolvo);
                        }
                        k++;
                        b.Enabled = false;
                    }
                    break;
            }
            b.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
            cost = Int32.Parse(textBox2.Text);
            costsittingdown = cost / 100 * 25;
            groupBox1.Enabled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                if (textBox2.Text.Length == 3 && textBox2.Text.Length <= 3)
                {
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }
            }
            e.Handled = true;
        }
    }
}
