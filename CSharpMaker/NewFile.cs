using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharpMaker
{
    public partial class NewFile : Form
    {
        public int Num = 0;
        public NewFile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Num = 1;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Num = 2;
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Num = 3;
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Num = -1;
            this.Hide();
        }
    }
}
