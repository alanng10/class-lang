namespace Avalon.Text;

public class Format : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.TextInfra = Infra.This;

        this.InitCountState();
        this.InitResultState();
        return true;
    }

    public virtual CharForm CharForm { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual Infra TextInfra { get; set; }
    protected virtual int KindCount { get { return 5; } set { } }
    protected virtual Array CountState { get; set; }
    protected virtual Array ResultState { get; set; }
    protected virtual Array Array { get; set; }
    protected virtual int ArrayIndex { get; set; }

    protected virtual bool InitCountState()
    {
        this.CountState = new Array();
        this.CountState.Count = this.KindCount;
        this.CountState.Init();

        this.Array = this.CountState;
        this.ArrayIndex = 0;

        this.CountStateAdd(new BoolFormatCountState());
        this.CountStateAdd(new IntFormatCountState());
        this.CountStateAdd(new SIntFormatCountState());
        this.CountStateAdd(new TextFormatCountState());
        this.CountStateAdd(new CharFormatCountState());
        return true;
    }

    protected virtual bool InitResultState()
    {
        this.ResultState = new Array();
        this.ResultState.Count = this.KindCount;
        this.ResultState.Init();

        this.Array = this.ResultState;
        this.ArrayIndex = 0;

        this.ResultStateAdd(new BoolFormatResultState());
        this.ResultStateAdd(new IntFormatResultState());
        this.ResultStateAdd(new SIntFormatResultState());
        this.ResultStateAdd(new TextFormatResultState());
        this.ResultStateAdd(new CharFormatResultState());
        return true;
    }

    protected virtual bool CountStateAdd(FormatCountState state)
    {
        state.Format = this;
        state.Init();
        this.ArrayAdd(state);
        return true;
    }

    protected virtual bool ResultStateAdd(FormatResultState state)
    {
        state.Format = this;
        state.Init();
        this.ArrayAdd(state);
        return true;
    }

    protected virtual bool ArrayAdd(object item)
    {
        int index;
        index = this.ArrayIndex;
        this.Array.SetAt(index, item);
        index = index + 1;
        this.ArrayIndex = index;
        return true;
    }

    public virtual int ExecuteCount(Text varBase, Array argList)
    {
        int count;
        count = argList.Count;
        int k;
        k = 0;
        int i;
        i = 0;
        while (i < count)
        {
            FormatArg arg;
            arg = (FormatArg)argList.GetAt(i);
            
            if (!arg.HasCount)
            {
                this.ExecuteArgCount(arg);
            }

            int ka;
            ka = arg.Count;

            k = k + ka;

            i = i + 1;
        }

        int baseCount;
        baseCount = varBase.Range.Count;

        k = k + baseCount;

        int a;
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
        int baseStart;
        baseStart = baseRange.Index;
        int baseCount;
        baseCount = baseRange.Count;

        int argCount;
        argCount = argList.Count;

        Data resultData;
        resultData = result.Data;
        Range resultRange;
        resultRange = result.Range;
        int resultStart;
        resultStart = resultRange.Index;
        int resultCount;
        resultCount = resultRange.Count;

        int count;
        count = baseCount + 1;
        int resultIndex;
        resultIndex = 0;
        int argIndex;
        argIndex = 0;
        int i;
        i = 0;
        while (i < count)
        {
            bool b;
            b = false;

            while ((!b) & (argIndex < argCount))
            {
                FormatArg arg;
                arg = (FormatArg)argList.GetAt(argIndex);

                int k;
                k = arg.Pos;

                bool ba;
                ba = (i == k);
                if (ba)
                {
                    int countA;
                    countA = arg.Count;

                    int oa;
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
                char oc;
                oc = textInfra.DataCharGet(baseData, baseStart + i);

                textInfra.DataCharSet(resultData, resultStart + resultIndex, oc);
                
                resultIndex = resultIndex + 1;
            }

            i = i + 1;
        }
        return true;
    }

    public virtual bool ExecuteArgCount(FormatArg arg)
    {
        if (!this.ValidArg(arg))
        {
            return false;
        }

        int kind;
        kind = arg.Kind;
        FormatCountState state;
        state = (FormatCountState)this.CountState.GetAt(kind);

        state.Arg = arg;
        state.Execute();

        Value aa;
        aa = (Value)state.Result;

        int valueCount;
        valueCount = aa.Mid;

        int fieldWidth;
        fieldWidth = arg.FieldWidth;

        int maxWidth;
        maxWidth = arg.MaxWidth;

        long u;
        u = maxWidth;
        u = u << 4;
        u = u >> 4;

        int count;
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

        arg.HasCount = true;
        arg.ValueCount = valueCount;
        arg.Count = count;
        return true;
    }

    public virtual bool ExecuteArgResult(FormatArg arg, Text result)
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

        int kind;
        kind = arg.Kind;
        FormatResultState state;
        state = (FormatResultState)this.ResultState.GetAt(kind);

        state.Arg = arg;
        state.ArgResult = result;
        state.Execute();
        return true;
    }

    public virtual bool ResultBool(Text result, bool value, int varCase, int valueWriteCount, int valueStart, int valueIndex)
    {
        Infra textInfra;
        textInfra = this.TextInfra;

        CharForm charForm;
        charForm = this.CharForm;

        Data destData;
        destData = result.Data;
        int destStart;
        destStart = result.Range.Index;

        string source;
        source = null;
        if (!value)
        {
            source = textInfra.BoolFalseString;
        }
        if (value)
        {
            source = textInfra.BoolTrueString;
        }

        int destIndex;
        destIndex = destStart + valueStart;
        char ouc;
        ouc = (char)0;
        char oc;
        oc = (char)0;
        int aa;
        aa = 0;
        int index;
        index = 0;
        int count;
        count = valueWriteCount;
        int i;
        i = 0;
        while (i < count)
        {
            index = i + valueIndex;

            ouc = source[index];
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
            oc = (char)aa;

            oc = (char)charForm.Execute(oc);

            textInfra.DataCharSet(destData, destIndex + i, oc);

            i = i + 1;
        }
        return true;
    }

    public virtual bool ResultInt(Text result, ulong value, int varBase, int varCase, int valueCount, int valueWriteCount, int valueStart, int valueIndex)
    {
        Infra textInfra;
        textInfra = this.TextInfra;

        CharForm charForm;
        charForm = this.CharForm;

        Data destData;
        destData = result.Data;
        int destStart;
        destStart = result.Range.Index;

        int destIndex;
        destIndex = destStart + valueStart;

        if (value == 0)
        {
            if (!(valueWriteCount == 0))
            {
                char occ;
                occ = '0';

                occ = (char)charForm.Execute(occ);

                textInfra.DataCharSet(destData, destIndex, occ);
            }
            return true;
        }

        int end;
        end = valueIndex + valueWriteCount;

        bool upperCase;
        upperCase = !(varCase == 0);
        char letterDigitStart;
        letterDigitStart = 'a';
        if (upperCase)
        {
            letterDigitStart = 'A';
        }
        ulong ca;
        ca = (ulong)varBase;
        ulong k;
        k = value;
        ulong j;
        j = 0;
        ulong ka;
        ka = 0;
        int digit;
        digit = 0;
        int oa;
        oa = 0;
        char c;
        c = (char)0;

        int index;
        index = 0;
        int count;
        count = valueCount;
        int i;
        i = 0;
        while (i < count)
        {
            j = k / ca;

            index = count - 1 - i;

            if ((!(index < valueIndex)) & index < end)
            {
                ka = k - j * ca;

                digit = (int)ka;

                c = textInfra.DigitChar(digit, letterDigitStart);

                c = (char)charForm.Execute(c);

                oa = index - valueIndex;

                textInfra.DataCharSet(destData, destIndex + oa, c);
            }

            k = j;

            i = i + 1;
        }
        return true;
    }

    public virtual bool ResultText(Text result, Text value, int varCase, int valueWriteCount, int valueStart, int valueIndex)
    {
        Infra textInfra;
        textInfra = this.TextInfra;

        CharForm charForm;
        charForm = this.CharForm;

        Data sourceData;
        sourceData = value.Data;
        int sourceStart;
        sourceStart = value.Range.Index;

        Data destData;
        destData = result.Data;
        int destStart;
        destStart = result.Range.Index;

        int sourceIndex;
        sourceIndex = sourceStart + valueIndex;
        int destIndex;
        destIndex = destStart + valueStart;
        char ouc;
        ouc = (char)0;
        char oc;
        oc = (char)0;
        int aa;
        aa = 0;
        int count;
        count = valueWriteCount;
        int i;
        i = 0;
        while (i < count)
        {
            ouc = textInfra.DataCharGet(sourceData, sourceIndex + i);

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
            oc = (char)aa;

            oc = (char)charForm.Execute(oc);

            textInfra.DataCharSet(destData, destIndex + i, oc);

            i = i + 1;
        }
        return true;
    }

    public virtual bool ResultFill(Text dest, int fillIndex, int fillCount, char fillChar)
    {
        Infra textInfra;
        textInfra = this.TextInfra;
        Data destData;
        destData = dest.Data;
        int destStart;
        destStart = dest.Range.Index;
        int destIndex;
        destIndex = destStart + fillIndex;
        int index;
        index = 0;
        int count;
        count = fillCount;
        int i;
        i = 0;
        while (i < count)
        {
            index = destIndex + i;
            textInfra.DataCharSet(destData, index, fillChar);
            i = i + 1;
        }
        return true;
    }

    public virtual int IntDigitCount(ulong value, int varBase)
    {
        int digitCount;
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

        int a;
        a = digitCount;
        return a;
    }

    public virtual bool ValidArg(FormatArg arg)
    {
        int kind;
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
            if (arg.ValueText == null)
            {
                return false;
            }
            if (!this.TextInfra.ValidRange(arg.ValueText))
            {
                return false;
            }
        }
        return true;
    }

    public virtual bool ValidKind(int kind)
    {
        return this.InfraInfra.ValidIndex(this.KindCount, kind);
    }

    public virtual bool ValidIntBase(int varBase)
    {
        return !(varBase < 2 | 16 < varBase);
    }
}