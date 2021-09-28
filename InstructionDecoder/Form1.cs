using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstructionDecoder
{
    public partial class Form1 : Form
    {

        CPU cpu = new CPU();
        public Form1()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string filePath = "";
            string fileContent = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;

                StreamReader sr = new StreamReader(filePath);
                fileContent = sr.ReadToEnd();  
            }
            string[] values = fileContent.Split('\n');

            foreach(string value in values)
            {
                listBox1.Items.Add(value.Trim());
            }
        }

        private void button2_Click(object sender , EventArgs e)
        {
            if (listBox1.Items.Count - 1 > 0)
            {
                if (listBox1.SelectedIndex == -1)
                    listBox1.SelectedIndex = 0;
                else if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
                    listBox1.SelectedIndex++;
                string temp = listBox1.SelectedItem.ToString();
                int instruction = Int32.Parse(temp);

                temp = cpu.DecodeInstruction(instruction);
                string[] values = temp.Split('\t');
                textBox1.Text = values[0];
                textBox2.Text = values[1];
                textBox3.Text = values[2];
                textBox4.Text = values[3];
            }
        }
    }
}
