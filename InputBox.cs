using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.ComponentModel.Design;

namespace TagGenerator
{
    public partial class InputBox : UserControl
    {
        [
        Category("Appearance"),
        Description("Describe what variable is being set")
        ]
        public string Label { get { return lbl_Name.Text; } set { lbl_Name.Text = value; } }
        [
        Category("Appearance"),
        Description("Unit of measure")
        ]
        public string Unit { get { return lbl_Unit.Text; } set { lbl_Unit.Text = value; } }
        [
        Category("Appearance"),
        Description("Variable text")
        ]
        public string Input { get { return txt_Input.Text; } set { txt_Input.Text = value; } }

        public InputBox()
        {          
            InitializeComponent();
        }

        public InputBox(string Label, string Input, string unit = "")
        {
            InitializeComponent();

            if (unit == "")
            {
                tableLayoutPanel1.ColumnCount = 2;
            }
            lbl_Name.Text = Label;
            txt_Input.Text = Input;
        }
        public new event EventHandler TextChanged;

        private void txt_Input_TextChanged(object sender, EventArgs e)
        {
            if(this.TextChanged != null)
            {
                this.TextChanged(this, e);
            }

            if (this.Tag != null)
            {
                if(txt_Input.Text != string.Empty)
                {
                    var type = Properties.Settings.Default[(string)Tag].GetType();
                    if (type == typeof(float))
                    {
                        Properties.Settings.Default[Tag.ToString()] = Convert.ToSingle(txt_Input.Text);
                    }
                    if (type == typeof(int))
                    {
                        //Properties.Settings.Default[(string)Tag] = Convert.ToInt16(txt_Input.Text);
                        Properties.Settings.Default[Tag.ToString()] = Convert.ToInt32(txt_Input.Text);
                    }
                }
               
            }
        }
    }
}
