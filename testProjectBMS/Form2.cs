using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testProjectBMS
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr!=8)
            {
                e.Handled = true;
                MessageBox.Show("Xahiş olunur rəqəm daxil edin.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Value.animal = comboBox1.Text;
            Value.pieces = Convert.ToInt32(textBox2.Text);
            Values val = new Values();
       
            val.Show();
            
        }
    }
}
