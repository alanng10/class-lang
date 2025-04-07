namespace Z.Tool.MathGen;

class PartGen : ToolBase
{
    public virtual Table Maide { get; set; }
    protected virtual String PartFilePath { get; set; }
    protected virtual String MaideFilePath { get; set; }
    protected virtual String MaideTwoFilePath { get; set; }
    protected virtual String MaideOperateFilePath { get; set; }
    protected virtual String TextPart { get; set; }
    protected virtual String TextMaide { get; set; }
    protected virtual String TextMaideTwo { get; set; }
    protected virtual String TextMaideOperate { get; set; }
    protected virtual String OutputFilePath { get; set; }

    public virtual bool Execute()
    {
        this.TextPart = this.StorageTextRead(this.PartFilePath);
        this.TextMaide = this.StorageTextRead(this.MaideFilePath);
        this.TextMaideTwo = this.StorageTextRead(this.MaideTwoFilePath);
        this.TextMaideOperate = this.StorageTextRead(this.MaideOperateFilePath);

        String ka;
        ka = this.GetPart();

        Text k;
        k = this.TextCreate(this.TextPart);
        k = this.Place(k, "#Part#", ka);

        String a;
        a = this.StringCreate(k);

        this.StorageTextWrite(this.OutputFilePath, a);
        return true;
    }

    protected virtual String GetPart()
    {
        this.AddClear();

        bool ba;
        ba = false;

        Iter iter;
        iter = this.Maide.IterCreate();
        this.Maide.IterSet(iter);

        while (iter.Next())
        {
            if (ba)
            {
                this.AddNewLine();
            }

            Maide aa;
            aa = iter.Value as Maide;

            String a;
            a = this.MaideString(aa);

            this.Add(a);
            
            ba = true;
        }

        String k;
        k = this.AddResult();
        return k;
    }

    protected virtual bool AddNewLine()
    {
        this.AddLine();
        return true;
    }

    protected virtual String MaideString(Maide maide)
    {
        String name;
        name = maide.Name;

        String delimit;
        delimit = maide.OperateDelimit;

        String empty;
        empty = this.S("");

        bool b;
        b = maide.OperandTwo;

        bool ba;
        ba = (delimit == null);

        String ka;
        ka = null;

        String func;
        func = null;

        if (ba)
        {
            if (!b)
            {
                ka = this.TextMaide;
            }

            if (b)
            {
                ka = this.TextMaideTwo;
            }

            delimit = empty;

            func = this.FuncLibName(name);
        }

        if (!ba)
        {
            ka = this.TextMaideOperate;

            func = empty;
        }

        Text k;
        k = this.TextCreate(ka);
        k = this.Place(k, "#Name#", name);
        k = this.Place(k, "#Func#", func);
        k = this.Place(k, "#Delimit#", delimit);

        String a;
        a = this.StringCreate(k);
        return a;
    }

    protected virtual String FuncLibName(String name)
    {
        return name;
    }
}