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

namespace GuiAssignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = Microsoft.VisualBasic.Interaction.InputBox("Please enter filename :", "File Name", "", 60, 90);
                label1.Text = label1.Text + fileName;

            if (fileName.isEmpty())
            {

            }
                StreamReader myFile;

            try
            {
                myFile = File.OpenText(fileName);
                string line = "";
                do
                {
                    line = myFile.ReadLine();
                    if (line != null)
                    {
                        richTextBox1.AppendText(Environment.NewLine + line);
                    }
                } while (line != null);
            }
            catch (IOException)
            {
                MessageBox.Show("File Not Found", "File Location Error",
               MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string countText;
            countText = Convert.ToString(richTextBox1.Text.Count());
            MessageBox.Show("The Character Count is:" +
           countText, "Characters", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.Copy();
            richTextBox2.Paste();
        }

        private void WriteBtn_Click(object sender, EventArgs e)
        {
            StreamWriter myFile;
            string fileName = Microsoft.VisualBasic.Interaction.InputBox("Please Name Your File:", "Enter File Name", "", 60, 90);
            myFile = File.CreateText(fileName);
            try
            {
                for (int i = 0; i < richTextBox2.Lines.Length; i++)
                {
                    myFile.WriteLine(richTextBox2.Lines[i]);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Error Writing to File", "File Write Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            myFile.Close();
            MessageBox.Show("File Creation " + fileName + " was successful!", "File Creation Success", MessageBoxButtons.OK,
           MessageBoxIcon.Information);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            int start = 0;
            int end = richTextBox2.Text.LastIndexOf(txtSearch.Text);
            while (start < end)
            {
                richTextBox2.Find(txtSearch.Text, start, richTextBox2.TextLength, RichTextBoxFinds.MatchCase);
                richTextBox2.SelectionBackColor = Color.GreenYellow;
                start = richTextBox2.Text.IndexOf(txtSearch.Text, start) + 1;

            }


        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fileOpeningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName =
      Microsoft.VisualBasic.Interaction.InputBox("Please enter filename :", "File Name", "", 60, 90);
            label1.Text = label1.Text + fileName;
            StreamReader myFile;
            try
            {
                myFile = File.OpenText(fileName);
                string line = "";
                do
                {
                    line = myFile.ReadLine();
                    if (line != null)
                    {
                        richTextBox1.AppendText(Environment.NewLine + line);
                    }
                } while (line != null);
            }
            catch (IOException)
            {
                MessageBox.Show("File Not Found", "File Location Error",
               MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

