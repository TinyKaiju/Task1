
namespace GADE6122
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.MemoPlayerInfo = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnAttack = new System.Windows.Forms.Button();
            this.MemoEnemyInfo = new System.Windows.Forms.RichTextBox();
            this.CmbEnemyList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(352, 546);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(379, 528);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // MemoPlayerInfo
            // 
            this.MemoPlayerInfo.BackColor = System.Drawing.Color.IndianRed;
            this.MemoPlayerInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MemoPlayerInfo.Location = new System.Drawing.Point(443, 36);
            this.MemoPlayerInfo.Name = "MemoPlayerInfo";
            this.MemoPlayerInfo.Size = new System.Drawing.Size(331, 90);
            this.MemoPlayerInfo.TabIndex = 2;
            this.MemoPlayerInfo.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCoral;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.BtnAttack);
            this.panel1.Controls.Add(this.MemoEnemyInfo);
            this.panel1.Controls.Add(this.CmbEnemyList);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(443, 141);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 311);
            this.panel1.TabIndex = 3;
            // 
            // BtnAttack
            // 
            this.BtnAttack.BackColor = System.Drawing.Color.IndianRed;
            this.BtnAttack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAttack.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnAttack.Location = new System.Drawing.Point(13, 173);
            this.BtnAttack.Name = "BtnAttack";
            this.BtnAttack.Size = new System.Drawing.Size(302, 29);
            this.BtnAttack.TabIndex = 5;
            this.BtnAttack.Text = "Attack";
            this.BtnAttack.UseVisualStyleBackColor = false;
            // 
            // MemoEnemyInfo
            // 
            this.MemoEnemyInfo.BackColor = System.Drawing.Color.IndianRed;
            this.MemoEnemyInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MemoEnemyInfo.Location = new System.Drawing.Point(13, 61);
            this.MemoEnemyInfo.Name = "MemoEnemyInfo";
            this.MemoEnemyInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.MemoEnemyInfo.Size = new System.Drawing.Size(302, 105);
            this.MemoEnemyInfo.TabIndex = 4;
            this.MemoEnemyInfo.Text = "";
            // 
            // CmbEnemyList
            // 
            this.CmbEnemyList.FormattingEnabled = true;
            this.CmbEnemyList.Location = new System.Drawing.Point(13, 32);
            this.CmbEnemyList.Name = "CmbEnemyList";
            this.CmbEnemyList.Size = new System.Drawing.Size(302, 23);
            this.CmbEnemyList.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Attacking";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.IndianRed;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(13, 209);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(302, 82);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.IndianRed;
            this.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUp.Font = new System.Drawing.Font("Unispace", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUp.Location = new System.Drawing.Point(561, 463);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(76, 50);
            this.btnUp.TabIndex = 4;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = false;
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.Color.IndianRed;
            this.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDown.Font = new System.Drawing.Font("Unispace", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDown.Location = new System.Drawing.Point(561, 519);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(76, 50);
            this.btnDown.TabIndex = 5;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = false;
            // 
            // btnLeft
            // 
            this.btnLeft.BackColor = System.Drawing.Color.IndianRed;
            this.btnLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLeft.Font = new System.Drawing.Font("Unispace", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLeft.Location = new System.Drawing.Point(479, 490);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(76, 50);
            this.btnLeft.TabIndex = 6;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = false;
            // 
            // btnRight
            // 
            this.btnRight.BackColor = System.Drawing.Color.IndianRed;
            this.btnRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRight.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRight.FlatAppearance.BorderSize = 0;
            this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRight.Font = new System.Drawing.Font("Unispace", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRight.Location = new System.Drawing.Point(643, 490);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(76, 50);
            this.btnRight.TabIndex = 7;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 581);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MemoPlayerInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox MemoPlayerInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnAttack;
        private System.Windows.Forms.RichTextBox MemoEnemyInfo;
        private System.Windows.Forms.ComboBox CmbEnemyList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
    }
}

