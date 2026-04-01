namespace homework1
{
    partial class FrmBMI
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
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.grpOutput = new System.Windows.Forms.GroupBox();
            this.lblBmiResult = new System.Windows.Forms.Label();
            this.lblBMI = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpInput.SuspendLayout();
            this.grpOutput.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInput
            // 
            this.grpInput.BackColor = System.Drawing.Color.White;
            this.grpInput.Controls.Add(this.btnRun);
            this.grpInput.Controls.Add(this.txtWeight);
            this.grpInput.Controls.Add(this.txtHeight);
            this.grpInput.Controls.Add(this.lblWeight);
            this.grpInput.Controls.Add(this.lblHeight);
            this.grpInput.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInput.ForeColor = System.Drawing.Color.DarkCyan;
            this.grpInput.Location = new System.Drawing.Point(0, 31);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(396, 122);
            this.grpInput.TabIndex = 0;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "輸入";
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.White;
            this.btnRun.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnRun.Location = new System.Drawing.Point(308, 29);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(71, 69);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "計算";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // txtWeight
            // 
            this.txtWeight.BackColor = System.Drawing.Color.White;
            this.txtWeight.Location = new System.Drawing.Point(99, 65);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(189, 33);
            this.txtWeight.TabIndex = 4;
            // 
            // txtHeight
            // 
            this.txtHeight.BackColor = System.Drawing.Color.White;
            this.txtHeight.Location = new System.Drawing.Point(99, 26);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(189, 33);
            this.txtHeight.TabIndex = 3;
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.ForeColor = System.Drawing.Color.Black;
            this.lblWeight.Location = new System.Drawing.Point(6, 62);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(82, 24);
            this.lblWeight.TabIndex = 1;
            this.lblWeight.Text = "體重(kg)";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.ForeColor = System.Drawing.Color.Black;
            this.lblHeight.Location = new System.Drawing.Point(6, 29);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(87, 24);
            this.lblHeight.TabIndex = 0;
            this.lblHeight.Text = "身高(cm)";
            // 
            // grpOutput
            // 
            this.grpOutput.BackColor = System.Drawing.Color.White;
            this.grpOutput.Controls.Add(this.lblBmiResult);
            this.grpOutput.Controls.Add(this.lblBMI);
            this.grpOutput.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOutput.ForeColor = System.Drawing.Color.DarkCyan;
            this.grpOutput.Location = new System.Drawing.Point(0, 151);
            this.grpOutput.Name = "grpOutput";
            this.grpOutput.Size = new System.Drawing.Size(396, 87);
            this.grpOutput.TabIndex = 1;
            this.grpOutput.TabStop = false;
            this.grpOutput.Text = "計算結果";
            // 
            // lblBmiResult
            // 
            this.lblBmiResult.BackColor = System.Drawing.Color.White;
            this.lblBmiResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBmiResult.ForeColor = System.Drawing.Color.Azure;
            this.lblBmiResult.Location = new System.Drawing.Point(188, 40);
            this.lblBmiResult.Name = "lblBmiResult";
            this.lblBmiResult.Size = new System.Drawing.Size(177, 23);
            this.lblBmiResult.TabIndex = 3;
            this.lblBmiResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBMI
            // 
            this.lblBMI.AutoSize = true;
            this.lblBMI.ForeColor = System.Drawing.Color.Black;
            this.lblBMI.Location = new System.Drawing.Point(11, 40);
            this.lblBMI.Name = "lblBMI";
            this.lblBMI.Size = new System.Drawing.Size(171, 24);
            this.lblBMI.TabIndex = 2;
            this.lblBMI.Text = "身體質量指數(BMI)";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.DarkCyan;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 225);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(391, 50);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(45, 45);
            this.toolStripStatusLabel1.Text = "BMI";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(100, 45);
            this.toolStripStatusLabel2.Text = "Reference";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // FrmBMI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(391, 275);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpOutput);
            this.Controls.Add(this.grpInput);
            this.Name = "FrmBMI";
            this.Text = "BMI計算機";
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.grpOutput.ResumeLayout(false);
            this.grpOutput.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.GroupBox grpOutput;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblBMI;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label lblBmiResult;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}

