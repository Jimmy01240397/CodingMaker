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
    public partial class SetProgramForInclude : UserControl
    {
        private string _program = "#include <>";

        public string Program
        {
            get
            {
                return _program;
            }
        }

        public SetProgramForInclude()
        {
            InitializeComponent();

            comboBox2.SelectedIndex = 0;
            comboBox1.Items.Add(comboBox1.Text);
            try
            {
                DirectoryInfo a = new DirectoryInfo(System.Environment.CurrentDirectory + @"\core\include");
                foreach (FileInfo i in a.GetFiles("*.h", SearchOption.AllDirectories))
                {
                    comboBox1.Items.Add(i.Name);
                }
            }
            catch (SystemException)
            {

            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add(comboBox1.Text);
            try
            {
                DirectoryInfo a = new DirectoryInfo(System.Environment.CurrentDirectory + @"\core\include");
                foreach (FileInfo i in a.GetFiles(comboBox1.Text + "*.h", SearchOption.AllDirectories))
                {
                    comboBox1.Items.Add(i.Name);
                }
                comboBox1.Select(comboBox1.Text.Length, 0);
            }
            catch (SystemException)
            {

            }
            if (comboBox1.SelectedIndex == 0)
            {
                _program = "#include <" + comboBox1.Text + ">";
            }
            else
            {
                _program = "#include \"" + comboBox1.Text + "\"";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                _program = "#include <>";
            }
            else
            {
                _program = @"#include """;
            }
        }
    }
}
