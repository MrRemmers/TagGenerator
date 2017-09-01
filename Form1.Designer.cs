namespace TagGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rtxt_Out = new System.Windows.Forms.RichTextBox();
            this.btn_Generate = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageEdit = new System.Windows.Forms.TabPage();
            this.tabPagePreview = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPageGcode = new System.Windows.Forms.TabPage();
            this.txt_CharSpacing = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_EngravingDepth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_ClearanceHeight = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Diameter = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Retract = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_Plunge = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_CutRate = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPagePreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPageGcode.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtxt_Out
            // 
            this.rtxt_Out.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt_Out.Location = new System.Drawing.Point(3, 3);
            this.rtxt_Out.Name = "rtxt_Out";
            this.rtxt_Out.Size = new System.Drawing.Size(715, 553);
            this.rtxt_Out.TabIndex = 2;
            this.rtxt_Out.Text = "";
            // 
            // btn_Generate
            // 
            this.btn_Generate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Generate.Location = new System.Drawing.Point(12, 529);
            this.btn_Generate.Name = "btn_Generate";
            this.btn_Generate.Size = new System.Drawing.Size(108, 52);
            this.btn_Generate.TabIndex = 3;
            this.btn_Generate.Text = "Generate";
            this.btn_Generate.UseVisualStyleBackColor = true;
            this.btn_Generate.Click += new System.EventHandler(this.btn_Generate_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageEdit);
            this.tabControl1.Controls.Add(this.tabPagePreview);
            this.tabControl1.Controls.Add(this.tabPageGcode);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControl1.Location = new System.Drawing.Point(274, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(729, 585);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPageEdit
            // 
            this.tabPageEdit.Location = new System.Drawing.Point(4, 22);
            this.tabPageEdit.Name = "tabPageEdit";
            this.tabPageEdit.Size = new System.Drawing.Size(721, 559);
            this.tabPageEdit.TabIndex = 2;
            this.tabPageEdit.Text = "Edit";
            this.tabPageEdit.UseVisualStyleBackColor = true;
            // 
            // tabPagePreview
            // 
            this.tabPagePreview.Controls.Add(this.pictureBox1);
            this.tabPagePreview.Location = new System.Drawing.Point(4, 22);
            this.tabPagePreview.Name = "tabPagePreview";
            this.tabPagePreview.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePreview.Size = new System.Drawing.Size(721, 559);
            this.tabPagePreview.TabIndex = 3;
            this.tabPagePreview.Text = "Preview";
            this.tabPagePreview.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(715, 553);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // tabPageGcode
            // 
            this.tabPageGcode.Controls.Add(this.rtxt_Out);
            this.tabPageGcode.Location = new System.Drawing.Point(4, 22);
            this.tabPageGcode.Name = "tabPageGcode";
            this.tabPageGcode.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGcode.Size = new System.Drawing.Size(721, 559);
            this.tabPageGcode.TabIndex = 1;
            this.tabPageGcode.Text = "GCode";
            this.tabPageGcode.UseVisualStyleBackColor = true;
            // 
            // txt_CharSpacing
            // 
            this.txt_CharSpacing.Location = new System.Drawing.Point(110, 81);
            this.txt_CharSpacing.Name = "txt_CharSpacing";
            this.txt_CharSpacing.Size = new System.Drawing.Size(100, 20);
            this.txt_CharSpacing.TabIndex = 5;
            this.txt_CharSpacing.TextChanged += new System.EventHandler(this.txt_Parameter_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Character Spacing";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "in.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Engraving Depth";
            // 
            // txt_EngravingDepth
            // 
            this.txt_EngravingDepth.Location = new System.Drawing.Point(110, 264);
            this.txt_EngravingDepth.Name = "txt_EngravingDepth";
            this.txt_EngravingDepth.Size = new System.Drawing.Size(100, 20);
            this.txt_EngravingDepth.TabIndex = 8;
            this.txt_EngravingDepth.TextChanged += new System.EventHandler(this.txt_Parameter_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(216, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "in.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Clearance Height";
            // 
            // txt_ClearanceHeight
            // 
            this.txt_ClearanceHeight.Location = new System.Drawing.Point(110, 212);
            this.txt_ClearanceHeight.Name = "txt_ClearanceHeight";
            this.txt_ClearanceHeight.Size = new System.Drawing.Size(100, 20);
            this.txt_ClearanceHeight.TabIndex = 11;
            this.txt_ClearanceHeight.TextChanged += new System.EventHandler(this.txt_Parameter_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(216, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "in.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Engraver Diameter";
            // 
            // txt_Diameter
            // 
            this.txt_Diameter.Location = new System.Drawing.Point(110, 186);
            this.txt_Diameter.Name = "txt_Diameter";
            this.txt_Diameter.Size = new System.Drawing.Size(100, 20);
            this.txt_Diameter.TabIndex = 14;
            this.txt_Diameter.TextChanged += new System.EventHandler(this.txt_Parameter_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(216, 241);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "in.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 241);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Retract Height";
            // 
            // txt_Retract
            // 
            this.txt_Retract.Location = new System.Drawing.Point(110, 238);
            this.txt_Retract.Name = "txt_Retract";
            this.txt_Retract.Size = new System.Drawing.Size(100, 20);
            this.txt_Retract.TabIndex = 17;
            this.txt_Retract.TextChanged += new System.EventHandler(this.txt_Parameter_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(216, 319);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "in./min.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 319);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Plunge Feed Rate";
            // 
            // txt_Plunge
            // 
            this.txt_Plunge.Location = new System.Drawing.Point(110, 316);
            this.txt_Plunge.Name = "txt_Plunge";
            this.txt_Plunge.Size = new System.Drawing.Size(100, 20);
            this.txt_Plunge.TabIndex = 20;
            this.txt_Plunge.TextChanged += new System.EventHandler(this.txt_Parameter_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(216, 345);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "in./min.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 345);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Cutting Feed Rate";
            // 
            // txt_CutRate
            // 
            this.txt_CutRate.Location = new System.Drawing.Point(110, 342);
            this.txt_CutRate.Name = "txt_CutRate";
            this.txt_CutRate.Size = new System.Drawing.Size(100, 20);
            this.txt_CutRate.TabIndex = 23;
            this.txt_CutRate.TextChanged += new System.EventHandler(this.txt_Parameter_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 585);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txt_CutRate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txt_Plunge);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_Retract);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_Diameter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_ClearanceHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_EngravingDepth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_CharSpacing);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_Generate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Tag Engraver";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPagePreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPageGcode.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox rtxt_Out;
        private System.Windows.Forms.Button btn_Generate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageGcode;
        private System.Windows.Forms.TabPage tabPageEdit;
        private System.Windows.Forms.TabPage tabPagePreview;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_CharSpacing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_EngravingDepth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_ClearanceHeight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Diameter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Retract;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_Plunge;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_CutRate;
    }
}

