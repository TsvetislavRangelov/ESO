using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenHouseVS
{
    public partial class Form1 : Form
    {
        string message;
        bool windows = false;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 9600;
            serialPort1.PortName = "COM3";
            serialPort1.Open();
            timer1.Start();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialPort1.Close();
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(serialPort1.BytesToRead > 0)
            {
                string logOutput = serialPort1.ReadLine();

                logOutput = logOutput.Trim();

            }
        }
    }
}
