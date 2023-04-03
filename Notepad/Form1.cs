using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notepad
{
    public partial class Form1 : Form
    {
        private OpenFileDialog openFile;
        private SaveFileDialog saveFile;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       public void newNote()
        {
            if (!string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Save first please!");
            }
            else
            {
                richTextBox1.Text = string.Empty;
                Text = "untitled";
            }
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newNote();
        }

        public void openNote()
        {
            openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFile.FileName);
                Text = openFile.FileName;
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openNote();
        }

        public void saveNote()
        {
            if (!string.IsNullOrEmpty(richTextBox1.Text))
            {
                saveFile = new SaveFileDialog();
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFile.FileName, richTextBox1.Text);
                }
                else
                {
                    MessageBox.Show("File empty error!");
                }
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveNote();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveNote();
        }

        public void closeNote()
        {
            if (!string.IsNullOrEmpty(richTextBox1.Text))
            {
                saveFile = new SaveFileDialog();
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFile.FileName, richTextBox1.Text);
                }
                else
                {
                    Close();
                }
            }
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeNote();
        }
    }
}
