using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Drawing.Drawing2D;

namespace TagGenerator
{
    public partial class MainForm : Form
    {
        #region "Variables"
        public string FontFile;// = AppDomain.CurrentDomain.BaseDirectory + @"cxf-fonts\" + Properties.Settings.Default.FontFileName;
        public JigTemplate Jig;

        public Dictionary<char, Character> cxfFont;
        Dictionary<string, string> comboFonts = new Dictionary<string, string>();

        public class NamePlate
        {
            public int numTag = 0;
            public List<PointF[]> Segments = new List<PointF[]>();
            public GraphicsPath path = new GraphicsPath();

        }
        public List<NamePlate> Tags = new List<NamePlate>();

        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //initTemplate();
            LoadTemplate();
            loadFonts();

            cxfFont = parse(FontFile);
            normalizeFont(ref cxfFont);
            //rearrangeFont(ref cxfFont);

            in_CharSpacing.Input = Convert.ToString(Properties.Settings.Default.CharSpacing);
            in_CharSpacing.Tag = nameof(Properties.Settings.Default.CharSpacing);
            inputBox_Diameter.Input = Convert.ToString(Properties.Settings.Default.EngraverDiameter);
            inputBox_Diameter.Tag = nameof(Properties.Settings.Default.EngraverDiameter);
            inputBox_Clearance.Input = Convert.ToString(Properties.Settings.Default.ClearanceHeight);
            inputBox_Clearance.Tag = nameof(Properties.Settings.Default.ClearanceHeight);
            inputBox_Retract.Input = Convert.ToString(Properties.Settings.Default.RetractHeight);
            inputBox_Clearance.Tag = nameof(Properties.Settings.Default.RetractHeight);
            inputBox_Depth.Input = Convert.ToString(Properties.Settings.Default.EngravingDepth);
            inputBox_Depth.Tag = nameof(Properties.Settings.Default.EngravingDepth);
            inputBox_Plunge.Input = Convert.ToString(Properties.Settings.Default.PlungeFeedRate);
            inputBox_Plunge.Tag = nameof(Properties.Settings.Default.PlungeFeedRate);
            inputBox_CutFeed.Input = Convert.ToString(Properties.Settings.Default.CuttingFeedRate);
            inputBox_CutFeed.Tag = nameof(Properties.Settings.Default.CuttingFeedRate);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        void initTemplate()
        {
            JigTemplate Jig = new JigTemplate();
            Jig.Perimeter.X = 0F;
            Jig.Perimeter.Y = 0F;
            Jig.Perimeter.Width = 12f;
            Jig.Perimeter.Height = 6f;
            Jig.Tag = new RectangleF[35];

            int k = 0;
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    //Jig.Tag[i + j] = new RectangleF();
                    Jig.Tag[k].X = j * 1.75F + 1.656F;
                    Jig.Tag[k].Y = i * 0.75F + 0.283F;

                    Jig.Tag[k].Width = 1F;
                    Jig.Tag[k].Height = 0.5F;
                    k++;
                }

            }
            XmlSerializer serializer = new XmlSerializer(typeof(JigTemplate));
            System.Xml.XmlTextWriter write = new System.Xml.XmlTextWriter(AppDomain.CurrentDomain.BaseDirectory + @"template\50A.xml", Encoding.UTF8);
            serializer.Serialize(write, Jig);
            write.Close();

        }

        void LoadTemplate()
        {
            string TemplateFile = AppDomain.CurrentDomain.BaseDirectory + @"template\" + Properties.Settings.Default.TemplateFile;
            //open the template file
            if (File.Exists(TemplateFile))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(JigTemplate));
                using (System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(TemplateFile))
                {
                    Jig = (JigTemplate)(serializer.Deserialize(reader));
                    var size = tabPage_input.Size;
                    float Xscaling = size.Width / Jig.Perimeter.Width;
                    float Yscaling = size.Height / Jig.Perimeter.Height;

                    foreach (var item in Jig.Tag)
                    {
                        var Text = new TextBox();
                        Text.Location = new Point(Convert.ToInt16((item.Location.X * Xscaling)),
                                                  Convert.ToInt16(size.Height - (item.Location.Y * Yscaling)));
                        Text.Size = new Size(Convert.ToInt16(item.Size.Width * Xscaling),
                                             Convert.ToInt16(item.Size.Height * Yscaling));
                        Text.Tag = item;
                        tabPage_input.Controls.Add(Text);
                    }
                }
            }
            else
            {
                MessageBox.Show("Template not Found");
            }


        }

        void loadFonts()
        {
            string[] FontFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"cxf-fonts\", "*.cxf");

            foreach (var item in FontFiles)
            {
                comboFonts.Add(Path.GetFileNameWithoutExtension(item), item);

            }
            cmb_Font.Items.AddRange(comboFonts.Keys.ToArray());

            if (comboFonts.TryGetValue(Properties.Settings.Default.FontFileName, out FontFile))
            {
                cmb_Font.SelectedItem = Properties.Settings.Default.FontFileName;
            }
            else
            {

            }

        }

        /// <summary>
        /// # This routine parses the .cxf font file and builds a font dictionary of
        /// line segment strokes required to cut each character.
        /// Arcs (only used in some fonts) are converted to a number of line
        /// segemnts based on the angular length of the arc. Since the idea of
        /// this font description is to make it support independant x and y scaling,
        /// we can not use native arcs in the gcode.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public Dictionary<char, Character> parse(string font_path)
        {
            Dictionary<char, Character> font = new Dictionary<char, Character>();

            int num_cmds = 0;
            int line_num = 0;
            int cmds_read = 0;
            string key = string.Empty;
            List<Line> stroke_list = new List<Line>();
            float xmax = 0;
            float ymax = 0;
            float[] coords = new float[4];
            float[] Arccoords = new float[5];
            Regex end_char = new Regex(@"^$");
            Regex new_cmd = new Regex(@"^\[(.*)\]\s(\d+)");
            Regex line_cmd = new Regex(@"^L (.*)");
            Regex arc_cmd = new Regex(@"^A (.*)");

            if (File.Exists(font_path))
            {
                StreamReader sr = new StreamReader(font_path, System.Text.Encoding.Default);
                // Open the file to read from.        
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    line_num += 1;
                    if (end_char.IsMatch(s) && (key != string.Empty))
                    {
                        try
                        {
                            char Keychar = Convert.ToChar(key);
                            List<Line> theStrokes = stroke_list;
                            font.Add(Keychar, new Character(theStrokes));
                            //#if (num_cmds != cmds_read):
                        }
                        catch
                        {

                        }
                    }

                    //new command
                    if (new_cmd.IsMatch(s))
                    {

                        key = new_cmd.Match(s).Groups[1].Value;
                        num_cmds = Convert.ToInt16(new_cmd.Match(s).Groups[2].Value);
                        cmds_read = 0;
                        stroke_list = new List<Line>();
                        xmax = 0;
                        ymax = 0;
                    }
                    //Line command
                    if (line_cmd.IsMatch(s))
                    {
                        cmds_read++;
                        string[] temp = line_cmd.Match(s).Groups[1].Value.Split(',');
                        for (int i = 0; i < temp.Length; i++)
                        {
                            coords[i] = float.Parse(temp[i]);
                        }
                        stroke_list.Add(new Line(coords));
                        xmax = Math.Max(xmax, coords[0]);
                        xmax = Math.Max(xmax, coords[2]);
                    }

                    if (arc_cmd.IsMatch(s))
                    {
                        cmds_read++;
                        string[] temp = arc_cmd.Match(s).Groups[1].Value.Split(',');
                        for (int i = 0; i < (temp.Length); i++)
                        {
                            Arccoords[i] = float.Parse(temp[i]);
                        }
                        //          xcenter, ycenter, radius, start_angle, end_angle = coords 
                        //  Arccoords [0]      [1]       [2]     [3]         [4]         
                        //    # since font defn has arcs as ccw, we need some font foo
                        if (Arccoords[4] < Arccoords[3])
                        {
                            Arccoords[3] -= 360;
                        }
                        //approximate arc with line seg every 20 degrees
                        int segs = (int)Math.Floor(((Arccoords[4] - Arccoords[3]) / 45)) + 1;
                        int angleincr = (int)((Arccoords[4] - Arccoords[3]) / segs);
                        float xstart = (float)Math.Cos(toRad(Arccoords[3])) * Arccoords[2] + Arccoords[0];
                        float ystart = (float)Math.Sin(toRad(Arccoords[3])) * Arccoords[2] + Arccoords[1];
                        float angle = Arccoords[3];

                        //    for i in range(segs):
                        for (int i = 0; i < segs; i++)
                        {
                            angle += angleincr;
                            //xend = cos(angle * pi / 180) * radius + xcenter
                            float xend = (float)Math.Cos(toRad(angle)) * Arccoords[2] + Arccoords[0];
                            //yend = sin(angle * pi / 180) * radius + ycenter
                            float yend = (float)Math.Sin(toRad(angle)) * Arccoords[2] + Arccoords[1];
                            //coords = [xstart, ystart, xend, yend]
                            coords[0] = xstart;
                            coords[1] = ystart;
                            coords[2] = xend;
                            coords[3] = yend;

                            stroke_list.Add(new Line(coords));
                            xmax = Math.Max(xmax, coords[0]);
                            xmax = Math.Max(xmax, coords[2]);

                            ymax = Math.Max(ymax, coords[1]);
                            ymax = Math.Max(ymax, coords[3]);
                            xstart = xend;
                            ystart = yend;
                        }
                    }
                }
                //}
            }
            return font;
        }

        /// <summary>
        /// /resize the font to a normalize 0 to 1
        /// </summary>
        /// <param name="font"></param>
        public void normalizeFont(ref Dictionary<char, Character> font)
        {
            float font_line_height = font.Aggregate((l, r) => l.Value.get_ymax() > r.Value.get_ymax() ? l : r).Value.get_ymax();
            float font_word_space = font.Aggregate((l, r) => l.Value.get_xmax() > r.Value.get_xmax() ? l : r).Value.get_xmax();

            foreach (var ch in font)
            {
                foreach (var st in ch.Value.stroke_list)
                {
                    st.xend = st.xend / font_word_space;
                    st.xstart = st.xstart / font_word_space;
                    st.xmax = st.xmax / font_word_space;

                    st.yend = st.yend / font_line_height;
                    st.ystart = st.ystart / font_line_height;
                    st.ymax = st.ymax / font_line_height;
                }
            }

        }

        public void rearrangeFont(ref Dictionary<char, Character> font)
        {
            foreach (var ch in font)
            {
                for (int i = 0; i < ch.Value.stroke_list.Count; i++)
                {
                    var tempList = ch.Value.stroke_list;
                    if ((i + 1) < ch.Value.stroke_list.Count)
                    {
                        var tempLine = tempList[i];
                        var nextLine = tempList[i + 1];

                        //var firstdist = calculateDistance(tempLine, nextLine);

                    }
                    else
                    {

                    }
                }
            }
        }

        static float toRad(float Deg)
        {
            return (float)(Deg * (Math.PI / 180));
        }

        public class Line
        {
            public float xstart, ystart, xend, yend;
            public float xmax;
            public float ymax;

            public Line() { }

            public Line(float[] coord)
            {
                xstart = coord[0];
                ystart = coord[1];
                xend = coord[2];
                yend = coord[3];

                xmax = Math.Max(xstart, xend);
                ymax = Math.Max(ystart, yend);

            }

        }

        public class Character
        {
            //private char key;
            public List<Line> stroke_list;

            public Character(List<Line> strokes)
            {
                //key = Key;
                stroke_list = strokes;
            }
            public float get_xmax()
            {
                try
                {
                    float CharXmax = 0;
                    foreach (var Line in stroke_list)
                    {
                        CharXmax = Math.Max(CharXmax, Line.xmax);
                    }
                    return CharXmax;
                }
                catch (Exception)
                {
                    // throw;
                    return 0;
                }
            }

            public float get_ymax()
            {
                try
                {
                    float CharYmax = 0;
                    foreach (var Line in stroke_list)
                    {
                        CharYmax = Math.Max(CharYmax, Line.ymax);
                    }
                    return CharYmax;
                }
                catch (Exception)
                {

                    //throw;
                    return 0;
                }
            }
        }

        public StringBuilder Gcode = new StringBuilder();

        public void CalculateStrokes(Control.ControlCollection controls)
        {
            int numTag = 0;
            Tags.Clear();
            PointF oldPoint = new PointF(-999990.0F, -999990.0F);
            float tracking = ((float)(Properties.Settings.Default.CharSpacing) / 100);

            foreach (TextBox item in controls.OfType<TextBox>())
            {
                NamePlate plate = new NamePlate();
                plate.numTag = numTag;
                RectangleF TagLoc = (RectangleF)item.Tag;

                //Scale starts out with text as large as possible
                float Scale = (TagLoc.Height - (float)(1 * Properties.Settings.Default.EngraverDiameter));
                //the X distance that the characters take
                float char_space = 0;
                //the width of the entire text box.
                float textWidth = 0;

                foreach (char letter in item.Text.ToCharArray())
                {
                    if (letter != ' ')
                    {
                        if (cxfFont[letter].get_xmax() == 0)
                        {
                            char_space += 0.25F;
                        }
                        char_space += cxfFont[letter].get_xmax();
                    }
                    else
                    {
                        char_space += 0.5F;
                    }
                }

                textWidth = tracking * Scale * char_space;

                if (textWidth > (TagLoc.Width - (Properties.Settings.Default.EngraverDiameter)))
                {
                    Scale = (TagLoc.Width - (Properties.Settings.Default.EngraverDiameter)) / (tracking * char_space);
                    textWidth = tracking * Scale * char_space;
                }

                //LeftJustified
                //float xoffset = TagLoc.X + (Properties.Settings.Default.EngraverDiameter / 2);
                //Centered
                float margin = (TagLoc.Width - textWidth);
                margin /= 2;
                float xoffset = TagLoc.X + margin;

                //justified along the bottom...
                //float yoffset = TagLoc.Y + (Properties.Settings.Default.EngraverDiameter / 2);
                //Centered?
                float yoffset = TagLoc.Y;// - (Properties.Settings.Default.EngraverDiameter/2);
                yoffset += ((TagLoc.Height - Scale) / 2);

                PointF[] points = new PointF[0];

                foreach (char letter in item.Text.ToCharArray())
                {
                    if (letter == ' ')
                    {
                        xoffset += tracking * Scale * 0.5F;
                        continue;
                    }
                    float char_X = Scale * cxfFont[letter].get_xmax();
                    if (char_X == 0)
                    {
                        char_X = (float)(Scale * 0.25);
                        xoffset += (float)(char_X * 0.125);
                    }

                    bool first_stroke = true;
                    bool onlyTwo = true;
                    foreach (var stroke in cxfFont[letter].stroke_list)
                    {
                        float dx = oldPoint.X - Scale * stroke.xstart;
                        float dy = oldPoint.Y - Scale * stroke.ystart;
                        float dist = (float)Math.Sqrt(dx * dx + dy * dy);

                        if ((dist < 0.001))
                        {
                            Array.Resize(ref points, points.Length + 1);
                            points[points.Length - 1].X = Scale * stroke.xend + xoffset;
                            points[points.Length - 1].Y = Scale * stroke.yend + yoffset;
                            onlyTwo = false;
                        }
                        else
                        {
                            if (!first_stroke && points.Length > 1)
                            {
                                plate.Segments.Add(points);
                            }
                            points = new PointF[2];
                            points[0].X = (Scale * stroke.xstart) + xoffset;
                            points[0].Y = (Scale * stroke.ystart) + yoffset;
                            points[1].X = (Scale * stroke.xend) + xoffset;
                            points[1].Y = (Scale * stroke.yend) + yoffset;
                        }
                        oldPoint.X = points.Last().X;
                        oldPoint.Y = points.Last().Y;
                        first_stroke = false;
                    }

                    if (onlyTwo)
                    {
                        plate.Segments.Add(points);
                    }
                    xoffset += tracking * char_X;
                }
                Tags.Add(plate);
                numTag++;
            }
        }

        public float calculateDistance(PointF first, PointF second)
        {
            float dx = first.X - second.X;
            float dy = first.X - second.Y;
            float dist = (float)Math.Sqrt(dx * dx + dy * dy);

            return dist;
        }

        public float calcutateDistance(Line first, Line second)
        {
            float dx = first.xend;

            float dist = dx;
            return dist;
        }

        public void CreateGcode()
        {
            Gcode.Clear();

            float ClearanceZ = Properties.Settings.Default.ClearanceHeight;
            float RetractZ = Properties.Settings.Default.RetractHeight;
            float Depth = -Properties.Settings.Default.EngravingDepth;

            float PlungeFeed = Properties.Settings.Default.PlungeFeedRate;
            float CuttingFeed = Properties.Settings.Default.CuttingFeedRate;

            //float oldx = -999990.0F;
            //float oldy = oldx;

            Gcode.AppendFormat(" Font File: {0}", System.IO.Path.GetFileName(FontFile)).AppendLine();
            Gcode.Append("G90 ");    //Absolute programming of XYZ
            Gcode.Append("G94 ");    //Units per minute feed mode.
            Gcode.Append("G17 ");    //Select X-Y plane
            Gcode.AppendLine();
            Gcode.AppendLine("G20 ");    //Program coordinates are inches

            //set spindle speed and rotate Clockwise.
            Gcode.AppendFormat("S{0} M03", Properties.Settings.Default.SpindleSpeed).AppendLine();

            IssueGCommand(ref Gcode, "clear", 0, 0, 0, 0);
            IssueGCommand(ref Gcode, "G00", 0, 0, ClearanceZ, 0);
            foreach (var tag in Tags)
            {
                //Gcode.AppendFormat(" Tag Number: {0}", tag.numTag).AppendLine();
                //Gcode.AppendLine(IssueGCommand("G00", 0, 0, ClearanceZ, 0));
                bool freshTag = true;
                foreach (var item in tag.Segments)
                {
                    bool newStroke = true;
                    foreach (var point in item)
                    {
                        if (freshTag)
                        {
                            IssueGCommand(ref Gcode, "G00", point.X, point.Y, ClearanceZ, 0);
                            IssueGCommand(ref Gcode,"G00", point.X, point.Y, RetractZ, 0);
                            IssueGCommand(ref Gcode, "G01", point.X, point.Y, Depth, PlungeFeed);
                            freshTag = false;
                            newStroke = false;
                        }
                        else if (newStroke)
                        {
                            IssueGCommand(ref Gcode, "G00", point.X, point.Y, RetractZ, 0);
                            IssueGCommand(ref Gcode, "G01", point.X, point.Y, Depth, PlungeFeed);
                            newStroke = false;
                        }
                        else
                        {
                           IssueGCommand(ref Gcode, "G01", point.X, point.Y, Depth, CuttingFeed);
                        }
                    }
                    if (item == tag.Segments.Last())
                    {
                        IssueGCommand(ref Gcode, "G00", Xold, Yold, RetractZ, 0);  
                    }
                           
                }
                IssueGCommand(ref Gcode, "G00", Xold, Yold, ClearanceZ, 0);
            }
            Gcode.AppendLine("M30");
            Gcode.AppendLine("%");
        }

        public String Gold = string.Empty;
        public float Xold = 0;
        public float Yold = 0;
        public float Zold = 0;
        public float Fold = 0;

        public void IssueGCommand(ref StringBuilder Builder, String Command, float X, float Y, float Z, float F)
        {
            String GcodeLine = string.Empty;
            if (Command != Gold)
            {
                GcodeLine = Command;
                if (X != Xold)
                {
                    GcodeLine += " X" + X.ToString("0.0###");
                }
                if (Y != Yold)
                {
                    GcodeLine += " Y" + Y.ToString("0.0###");
                }
                if (Z != Zold)
                {
                    GcodeLine += " Z" + Z.ToString("0.0###");
                }
                if (F != Fold && Command != "G00")
                {
                    GcodeLine += " F" + F.ToString("0.0###");
                }
            }
            else
            {
                if (X != Xold)
                {
                    GcodeLine += "X" + X.ToString("0.0###");
                }
                if (Y != Yold)
                {
                    GcodeLine += " Y" + Y.ToString("0.0###");
                }
                if (Z != Zold)
                {
                    GcodeLine += " Z" + Z.ToString("0.0###");
                }
                if (F != Fold && Gold != "G00")
                {
                    GcodeLine += " F" + F.ToString("0.0###");
                }
            }
            Gold = Command;
            Xold = X;
            Yold = Y;
            Zold = Z;
            Fold = F;
            if (Command == "clear")
            {
                return;
            }

            if (GcodeLine != string.Empty)
            {
                Builder.AppendLine(GcodeLine);
            }
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            richTextBox_Gcode.Clear();
            CalculateStrokes(tabPage_input.Controls);
            pictureBox_Preview.Invalidate();
            CreateGcode();
            richTextBox_Gcode.Text = Gcode.ToString();
            tabControl1.SelectedTab = tabPage_preview;
        }

        private void pictureBox_Preview_Paint(object sender, PaintEventArgs g)
        {
            g.Graphics.Clear(Color.White);
            if (Jig != null)
            {
                Pen thick = new Pen(Color.Black, 1.5F);
                float Xscale = pictureBox_Preview.Width / Jig.Perimeter.Width;
                float Yscale = pictureBox_Preview.Height / Jig.Perimeter.Height;
                Xscale = Math.Min(Xscale, Yscale);
                Yscale = Xscale;

                g.Graphics.ScaleTransform(1F, -1F);
                g.Graphics.TranslateTransform(0F, ((float)(0.25 * Yscale * Jig.Perimeter.Height)) - pictureBox_Preview.Height);

                Rectangle Out = new Rectangle(0, 0, (int)(Xscale * Jig.Perimeter.Width), (int)(Yscale * Jig.Perimeter.Height));
                g.Graphics.DrawRectangle(Pens.Blue, Out);

                foreach (var item in Jig.Tag)
                {
                    Rectangle Bound = new Rectangle((int)(Xscale * item.X), (int)(Yscale * item.Y), (int)(Xscale * item.Width), (int)(Yscale * item.Height));
                    g.Graphics.DrawRectangle(Pens.Black, Bound);
                }

                if (Tags.Count > 0)
                {
                    foreach (var item in Tags)
                    {
                        foreach (PointF[] ln in item.Segments)
                        {
                            var j = ln.Count();
                            PointF[] sSeg = new PointF[j];

                            for (int i = 0; i < j; i++)
                            {
                                sSeg[i].X = ln[i].X * Xscale;
                                sSeg[i].Y = ln[i].Y * Yscale;
                                g.Graphics.FillRectangle(Brushes.Blue, new RectangleF(sSeg[i].X, sSeg[i].Y, 1, 1));
                            }
                            g.Graphics.DrawLines(thick, sSeg);
                        }
                    }
                    thick.Dispose();
                }
            }
            g.Dispose();
        }

        private void cmb_Font_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboFonts.TryGetValue((string)cmb_Font.SelectedItem, out FontFile);
            cxfFont = parse(FontFile);
            normalizeFont(ref cxfFont);
            Properties.Settings.Default.FontFileName = FontFile;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            //var msgClear = new MessageBox(MessageBoxButtons.YesNo, "You Sure?");
            DialogResult result;

            result = MessageBox.Show("You sure?", "You're about to delete all text", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                foreach (TextBox item in tabPage_input.Controls.OfType<TextBox>())
                {
                    item.Text = string.Empty;
                }
                pictureBox_Preview.Invalidate();
                richTextBox_Gcode.Clear();
            }
        }
    }
}
