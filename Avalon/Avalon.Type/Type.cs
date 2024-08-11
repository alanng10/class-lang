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

        this.InitFieldList();

        
        this.ChangeArg = new ChangeArg();
        this.ChangeArg.Init();
        this.Change = new EventEvent();
        this.Change.Init();
        return true;
    }

    protected virtual bool InitFieldList()
    {
        this.FieldList = new Array();
        this.FieldList.Count = this.Button.Count;
        this.FieldList.Init();

        Array array;
        array = this.FieldList;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Value a;
            a = new Value();
            a.Init();
            array.SetAt(i, a);
            i = i + 1;
        }
        return true;
    }


    protected virtual ChangeArg ChangeArg { get; set; }

    public virtual bool Get(int index)
    {
        Value a;
        a = (Value)this.FieldList.GetAt(index);
        return a.Bool;
    }

    public virtual bool Set(int index, bool value)
    {
        Button button;
        button = this.Button.Get(index);
        
        if (button == null)
        {
            return true;
        }

        Value a;
        a = (Value)this.FieldList.GetAt(index);

        if (a.Bool == value)
        {
            return true;
        }

        a.Bool = value;
        this.ChangeArg.Button = button;
        this.ChangeArg.Field = value;
        this.Change.Execute(this.ChangeArg);
        return true;
    }

    public virtual ButtonList Button { get; set; }
    public virtual EventEvent Change { get; set; }
    protected virtual Array FieldList { get; set; }
}