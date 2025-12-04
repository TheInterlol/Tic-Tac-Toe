using System.Runtime.CompilerServices;

namespace Tic_Tac_Toe
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            B00 = new Button();
            B01 = new Button();
            B02 = new Button();
            B12 = new Button();
            B11 = new Button();
            B10 = new Button();
            B22 = new Button();
            B21 = new Button();
            B20 = new Button();
            btnRestart = new Button();
            RBEasy = new RadioButton();
            RBHard = new RadioButton();
            btnZpet = new Button();
            SuspendLayout();
            // 
            // B00
            // 
            B00.BackColor = Color.Coral;
            B00.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            B00.Location = new Point(53, 34);
            B00.Name = "B00";
            B00.Size = new Size(63, 58);
            B00.TabIndex = 0;
            B00.UseVisualStyleBackColor = false;
            B00.Click += B00_Click;
            // 
            // B01
            // 
            B01.BackColor = Color.Coral;
            B01.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            B01.Location = new Point(137, 34);
            B01.Name = "B01";
            B01.Size = new Size(63, 58);
            B01.TabIndex = 1;
            B01.UseVisualStyleBackColor = false;
            // 
            // B02
            // 
            B02.BackColor = Color.Coral;
            B02.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            B02.Location = new Point(220, 34);
            B02.Name = "B02";
            B02.Size = new Size(63, 58);
            B02.TabIndex = 2;
            B02.UseVisualStyleBackColor = false;
            // 
            // B12
            // 
            B12.BackColor = Color.Coral;
            B12.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            B12.Location = new Point(220, 114);
            B12.Name = "B12";
            B12.Size = new Size(63, 58);
            B12.TabIndex = 5;
            B12.UseVisualStyleBackColor = false;
            // 
            // B11
            // 
            B11.BackColor = Color.Coral;
            B11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            B11.Location = new Point(137, 114);
            B11.Name = "B11";
            B11.Size = new Size(63, 58);
            B11.TabIndex = 4;
            B11.UseVisualStyleBackColor = false;
            // 
            // B10
            // 
            B10.BackColor = Color.Coral;
            B10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            B10.Location = new Point(53, 114);
            B10.Name = "B10";
            B10.Size = new Size(63, 58);
            B10.TabIndex = 3;
            B10.UseVisualStyleBackColor = false;
            // 
            // B22
            // 
            B22.BackColor = Color.Coral;
            B22.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            B22.Location = new Point(220, 200);
            B22.Name = "B22";
            B22.Size = new Size(63, 58);
            B22.TabIndex = 8;
            B22.UseVisualStyleBackColor = false;
            // 
            // B21
            // 
            B21.BackColor = Color.Coral;
            B21.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            B21.Location = new Point(137, 200);
            B21.Name = "B21";
            B21.Size = new Size(63, 58);
            B21.TabIndex = 7;
            B21.UseVisualStyleBackColor = false;
            // 
            // B20
            // 
            B20.BackColor = Color.Coral;
            B20.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            B20.Location = new Point(53, 200);
            B20.Name = "B20";
            B20.Size = new Size(63, 58);
            B20.TabIndex = 6;
            B20.UseVisualStyleBackColor = false;
            // 
            // btnRestart
            // 
            btnRestart.BackColor = Color.Coral;
            btnRestart.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnRestart.Location = new Point(53, 280);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(230, 41);
            btnRestart.TabIndex = 9;
            btnRestart.Text = "Restart";
            btnRestart.UseVisualStyleBackColor = false;
            btnRestart.Click += btnRestart_Click;
            // 
            // RBEasy
            // 
            RBEasy.AutoSize = true;
            RBEasy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            RBEasy.Location = new Point(53, 327);
            RBEasy.Name = "RBEasy";
            RBEasy.Size = new Size(91, 24);
            RBEasy.TabIndex = 10;
            RBEasy.TabStop = true;
            RBEasy.Text = "AI - Easy";
            RBEasy.UseVisualStyleBackColor = true;
            RBEasy.CheckedChanged += RBEasy_CheckedChanged;
            RBEasy.Click += RBEasy_Click;
            // 
            // RBHard
            // 
            RBHard.AutoSize = true;
            RBHard.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            RBHard.Location = new Point(53, 357);
            RBHard.Name = "RBHard";
            RBHard.Size = new Size(94, 24);
            RBHard.TabIndex = 11;
            RBHard.TabStop = true;
            RBHard.Text = "AI - Hard";
            RBHard.UseVisualStyleBackColor = true;
            RBHard.CheckedChanged += RBHard_CheckedChanged;
            RBHard.Click += RBHard_Click;
            // 
            // btnZpet
            // 
            btnZpet.BackColor = Color.Coral;
            btnZpet.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnZpet.ForeColor = Color.White;
            btnZpet.Location = new Point(150, 327);
            btnZpet.Name = "btnZpet";
            btnZpet.Size = new Size(133, 54);
            btnZpet.TabIndex = 12;
            btnZpet.Text = "Zpět";
            btnZpet.UseVisualStyleBackColor = false;
            btnZpet.Click += btnZpet_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 49, 66);
            ClientSize = new Size(342, 410);
            Controls.Add(btnZpet);
            Controls.Add(RBHard);
            Controls.Add(RBEasy);
            Controls.Add(btnRestart);
            Controls.Add(B22);
            Controls.Add(B21);
            Controls.Add(B20);
            Controls.Add(B12);
            Controls.Add(B11);
            Controls.Add(B10);
            Controls.Add(B02);
            Controls.Add(B01);
            Controls.Add(B00);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Piškvorky";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button B00;
        private Button B01;
        private Button B02;
        private Button B12;
        private Button B11;
        private Button B10;
        private Button B22;
        private Button B21;
        private Button B20;
        private Button btnRestart;
        private RadioButton RBEasy;
        private RadioButton RBHard;
        private Button btnZpet;

        
    }
}
