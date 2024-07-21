namespace Class.Console;




class ObjectString : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.TextInfra = TextInfra.This;
        this.PrintableChar = PrintableChar.This;
        this.StringCreate = new StringCreate();
        this.StringCreate.Init();


        this.NodeType = typeof(NodeNode);



        this.CodeType = typeof(Code);



        this.TokenType = typeof(TokenToken);



        this.CommentType = typeof(TokenInfo);


        this.CharSpace = ' ';



        this.IndentSize = 4;




        this.TrueString = "true";


        this.FalseString = "false";
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual PrintableChar PrintableChar { get; set; }
    protected virtual StringCreate StringCreate { get; set; }


    private char CharSpace { get; set; }



    private int IndentSize { get; set; }




    private StringBuilder StringBuilder { get; set; }



    private int SpaceCount { get; set; }





    private Type NodeType { get; set; }



    private Type CodeType { get; set; }



    private Type TokenType { get; set; }



    private Type CommentType { get; set; }




    private string TrueString { get; set; }



    private string FalseString { get; set; }






    public string Result()
    {
        return this.StringBuilder.ToString();
    }



    public bool Execute(object varObject)
    {
        this.StringBuilder = new StringBuilder();



        this.SpaceCount = 0;



        this.ExecuteObject(varObject);



        return true;
    }




    private bool ExecuteObject(object varObject)
    {
        if (varObject == null)
        {
            this.Append("null").Append(",").AppendLine();

            return true;
        }



        if (varObject is bool)
        {
            bool k;

            k = (bool)varObject;



            string aa;

            aa = null;


            if (k)
            {
                aa = this.TrueString;
            }


            if (!k)
            {
                aa = this.FalseString;
            }


            

            this.Append(aa).Append(",").AppendLine();


            return true;
        }
        if (varObject is int)
        {
            int k;

            k = (int)varObject;


            this.Append(k.ToString()).Append(",").AppendLine();

            return true;
        }
        if (varObject is ulong)
        {
            ulong k;

            k = (ulong)varObject;


            this.Append(k.ToString()).Append(",").AppendLine();


            return true;
        }
        if (varObject is long)
        {
            long k;

            k = (long)varObject;


            this.Append(k.ToString()).Append(",").AppendLine();


            return true;
        }
        if (varObject is string)
        {
            string s;
            
            s = (string)varObject;


            s = this.EscapeString(s);


            this.Append("\"").Append(s).Append("\"").Append(",").AppendLine();


            return true;
        }



        Type objectType;
        
        objectType = varObject.GetType();


        string objectTypeName;
        
        objectTypeName = objectType.Name;



        this.Append(objectTypeName).AppendLine();
            

        this.AppendSpace().Append("{").AppendLine();


        this.SpaceCount = this.SpaceCount + this.IndentSize;

            



        this.PropertyList(objectType, varObject);
        







        this.SpaceCount = this.SpaceCount - this.IndentSize;


        this.AppendSpace().Append("}").Append(",").AppendLine();



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
                this.Field(fieldName, resultType, fieldGetValue);
            }
        }



        return true;
    }







    private bool Fields(Type objectType, object varObject)
    {
        IEnumerableFieldInfo fieldInfos;


        fieldInfos = objectType.GetFields(BindingFlags.Public | BindingFlags.Instance);



        FieldInfoDictionary dictionary;
        
        dictionary = new FieldInfoDictionary();



        foreach (FieldInfo fieldInfo in fieldInfos)
        {
            if (!dictionary.ContainsKey(fieldInfo.Name))
            {
                dictionary.Add(fieldInfo.Name, fieldInfo);
            }
        }



        fieldInfos = dictionary.Values;




        foreach (FieldInfo fieldInfo in fieldInfos)
        {
            string fieldName;
                
            fieldName = fieldInfo.Name;


            Type resultType;
                
            resultType = fieldInfo.FieldType;



            object fieldGetValue;


            fieldGetValue = fieldInfo.GetValue(varObject);




            bool objectIsNode;

            objectIsNode = this.IsType(objectType, this.NodeType);



            if (objectIsNode)
            {
                if (fieldName == "Range" | fieldName == "Id")
                {
                    continue;
                }
            }



            this.Field(fieldName, resultType, fieldGetValue);
        }



        return true;
    }




    private bool Field(string fieldName, Type resultType, object fieldGetValue)
    {
        this.AppendSpace().Append(fieldName).Append(" ").Append(":").Append(" ");


        bool b;
        b = false;

        if (!b & this.IsType(resultType, typeof(IEnumerable)) & !resultType.Equals(typeof(string)))
        {
            int lastSpaceCount = this.SpaceCount;


            this.SpaceCount = this.SpaceCount + fieldName.Length + 3;


            this.Append("[").AppendLine();


            this.SpaceCount = this.SpaceCount + this.IndentSize;


            IEnumerable objects;
            objects = (IEnumerable)fieldGetValue;


            IEnumerator enumerator;
            enumerator = objects.GetEnumerator();

            while (enumerator.MoveNext())
            {
                object o;
                o = enumerator.Current;


                this.AppendSpace();


                this.ExecuteObject(o);
            }


            this.SpaceCount = this.SpaceCount - this.IndentSize;


            this.AppendSpace().Append("]").Append(",").AppendLine();


            this.SpaceCount = lastSpaceCount;

            b = true;
        }
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
            int lastSpaceCount = this.SpaceCount;


            this.SpaceCount = this.SpaceCount + fieldName.Length + 3;

            object n;
            n = fieldGetValue;
            this.ExecuteObject(n);


            this.SpaceCount = lastSpaceCount;
        }
        return true;
    }





    protected virtual bool ExecuteList(string fieldName, List list, Iter iter)
    {
        int lastSpaceCount;


        lastSpaceCount = this.SpaceCount;




        this.SpaceCount = this.SpaceCount + fieldName.Length + 3;




        this.Append("[").AppendLine();



        this.SpaceCount = this.SpaceCount + this.IndentSize;




        list.IterSet(iter);



        while (iter.Next())
        {
            object o;

            o = iter.Value;

            this.AppendSpace();
            this.ExecuteObject(o);
        }




        this.SpaceCount = this.SpaceCount - this.IndentSize;




        this.AppendSpace().Append("]").Append(",").AppendLine();




        this.SpaceCount = lastSpaceCount;




        return true;
    }




    private bool IsType(Type objectType, Type type)
    {
        bool b;


        b = type.IsAssignableFrom(objectType);



        bool ret;

        ret = b;

        return ret;
    }




    public string EscapeString(string o)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        PrintableChar printableChar;
        printableChar = this.PrintableChar;
        StringCreate stringCreate;
        stringCreate = this.StringCreate;

        StringJoin h;
        h = new StringJoin();
        h.Init();

        int count;
        count = o.Length;
        int i;
        i = 0;
        while (i < count)
        {
            char oc;
            oc = o[i];

            bool b;
            b = false;
            if (!b)
            {
                if (oc == '\\')
                {
                    h.Append("\\\\");
                    b = true;
                }
            }
            if (!b)
            {
                if (oc == '\"')
                {
                    h.Append("\\\"");
                    b = true;
                }
            }
            if (!b)
            {
                if (oc == '\t')
                {
                    h.Append("\\t");
                    b = true;
                }
            }
            if (!b)
            {
                if (oc == '\n')
                {
                    h.Append("\\n");
                    b = true;
                }
            }
            if (!b)
            {
                bool ba;
                ba = printableChar.Get(oc);

                if (!ba)
                {
                    int k;
                    k = oc;

                    char letterStart;
                    letterStart = 'a';

                    int countA;
                    countA = sizeof(char) * 2;

                    Data data;
                    data = new Data();
                    data.Count = countA * sizeof(char);
                    data.Init();

                    int iA;
                    iA = 0;
                    while (iA < countA)
                    {
                        int index;
                        index = countA - 1 - iA;

                        int ka;
                        ka = k >> (index * 4);
                        ka = ka & 0xf;

                        char kb;
                        kb = textInfra.DigitChar(ka, letterStart);
                        
                        textInfra.DataCharSet(data, iA, kb);

                        iA = iA + 1;
                    }

                    string kk;
                    kk = stringCreate.Data(data, null);

                    h.Append("\\u");
                    h.Append(kk);
                }

                if (ba)
                {
                    h.AppendChar(oc);
                }
            }

            i = i + 1;
        }


        string ret;
        ret = h.Result();

        return ret;
    }






    private ObjectString Append(string s)
    {
        StringBuilder.Append(s);

        return this;
    }



    private ObjectString AppendLine()
    {
        this.Append('\n', 1);


        return this;
    }



    private ObjectString Append(char c, int count)
    {
        StringBuilder.Append(c, count);

        return this;
    }



    private ObjectString AppendSpace()
    {
        return this.Append(CharSpace, this.SpaceCount);
    }
}