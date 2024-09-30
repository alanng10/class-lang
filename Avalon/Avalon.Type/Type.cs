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
        this.Button = ButtonList.This;

        this.InitFieldList();
        
        this.ChangeArg = new ChangeArg();
        this.ChangeArg.Init();
        this.Change = new EventEvent();
        this.Change.Init();
        return true;
    }

    protected virtual bool InitFieldList()
    {
        this.FieldData = new Data();
        this.FieldData.Count = this.Button.Count;
        this.FieldData.Init();
        return true;
    }

    protected virtual ChangeArg ChangeArg { get; set; }

    public virtual bool Get(long index)
    {
        long k;
        k = this.FieldData.Get(index);

        bool a;
        a = !(k == 0);

        return a;
    }

    public virtual bool Set(long index, bool value)
    {
        Button button;
        button = this.Button.Get(index);
        
        if (button == null)
        {
            return true;
        }

        bool ka;
        ka = this.Get(index);

        if (ka == value)
        {
            return true;
        }

        long k;
        k = 0;
        if (value)
        {
            k = 1;
        }

        this.FieldData.Set(index, k);

        this.ChangeArg.Button = button;
        this.ChangeArg.Field = value;
        this.Change.Execute(this.ChangeArg);
        return true;
    }

    public virtual ButtonList Button { get; set; }
    public virtual EventEvent Change { get; set; }
    protected virtual Data FieldData { get; set; }
}