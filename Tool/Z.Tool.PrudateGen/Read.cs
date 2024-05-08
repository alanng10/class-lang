namespace Z.Tool.PrudateGen;





class Read : Any
{
    public virtual int Execute()
    {
        this.Result = new ReadResult();

        this.Result.Init();




        bool b;

        b = this.SetClassArray();


        if (!b)
        {
            return 1;
        }



        b = this.SetMethodArray();


        if (!b)
        {
            return 2;
        }
        


        return 0;
    }





    public virtual ReadResult Result { get; set; }




    protected virtual List ClassList { get; set; }


    protected virtual Class Class { get; set; }






    protected virtual List FieldList { get; set; }



    protected virtual List MethodList { get; set; }



    protected virtual List StaticFieldList { get; set; }



    protected virtual List StaticMethodList { get; set; }



    protected virtual List DelegateList { get; set; }









    protected virtual bool SetClassArray()
    {
        ToolInfra infra;

        infra = ToolInfra.This;



        string ka;

        ka = infra.StorageTextRead("ToolData/ClassList.txt");



        Array lineArray;
        
        lineArray = infra.SplitLineList(ka);




        this.ClassList = new List();

        this.ClassList.Init();




        int count;

        count = lineArray.Count;


        int i;

        i = 0;


        while (i < count)
        {
            string line;


            line = (string)lineArray.Get(i);



            bool b;

            b = this.SetClassArrayOneLine(line);


            if (!b)
            {
                return false;
            }




            i = i + 1;
        }



        this.EndCurrentClass();




        this.Result.Class = this.CreateArray(this.ClassList);




        this.ClassList = null;




        return true;
    }





    protected virtual bool SetClassArrayOneLine(string line)
    {
        if (line.Length == 0)
        {
            return true;
        }


        string oo;

        oo = "    ";


        bool b;

        b = line.StartsWith(oo);


        if (!b)
        {
            this.EndCurrentClass();





            Class varClass;

            varClass = this.GetClass(line);


            if (varClass == null)
            {
                return false;
            }



            this.Class = varClass;



            this.ClassList.Add(this.Class);



            this.FieldList = new List();

            this.FieldList.Init();


            this.MethodList = new List();

            this.MethodList.Init();


            this.StaticFieldList = new List();

            this.StaticFieldList.Init();


            this.StaticMethodList = new List();

            this.StaticMethodList.Init();


            this.DelegateList = new List();

            this.DelegateList.Init();

        }


        if (b)
        {
            string compLine;

            compLine = line.Substring(oo.Length);



            string ooa;

            ooa = " --";


            bool boa;

            boa = compLine.EndsWith(ooa);



            if (boa)
            {
                int koa;

                koa = compLine.Length - ooa.Length;


                string aoa;
                
                aoa = compLine.Substring(0, koa);



                Delegate aa;

                aa = this.GetDelegate(aoa);


                if (aa == null)
                {
                    return false;
                }



                this.DelegateList.Add(aa);
            }


            if (!boa)
            {
                string oob;

                oob = " -";



                bool bob;

                bob = compLine.EndsWith(oob);



                string ka;

                ka = compLine;


                if (bob)
                {
                    int kob;

                    kob = compLine.Length - oob.Length;


                    ka = compLine.Substring(0, kob);
                }



                bool isStatic;

                isStatic = bob;



                bool isMethod;

                isMethod = ka.EndsWith(')');



                if (isMethod)
                {
                    Method oa;

                    oa = this.GetMethod(ka, isStatic);


                    if (oa == null)
                    {
                        return false;
                    }


                    List list;

                    list = this.MethodList;


                    if (isStatic)
                    {
                        list = this.StaticMethodList;
                    }


                    list.Add(oa);
                }


                if (!isMethod)
                {
                    Field ob;

                    ob = this.GetField(ka, isStatic);


                    if (ob == null)
                    {
                        return false;
                    }


                    List list;

                    list = this.FieldList;


                    if (isStatic)
                    {
                        list = this.StaticFieldList;
                    }


                    list.Add(ob);
                }
                    
            }
        }



        return true;
    }




    protected virtual bool EndCurrentClass()
    {
        if (this.Class == null)
        {
            return true;
        }



        this.Class.Field = this.CreateArray(this.FieldList);


        this.Class.Method = this.CreateArray(this.MethodList);


        this.Class.StaticField = this.CreateArray(this.StaticFieldList);


        this.Class.StaticMethod = this.CreateArray(this.StaticMethodList);


        this.Class.Delegate = this.CreateArray(this.DelegateList);




        if (this.Class.Name == "Stat")
        {
            this.Result.Stat = this.Class;
        }




        this.Class = null;


        this.FieldList = null;

        this.MethodList = null;

        this.StaticFieldList = null;

        this.StaticMethodList = null;

        this.DelegateList = null;



        return true;
    }



    protected virtual Array CreateArray(List list)
    {
        Iter iter;

        iter = list.IterCreate();


        list.IterSet(iter);
        


        int count;

        count = list.Count;


        Array a;

        a = new Array();

        a.Count = count;

        a.Init();


        int i;

        i = 0;


        while (i < count & iter.Next())
        {
            object o;

            o = iter.Value;


            a.Set(i, o);



            i = i + 1;
        }



        return a;
    }




    protected virtual Class GetClass(string a)
    {
        string ooo;

        ooo = " -";


        bool ba;

        ba = a.EndsWith(ooo);



        string name;

        name = a;


        if (ba)
        {
            int countA;

            countA = a.Length - ooo.Length;


            name = a.Substring(0, countA);
        }



        bool hasNew;

        hasNew = !ba;



        Class varClass;

        varClass = new Class();

        varClass.Init();

        varClass.Name = name;

        varClass.HasNew = hasNew;


        return varClass;
    }





    protected virtual Field GetField(string a, bool isStatic)
    {
        Field o;

        o = new Field();

        o.Init();

        o.Name = a;

        o.Static = isStatic;


        return o;
    }





    protected virtual Method GetMethod(string a, bool isStatic)
    {
        NameParamResult u;

        u = this.GetNameParamResult(a);


        if (u == null)
        {
            return null;
        }



        Method o;

        o = new Method();

        o.Init();

        o.Name = u.Name;

        o.Param = u.Param;

        o.Static = isStatic;


        return o;
    }






    protected virtual Delegate GetDelegate(string a)
    {
        NameParamResult u;

        u = this.GetNameParamResult(a);


        if (u == null)
        {
            return null;
        }


        Delegate o;

        o = new Delegate();

        o.Init();

        o.Name = u.Name;

        o.Param = u.Param;


        return o;
    }





    protected virtual NameParamResult GetNameParamResult(string a)
    {
        int paramEnd;

        paramEnd = a.Length - 1;


        if (paramEnd < 0)
        {
            return null;
        }


        int uu;

        uu = a.IndexOf('(');


        if (uu < 0)
        {
            return null;
        }


        int paramStart;

        paramStart = uu + 1;



        int nameStart;

        nameStart = 0;


        int nameEnd;

        nameEnd = uu;


        int nameCount;

        nameCount = nameEnd - nameStart;



        string name;

        name = a.Substring(nameStart, nameCount);



        int paramCount;

        paramCount = paramEnd - paramStart;



        string paramLine;

        paramLine = a.Substring(paramStart, paramCount);



        Array param;

        param = this.GetParam(paramLine);


        if (param == null)
        {
            return null;
        }



        NameParamResult o;

        o = new NameParamResult();

        o.Init();

        o.Name = name;

        o.Param = param;


        return o;
    }





    protected virtual Array GetParam(string a)
    {
        string[] u;

        u = null;



        bool b;

        b = (a.Length == 0);


        if (b)
        {
            u = new string[0];
        }


        if (!b)
        {
            u = a.Split(", ", StringSplitOption.None);
        }
        
        



        int count;

        count = u.Length;


        Array array;

        array = new Array();

        array.Count = count;

        array.Init();



        int i;

        i = 0;

        while (i < count)
        {
            string o;


            o = u[i];


            array.Set(i, o);



            i = i + 1;
        }



        return array;
    }





    protected virtual bool SetMethodArray()
    {
        ToolInfra infra;

        infra = ToolInfra.This;



        string ka;

        ka = infra.StorageTextRead("ToolData/MethodList.txt");



        Array lineArray;

        lineArray = infra.SplitLineList(ka);



        int count;

        count = lineArray.Count;



        Array array;

        array = new Array();

        array.Count = count;

        array.Init();




        int i;

        i = 0;


        while (i < count)
        {
            string line;


            line = (string)lineArray.Get(i);



            Method method;

            method = this.GetMethod(line, true);


            if (method == null)
            {
                return false;
            }



            array.Set(i, method);



            i = i + 1;
        }




        this.Result.Method = array;




        return true;
    }
}