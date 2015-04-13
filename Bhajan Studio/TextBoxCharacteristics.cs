using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace Bhajans
{
    class TextBoxCharacteristics
    {
        public int left = 100;
        public int top = 100;
        public int width = 500;
        public int height = 200;
        public string fontname = "Constantia";
        public float fontsize = 28;
        public bool bold = false;
        public bool italic = false;
        public bool underline = false;
        public int red = 204;
        public int green = 255;
        public int blue = 204;

        public TextBoxCharacteristics(string characteristics)
        {
            Regex re1 = new Regex(",");
            Regex re2 = new Regex("=");
            Regex re3 = new Regex(":");

            string[] parts = re1.Split(characteristics);
            for (int i = 0; i < parts.GetLength(0); i++)
            {
                string[] namevalue = re2.Split(parts[i]);
                string[] components = null;

                if (namevalue[1] != null)
                    components = re3.Split(namevalue[1]);

                if (namevalue[0].Equals("Dimensions"))
                {
                    if (components.GetLength(0) > 0)
                        left = Int32.Parse(components[0]);

                    if (components.GetLength(0) > 1)
                        top = Int32.Parse(components[1]);

                    if (components.GetLength(0) > 2)
                        width = Int32.Parse(components[2]);

                    if (components.GetLength(0) > 3)
                        height = Int32.Parse(components[3]);
                }
                else if (namevalue[0].Equals("Font"))
                {
                    if (components.GetLength(0) > 0)
                        fontname = components[0];

                    if (components.GetLength(0) > 1)
                        fontsize = Single.Parse(components[1]);

                    for (int j = 2; j < components.GetLength(0); j++)
                    {
                        if (components[j].ToLower().Equals("bold"))
                            bold = true;
                        else if (components[j].ToLower().Equals("italic"))
                            italic = true;
                        else if (components[j].ToLower().Equals("underline"))
                            underline = true;
                    }
                }
                else if (namevalue[0].Equals("Color"))
                {
                    if (components.GetLength(0) > 0)
                        red = Int32.Parse(components[0]);

                    if (components.GetLength(0) > 1)
                        green = Int32.Parse(components[1]);

                    if (components.GetLength(0) > 2)
                        blue = Int32.Parse(components[2]);
                }
            }
        }

        public void TransferCharacteristics(Microsoft.Office.Interop.PowerPoint.Shape shape)
        {
            shape.Left = left;
            shape.Top = top;
            shape.Width = width;
            shape.Height = height;

            shape.TextFrame.TextRange.Font.Name = fontname;
            shape.TextFrame.TextRange.Font.Size = fontsize;
            if (bold)
                shape.TextFrame.TextRange.Font.Bold = MsoTriState.msoTrue;
            if (italic)
                shape.TextFrame.TextRange.Font.Italic = MsoTriState.msoTrue;
            if (underline)
                shape.TextFrame.TextRange.Font.Underline = MsoTriState.msoTrue;

            shape.TextFrame.TextRange.Font.Color.RGB = System.Drawing.Color.FromArgb(red, green, blue).ToArgb();
        }
    }
}