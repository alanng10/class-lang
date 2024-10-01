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
        this.Index = IndexList.This;

        this.InitFieldList();

        this.Change = this.CreateChangeEvent();
        this.ModArg = this.CreateChangeArg();
        return true;
    }

    public virtual IndexList Index { get; set; }
    public virtual EventEvent Change { get; set; }
    protected virtual ModArg ModArg { get; set; }
    protected virtual Data FieldData { get; set; }
    
    protected virtual EventEvent CreateChangeEvent()
    {
        EventEvent a;
        a = new EventEvent();
        a.Init();
        return a;
    }

    protected virtual ModArg CreateChangeArg()
    {
        ModArg a;
        a = new ModArg();
        a.Init();
        return a;
    }

    protected virtual bool InitFieldList()
    {
        this.FieldData = new Data();
        this.FieldData.Count = this.Index.Count;
        this.FieldData.Init();
        return true;
    }

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
        Index k;
        k = this.Index.Get(index);
        
        if (k == null)
        {
            return true;
        }

        bool ka;
        ka = this.Get(index);

        if (ka == value)
        {
            return true;
        }

        long ke;
        ke = 0;
        if (value)
        {
            ke = 1;
        }

        this.FieldData.Set(index, ke);

        this.ModArg.Button = k;
        this.ModArg.Field = value;
        this.Change.Execute(this.ModArg);
        return true;
    }
}