namespace Avalon.Text;

public class Format : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.TextInfra = Infra.This;
        return true;
    }

    protected virtual InfraInfra InfraInfra { get { return __D_InfraInfra; } set { __D_InfraInfra = value; } }
    protected InfraInfra __D_InfraInfra;
    protected virtual Infra TextInfra { get { return __D_TextInfra; } set { __D_TextInfra = value; } }
    protected Infra __D_TextInfra;
    protected virtual Array CountState { get { return __D_CountState; } set { __D_CountState = value; } }
    protected Array __D_CountState;
    protected virtual Array Array { get { return __D_Array; } set { __D_Array = value; } }
    protected Array __D_Array;
    protected virtual int ArrayIndex { get { return __D_ArrayIndex; } set { __D_ArrayIndex = value; } }
    protected int __D_ArrayIndex;

    protected virtual bool InitCountState()
    {
        this.CountState = new Array();
        this.CountState.Count = 5;
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

    protected virtual bool CountStateAdd(FormatCountState state)
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
        return true;
    }

    public virtual int IntDigitCount(long value, int varBase)
    {
        if (!this.CheckIntBase(varBase))
        {
            return -1;
        }

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

    protected virtual bool CheckIntBase(int varBase)
    {
        return !(varBase < 2 | 16 < varBase);
    }
}