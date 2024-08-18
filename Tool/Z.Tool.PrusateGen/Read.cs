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
        long lineCount;
        lineCount = this.StringCount(line);

        if (lineCount == 0)
        {
            return true;
        }

        Text k;
        k = this.TextCreate(line);

        String oo;
        oo = this.S("    ");

        Text ook;
        ook = this.TextCreate(oo);

        bool b;
        b =  this.TextStart(k, ook);

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
            long ooCount;
            ooCount = this.StringCount(oo);

            String compLine;
            compLine = this.StringCreateIndex(line, ooCount);

            String ooa;
            ooa = this.S(" --");

            Text ooak;
            ooak = this.TextCreate(ooa);

            Text textCompLine;
            textCompLine = this.TextCreate(compLine);

            long compLineCount;
            compLineCount = this.StringCount(compLine);

            bool boa;
            boa = this.TextEnd(textCompLine, ooak);
            if (boa)
            {
                long ooaCount;
                ooaCount = ooak.Range.Count;

                long koa;
                koa = compLineCount - ooaCount;

                String aoa;
                aoa = this.StringCreateRange(compLine, 0, koa);

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
                String oob;
                oob = this.S(" -");

                Text oobk;
                oobk = this.TextCreate(oob);

                bool bob;
                bob = this.TextEnd(textCompLine, oobk);

                String ka;
                ka = compLine;

                if (bob)
                {
                    long kob;
                    kob = compLineCount - this.StringCount(oob);

                    ka = this.StringCreateRange(compLine, 0, kob);
                }

                bool isStatic;
                isStatic = bob;

                Text rightBracket;
                rightBracket = this.TextCreate(this.S(")"));

                Text textKa;
                textKa = this.TextCreate(ka);

                bool isMethod;
                isMethod = this.TextEnd(textKa, rightBracket);

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

    protected virtual Maide GetMethod(String o, bool isStatic)
    {
        NameParamResult u;
        u = this.GetNameParamResult(o);

        if (u == null)
        {
            return null;
        }

        Maide a;
        a = new Maide();
        a.Init();
        a.Name = u.Name;
        a.Param = u.Param;
        a.Static = isStatic;
        return a;
    }

    protected virtual Delegate GetDelegate(String o)
    {
        NameParamResult u;
        u = this.GetNameParamResult(o);

        if (u == null)
        {
            return null;
        }

        Delegate a;
        a = new Delegate();
        a.Init();
        a.Name = u.Name;
        a.Param = u.Param;
        return a;
    }

    protected virtual NameParamResult GetNameParamResult(String o)
    {
        long paramEnd;
        paramEnd = this.StringComp.Count(o) - 1;

        if (paramEnd < 0)
        {
            return null;
        }

        Text k;
        k = this.TextCreate(o);

        Text leftBracket;
        leftBracket = this.TextCreate(this.S("("));

        long uu;
        uu = this.TextIndex(k, leftBracket);

        if (uu < 0)
        {
            return null;
        }

        long paramStart;
        paramStart = uu + 1;

        long nameStart;
        long nameEnd;
        nameStart = 0;
        nameEnd = uu;

        long nameCount;
        nameCount = nameEnd - nameStart;

        Range range;
        range = new Range();
        range.Init();
        range.Index = nameStart;
        range.Count = nameCount;

        String name;
        name = this.StringComp.CreateString(o, range);

        long paramCount;
        paramCount = paramEnd - paramStart;

        range.Index = paramStart;
        range.Count = paramCount;

        String paramLine;
        paramLine = this.StringComp.CreateString(o, range);

        Array param;
        param = this.GetParam(paramLine);

        if (param == null)
        {
            return null;
        }

        NameParamResult a;
        a = new NameParamResult();
        a.Init();
        a.Name = name;
        a.Param = param;
        return a;
    }

    protected virtual Array GetParam(String o)
    {
        Text k;
        k = this.TextCreate(o);

        Text delimit;
        delimit = this.TextCreate(this.S(", "));

        Array array;
        array = this.TextSplit(k, delimit);

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            Text aa;
            aa = (Text)array.GetAt(i);

            String a;
            a = this.StringCreate(aa);

            array.SetAt(i, a);
        
            i = i + 1;
        }

        return array;
    }

    protected virtual bool SetMaideArray()
    {
        ToolInfra toolInfra;
        toolInfra = ToolInfra.This;

        String ka;
        ka = toolInfra.StorageTextRead(this.S("ToolData/Prusate/MaideList.txt"));

        Array lineArray;
        lineArray = this.TextSplitLineString(ka);

        long count;
        count = lineArray.Count;

        Array array;
        array = this.ListInfra.ArrayCreate(count);

        long i;
        i = 0;
        while (i < count)
        {
            String line;
            line = (String)lineArray.GetAt(i);

            Maide maide;
            maide = this.GetMethod(line, true);

            if (maide == null)
            {
                return false;
            }

            array.SetAt(i, maide);

            i = i + 1;
        }

        this.Result.Maide = array;
        return true;
    }
}