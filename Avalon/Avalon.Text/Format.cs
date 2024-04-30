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

    protected virtual InfraInfra InfraInfra { get { return __D_InfraInfra; } set { __D_InfraInfra = value; } }
    protected InfraInfra __D_InfraInfra;
    protected virtual Infra TextInfra { get { return __D_TextInfra; } set { __D_TextInfra = value; } }
    protected Infra __D_TextInfra;
    protected virtual int KindCount { get { return 5; } set { } }
    protected int __D_KindCount;
    protected virtual Array CountState { get { return __D_CountState; } set { __D_CountState = value; } }
    protected Array __D_CountState;
    protected virtual Array ResultState { get { return __D_ResultState; } set { __D_ResultState = value; } }
    protected Array __D_ResultState;
    protected virtual Array Array { get { return __D_Array; } set { __D_Array = value; } }
    protected Array __D_Array;
    protected virtual int ArrayIndex { get { return __D_ArrayIndex; } set { __D_ArrayIndex = value; } }
    protected int __D_ArrayIndex;
    public virtual string BoolFalseString { get { return "false"; } set { } }
    public virtual string BoolTrueString { get { return "true"; } set { } }

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
        this.ResultStateAdd(null);
        this.ResultStateAdd(null);
        this.ResultStateAdd(null);
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
        this.Array.Set(index, item);
        index = index + 1;
        this.ArrayIndex = index;
        return true;
    }

    public virtual int ExecuteCount(Text varBase, Array argList)
    {
        return 0;
    }

    public virtual bool ExecuteResult(Text varBase, Array argList, Text result)
    {
        return true;
    }

    public virtual bool ExecuteArgCount(FormatArg arg)
    {
        if (!this.CheckArg(arg))
        {
            return false;
        }

        int kind;
        kind = arg.Kind;
        FormatCountState state;
        state = (FormatCountState)this.CountState.Get(kind);

        state.Arg = arg;
        state.Execute();

        int valueCount;
        valueCount = state.Result;

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
        if (!this.CheckArg(arg))
        {
            return false;
        }
        if (!this.TextInfra.CheckRange(result))
        {
            return false;
        }


        
        return true;
    }

    public virtual bool ResultBool(Text result, bool value, int varCase, int valueWriteCount, int valueStart, int valueIndex)
    {
        Infra textInfra;
        textInfra = this.TextInfra;

        Data destData;
        destData = result.Data;
        int destStart;
        destStart = result.Range.Index;

        string source;
        source = null;
        if (!value)
        {
            source = this.BoolFalseString;
        }
        if (value)
        {
            source = this.BoolTrueString;
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

            textInfra.DataCharSet(destData, destIndex + i, oc);

            i = i + 1;
        }
        return true;
    }

    public virtual bool ResultString(Text result, Text value, int varCase, int valueWriteCount, int valueStart, int valueIndex)
    {
        Infra textInfra;
        textInfra = this.TextInfra;

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

    public virtual int IntDigitCount(long value, int varBase)
    {
        long mask;
        mask = this.InfraInfra.IntCapValue - 1;
        value = value & mask;

        int digitCount;
        digitCount = 0;

        long oa;
        oa = value;
        while (0 < oa)
        {
            oa = oa / varBase;
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

    protected virtual bool CheckArg(FormatArg arg)
    {
        int kind;
        kind = arg.Kind;

        if (!this.CheckKind(kind))
        {
            return false;
        }

        if (kind == 1 | kind == 2)
        {
            if (!this.CheckIntBase(arg.Base))
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
            if (!this.TextInfra.CheckRange(arg.ValueText))
            {
                return false;
            }
        }
        return true;
    }

    protected virtual bool CheckKind(int kind)
    {
        return this.InfraInfra.CheckIndex(this.KindCount, kind);
    }

    protected virtual bool CheckIntBase(int varBase)
    {
        return !(varBase < 2 | 16 < varBase);
    }
}