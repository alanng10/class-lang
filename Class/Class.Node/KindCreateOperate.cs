namespace Class.Node;

public class KindCreateOperate : CreateOperate
{
    public override bool Init()
    {
        base.Init();
        this.DataWrite = new DataWrite();
        this.DataWrite.Init();
        this.List = new Array();
        this.List.Count = 0;
        this.List.Init();
        return true;
    }

    protected virtual DataWrite DataWrite { get; set; }

    protected virtual Array List { get; set; }

    public override Node Execute()
    {
        int index;
        index = this.Create.NodeIndex;

        this.Create.KindData.Value[index] = (byte)(this.Create.OperateArg.Kind.Index);

        index = index + 1;

        this.Create.NodeIndex = index;

        Node a;
        a = this.Create.OperateArg.Kind.Node;
        return a;
    }

    public override int ExecuteListNew()
    {
        int index;
        index = this.Create.ListIndex;

        int a;
        a = index;

        index = index + 1;

        this.Create.ListIndex = index;
        return a;
    }

    public override Array ExecuteListGet(int index)
    {
        return this.List;
    }

    public override bool ExecuteListCount(int index, int count)
    {
        this.DataWrite.Data = this.Create.ListData;

        long oa;
        oa = index * sizeof(int);

        this.DataWrite.ExecuteInt(oa, count);
        return true;
    }
}