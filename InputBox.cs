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

        //class MyDesigner : System.Windows.Forms.Design.con
        //{
        //    public override void Initialize(IComponent comp)
        //    {
        //        base.Initialize(comp);
        //        var uc = (UserControl1)comp;
        //        EnableDesignMode(uc.Employees, "Employees");
        //    }
        //}

    }
}
