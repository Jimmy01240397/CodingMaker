using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PictureProgram
{
    public partial class SetProgramForVariable : UserControl
    {
        private string _program = "int ";

        public string Program
        {
            get
            {
                return _program;
            }
        }

        public SetProgramForVariable()
        {
            InitializeComponent();
            comboBox2.SelectedIndex = 0;
            try
            {
                DirectoryInfo a = new DirectoryInfo(System.Environment.CurrentDirectory + @"\core\include");
                foreach (FileInfo i in a.GetFiles("*.h", SearchOption.AllDirectories))
                {
                }
            }
            catch (SystemException)
            {

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox2.SelectedIndex)
            {
                case 0:
                    {
                        numericUpDown1.Visible = true;
                        textBox2.Visible = false;
                        checkBox1.Visible = false;
                        numericUpDown1.DecimalPlaces = 0;
                        break;
                    }
                case 1:
                    {
                        numericUpDown1.Visible = true;
                        textBox2.Visible = false;
                        checkBox1.Visible = false;
                        numericUpDown1.DecimalPlaces = 48;
                        break;
                    }
                case 2:
                    {
                        numericUpDown1.Visible = true;
                        textBox2.Visible = false;
                        checkBox1.Visible = false;
                        numericUpDown1.DecimalPlaces = 99;
                        break;
                    }
                case 3:
                    {
                        numericUpDown1.Visible = false;
                        textBox2.Visible = false;
                        checkBox1.Visible = true;
                        break;
                    }
                case 4:
                    {
                        numericUpDown1.Visible = false;
                        textBox2.Visible = true;
                        checkBox1.Visible = false;
                        break;
                    }
                case 5:
                    {
                        numericUpDown1.Visible = false;
                        textBox2.Visible = true;
                        checkBox1.Visible = false;
                        break;
                    }
            }
            if (comboBox2.SelectedIndex == 0)
            {
                _program = "#include <>";
            }
            else
            {
                _program = @"#include """;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            switch(comboBox2.SelectedIndex)
            {
                case 0:
                    {
                        _program = "int " + textBox1.Text + " = " + numericUpDown1.Value;
                        break;
                    }
                case 1:
                    {
                        _program = "float " + textBox1.Text + " = " + numericUpDown1.Value;
                        break;
                    }
                case 2:
                    {
                        _program = "double " + textBox1.Text + " = " + numericUpDown1.Value;
                        break;
                    }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
