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
    private Array Array { get; set; }
    private int ArrayIndex { get; set; }

    protected virtual bool InitCountState()
    {
        this.CountState = new Array();
        this.CountState.Count = 5;
        this.CountState.Init();

        this.Array = this.CountState;
        this.ArrayIndex = 0;

        this.CountStateAdd(new BoolFormatCountState());
        this.CountStateAdd(new TextFormatCountState());
        this.CountStateAdd(new CharFormatCountState());
        return true;
    }

    private bool CountStateAdd(FormatCountState state)
    {
        state.Format = this;
        state.Init();
        this.ArrayAdd(state);
        return true;
    }

    private bool ArrayAdd(object item)
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
        return true;
    }

    public virtual bool ExecuteArgResult(FormatArg arg, Text result)
    {
        return true;
    }
}