namespace Class.Node;

public class CountCreateOperate : CreateOperate
{
    public override bool Init()
    {
        base.Init();
        this.List = new Array();
        this.List.Count = 0;
        this.List.Init();
        return true;
    }

    protected virtual Array List { get; set; }

    public override Node Execute()
    {
        int index;
        index = this.Create.NodeIndex;

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

    public override bool ExecuteError(ErrorKind kind, int start, int end)
    {
        int index;
        index = this.Create.ErrorIndex;

        index = index + 1;

        this.Create.ErrorIndex = index;
        return true;
    }
}