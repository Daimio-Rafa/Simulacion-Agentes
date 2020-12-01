namespace Visual
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
            this.PbEnviroment1 = new System.Windows.Forms.PictureBox();
            this.PbEnviroment2 = new System.Windows.Forms.PictureBox();
            this.LblResult1 = new System.Windows.Forms.Label();
            this.LblResult2 = new System.Windows.Forms.Label();
            this.BtnContinue = new System.Windows.Forms.Button();
            this.NudSize2 = new System.Windows.Forms.NumericUpDown();
            this.LblSize2 = new System.Windows.Forms.Label();
            this.LblSize1 = new System.Windows.Forms.Label();
            this.LblDirt = new System.Windows.Forms.Label();
            this.LblBlocking = new System.Windows.Forms.Label();
            this.LblChildren = new System.Windows.Forms.Label();
            this.NudSize1 = new System.Windows.Forms.NumericUpDown();
            this.NudDirt = new System.Windows.Forms.NumericUpDown();
            this.NudBlocking = new System.Windows.Forms.NumericUpDown();
            this.NudChildren = new System.Windows.Forms.NumericUpDown();
            this.BtnStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PbEnviroment1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbEnviroment2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSize2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSize1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudDirt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudBlocking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudChildren)).BeginInit();
            this.SuspendLayout();
            // 
            // PbEnviroment1
            // 
            this.PbEnviroment1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbEnviroment1.Location = new System.Drawing.Point(12, 12);
            this.PbEnviroment1.Name = "PbEnviroment1";
            this.PbEnviroment1.Size = new System.Drawing.Size(600, 600);
            this.PbEnviroment1.TabIndex = 0;
            this.PbEnviroment1.TabStop = false;
            this.PbEnviroment1.Paint += new System.Windows.Forms.PaintEventHandler(this.PbEnviroment1_Paint);
            // 
            // PbEnviroment2
            // 
            this.PbEnviroment2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbEnviroment2.Location = new System.Drawing.Point(634, 12);
            this.PbEnviroment2.Name = "PbEnviroment2";
            this.PbEnviroment2.Size = new System.Drawing.Size(600, 600);
            this.PbEnviroment2.TabIndex = 1;
            this.PbEnviroment2.TabStop = false;
            this.PbEnviroment2.Paint += new System.Windows.Forms.PaintEventHandler(this.PbEnviroment2_Paint);
            // 
            // LblResult1
            // 
            this.LblResult1.AutoSize = true;
            this.LblResult1.Location = new System.Drawing.Point(1256, 12);
            this.LblResult1.Name = "LblResult1";
            this.LblResult1.Size = new System.Drawing.Size(116, 17);
            this.LblResult1.TabIndex = 2;
            this.LblResult1.Text = "Agente Proactivo";
            // 
            // LblResult2
            // 
            this.LblResult2.AutoSize = true;
            this.LblResult2.Location = new System.Drawing.Point(1576, 12);
            this.LblResult2.Name = "LblResult2";
            this.LblResult2.Size = new System.Drawing.Size(112, 17);
            this.LblResult2.TabIndex = 3;
            this.LblResult2.Text = "Agente Reactivo";
            // 
            // BtnContinue
            // 
            this.BtnContinue.Location = new System.Drawing.Point(1087, 726);
            this.BtnContinue.Name = "BtnContinue";
            this.BtnContinue.Size = new System.Drawing.Size(147, 51);
            this.BtnContinue.TabIndex = 28;
            this.BtnContinue.Text = "Continuar";
            this.BtnContinue.UseVisualStyleBackColor = true;
            this.BtnContinue.Click += new System.EventHandler(this.BtnContinue_Click);
            // 
            // NudSize2
            // 
            this.NudSize2.Location = new System.Drawing.Point(698, 862);
            this.NudSize2.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NudSize2.Name = "NudSize2";
            this.NudSize2.Size = new System.Drawing.Size(147, 22);
            this.NudSize2.TabIndex = 25;
            this.NudSize2.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // LblSize2
            // 
            this.LblSize2.AutoSize = true;
            this.LblSize2.Location = new System.Drawing.Point(695, 842);
            this.LblSize2.Name = "LblSize2";
            this.LblSize2.Size = new System.Drawing.Size(130, 17);
            this.LblSize2.TabIndex = 24;
            this.LblSize2.Text = "Largo del ambiente";
            // 
            // LblSize1
            // 
            this.LblSize1.AutoSize = true;
            this.LblSize1.Location = new System.Drawing.Point(695, 726);
            this.LblSize1.Name = "LblSize1";
            this.LblSize1.Size = new System.Drawing.Size(133, 17);
            this.LblSize1.TabIndex = 23;
            this.LblSize1.Text = "Ancho del ambiente";
            // 
            // LblDirt
            // 
            this.LblDirt.AutoSize = true;
            this.LblDirt.Location = new System.Drawing.Point(336, 726);
            this.LblDirt.Name = "LblDirt";
            this.LblDirt.Size = new System.Drawing.Size(147, 17);
            this.LblDirt.TabIndex = 22;
            this.LblDirt.Text = "Cantidad de Suciedad";
            // 
            // LblBlocking
            // 
            this.LblBlocking.AutoSize = true;
            this.LblBlocking.Location = new System.Drawing.Point(27, 842);
            this.LblBlocking.Name = "LblBlocking";
            this.LblBlocking.Size = new System.Drawing.Size(156, 17);
            this.LblBlocking.TabIndex = 21;
            this.LblBlocking.Text = "Cantidad de obstaculos";
            // 
            // LblChildren
            // 
            this.LblChildren.AutoSize = true;
            this.LblChildren.Location = new System.Drawing.Point(27, 726);
            this.LblChildren.Name = "LblChildren";
            this.LblChildren.Size = new System.Drawing.Size(122, 17);
            this.LblChildren.TabIndex = 20;
            this.LblChildren.Text = "Cantidad de niños";
            // 
            // NudSize1
            // 
            this.NudSize1.Location = new System.Drawing.Point(698, 746);
            this.NudSize1.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NudSize1.Name = "NudSize1";
            this.NudSize1.Size = new System.Drawing.Size(147, 22);
            this.NudSize1.TabIndex = 19;
            this.NudSize1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // NudDirt
            // 
            this.NudDirt.Location = new System.Drawing.Point(339, 746);
            this.NudDirt.Name = "NudDirt";
            this.NudDirt.Size = new System.Drawing.Size(147, 22);
            this.NudDirt.TabIndex = 18;
            // 
            // NudBlocking
            // 
            this.NudBlocking.Location = new System.Drawing.Point(30, 862);
            this.NudBlocking.Name = "NudBlocking";
            this.NudBlocking.Size = new System.Drawing.Size(147, 22);
            this.NudBlocking.TabIndex = 17;
            // 
            // NudChildren
            // 
            this.NudChildren.Location = new System.Drawing.Point(30, 746);
            this.NudChildren.Name = "NudChildren";
            this.NudChildren.Size = new System.Drawing.Size(147, 22);
            this.NudChildren.TabIndex = 16;
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(1087, 832);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(147, 52);
            this.BtnStart.TabIndex = 15;
            this.BtnStart.Text = "Comenzar";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.BtnContinue);
            this.Controls.Add(this.NudSize2);
            this.Controls.Add(this.LblSize2);
            this.Controls.Add(this.LblSize1);
            this.Controls.Add(this.LblDirt);
            this.Controls.Add(this.LblBlocking);
            this.Controls.Add(this.LblChildren);
            this.Controls.Add(this.NudSize1);
            this.Controls.Add(this.NudDirt);
            this.Controls.Add(this.NudBlocking);
            this.Controls.Add(this.NudChildren);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.LblResult2);
            this.Controls.Add(this.LblResult1);
            this.Controls.Add(this.PbEnviroment2);
            this.Controls.Add(this.PbEnviroment1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PbEnviroment1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbEnviroment2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSize2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSize1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudDirt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudBlocking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudChildren)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PbEnviroment1;
        private System.Windows.Forms.PictureBox PbEnviroment2;
        private System.Windows.Forms.Label LblResult1;
        private System.Windows.Forms.Label LblResult2;
        private System.Windows.Forms.Button BtnContinue;
        private System.Windows.Forms.NumericUpDown NudSize2;
        private System.Windows.Forms.Label LblSize2;
        private System.Windows.Forms.Label LblSize1;
        private System.Windows.Forms.Label LblDirt;
        private System.Windows.Forms.Label LblBlocking;
        private System.Windows.Forms.Label LblChildren;
        private System.Windows.Forms.NumericUpDown NudSize1;
        private System.Windows.Forms.NumericUpDown NudDirt;
        private System.Windows.Forms.NumericUpDown NudBlocking;
        private System.Windows.Forms.NumericUpDown NudChildren;
        private System.Windows.Forms.Button BtnStart;
    }
}

