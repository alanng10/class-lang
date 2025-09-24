namespace Z.Tool.Saber.OperateKindList;

public class InitGen : ToolBase
{
    public override bool Init()
    {
        base.Init();
        this.PathEffect = this.S("../../Saber/Saber.Console/ClassGen_Part.cs");
        this.PathStateSource = this.S("ToolData/Saber/OperateStateInitSource.txt");
        this.PathStateItemSource = this.S("ToolData/Saber/OperateStateInitItemSource.txt");

        this.SThis = this.S("This");
        this.SGet = this.S("Get");
        return true;
    }

    public virtual Table ItemTable { get; set; }
    protected virtual String PathEffect { get; set; }
    protected virtual String PathStateSource { get; set; }
    protected virtual String PathStateItemSource { get; set; }
    protected virtual String TextStateSource { get; set; }
    protected virtual String TextStateItemSource { get; set; }
    protected virtual String SThis { get; set; }
    protected virtual String SGet { get; set; }

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

            String ka;
            ka = this.ExecuteItem(name);

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

    protected virtual String ExecuteItem(String name)
    {
        String fieldName;
        fieldName = this.FieldName(name);

        Text k;
        k = this.TextCreate(this.TextStateItemSource);

        k = this.Place(k, "#FieldName#", fieldName);
        k = this.Place(k, "#Name#", name);

        String a;
        a = this.StringCreate(k);
        return a;
    }

    protected virtual String FieldName(String name)
    {
        String k;
        k = name;

        if (this.TextSame(this.TA(name), this.TB(this.SThis)) |
            this.TextSame(this.TA(name), this.TB(this.SGet))
        )
        {
            StringAdd ke;
            ke = this.StringAdd;

            this.StringAdd = new StringAdd();
            this.StringAdd.Init();

            k = this.AddClear().AddS("Item").Add(name).AddResult();

            this.StringAdd = ke;
        }

        return k;
    }
}