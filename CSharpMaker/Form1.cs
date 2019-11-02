using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ScintillaNET;
using System.IO;
using SizeAndLocation;
using System.Diagnostics;

namespace CSharpMaker
{
    public partial class Form1 : Form
    {
        Sizes[] _Size;
        Locations[] _Location;
        Dictionary<TabPage, string> GetFile;
        Dictionary<TabPage, Scintilla> GetScintilla;
        List<TabPage> GetTabPage;
        Dictionary<TabPage, bool> ItSave;
        StreamWriter sw;
        int _cound = 1;
        public Form1()
        {
            InitializeComponent();

            _Size = new Sizes[6] 
            { 
                new Sizes(this.Size, tabControl1.Size), 
                new Sizes(this.Size, panel1.Size), 
                new Sizes(this.Size, panel2.Size), 
                new Sizes(this.Size, panel3.Size), 
                new Sizes(this.Size, listBox1.Size),
                null 
            };
            _Location = new Locations[6] 
            { 
                new Locations(this.Size, tabControl1.Location),
                new Locations(this.Size, panel1.Location), 
                new Locations(this.Size, panel2.Location), 
                new Locations(this.Size, panel3.Location),
                new Locations(this.Size, listBox1.Location),
                null 
            };
            process1.Start();
            sw = process1.StandardInput;
            GetFile = new Dictionary<TabPage, string>();
            GetScintilla = new Dictionary<TabPage, Scintilla>();
            GetTabPage = new List<TabPage>();
            ItSave = new Dictionary<TabPage, bool>();
            //以下是声明了编辑代码的控件 这里取名“Myediter”
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            _Size[0].SetSize(this.Size, 3, 1);
            _Location[0].SetLocation(this.Size, 1.5, 0);
            _Size[1].SetSize(this.Size, 3, 1);
            _Location[1].SetLocation(this.Size, 3, 0);
            _Size[2].SetSize(this.Size, 3, 1);
            _Size[3].SetSize(this.Size, 1, 0);
            _Location[3].SetLocation(this.Size, 0, 1);
            _Size[4].SetSize(this.Size, 1, 0);
            tabControl1.Size = _Size[0]._OdjectSize;
            tabControl1.Location = _Location[0]._OdjectLocation;
            panel1.Size = _Size[1]._OdjectSize;
            panel1.Location = _Location[1]._OdjectLocation;
            panel2.Size = _Size[2]._OdjectSize;
            panel3.Size = _Size[3]._OdjectSize;
            panel3.Location = _Location[3]._OdjectLocation;
            listBox1.Size = _Size[4]._OdjectSize;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TabPage tabPageX = new TabPage();
            tabPageX.Location = new System.Drawing.Point(4, 22);
            tabPageX.Name = "tabPage" + _cound;
            tabPageX.Padding = new System.Windows.Forms.Padding(3);
            tabPageX.Size = new System.Drawing.Size(1252, 611);
            tabPageX.TabIndex = 1;
            tabPageX.Text = "tabPage" + _cound;
            tabPageX.UseVisualStyleBackColor = true;
            Scintilla a = NewScintilla("cs", "");
            tabPageX.Controls.Add(a);
            this.tabControl1.Controls.Add(tabPageX);
            GetTabPage.Add(tabPageX);
            GetFile.Add(tabPageX, "");
            GetScintilla.Add(tabPageX, a);
            ItSave.Add(tabPageX, true);
            tabControl1.SelectedTab = tabPageX;
            _cound++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TabPage tabPageX = new TabPage();
            tabPageX.Location = new System.Drawing.Point(4, 22);
            tabPageX.Name = "tabPage" + _cound;
            tabPageX.Padding = new System.Windows.Forms.Padding(3);
            tabPageX.Size = new System.Drawing.Size(1252, 611);
            tabPageX.TabIndex = 1;
            tabPageX.Text = "tabPage" + _cound;
            tabPageX.UseVisualStyleBackColor = true;
            Scintilla a = NewScintilla("html", "");
            tabPageX.Controls.Add(a);
            this.tabControl1.Controls.Add(tabPageX);
            GetTabPage.Add(tabPageX);
            GetFile.Add(tabPageX, "");
            GetScintilla.Add(tabPageX, a);
            ItSave.Add(tabPageX, true);
            tabControl1.SelectedTab = tabPageX;
            _cound++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TabPage tabPageX = new TabPage();
            tabPageX.Location = new System.Drawing.Point(4, 22);
            tabPageX.Name = "tabPage" + _cound;
            tabPageX.Padding = new System.Windows.Forms.Padding(3);
            tabPageX.Size = new System.Drawing.Size(1252, 611);
            tabPageX.TabIndex = 1;
            tabPageX.Text = "tabPage" + _cound;
            tabPageX.UseVisualStyleBackColor = true;
            Scintilla a = NewScintilla("xml", "");
            tabPageX.Controls.Add(a);
            this.tabControl1.Controls.Add(tabPageX);
            GetTabPage.Add(tabPageX);
            GetFile.Add(tabPageX, "");
            GetScintilla.Add(tabPageX, a);
            ItSave.Add(tabPageX, true);
            tabControl1.SelectedTab = tabPageX;
            _cound++;
        }

        private void CMD(string write)
        {
            sw.WriteLine(write);
        }

        private List<string> CMDRead()
        {
            process1.StandardInput.WriteLine("exit");
            process1.StandardInput.AutoFlush = true;
            List<string> output = new List<string>();
            string output1 = process1.StandardError.ReadToEnd();
            string[] output2 = output1.Split(new Char[1]{'\n'});
            output.AddRange(output2);
            process1.WaitForExit();//等待程序执行完退出进程
            process1.Close();
            process1.Start();
            sw = process1.StandardInput;
            return output;
        }
        private Scintilla NewScintilla(string Language, string text)
        {
            Scintilla Myediter;
            Myediter = new Scintilla();
            Myediter.Margins.Margin1.Width = 1;
            Myediter.Margins.Margin0.Type = MarginType.Number;
            Myediter.Margins.Margin0.Width = 0x23;
            Myediter.ConfigurationManager.Language = Language;
            Myediter.Dock = DockStyle.Fill;
            Myediter.Scrolling.ScrollBars = ScrollBars.Both;
            Myediter.ConfigurationManager.IsBuiltInEnabled = true;
            Myediter.ContextMenuStrip = contextMenuStrip1;
            Myediter.AppendText(text);
            Myediter.UndoRedo.EmptyUndoBuffer();
            return Myediter;
        }

        private void 開啟檔案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            string _file = openFileDialog1.FileName;
            if (!File.Exists(_file))
            {
                switch (Path.GetExtension(_file))
                {
                    case "c":
                        {
                            AddCsPage(_file);
                            break;
                        }
                    case "cs":
                        {
                            AddCsPage(_file);
                            break;
                        }
                    case "html":
                        {
                            AddHtmlPage(_file);
                            break;
                        }
                    case "xml":
                        {
                            AddXmlPage(_file);
                            break;
                        }
                    default:
                        {
                            AddCsPage(_file);
                            break;
                        }
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            string _file = openFileDialog1.FileName;
            if (File.Exists(_file))
            {
                switch (Path.GetExtension(_file))
                {
                    case "c":
                        {
                            AddCsPage(_file);
                            break;
                        }
                    case "cs":
                        {
                            AddCsPage(_file);
                            break;
                        }
                    case "html":
                        {
                            AddHtmlPage(_file);
                            break;
                        }
                    case "xml":
                        {
                            AddXmlPage(_file);
                            break;
                        }
                    default:
                        {
                            AddCsPage(_file);
                            break;
                        }
                }
            }
        }
        private void AddCsPage(string file)
        {
            TabPage tabPageX = new TabPage();
            tabPageX.Location = new System.Drawing.Point(4, 22);
            tabPageX.Name = "tabPage" + _cound;
            tabPageX.Padding = new System.Windows.Forms.Padding(3);
            tabPageX.Size = new System.Drawing.Size(1252, 611);
            tabPageX.TabIndex = 1;
            tabPageX.UseVisualStyleBackColor = true;
            Scintilla a;
            if (file == "")
            {
                tabPageX.Text = "tabPage" + _cound;
                a = NewScintilla("cs", "");
            }
            else
            {
                tabPageX.Text = Path.GetFileName(file);
                a = NewScintilla("cs", File.ReadAllText(file, Encoding.GetEncoding("big5")));
            }
            tabPageX.Controls.Add(a);
            this.tabControl1.Controls.Add(tabPageX);
            GetTabPage.Add(tabPageX);
            GetFile.Add(tabPageX, file);
            GetScintilla.Add(tabPageX, a);
            ItSave.Add(tabPageX, true);
            tabControl1.SelectedTab = tabPageX;
            _cound++;
        }

        private void AddHtmlPage(string file)
        {
            TabPage tabPageX = new TabPage();
            tabPageX.Location = new System.Drawing.Point(4, 22);
            tabPageX.Name = "tabPage" + _cound;
            tabPageX.Padding = new System.Windows.Forms.Padding(3);
            tabPageX.Size = new System.Drawing.Size(1252, 611);
            tabPageX.TabIndex = 1;
            tabPageX.UseVisualStyleBackColor = true;
            Scintilla a;
            if (file == "")
            {   
                tabPageX.Text = "tabPage" + _cound;
                a = NewScintilla("html", "");
            }
            else
            {
                tabPageX.Text = Path.GetFileName(file);
                a = NewScintilla("html", File.ReadAllText(file, Encoding.GetEncoding("big5")));
            }
            tabPageX.Controls.Add(a);
            this.tabControl1.Controls.Add(tabPageX);
            GetTabPage.Add(tabPageX);
            GetFile.Add(tabPageX, file);
            GetScintilla.Add(tabPageX, a);
            ItSave.Add(tabPageX, true);
            tabControl1.SelectedTab = tabPageX;
            _cound++;
        }

        private void AddXmlPage(string file)
        {
            TabPage tabPageX = new TabPage();
            tabPageX.Location = new System.Drawing.Point(4, 22);
            tabPageX.Name = "tabPage" + _cound;
            tabPageX.Padding = new System.Windows.Forms.Padding(3);
            tabPageX.Size = new System.Drawing.Size(1252, 611);
            tabPageX.TabIndex = 1;
            tabPageX.Text = "tabPage" + _cound;
            tabPageX.UseVisualStyleBackColor = true;
            Scintilla a;
            if (file == "")
            {
                tabPageX.Text = "tabPage" + _cound;
                a = NewScintilla("xml", "");
            }
            else
            {
                tabPageX.Text = Path.GetFileName(file);
                a = NewScintilla("xml", File.ReadAllText(file, Encoding.GetEncoding("big5")));
            }
            tabPageX.Controls.Add(a);
            this.tabControl1.Controls.Add(tabPageX);
            GetTabPage.Add(tabPageX);
            GetFile.Add(tabPageX, file);
            GetScintilla.Add(tabPageX, a);
            ItSave.Add(tabPageX, true);
            tabControl1.SelectedTab = tabPageX;
            _cound++;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            NewFile f1 = new NewFile();
            f1.ShowDialog();
            switch (f1.Num)
            {
                case 1:
                    {
                        AddCsPage("");
                        break;
                    }
                case 2:
                    {
                        AddHtmlPage("");
                        break;
                    }
                case 3:
                    {
                        AddXmlPage("");
                        break;
                    }
                case -1:
                    {
                        break;
                    }
                default:
                    {
                        MessageBox.Show("請選擇檔案類型", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        f1.ShowDialog();
                        break;
                    }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string a;
            Scintilla b;
            if (!GetFile.TryGetValue(tabControl1.SelectedTab, out a))
            {
                return;
            }
            GetScintilla.TryGetValue(tabControl1.SelectedTab, out b);
            if (File.Exists(a))
            {
                File.WriteAllText(a, b.Text, Encoding.GetEncoding("big5"));
            }
            else
            {
                saveFileDialog1.FileName = a;
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName == "")
                {
                    return;
                }
                a = saveFileDialog1.FileName;
                File.WriteAllText(a, b.Text, Encoding.GetEncoding("big5"));
                GetFile.Remove(tabControl1.SelectedTab);
                GetFile.Add(tabControl1.SelectedTab, a);
                tabControl1.SelectedTab.Text = Path.GetFileName(a);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GetTabPage.Count; i++)
            {
                string a;
                Scintilla b;
                GetFile.TryGetValue(GetTabPage[i], out a);
                GetScintilla.TryGetValue(GetTabPage[i], out b);
                if (File.Exists(a))
                {
                    File.WriteAllText(a, b.Text, Encoding.GetEncoding("big5"));
                }
                else
                {
                    saveFileDialog1.FileName = a;
                    saveFileDialog1.ShowDialog();
                    if (saveFileDialog1.FileName == "")
                    {
                        return;
                    }
                    a = saveFileDialog1.FileName;
                    File.WriteAllText(a, b.Text, Encoding.GetEncoding("big5"));
                    GetFile.Remove(GetTabPage[i]);
                    GetFile.Add(GetTabPage[i], a);
                    GetTabPage[i].Text = Path.GetFileName(a);
                }
            }
        }

        private void 另存新檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string a = "";
            if (!GetFile.TryGetValue(tabControl1.SelectedTab, out a))
            {
                return;
            }
            saveFileDialog1.FileName = "";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName == "")
            {
                return;
            }
            a = saveFileDialog1.FileName;
            Scintilla b;
            GetScintilla.TryGetValue(tabControl1.SelectedTab, out b);
            File.WriteAllText(a, b.Text, Encoding.GetEncoding("big5"));
            GetFile.Remove(tabControl1.SelectedTab);
            GetFile.Add(tabControl1.SelectedTab, a);
            tabControl1.SelectedTab.Text = Path.GetFileName(a);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < GetTabPage.Count; i++)
            {
                string _file;
                Scintilla a;
                bool b;
                GetFile.TryGetValue(GetTabPage[i], out _file);
                GetScintilla.TryGetValue(GetTabPage[i], out a);
                ItSave.TryGetValue(GetTabPage[i], out b);
                if (File.Exists(_file))
                {
                    string c = File.ReadAllText(_file, Encoding.GetEncoding("big5"));
                    if (File.ReadAllText(_file, Encoding.GetEncoding("big5")) != a.Text)
                    {
                        if (b)
                        {
                            GetTabPage[i].Text = GetTabPage[i].Text + "*";
                            ItSave.Remove(GetTabPage[i]);
                            ItSave.Add(GetTabPage[i], false);
                        }
                    }
                    else
                    {
                        if (!b)
                        {
                            GetTabPage[i].Text = Path.GetFileName(_file);
                            ItSave.Remove(GetTabPage[i]);
                            ItSave.Add(GetTabPage[i], true);
                        }
                    }
                }
            }
            Scintilla d;
            GetScintilla.TryGetValue(tabControl1.SelectedTab, out d);
            if (d != null)
            {
                toolStripButton8.Enabled = d.UndoRedo.CanUndo;
                復原ToolStripMenuItem.Enabled = d.UndoRedo.CanUndo;
                復原ToolStripMenuItem1.Enabled = d.UndoRedo.CanUndo;
                toolStripButton9.Enabled = d.UndoRedo.CanRedo;
                取消復原ToolStripMenuItem.Enabled = d.UndoRedo.CanRedo;
                取消復原ToolStripMenuItem1.Enabled = d.UndoRedo.CanRedo;
                toolStripButton5.Enabled = d.Selection.Text != "";
                toolStripButton6.Enabled = d.Selection.Text != "";
                toolStripButton7.Enabled = d.Clipboard.CanPaste;
                剪下ToolStripMenuItem.Enabled = d.Selection.Text != "";
                複製ToolStripMenuItem.Enabled = d.Selection.Text != "";
                貼上ToolStripMenuItem.Enabled = d.Clipboard.CanPaste;
                剪下ToolStripMenuItem1.Enabled = d.Selection.Text != "";
                複製ToolStripMenuItem1.Enabled = d.Selection.Text != "";
                刪除ToolStripMenuItem.Enabled = d.Selection.Text != "";
                貼上ToolStripMenuItem1.Enabled = d.Clipboard.CanPaste;
                全選ToolStripMenuItem.Enabled = true;
                全選ToolStripMenuItem1.Enabled = true;
            }
            else
            {
                toolStripButton8.Enabled = false;
                復原ToolStripMenuItem.Enabled = false;
                復原ToolStripMenuItem1.Enabled = false;
                toolStripButton9.Enabled = false;
                取消復原ToolStripMenuItem.Enabled = false;
                取消復原ToolStripMenuItem1.Enabled = false;
                toolStripButton5.Enabled = false;
                toolStripButton6.Enabled = false;
                toolStripButton7.Enabled = false;
                剪下ToolStripMenuItem.Enabled = false;
                複製ToolStripMenuItem.Enabled = false;
                貼上ToolStripMenuItem.Enabled = false;
                剪下ToolStripMenuItem1.Enabled = false;
                複製ToolStripMenuItem1.Enabled = false;
                刪除ToolStripMenuItem.Enabled = false;
                貼上ToolStripMenuItem1.Enabled = false;
                全選ToolStripMenuItem.Enabled = false;
                全選ToolStripMenuItem1.Enabled = false;
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            bool a;
            string d;
            if (!GetFile.TryGetValue(tabControl1.SelectedTab, out d))
            {
                return;
            }
            ItSave.TryGetValue(tabControl1.SelectedTab, out a);
            if (!a)
            {
                switch (MessageBox.Show("要儲存嗎？", "", MessageBoxButtons.YesNoCancel))
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        {
                            string b;
                            Scintilla c;
                            if (!GetFile.TryGetValue(tabControl1.SelectedTab, out b))
                            {
                                return;
                            }
                            GetScintilla.TryGetValue(tabControl1.SelectedTab, out c);
                            if (File.Exists(b))
                            {
                                File.WriteAllText(b, c.Text, Encoding.GetEncoding("big5"));
                            }
                            else
                            {
                                saveFileDialog1.FileName = b;
                                saveFileDialog1.ShowDialog();
                                if (saveFileDialog1.FileName == "")
                                {
                                    return;
                                }
                                b = saveFileDialog1.FileName;
                                File.WriteAllText(b, c.Text, Encoding.GetEncoding("big5"));
                                GetFile.Remove(tabControl1.SelectedTab);
                                GetFile.Add(tabControl1.SelectedTab, b);
                                tabControl1.SelectedTab.Text = Path.GetFileName(b);
                            }
                            break;
                        }
                    case System.Windows.Forms.DialogResult.No:
                        {
                            break;
                        }
                    case System.Windows.Forms.DialogResult.Cancel:
                        {
                            return;
                        }
                }
            }
            tabControl1.Controls.Remove(tabControl1.SelectedTab);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < GetTabPage.Count; i++)
            {
                bool a;
                ItSave.TryGetValue(GetTabPage[i], out a);
                if (!a)
                {
                    switch (MessageBox.Show("要全部儲存嗎？", "", MessageBoxButtons.YesNoCancel))
                    {
                        case System.Windows.Forms.DialogResult.Yes:
                            {
                                for (int ii = 0; ii < GetTabPage.Count; ii++)
                                {
                                    string b;
                                    Scintilla c;
                                    GetFile.TryGetValue(GetTabPage[ii], out b);
                                    GetScintilla.TryGetValue(GetTabPage[ii], out c);
                                    if (File.Exists(b))
                                    {
                                        File.WriteAllText(b, c.Text, Encoding.GetEncoding("big5"));
                                    }
                                    else
                                    {
                                        saveFileDialog1.FileName = b;
                                        saveFileDialog1.ShowDialog();
                                        if (saveFileDialog1.FileName == "")
                                        {
                                            return;
                                        }
                                        b = saveFileDialog1.FileName;
                                        File.WriteAllText(b, c.Text, Encoding.GetEncoding("big5"));
                                        GetFile.Remove(GetTabPage[ii]);
                                        GetFile.Add(GetTabPage[ii], b);
                                        GetTabPage[ii].Text = Path.GetFileName(b);
                                    }
                                }
                                return;
                            }
                        case System.Windows.Forms.DialogResult.No:
                            {
                                for (int ii = 0; ii < GetTabPage.Count; ii++)
                                {
                                    tabControl1.Controls.Remove(GetTabPage[ii]);
                                }
                                return;
                            }
                        case System.Windows.Forms.DialogResult.Cancel:
                            {
                                e.Cancel = true;
                                return;
                            }
                    }
                }
            }

            for (int ii = 0; ii < GetTabPage.Count; ii++)
            {
                tabControl1.Controls.Remove(GetTabPage[ii]);
            }
        }

        private void ListBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                System.Text.StringBuilder copy_buffer = new System.Text.StringBuilder();
                foreach (object item in listBox1.SelectedItems)
                    copy_buffer.AppendLine(item.ToString());
                if (copy_buffer.Length > 0)
                    System.Windows.Forms.Clipboard.SetText(copy_buffer.ToString());
            }
        }

        private void 執行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string a;
            Scintilla b;
            if (!GetFile.TryGetValue(tabControl1.SelectedTab, out a))
            {
                return;
            }
            GetScintilla.TryGetValue(tabControl1.SelectedTab, out b);
            if (File.Exists(a))
            {
                listBox1.Items.Clear();
                File.WriteAllText(a, b.Text, Encoding.GetEncoding("big5"));
                CMD("cd \"" + Path.GetDirectoryName(a) + "\"");
                CMD(Path.GetPathRoot(a).Split(new Char[1] { '\\' })[0]);
                CMD("\"" + System.Environment.CurrentDirectory + "\\core\\bin\\gcc\" \"" + a + "\" -std=c99" + " -o " + "\"" + Path.GetFileNameWithoutExtension(a) + "\"");
                listBox1.Items.AddRange(CMDRead().ToArray());
                Process _process = new Process();
                _process.StartInfo = new ProcessStartInfo(Path.GetDirectoryName(a) + "\\" + Path.GetFileNameWithoutExtension(a) + ".exe");
                _process.StartInfo.UseShellExecute = false;
                _process.Start();
            }
            else
            {
                saveFileDialog1.FileName = a;
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName == "")
                {
                    return;
                }
                a = saveFileDialog1.FileName;
                File.WriteAllText(a, b.Text, Encoding.GetEncoding("big5"));
                GetFile.Remove(tabControl1.SelectedTab);
                GetFile.Add(tabControl1.SelectedTab, a);
                tabControl1.SelectedTab.Text = Path.GetFileName(a);
                CMD("cd \"" + Path.GetDirectoryName(a) + "\"");
                CMD(Path.GetPathRoot(a));
                CMD("\"" + System.Environment.CurrentDirectory + "\\core\\bin\\gcc\" \"" + a + "\" -std=C99" + " -o \"" + Path.GetFileNameWithoutExtension(a) + "\"");
                listBox1.Items.AddRange(CMDRead().ToArray());
                Process _process = new Process();
                _process.StartInfo = new ProcessStartInfo(Path.GetDirectoryName(a) + "\\" + Path.GetFileNameWithoutExtension(a) + ".exe");
                _process.StartInfo.UseShellExecute = false;
                _process.Start();
            }
        }

        private void 復原ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scintilla b;
            GetScintilla.TryGetValue(tabControl1.SelectedTab, out b);
            b.UndoRedo.Undo();
        }

        private void 取消復原ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scintilla b;
            GetScintilla.TryGetValue(tabControl1.SelectedTab, out b);
            b.UndoRedo.Redo();
        }

        private void 剪下ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scintilla b;
            GetScintilla.TryGetValue(tabControl1.SelectedTab, out b);
            b.Clipboard.Cut();
        }

        private void 複製ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scintilla b;
            GetScintilla.TryGetValue(tabControl1.SelectedTab, out b);
            b.Clipboard.Copy();
        }

        private void 貼上ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scintilla b;
            GetScintilla.TryGetValue(tabControl1.SelectedTab, out b);
            b.Clipboard.Paste();
        }

        private void 全選ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scintilla b;
            GetScintilla.TryGetValue(tabControl1.SelectedTab, out b);
            b.Selection.SelectAll();
        }

        private void 刪除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scintilla b;
            GetScintilla.TryGetValue(tabControl1.SelectedTab, out b);
            b.Selection.Clear();
        }

        private void 尋找與取代ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scintilla b;
            GetScintilla.TryGetValue(tabControl1.SelectedTab, out b);
            if (b != null)
            {
                b.FindReplace.FindText = tabControl1.SelectedTab.Text + ":尋找或取代";
                b.FindReplace.ShowFind();
            }
        }

        private void 移至ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scintilla b;
            GetScintilla.TryGetValue(tabControl1.SelectedTab, out b);
            if (b != null)
            {
                b.GoTo.ShowGoToDialog(tabControl1.SelectedTab.Text);
            }
        }
    }
}
