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

        Array a;
        a = this.FieldList;

        int count;
        count = a.Count;
        int i;
        i = 0;
        while (i < count)
        {
            ButtonField field;
            field = new ButtonField();
            field.Init();
            a.Set(i, field);
            i = i + 1;
        }
        return true;
    }


    protected virtual ChangeArg ChangeArg { get; set; }

    public virtual bool Get(int index)
    {
        ButtonField a;
        a = (ButtonField)this.FieldList.Get(index);
        return a.Value;
    }

    public virtual bool Set(int index, bool value)
    {
        Button button;
        button = this.Button.Get(index);
        
        if (button == null)
        {
            return true;
        }

        ButtonField a;
        a = (ButtonField)this.FieldList.Get(index);

        if (a.Value == value)
        {
            return true;
        }

        a.Value = value;
        this.ChangeArg.Button = button;
        this.ChangeArg.Field = value;
        this.Change.Execute(this.ChangeArg);
        return true;
    }

    public virtual ButtonList Button { get; set; }
    public virtual EventEvent Change { get; set; }
    protected virtual Array FieldList { get; set; }
}