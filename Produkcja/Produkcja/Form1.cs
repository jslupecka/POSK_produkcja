using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Produkcja
{
    public partial class Form1 : Form
    {

        public string login = "";

      public string password = "";

        public Form1()
        {
            InitializeComponent();

            textBox2.PasswordChar = '*';

        }

        private void button1_Click(object sender, EventArgs e)
         {

             Form2 Form = new Form2();

             if ((textBox1.Text == login) && (textBox2.Text == password))
             {

                 Form.Show();
                 this.Hide();

             }
             else
                 MessageBox.Show("Niepoprawne dane logowania");
  }

    





    

    private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
