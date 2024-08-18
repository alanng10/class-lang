namespace Z.Tool.PrusateGen;

class Read : ToolGen
{
    public virtual ReadResult Result { get; set; }

    protected virtual Table ClassTable { get; set; }
    protected virtual Class Class { get; set; }
    protected virtual List FieldList { get; set; }
    protected virtual List MaideList { get; set; }
    protected virtual List StaticFieldList { get; set; }
    protected virtual List StaticMaideList { get; set; }
    protected virtual List DelegateList { get; set; }

    public virtual long Execute()
    {
        this.Result = new ReadResult();
        this.Result.Init();

        bool b;

        b = this.SetClassTable();
        if (!b)
        {
            return 1;
        }

        b = this.SetMaideArray();
        if (!b)
        {
            return 2;
        }
        
        return 0;
    }

    protected virtual bool SetClassTable()
    {
        ToolInfra infra;
        infra = ToolInfra.This;

        String ka;
        ka = infra.StorageTextRead(this.S("ToolData/Prusate/ClassList.txt"));

        Array lineArray;        
        lineArray = this.TextSplitLineString(ka);

        Table table;
        table = infra.TableCreateStringCompare();

        this.ClassTable = table;

        long count;
        count = lineArray.Count;

        long i;
        i = 0;
        while (i < count)
        {
            String line;
            line = (String)lineArray.GetAt(i);

            bool b;
            b = this.SetClassArrayOneLine(line);

            if (!b)
            {
                return false;
            }
            i = i + 1;
        }

        this.EndCurrentClass();

        this.Result.Class = this.ClassTable;
        return true;
    }

    protected virtual bool SetClassArrayOneLine(String line)
    {
        if (this.StringComp.Count(line) == 0)
        {
            return true;
        }

        Text k;
        k = this.TextCreate(line);

        Text oo;
        oo = this.TextCreate(this.S("    "));

        bool b;
        b =  this.TextStart(k, oo);

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

            if (this.ClassTable.Valid(this.Class.Name))
            {
                return false;
            }

            this.ListInfra.TableAdd(this.ClassTable, this.Class.Name, this.Class);


            this.FieldList = new List();
            this.FieldList.Init();


            this.MaideList = new List();
            this.MaideList.Init();


            this.StaticFieldList = new List();
            this.StaticFieldList.Init();


            this.StaticMaideList = new List();
            this.StaticMaideList.Init();


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
                    Maide oa;

                    oa = this.GetMethod(ka, isStatic);


                    if (oa == null)
                    {
                        return false;
                    }


                    List list;

                    list = this.MaideList;


                    if (isStatic)
                    {
                        list = this.StaticMaideList;
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

        this.Class.Field = this.ListInfra.ArrayCreateList(this.FieldList);
        this.Class.Maide = this.ListInfra.ArrayCreateList(this.MaideList);
        this.Class.StaticField = this.ListInfra.ArrayCreateList(this.StaticFieldList);
        this.Class.StaticMaide = this.ListInfra.ArrayCreateList(this.StaticMaideList);
        this.Class.Delegate = this.ListInfra.ArrayCreateList(this.DelegateList);
        this.Class = null;
        this.FieldList = null;
        this.MaideList = null;
        this.StaticFieldList = null;
        this.StaticMaideList = null;
        this.DelegateList = null;
        return true;
    }

    protected virtual Class GetClass(String line)
    {
        Text k;
        k = this.TextCreate(line);

        Text ooo;
        ooo = this.TextCreate(this.S(" -"));

        bool ba;
        ba = this.TextEnd(k, ooo);

        String name;
        name = null;

        if (!ba)
        {
            name = line;
        }

        if (ba)
        {
            long countA;
            countA = k.Range.Count - ooo.Range.Count;

            k.Range.Count = countA;

            name = this.StringCreate(k);
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

    protected virtual Field GetField(String o, bool isStatic)
    {
        Field a;
        a = new Field();
        a.Init();
        a.Name = o;
        a.Static = isStatic;
        return a;
    }





    protected virtual Maide GetMethod(string a, bool isStatic)
    {
        NameParamResult u;

        u = this.GetNameParamResult(a);


        if (u == null)
        {
            return null;
        }



        Maide o;

        o = new Maide();

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


            array.SetAt(i, o);



            i = i + 1;
        }



        return array;
    }





    protected virtual bool SetMaideArray()
    {
        ToolInfra infra;

        infra = ToolInfra.This;



        string ka;

        ka = infra.StorageTextRead("ToolData/Prusate/MaideList.txt");



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


            line = (string)lineArray.GetAt(i);



            Maide method;

            method = this.GetMethod(line, true);


            if (method == null)
            {
                return false;
            }



            array.SetAt(i, method);



            i = i + 1;
        }




        this.Result.Maide = array;




        return true;
    }
}