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
            serialPort1.PortName = "COM4";
            serialPort1.Open();
            timer1.Start();

            lblWindows.Text = "Awaiting Input";
            lblShades.Text = "Awaiting Input";
            lblSprinklers.Text = "Awaiting Input";
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

                if(logOutput == "intervalHum")
                {
                    lblHumidity.Text = serialPort1.ReadLine();
                }

                if(logOutput == "intervalTemp")
                {
                    lblTemp.Text = serialPort1.ReadLine();
                }

                if(logOutput == "lightPrint")
                {
                    lblLight.Text = serialPort1.ReadLine();
                }
              
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!windows)
            {
                lblWindows.Text = "CLOSED";
                lbxLog.Items.Add("Windows are closed");
                message = "Windows overridden";
                lbxLog.Items.Add(message);
                serialPort1.WriteLine("Windows overridden");
                windows = true;
            }

            else
            {
                message = "Windows automatic";
                lbxLog.Items.Add(message);
                serialPort1.WriteLine("Windows automatic");
                windows = false;
            }
        }
    }
}
