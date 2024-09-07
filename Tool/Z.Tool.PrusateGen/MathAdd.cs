namespace Z.Tool.PrusateGen;

class MathAdd : ToolBase
{
    public virtual ReadResult ReadResult { get; set; }
    protected virtual Table MaideTable { get; set; }

    public virtual bool Execute()
    {
        MathRead read;
        read = new MathRead();
        read.Init();

        long o;
        o = read.Execute();

        if (!(o == 0))
        {
            return false;
        }

        this.MaideTable = read.MaideTable;

        read.MaideTable = null;
        
        bool b;
        b = this.SetMathClass();
        if (!b)
        {
            return false;
        }

        return true;
    }

    protected virtual bool SetMathClass()
    {
        Class mathClass;
        mathClass = (Class)this.ReadResult.Class.Get(this.S("Math"));

        if (mathClass == null)
        {
            return false;
        }

        long ka;
        ka = mathClass.Maide.Count;

        long kb;
        kb = this.MaideTable.Count;

        long k;
        k = ka;
        k = k + kb;

        Array array;
        array = new Array();
        array.Count = k;
        array.Init();

        long count;
        count = ka;
        long i;
        i = 0;
        while (i < count)
        {
            Maide method;
            method = (Maide)mathClass.Maide.GetAt(i);

            array.SetAt(i, method);

            i = i + 1;
        }

        Iter iter;
        iter = this.MaideTable.IterCreate();
        this.MaideTable.IterSet(iter);

        long start;
        start = ka;

        count = kb;
        i = 0;
        while (i < count)
        {
            iter.Next();

            MathMaide mathMaide;
            mathMaide = (MathMaide)iter.Value;

            Maide maide;
            maide = this.CreateMaide(mathMaide);

            long index;
            index = start + i;

            array.SetAt(index, maide);

            i = i + 1;
        }

        mathClass.Maide = array;
        return true;
    }

    protected virtual Maide CreateMaide(MathMaide mathMaide)
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        Array param;
        param = this.CreateParam(mathMaide.OperandTwo);

        Maide a;
        a = new Maide();
        a.Init();
        a.Name = mathMaide.Name;
        a.Param = param;
        return a;
    }

    protected virtual Array CreateParam(bool operandTwo)
    {
        int count;
        count = 1;

        bool b;
        b = operandTwo;

        if (b)
        {
            count = 2;
        }

        Array param;
        param = this.ListInfra.ArrayCreate(count);

        if (!b)
        {
            param.SetAt(0, this.S("value"));
        }

        if (b)
        {
            param.SetAt(0, this.S("valueA"));
            param.SetAt(1, this.S("valueB"));
        }

        return param;
    }
}