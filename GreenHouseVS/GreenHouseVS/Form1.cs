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

                bool isTemp = float.TryParse(logOutput, out _);

                //this is not a good way to do this, find something else, index out of bounds errors
                //occur in some cases

               /* if (logOutput[logOutput.Length - 1] == 't')
                {
                    //doing - 1 in .Length because the string always has 1 more character than the index
                    //since we start counting at 0 for the index and length returns the number of chars in the string
                    logOutput = logOutput.Remove(logOutput.Length - 1, 1);
                    lblTemp.Text = logOutput;
                }

                bool isHumidity = float.TryParse(logOutput, out _);

                if (logOutput[logOutput.Length - 1] == 'h')
                {
                    logOutput = logOutput.Remove(logOutput.Length - 1, 1);
                    lblHumidity.Text = logOutput;
                }

                bool isLight = int.TryParse(logOutput, out _);

                if (isLight)
                {
                    lblLight.Text = logOutput;
                } */
               
                
                    if (logOutput == "OPEN")
                    {
                        lblWindows.Text = logOutput;
                        lbxLog.Items.Add("Windows are open");
                    }

                    else if(logOutput == "CLOSED")
                    {
                        lblWindows.Text = logOutput;
                        lbxLog.Items.Add("Windows are closed");
                    }

                    else if(logOutput == "RAISED")
                    {
                        lblShades.Text = logOutput;
                        lbxLog.Items.Add("Shades are raised");
                    }

                    else if(logOutput == "LOWERED")
                    {
                        lblShades.Text = logOutput;
                        lbxLog.Items.Add("Shades are lowered");
                    }

                    else if(logOutput == "ON")
                    {
                    lblSprinklers.Text = logOutput;
                    lbxLog.Items.Add("Sprinklers are on");
                    }
                    
                    else if (logOutput == "OFF")
                    {
                    lblSprinklers.Text = logOutput;
                    lbxLog.Items.Add("Sprinklers are off");
                    }
                
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            lbxLog.Items.Clear();
        }
    }
}
