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
                listBoxInputStream.Items.Add(value.Trim());
            }
        }

        private void button2_Click(object sender , EventArgs e)
        {
            if (listBoxInputStream.Items.Count - 1 > 0)
            {
                if (listBoxInputStream.SelectedIndex == -1)
                    listBoxInputStream.SelectedIndex = 0;
                else if (listBoxInputStream.SelectedIndex < listBoxInputStream.Items.Count - 1)
                    listBoxInputStream.SelectedIndex++;
                string temp = listBoxInputStream.SelectedItem.ToString();
                int instruction = Int32.Parse(temp);

                temp = cpu.DecodeInstruction(instruction);
                string[] values = temp.Split('\t');
                textBoxProgramCounter.Text = values[0];
                textBoxHex.Text = values[1];
                textBoxInstruction.Text = values[2];
                textBoxRegisters.Text = values[3];
            }
        }
    }
}
