namespace GreenHouseVS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbxLog = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblWindows = new System.Windows.Forms.Label();
            this.lblShades = new System.Windows.Forms.Label();
            this.lblSprinklers = new System.Windows.Forms.Label();
            this.lblTemp = new System.Windows.Forms.Label();
            this.lblLight = new System.Windows.Forms.Label();
            this.lblHumidity = new System.Windows.Forms.Label();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Windows";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Shades";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sprinklers";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(117, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Temperature";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(120, 325);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Brightness";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(117, 362);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Humidity";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(277, 72);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lbxLog
            // 
            this.lbxLog.FormattingEnabled = true;
            this.lbxLog.Location = new System.Drawing.Point(445, 72);
            this.lbxLog.Name = "lbxLog";
            this.lbxLog.Size = new System.Drawing.Size(294, 342);
            this.lbxLog.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblWindows
            // 
            this.lblWindows.AutoSize = true;
            this.lblWindows.Location = new System.Drawing.Point(205, 122);
            this.lblWindows.Name = "lblWindows";
            this.lblWindows.Size = new System.Drawing.Size(0, 13);
            this.lblWindows.TabIndex = 9;
            // 
            // lblShades
            // 
            this.lblShades.AutoSize = true;
            this.lblShades.Location = new System.Drawing.Point(205, 164);
            this.lblShades.Name = "lblShades";
            this.lblShades.Size = new System.Drawing.Size(51, 13);
            this.lblShades.TabIndex = 10;
            this.lblShades.Text = "Windows";
            // 
            // lblSprinklers
            // 
            this.lblSprinklers.AutoSize = true;
            this.lblSprinklers.Location = new System.Drawing.Point(205, 198);
            this.lblSprinklers.Name = "lblSprinklers";
            this.lblSprinklers.Size = new System.Drawing.Size(51, 13);
            this.lblSprinklers.TabIndex = 11;
            this.lblSprinklers.Text = "Windows";
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Location = new System.Drawing.Point(205, 286);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(0, 13);
            this.lblTemp.TabIndex = 12;
            // 
            // lblLight
            // 
            this.lblLight.AutoSize = true;
            this.lblLight.Location = new System.Drawing.Point(205, 325);
            this.lblLight.Name = "lblLight";
            this.lblLight.Size = new System.Drawing.Size(0, 13);
            this.lblLight.TabIndex = 13;
            // 
            // lblHumidity
            // 
            this.lblHumidity.AutoSize = true;
            this.lblHumidity.Location = new System.Drawing.Point(205, 362);
            this.lblHumidity.Name = "lblHumidity";
            this.lblHumidity.Size = new System.Drawing.Size(0, 13);
            this.lblHumidity.TabIndex = 14;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(542, 35);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 15;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.lblHumidity);
            this.Controls.Add(this.lblLight);
            this.Controls.Add(this.lblTemp);
            this.Controls.Add(this.lblSprinklers);
            this.Controls.Add(this.lblShades);
            this.Controls.Add(this.lblWindows);
            this.Controls.Add(this.lbxLog);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox lbxLog;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblWindows;
        private System.Windows.Forms.Label lblShades;
        private System.Windows.Forms.Label lblSprinklers;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Label lblLight;
        private System.Windows.Forms.Label lblHumidity;
        private System.Windows.Forms.Button btnClearLog;
    }
}

