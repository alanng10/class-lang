namespace Z.Tool.TypeBoardSvgSourceGen;






public class Gen : Any
{
    public override bool Init()
    {
        base.Init();




        this.OutputFilePath = "../../../../Info/System/System/Effect/Type/TypeBoard.svg";





        this.DigitButtonShiftChar = new char[10]
        {
            '&',
            '|',
            '!',
            '+',
            '-',
            '*',
            '/',
            '<',
            '>',
            '='
        };



        return true;
    }





    protected virtual string OutputFilePath { get; set; }




    protected virtual char[] DigitShiftCharArray { get; set; }





    public virtual int Execute()
    {
        string ua;

        ua = this.ReadTextFile("Svg.txt");




        StringBuilder sb;

        sb = new StringBuilder(ua);




        StringBuilder sba;

        sba = new StringBuilder();




        this.AddLetterButtonList(sba);


        this.AddDigitButtonList(sba);


        this.AddSignButtonList(sba);


        this.AddControlButtonList(sba);


        


        string aa;


        aa = sba.ToString();





        sb.Replace("#DrawList#", aa);





        string output;


        output = sb.ToString();




        this.WriteTextFile(this.OutputFilePath, output);




        return 0;
    }




    protected virtual bool AddLetterButtonList(StringBuilder sb)
    {
        int row;



        int startCol;




        int count;



        int letterIndex;


        letterIndex = 0;



        
        int aaa;


        aaa = 4;



        
        row = 2;


        startCol = 2;



        count = aaa;



        this.AddLetterButtonRange(sb, row, startCol, count, letterIndex);



        letterIndex = letterIndex + count;




        int aab;


        aab = 4;



        row = 3;


        startCol = 2;



        count = aab;



        this.AddLetterButtonRange(sb, row, startCol, count, letterIndex);



        letterIndex = letterIndex + count;




        int aac;


        aac = 5;



        row = 1;


        startCol = 1;



        count = aac;



        this.AddLetterButtonRange(sb, row, startCol, count, letterIndex);



        letterIndex = letterIndex + count;




        int aad;


        aad = 5;




        row = 1;


        startCol = aac + 1;



        count = aad;



        this.AddLetterButtonRange(sb, row, startCol, count, letterIndex);



        letterIndex = letterIndex + count;





        int aae;


        aae = 4;




        row = 3;


        startCol = aab + 2;



        count = aae;



        this.AddLetterButtonRange(sb, row, startCol, count, letterIndex);



        letterIndex = letterIndex + count;





        int aaf;


        aaf = 4;



        count = aaf;



        row = 2;


        startCol = aaa + 2;



        this.AddLetterButtonRange(sb, row, startCol, count, letterIndex);


        
        letterIndex = letterIndex + count;





        return true;
    }






    protected virtual bool AddLetterButtonRange(StringBuilder sb, int row, int startCol, int count, int letterIndex)
    {
        int col;


        int uu;



        int i;


        i = 0;


        while (i < count)
        {
            col = startCol + i;


            uu = 'A' + letterIndex + i;



            this.AddButton(sb, uu, this.NullInt, row, col);



            i = i + 1;
        }



        return true;
    }






    protected virtual bool AddDigitButtonList(StringBuilder sb)
    {
        int row;


        row = 0;



        int startCol;

        startCol = 1;



        int col;


        int uu;


        char shiftChar;


        int ua;




        int count;


        count = 10;


        int i;


        i = 0;


        while (i < count)
        {
            col = startCol + i;



            uu = '0' + i;



            shiftChar = this.DigitButtonShiftChar[i];


            ua = shiftChar;



            this.AddButton(sb, uu, ua, row, col);




            i = i + 1;
        }



        return true;
    }








    protected virtual bool AddSignButtonList(StringBuilder sb)
    {
        this.AddButton(sb, '(', '{', 2, 1);



        this.AddButton(sb, ')', '}', 2, 10);




        this.AddButton(sb, ',', '[', 3, 1);



        this.AddButton(sb, '.', ']', 3, 10);




        this.AddButton(sb, '#', '^', 0, 0);


        this.AddButton(sb, '_', '?', 0, 11);



        this.AddButton(sb, ':', '\\', 1, 0);


        this.AddButton(sb, ';', '\"', 1, 11);





        return true;
    }






    protected virtual bool AddControlButtonList(StringBuilder sb)
    {
        this.AddControlButton(sb, "Tab", 2, 0);



        this.AddControlButton(sb, "Shift", 3, 0);





        this.AddControlButton(sb, "Enter", 2, 11);



        this.AddControlButton(sb, "Space", 3, 11);




        return true;
    }






    protected virtual bool AddControlButton(StringBuilder sb, string value, int row, int col)
    {
        int left;

        left = this.GetButtonLeft(col);



        int up;

        up = this.GetButtonUp(row);





        this.AddButtonRect(sb, left, up);




        int l;

        l = left + 8;


        int u;

        u = up + 21;




        this.AddText(sb, l, u, value, '\0', 11);



        this.AppendNewLine(sb);





        return true;
    }





    protected virtual bool AddButton(StringBuilder sb, int defaultChar, int shiftChar, int row, int col)
    {
        int left;

        left = this.GetButtonLeft(col);



        int up;

        up = this.GetButtonUp(row);





        this.AddButtonRect(sb, left, up);





        if (!(defaultChar == this.NullInt))
        {
            bool b;

            b = (shiftChar == this.NullInt);


            if (b)
            {
                char oc;

                oc = (char)defaultChar;




                int l;

                l = left + 10;


                int u;

                u = up + 24;



                this.AddText(sb, l, u, null, oc, 22);



                this.AppendNewLine(sb);
            }



            if (!b)
            {
                char oc;


                int l;
                

                int u;



                oc = (char)defaultChar;



                l = left + 9;


                u = up + 40;



                this.AddText(sb, l, u, null, oc, 16);



                this.AppendNewLine(sb);





                oc = (char)shiftChar;



                l = left + 9;


                u = up + 18;



                this.AddText(sb, l, u, null, oc, 16);


                this.AppendNewLine(sb);
            }
        }





        return true;
    }






    protected virtual bool AddButtonRect(StringBuilder sb, int left, int up)
    {
        int width;

        width = this.ButtonWidth;



        int height;

        height = width;



        int horizontalRadius;

        horizontalRadius = this.ButtonCornerRadius;


        int verticalRadius;

        verticalRadius = horizontalRadius;




        this.AddRect(sb, left, up, width, height, horizontalRadius, verticalRadius);



        this.AppendNewLine(sb);



        return true;
    }


    



    protected virtual int GetButtonLeft(int col)
    {
        return this.BoardLeft + col * (this.ButtonWidth + this.ButtonSpace);
    }




    protected virtual int GetButtonUp(int row)
    {
        return this.BoardUp + row * (this.ButtonWidth + this.ButtonSpace);
    }





    protected virtual char[] DigitButtonShiftChar { get; set; }





    protected virtual int ButtonWidth
    {
        get
        {
            return 50;
        }
        set
        {
        }
    }



    protected virtual int ButtonSpace
    {
        get
        {
            return 8;
        }
        set
        {
        }
    }




    protected virtual int BoardLeft
    {
        get
        {
            return 20;
        }
        set
        {
        }
    }




    protected virtual int BoardUp
    {
        get
        {
            return 20;
        }
        set
        {
        }
    }



    protected virtual int ButtonCornerRadius
    {
        get
        {
            return 5;
        }
        set
        {
        }
    }




    protected virtual int NullInt
    {
        get
        {
            return -1;
        }
        set
        {
        }
    }





    protected virtual bool AddRect(StringBuilder sb, int left, int up, int width, int height, int horizontalRadius, int verticalRadius)
    {
        this.AppendIndent(sb, 1);



        sb.Append("<rect");




        this.AddAttributeInt(sb, "x", left);


        this.AddAttributeInt(sb, "y", up);


        this.AddAttributeInt(sb, "width", width);


        this.AddAttributeInt(sb, "height", height);


        this.AddAttributeInt(sb, "rx", horizontalRadius);


        this.AddAttributeInt(sb, "ry", verticalRadius);



        this.AddAttributeString(sb, "stroke", "black");


        this.AddAttributeInt(sb, "stroke-width", 1);


        this.AddAttributeString(sb, "fill", "white");




        this.CloseTag(sb);



        this.AppendNewLine(sb);



        
        return true;
    }




    protected virtual bool AddText(StringBuilder sb, int left, int up, string value, char valueChar, int fontSize)
    {
        this.AppendIndent(sb, 1);



        sb.Append("<text");




        this.AddAttributeInt(sb, "x", left);


        this.AddAttributeInt(sb, "y", up);


        this.AddAttributeInt(sb, "font-size", fontSize);



        this.AddAttributeString(sb, "text-anchor", "start");


        this.AddAttributeString(sb, "fill", "black");


        this.AddAttributeString(sb, "font-family", "Source Code Pro");




        sb.Append(">");



        bool b;


        b = !(value == null);



        if (!b)
        {
            string kk;


            kk = this.EscapeChar(valueChar);



            sb.Append(kk);
        }


        if (b)
        {
            sb.Append(value);
        }

        


        sb.Append("</text>");




        this.AppendNewLine(sb);



        return true;
    }





    protected virtual string EscapeChar(char oc)
    {
        string k;

        k = null;


        bool b;

        b = false;



        if (!b & (oc == '<'))
        {
            k = "&lt;";


            b = true;
        }



        if (!b & (oc == '>'))
        {
            k = "&gt;";


            b = true;
        }



        if (!b & (oc == '&'))
        {
            k = "&amp;";


            b = true;
        }



        if (!b & (oc == '\"'))
        {
            k = "&quot;";


            b = true;
        }






        if (!b)
        {
            k = oc.ToString();
        }



        return k;
    }







    protected virtual bool AddAttributeInt(StringBuilder sb, string name, int value)
    {
        sb.Append(" ").Append(name).Append("=\"").Append(value).Append("\"");



        return true;
    }




    protected virtual bool AddAttributeChar(StringBuilder sb, string name, char value)
    {
        sb.Append(" ").Append(name).Append("=\"").Append(value).Append("\"");



        return true;
    }





    protected virtual bool AddAttributeString(StringBuilder sb, string name, string value)
    {
        sb.Append(" ").Append(name).Append("=\"").Append(value).Append("\"");



        return true;
    }





    protected virtual bool CloseTag(StringBuilder sb)
    {
        sb.Append(" />");


        return true;
    }




    protected virtual bool AppendNewLine(StringBuilder sb)
    {
        sb.Append("\n");


        return true;
    }



    protected virtual bool AppendIndent(StringBuilder sb, int indent)
    {
        int count;

        count = indent;



        int i;

        i = 0;


        while (i < count)
        {
            sb.Append("    ");



            i = i + 1;
        }
        

        return true;
    }





    protected virtual string ReadTextFile(string filePath)
    {
        string a;

        a = File.ReadAllText(filePath);


        return a;
    }





    protected virtual bool WriteTextFile(string filePath, string text)
    {
        File.WriteAllText(filePath, text);


        return true;
    }
}