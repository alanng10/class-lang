namespace Class.Console;

class ObjectString : ClassInfraGen
{
    public override bool Init()
    {
        base.Init();
        this.PrintableChar = PrintableChar.This;


        this.NodeType = typeof(NodeNode);
        this.CodeType = typeof(Code);
        this.TokenType = typeof(TokenToken);
        this.CommentType = typeof(TokenInfo);

        this.SComma = this.S(",");
        this.SSpace = this.S(" ");
        this.SQuote = this.S("\"");
        this.SColon = this.S(":");
        this.SBraceLite = this.S("{");
        this.SBraceRite = this.S("}");
        this.SBraceSquareLite = this.S("[");
        this.SBraceSquareRite = this.S("]");
        this.SNull = this.S("null");
        this.SEscapeBackSlash = this.S("\\\\");
        this.SEscapeQuote = this.S("\\\"");
        this.SEscapeNewLine = this.S("\\n");
        this.SEscapeCode = this.S("\\u");

        this.IndentSize = 4;
        return true;
    }

    protected virtual PrintableChar PrintableChar { get; set; }
    private String SComma { get; set; }
    private String SSpace { get; set; }
    private String SQuote { get; set; }
    private String SColon { get; set; }
    private String SBraceLite { get; set; }
    private String SBraceRite { get; set; }
    private String SBraceSquareLite { get; set; }
    private String SBraceSquareRite { get; set; }
    private String SNull { get; set; }
    private String SEscapeBackSlash { get; set; }
    private String SEscapeQuote { get; set; }
    private String SEscapeNewLine { get; set; }
    private String SEscapeCode { get; set; }
    private long IndentSize { get; set; }
    private long SpaceCount { get; set; }
    private Type NodeType { get; set; }
    private Type CodeType { get; set; }
    private Type TokenType { get; set; }
    private Type CommentType { get; set; }

    public virtual String Result()
    {
        return this.AddResult();
    }

    public virtual bool Execute(object any)
    {
        this.AddClear();

        this.SpaceCount = 0;

        this.ExecuteAny(any);
        return true;
    }

    public virtual bool ExecuteAny(object any)
    {
        if (any == null)
        {
            this.Add(this.SNull).Add(this.SComma).AddLine();

            return true;
        }

        if (any is bool)
        {
            bool ka;
            ka = (bool)any;

            String aa;
            aa = null;
            if (ka)
            {
                aa = this.TextInfra.BoolTrueString;
            }
            if (!ka)
            {
                aa = this.TextInfra.BoolFalseString;
            }

            this.Add(aa).Add(this.SComma).AddLine();

            return true;
        }
        if (any is long)
        {
            long kb;
            kb = (long)any;

            String kba;
            kba = this.IntString(kb);

            this.Add(kba).Add(this.SComma).AddLine();

            return true;
        }
        if (any is String)
        {
            String kc;
            kc = (String)any;

            this.Add(this.SQuote);
            
            this.AddEscapeString(kc);
            
            this.Add(this.SQuote).Add(this.SComma).AddLine();

            return true;
        }

        Type objectType;
        
        objectType = any.GetType();

        String objectTypeName;
        objectTypeName = this.S(objectType.Name);

        this.Add(objectTypeName).AddLine();
            

        this.AddSpace();
        this.Add(this.SBraceLite).AddLine();

        this.SpaceCount = this.SpaceCount + this.IndentSize;

        this.PropertyList(objectType, any);
        
        this.SpaceCount = this.SpaceCount - this.IndentSize;


        this.AddSpace();
        this.Add(this.SBraceRite).Add(this.SComma).AddLine();

        return true;
    }

    private bool PropertyList(Type objectType, object varObject)
    {
        IEnumerablePropertyInfo propertyInfoList;
        propertyInfoList = objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        PropertyInfoDictionary dictionary;        
        dictionary = new PropertyInfoDictionary();

        foreach (PropertyInfo propertyInfo in propertyInfoList)
        {
            if (!dictionary.ContainsKey(propertyInfo.Name))
            {
                dictionary.Add(propertyInfo.Name, propertyInfo);
            }
        }

        propertyInfoList = dictionary.Values;

        foreach (PropertyInfo propertyInfo in propertyInfoList)
        {
            string fieldName;                
            fieldName = propertyInfo.Name;

            Type resultType;                
            resultType = propertyInfo.PropertyType;

            object fieldGetValue;
            fieldGetValue = propertyInfo.GetValue(varObject);

            bool b;
            b = false;

            bool objectIsNode;
            objectIsNode = this.IsType(objectType, this.NodeType);
            if (objectIsNode)
            {
                if (fieldName == "Range" | fieldName == "NodeAny")
                {
                    b = true;
                }
            }

            if (!b)
            {
                this.Field(this.S(fieldName), resultType, fieldGetValue);
            }
        }

        return true;
    }

    private bool Field(String fieldName, Type resultType, object fieldGetValue)
    {
        this.AddSpace();
        this.Add(fieldName).Add(this.SSpace).Add(this.SColon).Add(this.SSpace);

        bool b;
        b = false;

        if (!b & this.IsType(resultType, typeof(List)))
        {
            List list;
            list = (List)fieldGetValue;

            Iter iter;
            iter = list.IterCreate();

            this.ExecuteList(fieldName, list, iter);

            b = true;
        }
        if (!b)
        {
            long lastSpaceCount;
            lastSpaceCount = this.SpaceCount;

            this.SpaceCount = this.SpaceCount + this.StringCount(fieldName) + 3;

            object any;
            any = fieldGetValue;

            this.ExecuteAny(any);

            this.SpaceCount = lastSpaceCount;
        }
        return true;
    }

    protected virtual bool ExecuteList(String fieldName, List list, Iter iter)
    {
        long lastSpaceCount;
        lastSpaceCount = this.SpaceCount;

        this.SpaceCount = this.SpaceCount + this.StringCount(fieldName) + 3;

        this.Add(this.SBraceSquareLite).AddLine();

        this.SpaceCount = this.SpaceCount + this.IndentSize;

        list.IterSet(iter);

        while (iter.Next())
        {
            object o;
            o = iter.Value;

            this.AddSpace();

            this.ExecuteAny(o);
        }

        this.SpaceCount = this.SpaceCount - this.IndentSize;

        this.AddSpace();
        this.Add(this.SBraceSquareRite).Add(this.SComma).AddLine();

        this.SpaceCount = lastSpaceCount;
        return true;
    }

    private bool IsType(Type objectType, Type type)
    {
        bool a;
        a = type.IsAssignableFrom(objectType);
        return a;
    }

    public virtual ObjectString AddEscapeString(String o)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        PrintableChar printableChar;
        printableChar = this.PrintableChar;

        long count;
        count = this.StringCount(o);
        long i;
        i = 0;
        while (i < count)
        {
            long oc;
            oc = this.StringComp.Char(o, i);

            bool b;
            b = false;
            if (!b)
            {
                if (oc == '\\')
                {
                    this.Add(this.SEscapeBackSlash);
                    b = true;
                }
            }
            if (!b)
            {
                if (oc == '\"')
                {
                    this.Add(this.SEscapeQuote);
                    b = true;
                }
            }
            if (!b)
            {
                if (oc == '\n')
                {
                    this.Add(this.SEscapeNewLine);
                    b = true;
                }
            }
            if (!b)
            {
                bool ba;
                ba = printableChar.Get(oc);

                if (!ba)
                {
                    this.Add(this.SEscapeCode);

                    long k;
                    k = oc;

                    long letterStart;
                    letterStart = 'a';

                    long countA;
                    countA = 8;

                    long iA;
                    iA = 0;
                    while (iA < countA)
                    {
                        long index;
                        index = countA - 1 - iA;

                        int shift;
                        shift = (int)(index * 4);

                        long ka;
                        ka = k >> shift;
                        ka = ka & 0xf;

                        long ke;
                        ke = textInfra.DigitChar(ka, letterStart);
                        
                        this.AddChar(ke);

                        iA = iA + 1;
                    }
                }

                if (ba)
                {
                    this.AddChar(oc);
                }
            }

            i = i + 1;
        }

        return this;
    }

    public virtual ObjectString AddSpace()
    {
        long count;
        count = this.SpaceCount;
        long i;
        i = 0;
        while (i < count)
        {
            this.Add(this.SSpace);

            i = i + 1;
        }
        return this;
    }
}