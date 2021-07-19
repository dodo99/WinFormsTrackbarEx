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

namespace WinFormsTrackbarEx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.DataBindings.Add(new Binding("Text", trackBar1, "Value", true, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            Trace.WriteLine("trackBar1_MouseUp");
            //your processing code here 
            //...
            //...
            //after done processing, re-enable the handler.
            textBox1.TextChanged += new System.EventHandler(textBox1_TextChanged);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Trace.WriteLine("textBox1_TextChanged");
            if (int.TryParse(((TextBox)sender).Text, out int aNumber))
            {
                if (aNumber < 0 || aNumber > 100)
                {
                    MessageBox.Show("Enter a number between 0 and 100", "INPUT ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Trace.WriteLine(((TextBox)sender).Text);

        }

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            Trace.WriteLine("trackBar1_MouseDown");
            textBox1.TextChanged -= new EventHandler(textBox1_TextChanged);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) ||
                (((TextBox)sender).Text == "0" && char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
