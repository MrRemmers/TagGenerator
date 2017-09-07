namespace TagGenerator
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tab_Parameters = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmb_Font = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel_Cutting = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btn_Transmit = new System.Windows.Forms.Button();
            this.btn_Generate = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_input = new System.Windows.Forms.TabPage();
            this.tabPage_preview = new System.Windows.Forms.TabPage();
            this.pictureBox_Preview = new System.Windows.Forms.PictureBox();
            this.tabPage_Gcode = new System.Windows.Forms.TabPage();
            this.richTextBox_Gcode = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox_SerialPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBox_BaudRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboBox_DataBit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.comboBox_Parity = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.comboBox_StopBits = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.comboBox_FlowControl = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.in_CharSpacing = new TagGenerator.InputBox();
            this.inputBox_Diameter = new TagGenerator.InputBox();
            this.inputBox_Clearance = new TagGenerator.InputBox();
            this.inputBox_Retract = new TagGenerator.InputBox();
            this.inputBox_Depth = new TagGenerator.InputBox();
            this.inputBox_CutFeed = new TagGenerator.InputBox();
            this.inputBox_Plunge = new TagGenerator.InputBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tab_Parameters.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel_Cutting.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_preview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Preview)).BeginInit();
            this.tabPage_Gcode.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tab_Parameters);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(934, 541);
            this.splitContainer1.SplitterDistance = 257;
            this.splitContainer1.TabIndex = 0;
            // 
            // tab_Parameters
            // 
            this.tab_Parameters.Controls.Add(this.tabPage1);
            this.tab_Parameters.Controls.Add(this.tabPage2);
            this.tab_Parameters.Controls.Add(this.tabPage3);
            this.tab_Parameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_Parameters.Location = new System.Drawing.Point(0, 0);
            this.tab_Parameters.Name = "tab_Parameters";
            this.tab_Parameters.SelectedIndex = 0;
            this.tab_Parameters.Size = new System.Drawing.Size(257, 541);
            this.tab_Parameters.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(249, 515);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Text";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.in_CharSpacing);
            this.flowLayoutPanel1.Controls.Add(this.btn_Clear);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(243, 509);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmb_Font);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 34);
            this.panel1.TabIndex = 0;
            // 
            // cmb_Font
            // 
            this.cmb_Font.FormattingEnabled = true;
            this.cmb_Font.Location = new System.Drawing.Point(60, 5);
            this.cmb_Font.Name = "cmb_Font";
            this.cmb_Font.Size = new System.Drawing.Size(135, 21);
            this.cmb_Font.TabIndex = 27;
            this.cmb_Font.SelectionChangeCommitted += new System.EventHandler(this.cmb_Font_SelectionChangeCommitted);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "Font";
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(3, 83);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(230, 40);
            this.btn_Clear.TabIndex = 2;
            this.btn_Clear.Text = "Clear Text";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.flowLayoutPanel_Cutting);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(249, 515);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cutting";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel_Cutting
            // 
            this.flowLayoutPanel_Cutting.Controls.Add(this.inputBox_Diameter);
            this.flowLayoutPanel_Cutting.Controls.Add(this.inputBox_Clearance);
            this.flowLayoutPanel_Cutting.Controls.Add(this.inputBox_Retract);
            this.flowLayoutPanel_Cutting.Controls.Add(this.inputBox_Depth);
            this.flowLayoutPanel_Cutting.Controls.Add(this.inputBox_CutFeed);
            this.flowLayoutPanel_Cutting.Controls.Add(this.inputBox_Plunge);
            this.flowLayoutPanel_Cutting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_Cutting.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel_Cutting.Name = "flowLayoutPanel_Cutting";
            this.flowLayoutPanel_Cutting.Size = new System.Drawing.Size(243, 509);
            this.flowLayoutPanel_Cutting.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.flowLayoutPanel2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(249, 515);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Com.";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btn_Transmit);
            this.splitContainer2.Panel1.Controls.Add(this.btn_Generate);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(673, 541);
            this.splitContainer2.SplitterDistance = 110;
            this.splitContainer2.TabIndex = 0;
            // 
            // btn_Transmit
            // 
            this.btn_Transmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Transmit.Location = new System.Drawing.Point(574, 7);
            this.btn_Transmit.Name = "btn_Transmit";
            this.btn_Transmit.Size = new System.Drawing.Size(96, 61);
            this.btn_Transmit.TabIndex = 1;
            this.btn_Transmit.Text = "Transmit";
            this.btn_Transmit.UseVisualStyleBackColor = true;
            this.btn_Transmit.Click += new System.EventHandler(this.btn_Transmit_Click);
            // 
            // btn_Generate
            // 
            this.btn_Generate.Location = new System.Drawing.Point(3, 7);
            this.btn_Generate.Name = "btn_Generate";
            this.btn_Generate.Size = new System.Drawing.Size(96, 61);
            this.btn_Generate.TabIndex = 0;
            this.btn_Generate.Text = "Generate";
            this.btn_Generate.UseVisualStyleBackColor = true;
            this.btn_Generate.Click += new System.EventHandler(this.btn_Generate_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage_input);
            this.tabControl1.Controls.Add(this.tabPage_preview);
            this.tabControl1.Controls.Add(this.tabPage_Gcode);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(10, 10);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(673, 427);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_input
            // 
            this.tabPage_input.Location = new System.Drawing.Point(37, 4);
            this.tabPage_input.Name = "tabPage_input";
            this.tabPage_input.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_input.Size = new System.Drawing.Size(632, 419);
            this.tabPage_input.TabIndex = 0;
            this.tabPage_input.Text = "Text";
            this.tabPage_input.UseVisualStyleBackColor = true;
            // 
            // tabPage_preview
            // 
            this.tabPage_preview.Controls.Add(this.pictureBox_Preview);
            this.tabPage_preview.Location = new System.Drawing.Point(37, 4);
            this.tabPage_preview.Name = "tabPage_preview";
            this.tabPage_preview.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_preview.Size = new System.Drawing.Size(632, 419);
            this.tabPage_preview.TabIndex = 1;
            this.tabPage_preview.Text = "Preview";
            this.tabPage_preview.UseVisualStyleBackColor = true;
            // 
            // pictureBox_Preview
            // 
            this.pictureBox_Preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_Preview.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_Preview.Name = "pictureBox_Preview";
            this.pictureBox_Preview.Size = new System.Drawing.Size(626, 413);
            this.pictureBox_Preview.TabIndex = 0;
            this.pictureBox_Preview.TabStop = false;
            this.pictureBox_Preview.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Preview_Paint);
            // 
            // tabPage_Gcode
            // 
            this.tabPage_Gcode.Controls.Add(this.richTextBox_Gcode);
            this.tabPage_Gcode.Location = new System.Drawing.Point(37, 4);
            this.tabPage_Gcode.Name = "tabPage_Gcode";
            this.tabPage_Gcode.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Gcode.Size = new System.Drawing.Size(632, 419);
            this.tabPage_Gcode.TabIndex = 2;
            this.tabPage_Gcode.Text = "Gcode";
            this.tabPage_Gcode.UseVisualStyleBackColor = true;
            // 
            // richTextBox_Gcode
            // 
            this.richTextBox_Gcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_Gcode.Location = new System.Drawing.Point(3, 3);
            this.richTextBox_Gcode.Name = "richTextBox_Gcode";
            this.richTextBox_Gcode.Size = new System.Drawing.Size(626, 413);
            this.richTextBox_Gcode.TabIndex = 0;
            this.richTextBox_Gcode.Text = "";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.panel2);
            this.flowLayoutPanel2.Controls.Add(this.panel3);
            this.flowLayoutPanel2.Controls.Add(this.panel4);
            this.flowLayoutPanel2.Controls.Add(this.panel5);
            this.flowLayoutPanel2.Controls.Add(this.panel6);
            this.flowLayoutPanel2.Controls.Add(this.panel7);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(243, 509);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBox_SerialPorts);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 34);
            this.panel2.TabIndex = 1;
            // 
            // comboBox_SerialPorts
            // 
            this.comboBox_SerialPorts.FormattingEnabled = true;
            this.comboBox_SerialPorts.Location = new System.Drawing.Point(92, 5);
            this.comboBox_SerialPorts.Name = "comboBox_SerialPorts";
            this.comboBox_SerialPorts.Size = new System.Drawing.Size(135, 21);
            this.comboBox_SerialPorts.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "COM port";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comboBox_BaudRate);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(3, 43);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(230, 34);
            this.panel3.TabIndex = 29;
            // 
            // comboBox_BaudRate
            // 
            this.comboBox_BaudRate.FormattingEnabled = true;
            this.comboBox_BaudRate.Items.AddRange(new object[] {
            "110",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000",
            "256000"});
            this.comboBox_BaudRate.Location = new System.Drawing.Point(92, 5);
            this.comboBox_BaudRate.Name = "comboBox_BaudRate";
            this.comboBox_BaudRate.Size = new System.Drawing.Size(135, 21);
            this.comboBox_BaudRate.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Baud Rate";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.comboBox_DataBit);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(3, 83);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(230, 34);
            this.panel4.TabIndex = 30;
            // 
            // comboBox_DataBit
            // 
            this.comboBox_DataBit.FormattingEnabled = true;
            this.comboBox_DataBit.Items.AddRange(new object[] {
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comboBox_DataBit.Location = new System.Drawing.Point(92, 5);
            this.comboBox_DataBit.Name = "comboBox_DataBit";
            this.comboBox_DataBit.Size = new System.Drawing.Size(135, 21);
            this.comboBox_DataBit.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Data Bit";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.comboBox_Parity);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(3, 123);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(230, 34);
            this.panel5.TabIndex = 31;
            // 
            // comboBox_Parity
            // 
            this.comboBox_Parity.FormattingEnabled = true;
            this.comboBox_Parity.Items.AddRange(new object[] {
            "Even",
            "Odd",
            "None",
            "Mark",
            "Space"});
            this.comboBox_Parity.Location = new System.Drawing.Point(92, 5);
            this.comboBox_Parity.Name = "comboBox_Parity";
            this.comboBox_Parity.Size = new System.Drawing.Size(135, 21);
            this.comboBox_Parity.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Parity";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.comboBox_StopBits);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Location = new System.Drawing.Point(3, 163);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(230, 34);
            this.panel6.TabIndex = 32;
            // 
            // comboBox_StopBits
            // 
            this.comboBox_StopBits.FormattingEnabled = true;
            this.comboBox_StopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.comboBox_StopBits.Location = new System.Drawing.Point(92, 5);
            this.comboBox_StopBits.Name = "comboBox_StopBits";
            this.comboBox_StopBits.Size = new System.Drawing.Size(135, 21);
            this.comboBox_StopBits.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Stop Bits";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.comboBox_FlowControl);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Location = new System.Drawing.Point(3, 203);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(230, 34);
            this.panel7.TabIndex = 33;
            // 
            // comboBox_FlowControl
            // 
            this.comboBox_FlowControl.FormattingEnabled = true;
            this.comboBox_FlowControl.Items.AddRange(new object[] {
            "Xon/Xoff",
            "Hardware",
            "None"});
            this.comboBox_FlowControl.Location = new System.Drawing.Point(92, 5);
            this.comboBox_FlowControl.Name = "comboBox_FlowControl";
            this.comboBox_FlowControl.Size = new System.Drawing.Size(135, 21);
            this.comboBox_FlowControl.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Flow Control";
            // 
            // in_CharSpacing
            // 
            this.in_CharSpacing.Dock = System.Windows.Forms.DockStyle.Top;
            this.in_CharSpacing.Input = "";
            this.in_CharSpacing.Label = "Character Spacing";
            this.in_CharSpacing.Location = new System.Drawing.Point(3, 43);
            this.in_CharSpacing.Name = "in_CharSpacing";
            this.in_CharSpacing.Size = new System.Drawing.Size(230, 34);
            this.in_CharSpacing.TabIndex = 1;
            this.in_CharSpacing.Unit = "%";
            // 
            // inputBox_Diameter
            // 
            this.inputBox_Diameter.Input = "";
            this.inputBox_Diameter.Label = "Engraver Diameter";
            this.inputBox_Diameter.Location = new System.Drawing.Point(3, 3);
            this.inputBox_Diameter.Name = "inputBox_Diameter";
            this.inputBox_Diameter.Size = new System.Drawing.Size(230, 30);
            this.inputBox_Diameter.TabIndex = 0;
            this.inputBox_Diameter.Unit = "in.";
            // 
            // inputBox_Clearance
            // 
            this.inputBox_Clearance.Input = "";
            this.inputBox_Clearance.Label = "Clearance Height";
            this.inputBox_Clearance.Location = new System.Drawing.Point(3, 39);
            this.inputBox_Clearance.Name = "inputBox_Clearance";
            this.inputBox_Clearance.Size = new System.Drawing.Size(230, 30);
            this.inputBox_Clearance.TabIndex = 1;
            this.inputBox_Clearance.Unit = "in.";
            // 
            // inputBox_Retract
            // 
            this.inputBox_Retract.Input = "";
            this.inputBox_Retract.Label = "Retract Height";
            this.inputBox_Retract.Location = new System.Drawing.Point(3, 75);
            this.inputBox_Retract.Name = "inputBox_Retract";
            this.inputBox_Retract.Size = new System.Drawing.Size(230, 30);
            this.inputBox_Retract.TabIndex = 2;
            this.inputBox_Retract.Unit = "in.";
            // 
            // inputBox_Depth
            // 
            this.inputBox_Depth.Input = "";
            this.inputBox_Depth.Label = "Engraving Depth";
            this.inputBox_Depth.Location = new System.Drawing.Point(3, 111);
            this.inputBox_Depth.Name = "inputBox_Depth";
            this.inputBox_Depth.Size = new System.Drawing.Size(230, 30);
            this.inputBox_Depth.TabIndex = 3;
            this.inputBox_Depth.Unit = "in.";
            // 
            // inputBox_CutFeed
            // 
            this.inputBox_CutFeed.Input = "";
            this.inputBox_CutFeed.Label = "Cutting Feed Rate";
            this.inputBox_CutFeed.Location = new System.Drawing.Point(3, 147);
            this.inputBox_CutFeed.Name = "inputBox_CutFeed";
            this.inputBox_CutFeed.Size = new System.Drawing.Size(230, 30);
            this.inputBox_CutFeed.TabIndex = 4;
            this.inputBox_CutFeed.Unit = "in./min";
            // 
            // inputBox_Plunge
            // 
            this.inputBox_Plunge.Input = "";
            this.inputBox_Plunge.Label = "Plunge Feed Rate";
            this.inputBox_Plunge.Location = new System.Drawing.Point(3, 183);
            this.inputBox_Plunge.Name = "inputBox_Plunge";
            this.inputBox_Plunge.Size = new System.Drawing.Size(230, 30);
            this.inputBox_Plunge.TabIndex = 5;
            this.inputBox_Plunge.Unit = "in./min";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 541);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "RickFont";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tab_Parameters.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.flowLayoutPanel_Cutting.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_preview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Preview)).EndInit();
            this.tabPage_Gcode.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tab_Parameters;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btn_Transmit;
        private System.Windows.Forms.Button btn_Generate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmb_Font;
        private System.Windows.Forms.Label label15;
        private InputBox in_CharSpacing;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Cutting;
        private InputBox inputBox_Diameter;
        private InputBox inputBox_Clearance;
        private InputBox inputBox_Retract;
        private InputBox inputBox_Depth;
        private InputBox inputBox_CutFeed;
        private InputBox inputBox_Plunge;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_input;
        private System.Windows.Forms.TabPage tabPage_preview;
        private System.Windows.Forms.TabPage tabPage_Gcode;
        private System.Windows.Forms.PictureBox pictureBox_Preview;
        private System.Windows.Forms.RichTextBox richTextBox_Gcode;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox_SerialPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBox_BaudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox comboBox_DataBit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox comboBox_Parity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox comboBox_StopBits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ComboBox comboBox_FlowControl;
        private System.Windows.Forms.Label label6;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}