using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace lab3_2
{
    public partial class Form1 : Form
    {
        static int bee;
        static int honey;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            bee = Convert.ToInt32(textBox1.Text);
            int bochka =0;
            int colsec = 0;
            int msec = 0;
            honey = 0;

            void Honey()
            {
                honey = honey + 10;
            }
               if (bee == 1)
                {
                    for (int i = 0; i < bee; i++)
                    {
                        var thr = new Thread(Honey);
                        thr.Start();
                        thr.Join();
                    }
                   // textBox2.Text += (string.Join(" ", honey).ToString());
                textBox4.Text = (string.Join("  ", 10 + " sec").ToString());
               // textBox3.Text += "Ест";
            }
                else
                {
                    //массив потоков 
                    //стартовые и конечные позиции, шаг (равное кол-о элементов)
                    int Step = 1;
                    int Start = -Step;
                    Thread[] arrThr = new Thread[bee];
                    //инициализация и запуск потоков в цикле
                   
                    for (int j = 0; j < bee; j++)
                    {
                        Random random = new Random();
                        int mseconds = random.Next(1, 3) * 10000;
                        Thread.Sleep(mseconds);
                        arrThr[j] = new Thread(Honey);
                        arrThr[j].Start();
                        colsec = colsec + mseconds;
                   
                }

                    //последовательное завершение(блокировка потоков)
                    for (int j = 0; j < bee; j++) arrThr[j].Join();
                    textBox4.Text = (string.Join("  ", colsec / 1000 + " sec").ToString());
                }
            
            Thread thr2 = new Thread(() =>
            {
               // msec = 0;
                bochka = honey;
                for (int i = 0; i < bee; i++)
                {
                    //int d = 20000;
                    Thread.Sleep(20000);
                    bochka -= 10;
                    msec = bee*20;
                }
                msec = bee * 20;

            int razn = msec-(colsec/1000);
                textBox3.BeginInvoke(new Action(() =>
                    {
                        if (razn > 0)
                        {
                            textBox3.Text += "Ест";
                           // textBox3.Text = (string.Join("  ", msec + " sec").ToString());
                        }
                        else
                        {
                            textBox3.Text += "Голоден";
                            //textBox3.Text = (string.Join("  ", msec + " sec").ToString());
                        }
                    }));
            });
            string selectedPriority2 = comboBox1.SelectedItem.ToString();
            if (selectedPriority2 == "AboveNormal") { thr2.Priority = ThreadPriority.AboveNormal; }
            else if (selectedPriority2 == "BelowNormal") { thr2.Priority = ThreadPriority.BelowNormal; }
            else if (selectedPriority2 == "Highest") { thr2.Priority = ThreadPriority.Highest; }
            else if (selectedPriority2 == "Lowest") { thr2.Priority = ThreadPriority.Lowest; }
            else { thr2.Priority = ThreadPriority.Normal; }
            textBox2.Text += (string.Join(" ", honey).ToString());
            thr2.Start();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
  }

