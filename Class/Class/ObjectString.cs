namespace Class;




class ObjectString : Any
{
    private char CharSpace { get; set; }



    private int IndentSize { get; set; }




    private StringBuilder StringBuilder { get; set; }



    private int SpaceCount { get; set; }



    public Text Source { get; set; }



    private InfraInfra InfraInfra { get; set; }



    private TextInfra TextInfra { get; set; }



    private Type NodeType { get; set; }



    private Type CodeType { get; set; }



    private Type TokenType { get; set; }



    private Type CommentType { get; set; }




    private Type TextRangeType { get; set; }




    private Type TextPosType { get; set; }




    private string TrueString { get; set; }



    private string FalseString { get; set; }




    public override bool Init()
    {
        base.Init();




        this.InfraInfra = InfraInfra.This;




        this.TextInfra = TextInfra.This;





        this.NodeType = typeof(NodeNode);



        this.CodeType = typeof(Code);



        this.TokenType = typeof(TokenToken);



        this.CommentType = typeof(Comment);




        this.TextRangeType = typeof(TextRange);



        this.TextPosType = typeof(TextPos);




        this.CharSpace = ' ';



        this.IndentSize = 4;




        this.TrueString = "true";


        this.FalseString = "false";




        return true;
    }



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



        if (this.IsType(objectType, this.TextRangeType))
        {
            objectTypeName = "TextRange";
        }




        this.Append(objectTypeName).AppendLine();
            

        this.AppendSpaces().Append("{").AppendLine();


        this.SpaceCount = this.SpaceCount + this.IndentSize;

            



        this.Propertys(objectType, varObject);
        







        this.SpaceCount = this.SpaceCount - IndentSize;


        this.AppendSpaces().Append("}").Append(",").AppendLine();



        return true;
    }






    private bool Propertys(Type objectType, object varObject)
    {
        IEnumerablePropertyInfo propertyInfos;


        propertyInfos = objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance);



        PropertyInfoDictionary dictionary;
        
        dictionary = new PropertyInfoDictionary();



        foreach (PropertyInfo propertyInfo in propertyInfos)
        {
            if (!dictionary.ContainsKey(propertyInfo.Name))
            {
                dictionary.Add(propertyInfo.Name, propertyInfo);
            }
        }



        propertyInfos = dictionary.Values;




        foreach (PropertyInfo propertyInfo in propertyInfos)
        {
            string fieldName;
                
            fieldName = propertyInfo.Name;


            Type resultType;
                
            resultType = propertyInfo.PropertyType;



            object fieldGetValue;


            fieldGetValue = propertyInfo.GetValue(varObject);




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
        this.AppendSpaces().Append(fieldName).Append(" ").Append(":").Append(" ");




        if ((this.IsType(resultType, typeof(IEnumerable))) && !resultType.Equals(typeof(string)))
        {
            int lastSpaceCount = this.SpaceCount;


            this.SpaceCount = this.SpaceCount + (fieldName.Length + 1 + 1 + 1);


            this.Append("[").AppendLine();


            this.SpaceCount = this.SpaceCount + IndentSize;


            IEnumerable objects;
            objects = (IEnumerable)fieldGetValue;


            IEnumerator enumerator;
            enumerator = objects.GetEnumerator();

            while (enumerator.MoveNext())
            {
                object o;
                o = enumerator.Current;


                this.AppendSpaces();


                this.ExecuteObject(o);
            }


            this.SpaceCount = this.SpaceCount - IndentSize;


            this.AppendSpaces().Append("]").Append(",").AppendLine();


            this.SpaceCount = lastSpaceCount;



        }
        else if (this.IsType(resultType, typeof(List)))
        {
            List list;
            list = (List)fieldGetValue;

            Iter iter;

            iter = list.IterCreate();


            this.ExecuteList(fieldName, list, iter);
        }
        else
        {
            int lastSpaceCount = this.SpaceCount;


            this.SpaceCount = this.SpaceCount + (fieldName.Length + 1 + 1 + 1);



            object n = fieldGetValue;


            this.ExecuteObject(n);


            this.SpaceCount = lastSpaceCount;
        }




        return true;
    }





    protected virtual bool ExecuteList(string fieldName, List list, Iter iter)
    {
        int lastSpaceCount;


        lastSpaceCount = this.SpaceCount;




        this.SpaceCount = this.SpaceCount + (fieldName.Length + 1 + 1 + 1);




        this.Append("[").AppendLine();



        this.SpaceCount = this.SpaceCount + IndentSize;




        list.IterSet(iter);



        while (iter.Next())
        {
            object o;

            o = iter.Value;



            this.AppendSpaces();



            this.ExecuteObject(o);
        }




        this.SpaceCount = this.SpaceCount - IndentSize;




        this.AppendSpaces().Append("]").Append(",").AppendLine();




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




    public string EscapeString(string s)
    {
        string t;


        t = s;


        t = t.Replace("\\", "\\\\");


        t = t.Replace("\"", "\\\"");


        t = t.Replace("\t", "\\t");


        t = t.Replace("\n", "\\n");


        t = t.Replace("\r", "\\r");


        string ret;
        ret = t;

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



    private ObjectString AppendSpaces()
    {
        return this.Append(CharSpace, this.SpaceCount);
    }
}