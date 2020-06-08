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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Такси. В такси одновременно сели три пассажира. Когда вышел первый пассажир, на счетчике было р1 рублей; когда вышел второй — р2 рублей. Сколько должен был заплатить каждый пассажир, если по окончании поездки счетчик показал р3 рублей? Плата за посадку составляет р0 рублей. Тестирование: общая сумма оплаты пассажирами должна совпадать с показанием счетчика по окончании поездки. Рассмотрим крайние ситуации. По справедливости, если все три пассажира вышли одновременно, они должны заплатить по(р0 +р3)/ 3 руб.Если же первый и второй пассажиры «передумали ехать», они платят по р0 / 3 руб., а оставшаяся сумма ложится на счет третьего пассажира", "Задание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
