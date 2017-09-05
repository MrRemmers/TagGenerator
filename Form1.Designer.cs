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
            this.cmb_Font = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grp_Font = new System.Windows.Forms.GroupBox();
            this.grp_Cutting = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1.SuspendLayout();
            this.tabPagePreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPageGcode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grp_Font.SuspendLayout();
            this.grp_Cutting.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtxt_Out
            // 
            this.rtxt_Out.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt_Out.Location = new System.Drawing.Point(3, 3);
            this.rtxt_Out.Name = "rtxt_Out";
            this.rtxt_Out.Size = new System.Drawing.Size(651, 553);
            this.rtxt_Out.TabIndex = 2;
            this.rtxt_Out.Text = "";
            // 
            // btn_Generate
            // 
            this.btn_Generate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Generate.Location = new System.Drawing.Point(27, 514);
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
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(665, 585);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPageEdit
            // 
            this.tabPageEdit.Location = new System.Drawing.Point(4, 22);
            this.tabPageEdit.Name = "tabPageEdit";
            this.tabPageEdit.Size = new System.Drawing.Size(657, 559);
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
            this.tabPagePreview.Size = new System.Drawing.Size(657, 559);
            this.tabPagePreview.TabIndex = 3;
            this.tabPagePreview.Text = "Preview";
            this.tabPagePreview.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(651, 553);
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
            this.tabPageGcode.Size = new System.Drawing.Size(657, 559);
            this.tabPageGcode.TabIndex = 1;
            this.tabPageGcode.Text = "GCode";
            this.tabPageGcode.UseVisualStyleBackColor = true;
            // 
            // txt_CharSpacing
            // 
            this.txt_CharSpacing.Location = new System.Drawing.Point(107, 45);
            this.txt_CharSpacing.Name = "txt_CharSpacing";
            this.txt_CharSpacing.Size = new System.Drawing.Size(100, 20);
            this.txt_CharSpacing.TabIndex = 5;
            this.txt_CharSpacing.TextChanged += new System.EventHandler(this.txt_Parameter_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Character Spacing";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "in.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Engraving Depth";
            // 
            // txt_EngravingDepth
            // 
            this.txt_EngravingDepth.Location = new System.Drawing.Point(139, 126);
            this.txt_EngravingDepth.Name = "txt_EngravingDepth";
            this.txt_EngravingDepth.Size = new System.Drawing.Size(92, 20);
            this.txt_EngravingDepth.TabIndex = 8;
            this.txt_EngravingDepth.TextChanged += new System.EventHandler(this.txt_Parameter_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "in.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Clearance Height";
            // 
            // txt_ClearanceHeight
            // 
            this.txt_ClearanceHeight.Location = new System.Drawing.Point(139, 44);
            this.txt_ClearanceHeight.Name = "txt_ClearanceHeight";
            this.txt_ClearanceHeight.Size = new System.Drawing.Size(92, 20);
            this.txt_ClearanceHeight.TabIndex = 11;
            this.txt_ClearanceHeight.TextChanged += new System.EventHandler(this.txt_Parameter_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(276, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "in.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Engraver Diameter";
            // 
            // txt_Diameter
            // 
            this.txt_Diameter.Location = new System.Drawing.Point(139, 3);
            this.txt_Diameter.Name = "txt_Diameter";
            this.txt_Diameter.Size = new System.Drawing.Size(92, 20);
            this.txt_Diameter.TabIndex = 14;
            this.txt_Diameter.TextChanged += new System.EventHandler(this.txt_Parameter_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(276, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "in.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Retract Height";
            // 
            // txt_Retract
            // 
            this.txt_Retract.Location = new System.Drawing.Point(139, 85);
            this.txt_Retract.Name = "txt_Retract";
            this.txt_Retract.Size = new System.Drawing.Size(92, 20);
            this.txt_Retract.TabIndex = 17;
            this.txt_Retract.TextChanged += new System.EventHandler(this.txt_Parameter_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(276, 164);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "in./min.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Plunge Feed Rate";
            // 
            // txt_Plunge
            // 
            this.txt_Plunge.Location = new System.Drawing.Point(139, 167);
            this.txt_Plunge.Name = "txt_Plunge";
            this.txt_Plunge.Size = new System.Drawing.Size(92, 20);
            this.txt_Plunge.TabIndex = 20;
            this.txt_Plunge.TextChanged += new System.EventHandler(this.txt_Parameter_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(276, 205);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "in./min.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 205);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Cutting Feed Rate";
            // 
            // txt_CutRate
            // 
            this.txt_CutRate.Location = new System.Drawing.Point(139, 208);
            this.txt_CutRate.Name = "txt_CutRate";
            this.txt_CutRate.Size = new System.Drawing.Size(92, 20);
            this.txt_CutRate.TabIndex = 23;
            this.txt_CutRate.TextChanged += new System.EventHandler(this.txt_Parameter_TextChanged);
            // 
            // cmb_Font
            // 
            this.cmb_Font.FormattingEnabled = true;
            this.cmb_Font.Location = new System.Drawing.Point(44, 19);
            this.cmb_Font.Name = "cmb_Font";
            this.cmb_Font.Size = new System.Drawing.Size(167, 21);
            this.cmb_Font.TabIndex = 0;
            this.cmb_Font.SelectionChangeCommitted += new System.EventHandler(this.cmb_Font_SelectionChangeCommitted);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Font";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grp_Font);
            this.splitContainer1.Panel1.Controls.Add(this.grp_Cutting);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1003, 585);
            this.splitContainer1.SplitterDistance = 334;
            this.splitContainer1.TabIndex = 27;
            // 
            // grp_Font
            // 
            this.grp_Font.Controls.Add(this.cmb_Font);
            this.grp_Font.Controls.Add(this.label15);
            this.grp_Font.Controls.Add(this.label1);
            this.grp_Font.Controls.Add(this.txt_CharSpacing);
            this.grp_Font.Controls.Add(this.label2);
            this.grp_Font.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp_Font.Location = new System.Drawing.Point(0, 0);
            this.grp_Font.Name = "grp_Font";
            this.grp_Font.Size = new System.Drawing.Size(334, 74);
            this.grp_Font.TabIndex = 28;
            this.grp_Font.TabStop = false;
            this.grp_Font.Text = "Font";
            // 
            // grp_Cutting
            // 
            this.grp_Cutting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_Cutting.Controls.Add(this.tableLayoutPanel1);
            this.grp_Cutting.Location = new System.Drawing.Point(3, 80);
            this.grp_Cutting.Name = "grp_Cutting";
            this.grp_Cutting.Size = new System.Drawing.Size(328, 271);
            this.grp_Cutting.TabIndex = 29;
            this.grp_Cutting.TabStop = false;
            this.grp_Cutting.Text = "Cutting Parameters";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.txt_Diameter, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label13, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_CutRate, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txt_ClearanceHeight, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label11, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txt_Plunge, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txt_Retract, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txt_EngravingDepth, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(322, 252);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 585);
            this.Controls.Add(this.btn_Generate);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Tag Engraver";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPagePreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPageGcode.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grp_Font.ResumeLayout(false);
            this.grp_Font.PerformLayout();
            this.grp_Cutting.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.ComboBox cmb_Font;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grp_Font;
        private System.Windows.Forms.GroupBox grp_Cutting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

