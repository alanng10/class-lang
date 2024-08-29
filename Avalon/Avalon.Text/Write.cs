namespace Avalon.Text;

public class Write : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.TextInfra = Infra.This;
        this.StringComp = StringComp.This;

        this.InitCountState();
        this.InitResultState();
        return true;
    }

    public virtual CharForm CharForm { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual Infra TextInfra { get; set; }
    protected virtual StringComp StringComp { get; set; }
    protected virtual long KindCount { get { return 3; } set { } }
    protected virtual Array CountState { get; set; }
    protected virtual Array ResultState { get; set; }
    protected virtual Array Array { get; set; }
    protected virtual long ArrayIndex { get; set; }

    protected virtual bool InitCountState()
    {
        this.CountState = new Array();
        this.CountState.Count = this.KindCount;
        this.CountState.Init();

        this.Array = this.CountState;
        this.ArrayIndex = 0;

        this.CountStateAdd(new BoolWriteCountState());
        this.CountStateAdd(new IntWriteCountState());
        this.CountStateAdd(new TextWriteCountState());
        return true;
    }

    protected virtual bool InitResultState()
    {
        this.ResultState = new Array();
        this.ResultState.Count = this.KindCount;
        this.ResultState.Init();

        this.Array = this.ResultState;
        this.ArrayIndex = 0;

        this.ResultStateAdd(new BoolWriteResultState());
        this.ResultStateAdd(new IntWriteResultState());
        this.ResultStateAdd(new TextWriteResultState());
        return true;
    }

    protected virtual bool CountStateAdd(WriteCountState state)
    {
        state.Write = this;
        state.Init();
        this.ArrayAdd(state);
        return true;
    }

    protected virtual bool ResultStateAdd(WriteResultState state)
    {
        state.Format = this;
        state.Init();
        this.ArrayAdd(state);
        return true;
    }

    protected virtual bool ArrayAdd(object item)
    {
        long index;
        index = this.ArrayIndex;
        this.Array.SetAt(index, item);
        index = index + 1;
        this.ArrayIndex = index;
        return true;
    }

    public virtual long ExecuteCount(Text varBase, Array argList)
    {
        long count;
        count = argList.Count;
        long k;
        k = 0;
        long i;
        i = 0;
        while (i < count)
        {
            WriteArg arg;
            arg = (WriteArg)argList.GetAt(i);

            this.ExecuteArgCount(arg);

            long ka;
            ka = arg.Count;

            k = k + ka;

            i = i + 1;
        }

        long baseCount;
        baseCount = varBase.Range.Count;

        k = k + baseCount;

        long a;
        a = k;
        return a;
    }

    public virtual bool ExecuteResult(Text varBase, Array argList, Text result)
    {
        Infra textInfra;
        textInfra = this.TextInfra;
        if (!textInfra.ValidRange(varBase))
        {
            return false;
        }
        if (!textInfra.ValidRange(result))
        {
            return false;
        }

        Data baseData;
        baseData = varBase.Data;
        Range baseRange;
        baseRange = varBase.Range;
        long baseStart;
        baseStart = baseRange.Index;
        long baseCount;
        baseCount = baseRange.Count;

        long argCount;
        argCount = argList.Count;

        Data resultData;
        resultData = result.Data;
        Range resultRange;
        resultRange = result.Range;
        long resultStart;
        resultStart = resultRange.Index;
        long resultCount;
        resultCount = resultRange.Count;

        long count;
        count = baseCount + 1;
        long resultIndex;
        resultIndex = 0;
        long argIndex;
        argIndex = 0;
        long i;
        i = 0;
        while (i < count)
        {
            bool b;
            b = false;

            while ((!b) & (argIndex < argCount))
            {
                WriteArg arg;
                arg = (WriteArg)argList.GetAt(argIndex);

                long k;
                k = arg.Pos;

                bool ba;
                ba = (i == k);
                if (ba)
                {
                    long countA;
                    countA = arg.Count;

                    long oa;
                    oa = resultStart + resultIndex;
                    resultRange.Index = oa;
                    resultRange.Count = countA;
                    
                    this.ExecuteArgResult(arg, result);

                    resultRange.Index = resultStart;
                    resultRange.Count = resultCount;

                    resultIndex = resultIndex + countA;

                    argIndex = argIndex + 1;
                }
                if (!ba)
                {
                    b = true;
                }
            }

            if (!(i == baseCount))
            {
                uint oc;
                oc = textInfra.DataCharGet(baseData, baseStart + i);

                textInfra.DataCharSet(resultData, resultStart + resultIndex, oc);
                
                resultIndex = resultIndex + 1;
            }

            i = i + 1;
        }
        return true;
    }

    public virtual bool ExecuteArgCount(WriteArg arg)
    {
        if (!this.ValidArg(arg))
        {
            return false;
        }

        long kind;
        kind = arg.Kind;
        WriteCountState state;
        state = (WriteCountState)this.CountState.GetAt(kind);

        state.Arg = arg;
        state.Execute();

        Value aa;
        aa = (Value)state.Result;

        long valueCount;
        valueCount = aa.Int;

        long fieldWidth;
        fieldWidth = arg.FieldWidth;

        long maxWidth;
        maxWidth = arg.MaxWidth;

        long u;
        u = maxWidth;
        u = u << 4;
        u = u >> 4;

        long count;
        count = valueCount;

        if (count < fieldWidth)
        {
            count = fieldWidth;
        }

        if (!(u == -1))
        {
            if (maxWidth < count)
            {
                count = maxWidth;
            }
        }

        arg.ValueCount = valueCount;
        arg.Count = count;
        return true;
    }

    public virtual bool ExecuteArgResult(WriteArg arg, Text result)
    {
        if (!this.ValidArg(arg))
        {
            return false;
        }
        if (!this.TextInfra.ValidRange(result))
        {
            return false;
        }
        if (result.Range.Count < arg.Count)
        {
            return false;
        }

        long kind;
        kind = arg.Kind;
        WriteResultState state;
        state = (WriteResultState)this.ResultState.GetAt(kind);

        WriteResultArg ke;
        ke = (WriteResultArg)state.Arg;
        ke.Arg = arg;
        ke.Result = result;
        state.Execute();
        return true;
    }

    public virtual bool ResultBool(Text result, bool value, long varCase, long valueWriteCount, long valueStart, long valueIndex)
    {
        Infra textInfra;
        textInfra = this.TextInfra;

        StringComp stringComp;
        stringComp = this.StringComp;
        CharForm charForm;
        charForm = this.CharForm;

        Data destData;
        destData = result.Data;
        long destStart;
        destStart = result.Range.Index;

        String source;
        source = null;
        if (!value)
        {
            source = textInfra.BoolFalseString;
        }
        if (value)
        {
            source = textInfra.BoolTrueString;
        }

        long destIndex;
        destIndex = destStart + valueStart;
        long count;
        count = valueWriteCount;
        long i;
        i = 0;
        while (i < count)
        {
            long index;
            index = i + valueIndex;

            uint ouc;
            ouc = (uint)stringComp.Char(source, index);
            long aa;
            aa = ouc;

            if (varCase == 1)
            {
                if (index == 0)
                {
                    aa = ouc - 'a' + 'A';
                }
            }
            if (varCase == 2)
            {
                aa = ouc - 'a' + 'A';
            }
            uint oc;
            oc = (uint)aa;

            oc = (uint)charForm.Execute(oc);

            textInfra.DataCharSet(destData, destIndex + i, oc);

            i = i + 1;
        }
        return true;
    }

    public virtual bool ResultInt(Text result, ulong value, long varBase, long varCase, long valueCount, long valueWriteCount, long valueStart, long valueIndex)
    {
        Infra textInfra;
        textInfra = this.TextInfra;

        CharForm charForm;
        charForm = this.CharForm;

        Data destData;
        destData = result.Data;
        long destStart;
        destStart = result.Range.Index;

        long destIndex;
        destIndex = destStart + valueStart;

        if (value == 0)
        {
            if (!(valueWriteCount == 0))
            {
                uint occ;
                occ = '0';

                occ = (uint)charForm.Execute(occ);

                textInfra.DataCharSet(destData, destIndex, occ);
            }
            return true;
        }

        long end;
        end = valueIndex + valueWriteCount;

        bool upperCase;
        upperCase = !(varCase == 0);
        
        uint letterDigitStart;
        letterDigitStart = 'a';
        if (upperCase)
        {
            letterDigitStart = 'A';
        }
        
        ulong ca;
        ca = (ulong)varBase;
        ulong k;
        k = value;

        long index;
        index = 0;
        long count;
        count = valueCount;
        long i;
        i = 0;
        while (i < count)
        {
            ulong j;
            j = k / ca;

            index = count - 1 - i;

            if ((!(index < valueIndex)) & index < end)
            {
                ulong ka;
                ka = k - j * ca;

                long digit;
                digit = (long)ka;

                uint c;
                c = textInfra.DigitChar(digit, letterDigitStart);

                c = (uint)charForm.Execute(c);

                long oa;
                oa = index - valueIndex;

                textInfra.DataCharSet(destData, destIndex + oa, c);
            }

            k = j;

            i = i + 1;
        }
        return true;
    }

    public virtual bool ResultText(Text result, Text value, long varCase, long valueWriteCount, long valueStart, long valueIndex)
    {
        Infra textInfra;
        textInfra = this.TextInfra;

        CharForm charForm;
        charForm = this.CharForm;

        Data sourceData;
        sourceData = value.Data;
        long sourceStart;
        sourceStart = value.Range.Index;

        Data destData;
        destData = result.Data;
        long destStart;
        destStart = result.Range.Index;

        long sourceIndex;
        sourceIndex = sourceStart + valueIndex;
        long destIndex;
        destIndex = destStart + valueStart;

        long count;
        count = valueWriteCount;
        long i;
        i = 0;
        while (i < count)
        {
            uint ouc;
            ouc = textInfra.DataCharGet(sourceData, sourceIndex + i);

            long aa;
            aa = ouc;

            if (varCase == 1)
            {
                if (textInfra.IsLetter(ouc, true))
                {
                    aa = ouc - 'A' + 'a';
                }
            }
            if (varCase == 2)
            {
                if (textInfra.IsLetter(ouc, false))
                {
                    aa = ouc - 'a' + 'A';
                }
            }

            uint oc;
            oc = (uint)aa;

            oc = (uint)charForm.Execute(oc);

            textInfra.DataCharSet(destData, destIndex + i, oc);

            i = i + 1;
        }
        return true;
    }

    public virtual bool ResultFill(Text dest, long fillIndex, long fillCount, long fillChar)
    {
        Infra textInfra;
        textInfra = this.TextInfra;
        Data destData;
        destData = dest.Data;
        long destStart;
        destStart = dest.Range.Index;
        long destIndex;
        destIndex = destStart + fillIndex;
        long count;
        count = fillCount;
        long i;
        i = 0;
        while (i < count)
        {
            long index;
            index = destIndex + i;
            textInfra.DataCharSet(destData, index, fillChar);
            i = i + 1;
        }
        return true;
    }

    public virtual long IntDigitCount(ulong value, long varBase)
    {
        long digitCount;
        digitCount = 0;

        ulong ca;
        ca = (ulong)varBase;
        ulong oa;
        oa = value;
        while (0 < oa)
        {
            oa = oa / ca;
            digitCount = digitCount + 1;
        }

        if (digitCount == 0)
        {
            digitCount = 1;
        }

        long a;
        a = digitCount;
        return a;
    }

    public virtual bool ValidArg(WriteArg arg)
    {
        long kind;
        kind = arg.Kind;

        if (!this.ValidKind(kind))
        {
            return false;
        }

        if (kind == 1 | kind == 2)
        {
            if (!this.ValidIntBase(arg.Base))
            {
                return false;
            }
        }
        if (kind == 3)
        {
            object aa;
            aa = arg.Value.Any;
            if (aa == null)
            {
                return false;
            }
            if (!(aa is Text))
            {
                return false;
            }

            Text text;
            text = (Text)aa;
            if (!this.TextInfra.ValidRange(text))
            {
                return false;
            }
        }
        return true;
    }

    public virtual bool ValidKind(long kind)
    {
        return this.InfraInfra.ValidIndex(this.KindCount, kind);
    }

    public virtual bool ValidIntBase(long varBase)
    {
        return !(varBase < 2 | 16 < varBase);
    }
}