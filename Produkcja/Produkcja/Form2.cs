using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Produkcja
{


    public partial class Form2 : Form
    {
        static PerformanceCounter cpuCounter;
        static PerformanceCounter m_memoryCounter;
        Random random = new Random();
        int timeLeft;
        int te;
        int ilosc;
        public Form2()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile("C:\\Users\\Joanna\\Desktop\\paczek.jpg");
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time");
            cpuCounter.InstanceName = "_Total";
            label1.Text = "CPU usage: " + CurrentCPUusage;

            m_memoryCounter = new PerformanceCounter("Memory", "Available MBytes");
            label2.Text = "Available memory: " + AvailableMemory;
            timer1.Start();
            timer3.Start();

            label3.Text = "Produkcja pączków rozpocznie się gdy temperatura oleju osiągnie 180 st.";
            label6.Text = "Ilość pączków w skrzynce: " + ilosc;
            button2.Text = "Produkcja ropocznie się gdy temperatura osiągnie 180 st.";
            label7.Text = " ";

        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (timeLeft > 0)
            {               
                timeLeft = timeLeft - 1;

                int awaria = random.Next(1,5);
                {
                    timer1.Stop();
                    timer2.Stop();
                    timer3.Stop();
                    timer4.Stop();
                    label7.Text = "Nastąpiła awaria. Wezwij technika.";
                    button3.Text = "Technik!!!";
                }
            }
            else
            {              
              timer1.Stop();
              button1.Text = "potwierdź obecność";
                Console.Beep();
                timer2.Start();
            }
        }

      

        private void button1_Click(object sender, EventArgs e)
        {          
                button1.Text = "Jesteś zalogowany jako Anna Nowak";
                timer1.Start();
                timer2.Stop();         
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {               
                timeLeft = timeLeft - 1;
            }
            else
            timer2.Stop();
            Application.Exit();
        }
        public static string CurrentCPUusage
        {
            get
            {
                return cpuCounter.NextValue() + "%";
            }
        }
        public static string AvailableMemory
        {
            get
            {
                return m_memoryCounter.NextValue().ToString();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0 || te<180)
            {
                timeLeft = timeLeft - 1;
                te = te + 30;
                label3.Text = "Temperatura wynosi: " + te.ToString() + " st. Trwa Nagrzewanie.";
                label1.Text = "CPU usage: " + CurrentCPUusage;
                label2.Text = "Available memory: " + AvailableMemory;

                if (te==180)
                {
                    label3.Text = "Temperatura wynosi: " + te.ToString() + " st.";
                    button2.Text = "Trwa produkcja";
                    timer3.Stop();
                    timer1.Start();
                    timer4.Start();
                }
            }
            else
                timeLeft = 1;

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timer1.Start();
                timeLeft = timeLeft - 1;
                ilosc = ilosc + 1;
                label6.Text = "Ilość pączków w skrzynce: "+ ilosc.ToString();
                label1.Text = "CPU usage: " + CurrentCPUusage;
                label2.Text = "Available memory: " + AvailableMemory;

                if (ilosc==10)
                {
                    timer4.Stop();
                    button2.Text = "pączki gotowe do wysłania";

                }
            }
            else
                timeLeft = 1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ilosc = 0;
            label6.Text = "Ilość pączków w skrzynce: " + ilosc.ToString();
            timer4.Start();
            button2.Text = "Trwa produkcja";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer3.Start();
            timer4.Start();
            button3.Text = " ";
            label7.Text = " ";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}