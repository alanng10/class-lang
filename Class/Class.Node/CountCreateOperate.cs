namespace Class.Node;

public class CountCreateOperate : CreateOperate
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.List = this.ListInfra.ArrayCreate(0);
        this.String = "";
        return true;
    }

    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual Array List { get; set; }
    protected virtual string String { get; set; }

    public override Node Execute()
    {
        CreateArg arg;
        arg = this.Create.Arg;

        int index;
        index = arg.NodeIndex;

        index = index + 1;

        arg.NodeIndex = index;

        Node a;
        a = this.Create.OperateArg.Kind.Node;
        return a;
    }

    public override int ExecuteListNew()
    {
        CreateArg arg;
        arg = this.Create.Arg;

        int index;
        index = arg.ListIndex;

        int a;
        a = index;

        index = index + 1;

        arg.ListIndex = index;
        return a;
    }

    public override Array ExecuteListGet(int index)
    {
        return this.List;
    }

    public override bool ExecuteError(ErrorKind kind, int start, int end)
    {
        CreateArg arg;
        arg = this.Create.Arg;

        int index;
        index = arg.ErrorIndex;

        index = index + 1;

        arg.ErrorIndex = index;
        return true;
    }

    public override string ExecuteNameValue(Text text)
    {
        int index;
        index = this.Create.NameValueIndex;
        int indexA;
        indexA = this.Create.NameValueTotalIndex;

        index = index + 1;
        indexA = indexA + text.Range.Count;

        this.Create.NameValueTotalIndex = indexA;
        this.Create.NameValueIndex = index;
        return this.String;
    }

    public override string ExecuteStringValue(Text text)
    {
        int index;
        index = this.Create.StringValueIndex;
        int indexA;
        indexA = this.Create.StringValueTotalIndex;
        
        StringValueWrite write;
        write = this.Create.StringValueWrite;
        write.WriteOperate = write.CountWriteOperate;
        write.Index = 0;
        write.ExecuteValueString(text);
        int count;
        count = write.Index;
        
        index = index + 1;
        indexA = indexA + count;

        this.Create.StringValueTotalIndex = indexA;
        this.Create.StringValueIndex = index;
        return this.String;
    }
}