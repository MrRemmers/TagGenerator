using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace TagGenerator
{
    public class cxfFont
    {

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
                        font.Add(Keychar, new Character(Keychar, theStrokes));
                        //font[key] = Character(key)                                     
                        //font[key].stroke_list = stroke_list
                        //font[key].xmax = xmax
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
                        for (int i = 0; i < (temp.Length - 1); i++)
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
                        int segs = Convert.ToInt16(Math.Floor(((Arccoords[4] - Arccoords[3]) / 20)) + 1);
                        int angleincr = Convert.ToInt16((Arccoords[4] - Arccoords[3]) / segs);
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
                            //        xstart = xend
                            //        ystart = yend
                            xstart = xend;
                            ystart = yend;
                        }
                    }
                }
                //}
            }
            return font;
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
            private char key;
            //private List<float> stroke_list;
            public List<Line> stroke_list;
            //private float xmax; , float x_max

            public Character(char Key, List<Line> strokes)
            {
                key = Key;
                stroke_list = strokes;
                //xmax = x_max;
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

        //static string sanitize(string String)
        //{
        //    //retval = ''
        //    string retval = string.Empty;
        ////good = ' ~!@#$%^&*_+=-{}[]|\:;"<>,./?'
        //Regex good = new Regex(@" ~!@#$%^&*_+=-{}[]|:;\"""" <>,./?");
        //    //for char in string:
        //    foreach (char C in String.ToCharArray())
        //    {
        //        if (char.IsLetterOrDigit(C) || good.IsMatch(C,) == false)
        //        {

        //        }
        //    }
        //    if char.isalnum() or good.find(char) != -1:
        //        retval += char
        //    else: retval += (' 0x%02X ' % ord(char))
        //return retval
        //}
        //public List<Line>
        public List<string> InputText = new List<string>();
        public StringBuilder Gcode = new StringBuilder();

        //public void CalculateGcode()
        //{
        //    Gcode.Clear();

        //    GatherInputs();

        //    EstablishLocations();

        //    float ClearanceZ = Properties.Settings.Default.ClearanceHeight;
        //    float RetractZ = Properties.Settings.Default.RetractHeight;
        //    float Depth = -Properties.Settings.Default.EngravingDepth;

        //    float PlungeFeed = Properties.Settings.Default.PlungeFeedRate;
        //    float CuttingFeed = Properties.Settings.Default.CuttingFeedRate;

        //    float oldx = -999990.0;
        //    float oldy = oldx;

        //    Gcode.AppendFormat(" Font File: {0}", System.IO.Path.GetFileName(FontFile)).AppendLine();
        //    Gcode.Append("G90 ");    //Absolute programming of XYZ
        //    Gcode.Append("G94 ");    //Units per minute feed mode.
        //    Gcode.Append("G17 ");    //Select X-Y plane
        //    Gcode.AppendLine();
        //    Gcode.AppendLine("G20 ");    //Program coordinates are inches

        //    //set spindle speed and rotate Clockwise.
        //    Gcode.AppendFormat("S{0} M03", Properties.Settings.Default.SpindleSpeed).AppendLine();
        //    //Move to the safe Z height.
        //    //Gcode.AppendFormat("G0 Z{0:0.0###}", ClearanceZ).AppendLine();  

        //    Dictionary<char, Character> Font = parse(FontFile);
        //    float font_line_height = Font.Aggregate((l, r) => l.Value.get_ymax() > r.Value.get_ymax() ? l : r).Value.get_ymax();
        //    Gcode.AppendFormat("Max Font Height: {0}", font_line_height).AppendLine();

        //    float font_word_space = Font.Aggregate((l, r) => l.Value.get_xmax() > r.Value.get_xmax() ? l : r).Value.get_xmax();
        //    float font_char_space = font_word_space * (Properties.Settings.Default.CharSpacing / 100);
        //    float xoffset = 0;

        //    //foreach TextBox in InputText
        //    //{
        //    Gcode.AppendFormat("G0 Z{0:0.0###}", ClearanceZ).AppendLine();

        //    foreach (var letter in InputText.FirstOrDefault().ToCharArray())
        //    {
        //        if (letter == ' ')
        //        {
        //            //            if char == ' ':
        //            //                xoffset += font_word_space
        //            xoffset += font_word_space;
        //            continue;
        //        }
        //        try
        //        {
        //            Gcode.AppendFormat("(character {0} )", letter).AppendLine();
        //            bool first_stroke = true;
        //            foreach (var stroke in Font[letter].stroke_list)
        //            {
        //                float dx = oldx - stroke.xstart;
        //                float dy = oldy - stroke.ystart;
        //                float dist = Math.Sqrt(dx * dx + dy * dy);
        //                float x1 = stroke.xstart + xoffset;
        //                float y1 = stroke.ystart;
        //                float x2 = stroke.xend + xoffset;
        //                float y2 = stroke.yend;

        //                //# check and see if we need to move to a new discontinuous start point
        //                if ((dist > 0.001) || first_stroke)
        //                {
        //                    if (!first_stroke)
        //                    {
        //                        Gcode.AppendFormat("G1 Z{0:0.0###} F{1:0.#}", RetractZ, PlungeFeed).AppendLine();
        //                    }
        //                    //G0 Rapid move to the point
        //                    Gcode.AppendFormat("G0 X{0:0.0###} Y{1:0.0###}", x1, y1).AppendLine();
        //                    //Gcode.AppendFormat("G0 Z{0:0.0###}", RetractZ).AppendLine();  //Rapid move to the Retract Height.
        //                    if (first_stroke)
        //                    {
        //                        //rapid to retract position
        //                        Gcode.AppendFormat("G0 Z{0:0.0###}", RetractZ).AppendLine();
        //                    }
        //                    Gcode.AppendFormat("G1 Z{0:0.0###} F{1:0.#}", Depth, PlungeFeed).AppendLine();  // move to the Depth
        //                    first_stroke = false;
        //                }
        //                //
        //                Gcode.AppendFormat("G1 X{0:0.0###} Y{1:0.0###} F{2:0.#}", x2, y2, CuttingFeed).AppendLine();
        //                //
        //                oldx = stroke.xend;
        //                oldy = stroke.yend;
        //            }
        //            // # move over for next character
        //            float char_width = Font[letter].get_xmax();
        //            xoffset += font_char_space + char_width;
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //        Gcode.AppendFormat("G1 Z{0:0.0###} F{1:0.#}", RetractZ, PlungeFeed).AppendLine();
        //        Gcode.AppendLine();
        //    }

        //    Gcode.AppendFormat("G0 Z{0:0.0###}", ClearanceZ).AppendLine();  //Rapid move to the Retract Height.
        //    Gcode.AppendLine("M30");
        //}
    }
}
