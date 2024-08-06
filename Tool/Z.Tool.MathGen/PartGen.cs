namespace Z.Tool.MathGen;

class PartGen : Any
{
    public override bool Init()
    {
        base.Init();
        this.ToolInfra = ToolInfra.This;
        return true;
    }

    public virtual Table Maide { get; set; }
    protected virtual ToolInfra ToolInfra { get; set; }
    protected virtual string PartFilePath { get; set; }
    protected virtual string MaideFilePath { get; set; }
    protected virtual string MaideTwoFilePath { get; set; }
    protected virtual string MaideOperateFilePath { get; set; }
    protected virtual string TextPart { get; set; }
    protected virtual string TextMaide { get; set; }
    protected virtual string TextMaideTwo { get; set; }
    protected virtual string TextMaideOperate { get; set; }
    protected virtual string OutputFilePath { get; set; }

    public virtual bool Execute()
    {
        ToolInfra toolInfra;
        toolInfra = this.ToolInfra;

        this.TextPart = toolInfra.StorageTextRead(this.PartFilePath);
        this.TextMaide = toolInfra.StorageTextRead(this.MaideFilePath);
        this.TextMaideTwo = toolInfra.StorageTextRead(this.MaideTwoFilePath);
        this.TextMaideOperate = toolInfra.StorageTextRead(this.MaideOperateFilePath);

        string k;
        k = this.GetPart();

        string ka;
        ka = this.TextPart;
        ka = ka.Replace("#Part#", k);

        toolInfra.StorageTextWrite(this.OutputFilePath, ka);

        return true;
    }

    protected virtual string GetPart()
    {
        ToolInfra toolInfra;
        toolInfra = this.ToolInfra;

        StringJoin h;
        h = new StringJoin();
        h.Init();

        bool ba;
        ba = false;

        Iter iter;
        iter = this.Maide.IterCreate();
        this.Maide.IterSet(iter);

        while (iter.Next())
        {
            if (ba)
            {
                this.AppendNewLine(h);
            }

            Maide aa;
            aa = (Maide)iter.Value;

            string a;
            a = this.MaideString(aa);

            toolInfra.Append(h, a);
            
            ba = true;
        }

        string k;
        k = h.Result();

        return k;
    }

    protected virtual bool AppendNewLine(StringJoin h)
    {
        ToolInfra toolInfra;
        toolInfra = this.ToolInfra;

        string newLine;
        newLine = toolInfra.NewLine;

        toolInfra.Append(h, newLine);
        return true;
    }

    protected virtual string MaideString(Maide maide)
    {
        string name;
        name = maide.Name;

        string delimit;
        delimit = maide.OperateDelimit;

        bool b;
        b = maide.OperandTwo;

        bool ba;
        ba = (delimit == null);

        string k;
        k = null;

        string func;
        func = null;

        if (ba)
        {
            if (!b)
            {
                k = this.TextMaide;
            }

            if (b)
            {
                k = this.TextMaideTwo;
            }

            delimit = "";

            func = this.FuncLibName(name);
        }

        if (!ba)
        {
            k = this.TextMaideOperate;

            func = "";
        }

        k = k.Replace("#Name#", name);
        k = k.Replace("#Func#", func);
        k = k.Replace("#Delimit#", delimit);

        return k;
    }

    protected virtual string FuncLibName(string name)
    {
        return name;
    }
}