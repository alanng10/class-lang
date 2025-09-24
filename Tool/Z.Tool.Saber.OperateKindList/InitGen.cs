namespace Z.Tool.Saber.OperateKindList;

public class InitGen : ToolBase
{
    public override bool Init()
    {
        base.Init();
        this.PathEffect = this.S("../../Saber/Saber.Console/ClassGen_Part.cs");
        this.PathStateSource = this.S("ToolData/Saber/OperateStateInitSource.txt");
        this.PathStateItemSource = this.S("ToolData/Saber/OperateStateInitItemSource.txt");
        return true;
    }

    public virtual Table ItemTable { get; set; }
    protected virtual String PathEffect { get; set; }
    protected virtual String PathStateSource { get; set; }
    protected virtual String PathStateItemSource { get; set; }
    protected virtual String TextStateSource { get; set; }
    protected virtual String TextStateItemSource { get; set; }

    public virtual long Execute()
    {
        this.TextStateSource = this.StorageTextRead(this.PathStateSource);
        this.TextStateItemSource = this.StorageTextRead(this.PathStateItemSource);

        this.AddClear();

        Iter iter;
        iter = this.ItemTable.IterCreate();
        this.ItemTable.IterSet(iter);

        while (iter.Next())
        {
            String name;
            name = iter.Index as String;

            Value value;
            value = iter.Value as Value;

            String ka;
            ka = this.ExecuteItem(name, value);

            this.Add(ka);
        }

        String kk;
        kk = this.AddResult();

        Text k;
        k = this.TextCreate(this.TextStateSource);

        k = this.Place(k, "#Init#", kk);

        String a;
        a = this.StringCreate(k);

        this.StorageTextWrite(this.PathEffect, a);
        return 0;
    }

    protected virtual String ExecuteItem(String name, Value value)
    {
        String fieldName;
        fieldName = value.FieldName;

        Text k;
        k = this.TextCreate(this.TextStateItemSource);

        k = this.Place(k, "#FieldName#", fieldName);
        k = this.Place(k, "#Name#", name);

        String a;
        a = this.StringCreate(k);
        return a;
    }
}