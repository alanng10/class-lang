namespace Avalon.Type;

public class Type : Any
{
    public static Type This { get; } = ShareCreate();

    private static Type ShareCreate()
    {
        Type share;
        share = new Type();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.Button = new ButtonList();
        this.Button.Init();
        this.FieldList = new bool[this.Button.Count];
        this.ChangeArg = new ChangeArg();
        this.ChangeArg.Init();
        this.Change = new EventEvent();
        this.Change.Init();
        return true;
    }

    protected virtual ChangeArg ChangeArg { get; set; }

    public virtual bool Get(int index)
    {
        return this.FieldList[index];
    }

    public virtual bool Set(int index, bool value)
    {
        Button button;
        button = this.Button.Get(index);
        
        if (button == null)
        {
            return true;
        }
        if (this.FieldList[index] == value)
        {
            return true;
        }

        this.FieldList[index]= value;
        this.ChangeArg.Button = button;
        this.ChangeArg.Field = value;
        this.Change.Trigger(this.ChangeArg);
        return true;
    }

    public virtual ButtonList Button { get; set; }
    public virtual EventEvent Change { get; set; }
    protected virtual bool[] FieldList { get; set; }
}