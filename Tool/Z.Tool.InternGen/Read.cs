namespace Z.Tool.InternGen;

public class Read : ToolBase
{
    public override bool Init()
    {
        base.Init();
        this.ClassInfra = ClassInfra.This;

        this.NameCheck = new NameCheck();
        this.NameCheck.Init();
        this.NameCheck.TextLess = this.ToolInfra.TextLess;
        this.NameCheck.CharLess = this.ToolInfra.CharLess;
        this.NameCheck.CharForm = this.ToolInfra.TextForm;

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

    public virtual long Execute()
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
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual NameCheck NameCheck { get; set; }
    protected virtual Text TextA { get; set; }
    protected virtual StringData StringDataA { get; set; }

    protected virtual bool SetMaideTable()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;
        ToolInfra toolInfra;
        toolInfra = this.ToolInfra;

        String ka;
        ka = toolInfra.StorageTextRead(this.S("ToolData/Intern/MaideList.txt"));

        Array lineArray;        
        lineArray = toolInfra.TextLimitLineString(ka);

        Table table;
        table = this.ClassInfra.TableCreateStringLess();
        this.MaideTable = table;

        long count;
        count = lineArray.Count;
        long i;
        i = 0;
        while (i < count)
        {
            String line;
            line = (String)lineArray.GetAt(i);

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


    protected virtual Maide GetMaide(String o)
    {
        Text kkk;
        kkk = this.TextCreate(this.S("|"));
        
        Text k;
        k = this.TextCreate(o);

        long uu;
        uu = this.TextIndex(k, kkk);

        if (uu < 0)
        {
            return null;
        }

        String ka;
        ka = this.StringCreateTextRange(k, 0, uu);
        
        String paramLine;
        paramLine = this.StringCreateTextIndex(k, uu + kkk.Range.Count);

        Text kka;
        kka = this.TextCreate(this.S(" "));

        Text kaa;
        kaa = this.TextCreate(ka);

        long ua;
        ua = this.TextIndex(kaa, kka);
        if (ua < 0)
        {
            return null;
        }

        String className;
        String maideName;

        className = this.StringCreateTextRange(kaa, 0, ua);

        if (!this.ValidIsName(className))
        {
            return null;
        }

        maideName = this.StringCreateTextIndex(kaa, ua + kka.Range.Count);

        if (!this.ValidIsName(maideName))
        {
            return null;
        }
        
        Table param;
        param = this.GetParam(paramLine);

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

    protected virtual Table GetParam(String o)
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        Table table;
        table = this.ClassInfra.TableCreateStringLess();

        Text k;
        k = this.TextCreate(o);

        if (k.Range.Count == 0)
        {
            return table;
        }

        Text limit;
        limit = this.TextCreate(this.S(", "));

        Array u;
        u = this.TextLimit(k, limit);

        Text kka;
        kka = this.TextCreate(this.S(" "));

        long count;
        count = u.Count;
        long i;
        i = 0;
        while (i < count)
        {
            Text ka;
            ka = (Text)u.GetAt(i);

            long ua;
            ua = this.TextIndex(ka, kka);

            if (ua < 0)
            {
                return null;
            }

            String className;
            String varName;

            className = this.StringCreateTextRange(ka, ka.Range.Index, ua);
        
            if (!this.ValidIsName(className))
            {
                return null;
            }

            varName = this.StringCreateTextIndex(ka, ka.Range.Index + ua + kka.Range.Count);

            if (!this.ValidIsName(varName))
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

    protected virtual bool ValidIsName(String value)
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

    protected virtual bool TextStringGet(Text text, StringData data, String o)
    {
        data.ValueString = o;

        text.Data = data;
        text.Range.Index = 0;
        text.Range.Count = this.StringComp.Count(o);
        return true;
    }
}