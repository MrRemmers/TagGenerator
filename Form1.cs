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
using System.Drawing.Text;

namespace TagGenerator
{
    public partial class Form1 : Form
    {
        #region "Variables"
        public string FontFile = AppDomain.CurrentDomain.BaseDirectory + @"cxf-fonts\" + Properties.Settings.Default.FontFileName;
        public JigTemplate Jig;

        public Dictionary<char, Character> cxfFont;

        public class NamePlate
        {
            public int numTag = 0;
            public List<PointF[]> Segments = new List<PointF[]>();
            public GraphicsPath path = new GraphicsPath();

        }
        public List<NamePlate> Tags = new List<NamePlate>();

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //uncomment to re-create the xml file used as template.
            //initTemplate();
            LoadTemplate();

            cxfFont = parse(FontFile);
            normalizeFont(ref cxfFont);

            txt_CharSpacing.Text = Convert.ToString( Properties.Settings.Default.CharSpacing);
            txt_Diameter.Text = Convert.ToString(Properties.Settings.Default.EngraverDiameter);
            txt_ClearanceHeight.Text = Convert.ToString(Properties.Settings.Default.ClearanceHeight);
            txt_Retract.Text = Convert.ToString(Properties.Settings.Default.RetractHeight);
            txt_EngravingDepth.Text = Convert.ToString(Properties.Settings.Default.EngravingDepth);
            txt_Plunge.Text = Convert.ToString(Properties.Settings.Default.PlungeFeedRate);
            txt_CutRate.Text = Convert.ToString(Properties.Settings.Default.CuttingFeedRate);
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
                    var size = tabPageEdit.Size;
                    float Xscaling = size.Width / Jig.Perimeter.Width;
                    float Yscaling = size.Height / Jig.Perimeter.Height;

                    foreach (var item in Jig.Tag)
                    {
                        //flowLayoutPanel_Text.Controls.Add(new TextBox());
                        var Text = new TextBox();
                        Text.Location = new Point(Convert.ToInt16((item.Location.X * Xscaling)),
                                                  Convert.ToInt16(size.Height - (item.Location.Y * Yscaling)));
                        Text.Size = new Size(Convert.ToInt16(item.Size.Width * Xscaling),
                                             Convert.ToInt16(item.Size.Height * Yscaling));
                        Text.Tag = item;
                        tabPageEdit.Controls.Add(Text);
                    }
                }
            }
            else
            {
                MessageBox.Show("Template not Found");
            }


        }

        #region "Gcode"
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
                        char Keychar = Convert.ToChar(key);
                        List<Line> theStrokes = stroke_list;
                        font.Add(Keychar, new Character(theStrokes));
                        //#if (num_cmds != cmds_read):
                        //# print "(warning: discrepancy in number of commands %s, line %s, %s != %s )" % (fontfile, line_num, num_cmds, cmds_read)                                               
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
            // float font_word_space = cxfFont.Aggregate((l, r) => l.Value.get_xmax() > r.Value.get_xmax() ? l : r).Value.get_xmax();            
            // float font_char_space = font_word_space * (Properties.Settings.Default.CharSpacing / 100);

            foreach (TextBox item in controls.OfType<TextBox>())
            {
                NamePlate plate = new NamePlate();
                plate.numTag = numTag;
                RectangleF TagLoc = (RectangleF)item.Tag;

                float YScale = (TagLoc.Height - (Properties.Settings.Default.EngraverDiameter));
                float char_space = (float)(1 * YScale);
                float word_space = ((float)(Properties.Settings.Default.CharSpacing) / 100) * char_space;

                float textWidth = word_space * item.TextLength;
                if(textWidth > (TagLoc.Width - (Properties.Settings.Default.EngraverDiameter / 2)))
                {
                    char_space = (TagLoc.Width - (Properties.Settings.Default.EngraverDiameter / 2)) / item.TextLength;
                    word_space = ((float)(Properties.Settings.Default.CharSpacing) / 100) * char_space;
                    YScale = char_space; // 1/aspect_ratio 
                }               
                float XScale = char_space; //(TagLoc.Width - (Properties.Settings.Default.EngraverDiameter / 2));

                //LeftJustified
                //float xoffset = TagLoc.X + (Properties.Settings.Default.EngraverDiameter / 2);
                //Centered
                float margin = (TagLoc.Width + Properties.Settings.Default.EngraverDiameter);
                margin = Math.Abs(margin - (word_space * item.TextLength));
                margin /= 2;
                float xoffset = TagLoc.X + margin;

                //justified along the bottom...
                //float yoffset = TagLoc.Y + (Properties.Settings.Default.EngraverDiameter / 2);
                //Centered?
                float yoffset = TagLoc.Y;
                yoffset += ((TagLoc.Height - YScale) / 2);

                PointF[] points = new PointF[0];

                foreach (char letter in item.Text.ToCharArray())
                {       
                    if (letter == ' ')
                    {
                        xoffset += XScale * word_space;
                        continue;
                    }
                        bool first_stroke = true;
                        bool onlyTwo = true;
                        foreach (var stroke in cxfFont[letter].stroke_list)
                        {
                            float dx = oldPoint.X - XScale * stroke.xstart;
                            float dy = oldPoint.Y - YScale * stroke.ystart;
                            float dist = (float)Math.Sqrt(dx * dx + dy * dy);

                            if ((dist < 0.001))
                            {
                                Array.Resize(ref points, points.Length + 1);
                                points[points.Length - 1].X = XScale * stroke.xend + xoffset;
                                points[points.Length - 1].Y = YScale * stroke.yend + yoffset;
                                onlyTwo = false;
                            }
                            else
                            {
                                if (!first_stroke && points.Length > 1)
                                {
                                    plate.Segments.Add(points);                                
                                }
                                points = new PointF[2];
                                points[0].X = (XScale * stroke.xstart) + xoffset;
                                points[0].Y = (YScale * stroke.ystart) + yoffset;
                                points[1].X = (XScale * stroke.xend) + xoffset;
                                points[1].Y = (YScale * stroke.yend) + yoffset;

                            }
                            oldPoint.X = points.Last().X;
                            oldPoint.Y = points.Last().Y;
                            first_stroke = false;
                        }

                        if (onlyTwo)
                        {
                            plate.Segments.Add(points);
                        }                  
                        if(letter == '.')
                    {
                        xoffset += word_space / 2;
                    }
                    else
                    {
                        xoffset += word_space;// + char_width;
                    }                           
                }

                Tags.Add(plate);
                numTag++;
            }
        }              
        #endregion

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

            IssueGCommand("a", 0, 0, 0, 0);
            Gcode.AppendLine(IssueGCommand("G00", 0,0, ClearanceZ, 0));
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
                            Gcode.AppendLine(IssueGCommand("G00", point.X, point.Y, ClearanceZ, 0));
                            Gcode.AppendLine(IssueGCommand("G00", point.X, point.Y, RetractZ, 0));
                            Gcode.AppendLine(IssueGCommand("G01", point.X, point.Y, Depth, PlungeFeed));
                            freshTag = false;
                            newStroke = false;                           
                        } else if (newStroke)
                        {
                            Gcode.AppendLine(IssueGCommand("G00", point.X, point.Y, RetractZ, 0));
                            Gcode.AppendLine(IssueGCommand("G01", point.X, point.Y, Depth, PlungeFeed));
                            newStroke = false;
                        }
                        else
                        {
                            Gcode.AppendLine(IssueGCommand("G01", point.X, point.Y, Depth, CuttingFeed));
                        }

                        
                    }
                    Gcode.AppendLine(IssueGCommand("G00", Xold, Yold, RetractZ, 0));
                }
                var lift = IssueGCommand("G00", Xold, Yold, ClearanceZ, 0);
                if(lift != string.Empty)
                {
                    Gcode.AppendLine(lift);
                }               
            }
            Gcode.AppendLine("M30");
            Gcode.AppendLine("%");
        }

        public String Gold = string.Empty;
        public float Xold = 0;
        public float Yold = 0;
        public float Zold = 0;
        public float Fold = 0;

        public String IssueGCommand(String Command, float X, float Y, float Z , float F )
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


            return GcodeLine;
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            rtxt_Out.Clear();
            CalculateStrokes(tabPageEdit.Controls);
            pictureBox1.Invalidate();
            CreateGcode();
            rtxt_Out.Text = Gcode.ToString();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs g)
        {
            g.Graphics.Clear(Color.White);
            if (Jig != null)
            {
                Pen thick = new Pen(Color.Black, 2);
                float Xscale = pictureBox1.Width / Jig.Perimeter.Width;
                float Yscale = pictureBox1.Height / Jig.Perimeter.Height;
#if truetype
                var temppath = Tags.First().path;
                var mat = new Matrix();
                mat.Scale(Xscale, Yscale);

                temppath.Transform(mat);
                g.Graphics.DrawPath(thick, temppath);
#endif
                g.Graphics.ScaleTransform(1F, -1F);
                g.Graphics.TranslateTransform(0F, -pictureBox1.Height);

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
                                //g.FillRectangle(Brushes.Black, new RectangleF(sketch[x].X, sketch[x].Y, 1, 1));
                            }
                            g.Graphics.DrawLines(thick, sSeg);
                        }
                    }
                    thick.Dispose();
                }
            }
            g.Dispose();                     
        }

        private void txt_CharSpacing_TextChanged(object sender, EventArgs e)
        {
            if(txt_CharSpacing.Text != string.Empty)
            {
                Properties.Settings.Default.CharSpacing = Convert.ToInt16(txt_CharSpacing.Text);
                //Properties.Settings.Default.Save();
            }
        }

        private void txt_Parameter_TextChanged(object sender, EventArgs e)
        {
            if(((TextBox)sender).Text != string.Empty)
            {
                string ParameterName = ((TextBox)sender).Name;
                switch (ParameterName)
                {
                    case "txt_CutRate":
                        Properties.Settings.Default.CuttingFeedRate = Convert.ToSingle(txt_CutRate.Text);
                        break;
                    case "txt_Plunge":
                        Properties.Settings.Default.PlungeFeedRate = Convert.ToSingle(txt_Plunge.Text);
                        break;
                    case "txt_Retract":
                        Properties.Settings.Default.RetractHeight = Convert.ToSingle(txt_Retract.Text);
                        break;
                    case "txt_Diameter":
                        Properties.Settings.Default.EngraverDiameter = Convert.ToSingle(txt_Diameter.Text);
                        break;
                    case "txt_ClearanceHeight":
                        Properties.Settings.Default.ClearanceHeight = Convert.ToSingle(txt_ClearanceHeight.Text);
                        break;

                    case "txt_EngravingDepth":
                        Properties.Settings.Default.EngravingDepth = Convert.ToSingle(txt_EngravingDepth.Text);
                        break;
                    case "txt_CharSpacing":
                        Properties.Settings.Default.CharSpacing = Convert.ToInt16(txt_CharSpacing.Text);
                        break;
                    default:
                        break;
                }
            }          
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }


        #region "Garbage"

        public void CalculateGcode(Control.ControlCollection controls)
        {
            Gcode.Clear();

            float ClearanceZ = Properties.Settings.Default.ClearanceHeight;
            float RetractZ = Properties.Settings.Default.RetractHeight;
            float Depth = -Properties.Settings.Default.EngravingDepth;

            float PlungeFeed = Properties.Settings.Default.PlungeFeedRate;
            float CuttingFeed = Properties.Settings.Default.CuttingFeedRate;

            float oldx = -999990.0F;
            float oldy = oldx;

            Gcode.AppendFormat(" Font File: {0}", System.IO.Path.GetFileName(FontFile)).AppendLine();
            Gcode.Append("G90 ");    //Absolute programming of XYZ
            Gcode.Append("G94 ");    //Units per minute feed mode.
            Gcode.Append("G17 ");    //Select X-Y plane
            Gcode.AppendLine();
            Gcode.AppendLine("G20 ");    //Program coordinates are inches

            //set spindle speed and rotate Clockwise.
            Gcode.AppendFormat("S{0} M03", Properties.Settings.Default.SpindleSpeed).AppendLine();
            //Move to the safe Z height.
            //Gcode.AppendFormat("G0 Z{0:0.0###}", ClearanceZ).AppendLine();  

            //Dictionary<char, Character> Font = parse(FontFile);

            float font_line_height = cxfFont.Aggregate((l, r) => l.Value.get_ymax() > r.Value.get_ymax() ? l : r).Value.get_ymax();

            Gcode.AppendFormat("Max Font Height: {0}", font_line_height).AppendLine();

            float font_word_space = cxfFont.Aggregate((l, r) => l.Value.get_xmax() > r.Value.get_xmax() ? l : r).Value.get_xmax();

            float font_char_space = font_word_space * (Properties.Settings.Default.CharSpacing / 100);

            float xoffset = 0;

            Gcode.AppendFormat("G0 Z{0:0.0###}", ClearanceZ).AppendLine();

            foreach (TextBox item in controls.OfType<TextBox>())
            {
                foreach (char letter in item.Text.ToCharArray())
                {
                    if (letter == ' ')
                    {
                        xoffset += font_word_space;
                        continue;
                    }
                    try
                    {
                        Gcode.AppendFormat("(character {0} )", letter).AppendLine();
                        bool first_stroke = true;
                        foreach (var stroke in cxfFont[letter].stroke_list)
                        {
                            float dx = oldx - stroke.xstart;
                            float dy = oldy - stroke.ystart;
                            float dist = (float)Math.Sqrt(dx * dx + dy * dy);
                            float x1 = stroke.xstart + xoffset;
                            float y1 = stroke.ystart;
                            float x2 = stroke.xend + xoffset;
                            float y2 = stroke.yend;

                            //# check and see if we need to move to a new discontinuous start point
                            if ((dist > 0.0001) || first_stroke)
                            {
                                if (!first_stroke)
                                {
                                    Gcode.AppendFormat("G1 Z{0:0.0###} F{1:0.#}", RetractZ, PlungeFeed).AppendLine();
                                }
                                //G0 Rapid move to the point
                                Gcode.AppendFormat("G0 X{0:0.0###} Y{1:0.0###}", x1, y1).AppendLine();
                                //Gcode.AppendFormat("G0 Z{0:0.0###}", RetractZ).AppendLine();  //Rapid move to the Retract Height.
                                if (first_stroke)
                                {
                                    //rapid to retract position
                                    Gcode.AppendFormat("G0 Z{0:0.0###}", RetractZ).AppendLine();
                                }
                                Gcode.AppendFormat("G1 Z{0:0.0###} F{1:0.#}", Depth, PlungeFeed).AppendLine();  // move to the Depth
                                first_stroke = false;
                            }
                            //
                            Gcode.AppendFormat("G1 X{0:0.0###} Y{1:0.0###} F{2:0.#}", x2, y2, CuttingFeed).AppendLine();
                            //
                            oldx = stroke.xend;
                            oldy = stroke.yend;
                        }
                        // # move over for next character
                        float char_width = cxfFont[letter].get_xmax();
                        xoffset += font_char_space + char_width;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    Gcode.AppendFormat("G1 Z{0:0.0###} F{1:0.#}", RetractZ, PlungeFeed).AppendLine();
                    Gcode.AppendLine();
                }

                Gcode.AppendFormat("G0 Z{0:0.0###}", ClearanceZ).AppendLine();  //Rapid move to the Retract Height.
                Gcode.AppendLine("M30");
            }
        }
        //public Dictionary<char, Character> parse(string font_path)
        //{
        //    Dictionary<char, Character> font = new Dictionary<char, Character>();

        //    int num_cmds = 0;
        //    int line_num = 0;
        //    int cmds_read = 0;
        //    string key = string.Empty;
        //    List<Line> stroke_list = new List<Line>();
        //    float xmax = 0;
        //    float ymax = 0;
        //    float[] coords = new float[4];
        //    float[] Arccoords = new float[5];
        //    Regex end_char = new Regex(@"^$");
        //    Regex new_cmd = new Regex(@"^\[(.*)\]\s(\d+)");
        //    Regex line_cmd = new Regex(@"^L (.*)");
        //    Regex arc_cmd = new Regex(@"^A (.*)");

        //    if (File.Exists(font_path))
        //    {
        //        StreamReader sr = new StreamReader(font_path, System.Text.Encoding.Default);
        //        // Open the file to read from.        
        //        string s = "";
        //        while ((s = sr.ReadLine()) != null)
        //        {
        //            line_num += 1;
        //            if (end_char.IsMatch(s) && (key != string.Empty))
        //            {
        //                char Keychar = Convert.ToChar(key);
        //                List<Line> theStrokes = stroke_list;
        //                font.Add(Keychar, new Character(Keychar, theStrokes));
        //                //#if (num_cmds != cmds_read):
        //                //# print "(warning: discrepancy in number of commands %s, line %s, %s != %s )" % (fontfile, line_num, num_cmds, cmds_read)                                               
        //            }

        //            //new command
        //            if (new_cmd.IsMatch(s))
        //            {
        //                key = new_cmd.Match(s).Groups[1].Value;
        //                num_cmds = Convert.ToInt16(new_cmd.Match(s).Groups[2].Value);
        //                cmds_read = 0;
        //                stroke_list = new List<Line>();
        //                xmax = 0;
        //                ymax = 0;
        //            }
        //            //Line command
        //            if (line_cmd.IsMatch(s))
        //            {
        //                cmds_read++;
        //                string[] temp = line_cmd.Match(s).Groups[1].Value.Split(',');
        //                for (int i = 0; i < temp.Length; i++)
        //                {
        //                    coords[i] = float.Parse(temp[i]);
        //                }
        //                stroke_list.Add(new Line(coords));
        //                xmax = Math.Max(xmax, coords[0]);
        //                xmax = Math.Max(xmax, coords[2]);
        //            }

        //            if (arc_cmd.IsMatch(s))
        //            {
        //                cmds_read++;
        //                string[] temp = arc_cmd.Match(s).Groups[1].Value.Split(',');
        //                for (int i = 0; i < (temp.Length - 1); i++)
        //                {
        //                    Arccoords[i] = float.Parse(temp[i]);
        //                }
        //                //          xcenter, ycenter, radius, start_angle, end_angle = coords 
        //                //  Arccoords [0]      [1]       [2]     [3]         [4]         
        //                //    # since font defn has arcs as ccw, we need some font foo
        //                if (Arccoords[4] < Arccoords[3])
        //                {
        //                    Arccoords[3] -= 360;
        //                }
        //                //approximate arc with line seg every 20 degrees
        //                int segs = Convert.ToInt16(Math.Floor(((Arccoords[4] - Arccoords[3]) / 20)) + 1);
        //                int angleincr = Convert.ToInt16((Arccoords[4] - Arccoords[3]) / segs);
        //                float xstart = Math.Cos(toRad(Arccoords[3])) * Arccoords[2] + Arccoords[0];
        //                float ystart = Math.Sin(toRad(Arccoords[3])) * Arccoords[2] + Arccoords[1];
        //                float angle = Arccoords[3];

        //                //    for i in range(segs):
        //                for (int i = 0; i < segs; i++)
        //                {
        //                    angle += angleincr;
        //                    //xend = cos(angle * pi / 180) * radius + xcenter
        //                    float xend = Math.Cos(toRad(angle)) * Arccoords[2] + Arccoords[0];
        //                    //yend = sin(angle * pi / 180) * radius + ycenter
        //                    float yend = Math.Sin(toRad(angle)) * Arccoords[2] + Arccoords[1];
        //                    //coords = [xstart, ystart, xend, yend]
        //                    coords[0] = xstart;
        //                    coords[1] = ystart;
        //                    coords[2] = xend;
        //                    coords[3] = yend;

        //                    stroke_list.Add(new Line(coords));
        //                    xmax = Math.Max(xmax, coords[0]);
        //                    xmax = Math.Max(xmax, coords[2]);

        //                    ymax = Math.Max(ymax, coords[1]);
        //                    ymax = Math.Max(ymax, coords[3]);
        //                    xstart = xend;
        //                    ystart = yend;
        //                }
        //            }
        //        }
        //        //}
        //    }
        //    return font;
        //}

        public void CalculateTTFStrokes(Control.ControlCollection controls)
        {
            int numTag = 0;
            Tags.Clear();
            PointF oldPoint = new PointF(-999990.0F, -999990.0F);
            // float font_word_space = cxfFont.Aggregate((l, r) => l.Value.get_xmax() > r.Value.get_xmax() ? l : r).Value.get_xmax();            
            // float font_char_space = font_word_space * (Properties.Settings.Default.CharSpacing / 100);

            foreach (TextBox item in controls.OfType<TextBox>())
            {
                NamePlate plate = new NamePlate();
                plate.numTag = numTag;
                RectangleF TagLoc = (RectangleF)item.Tag;

                float YScale = (TagLoc.Height - (Properties.Settings.Default.EngraverDiameter / 2));
                float char_space = (float)(0.75 * YScale);
                float word_space = ((float)(Properties.Settings.Default.CharSpacing) / 100) * char_space;

                float XScale = char_space; //(TagLoc.Width - (Properties.Settings.Default.EngraverDiameter / 2));

                //LeftJustified
                //float xoffset = TagLoc.X + (Properties.Settings.Default.EngraverDiameter / 2);
                //Centered
                float margin = (TagLoc.Width - (((float)item.TextLength - 1) * char_space) - Properties.Settings.Default.EngraverDiameter) / 2;
                float xoffset = TagLoc.X + margin;

                //justified along the bottom...
                //float yoffset = TagLoc.Y + (Properties.Settings.Default.EngraverDiameter / 2);
                //Centered?
                float yoffset = TagLoc.Y + ((TagLoc.Height - YScale) / 2);

                //PointF[] points = new PointF[0];
                GraphicsPath gpath = new GraphicsPath();
                PrivateFontCollection collection = new PrivateFontCollection();
                collection.AddFontFile(@"C:\Users\Rick\Documents\Visual Studio 2015\Projects\TagGenerator\cxf-fonts\stick1.ttf");
                //FontFamily fontFamily = new FontFamily("stick1", collection);
                //Font stickFont = new Font(fontFamily, YScale);               

                gpath.AddString(item.Text, collection.Families.First(), 0, YScale, new PointF(xoffset, xoffset), StringFormat.GenericDefault);

                plate.path = gpath;
                Tags.Add(plate);
                numTag++;

            }
        }
        #endregion
    }
}
