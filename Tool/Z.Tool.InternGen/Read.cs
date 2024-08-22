namespace Z.Tool.InternGen;

public class Read : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.ClassInfra = ClassInfra.This;
        this.ToolInfra = ToolInfra.This;

        CompareMid charCompare;
        charCompare = new CompareMid();
        charCompare.Init();
        CharForm charForm;
        charForm = new CharForm();
        charForm.Init();
        TextCompare compare;
        compare = new TextCompare();
        compare.CharCompare = charCompare;
        compare.LeftCharForm = charForm;
        compare.RightCharForm = charForm;
        compare.Init();

        this.NameCheck = new NameCheck();
        this.NameCheck.Init();
        this.NameCheck.TextCompare = compare;
        this.NameCheck.CharCompare = charCompare;
        this.NameCheck.CharForm = charForm;

        this.TextA = this.CreateText();
        this.StringDataA = new StringData();
        this.StringDataA.Init();
        return true;
    }

    private Text CreateText()
    {
        Text a;
        a = new Text();
        a.Init();
        a.Range = new Range();
        a.Range.Init();
        return a;
    }

    public virtual int Execute()
    {
        bool b;

        b = this.SetMaideTable();

        if (!b)
        {
            return 300;
        }

        return 0;
    }

    public virtual Table MaideTable { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual ToolInfra ToolInfra { get; set; }
    protected virtual NameCheck NameCheck { get; set; }
    protected virtual Text TextA { get; set; }
    protected virtual StringData StringDataA { get; set; }

    protected virtual bool SetMaideTable()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;
        ToolInfra toolInfra;
        toolInfra = this.ToolInfra;

        string ka;
        ka = toolInfra.StorageTextRead("ToolData/Intern/MaideList.txt");

        Array lineArray;        
        lineArray = toolInfra.SplitLineList(ka);

        Table table;
        table = this.ClassInfra.TableCreateStringLess();
        this.MaideTable = table;

        int count;
        count = lineArray.Count;
        int i;
        i = 0;
        while (i < count)
        {
            string line;
            line = (string)lineArray.GetAt(i);

            Maide maide;
            maide = this.GetMaide(line);
            if (maide == null)
            {
                return false;
            }

            if (table.Valid(maide.Name))
            {
                return false;
            }
            
            listInfra.TableAdd(table, maide.Name, maide);

            i = i + 1;
        }

        return true;
    }


    protected virtual Maide GetMaide(string o)
    {
        int uu;
        uu = o.IndexOf('|');

        if (uu < 0)
        {
            return null;
        }

        string ka;
        string kb;
        ka = o.Substring(0, uu);
        kb = o.Substring(uu + 1);

        int ua;
        ua = ka.IndexOf(' ');
        if (ua < 0)
        {
            return null;
        }

        string className;
        string maideName;

        className = ka.Substring(0, ua);
        if (!this.CheckIsName(className))
        {
            return null;
        }

        maideName = ka.Substring(ua + 1);

        if (!this.CheckIsName(maideName))
        {
            return null;
        }
        
        Table param;
        param = this.GetParam(kb);

        if (param == null)
        {
            return null;
        }

        Maide a;
        a = new Maide();
        a.Init();
        a.Class = className;
        a.Name = maideName;
        a.Param = param;
        return a;
    }

    protected virtual Table GetParam(string o)
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        Table table;
        table = this.ClassInfra.TableCreateStringLess();

        string[] u;
        u = o.Split(", ");
        
        if (u == null)
        {
            return table;
        }

        int count;
        count = u.Length;
        int i;
        i = 0;
        while (i < count)
        {
            string ka;
            ka = u[i];

            int ua;
            ua = ka.IndexOf(' ');

            if (ua < 0)
            {
                return null;
            }

            string className;
            string varName;
            className = ka.Substring(0, ua);
        
            if (!this.CheckIsName(className))
            {
                return null;
            }

            varName = ka.Substring(ua + 1);

            if (!this.CheckIsName(varName))
            {
                return null;
            }

            if (table.Valid(varName))
            {
                return null;
            }

            Var a;
            a = new Var();
            a.Init();
            a.Class = className;
            a.Name = varName;

            listInfra.TableAdd(table, varName, a);

            i = i + 1;
        }

        return table;
    }

    protected virtual bool CheckIsName(string value)
    {
        NameCheck nameCheck;
        nameCheck = this.NameCheck;

        Text textA;
        textA = this.TextA;
        StringData stringDataA;
        stringDataA = this.StringDataA;

        this.TextStringGet(textA, stringDataA, value);

        return nameCheck.IsName(textA);
    }

    protected virtual bool TextStringGet(Text text, StringData data, string o)
    {
        data.ValueString = o;

        text.Data = data;
        text.Range.Index = 0;
        text.Range.Count = o.Length;
        return true;
    }
}