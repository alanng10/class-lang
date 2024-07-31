namespace Class.Node;

public class SetCreateOperate : CreateOperate
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }

    public override Node Execute()
    {
        Create create;
        create = this.Create;

        CreateArg arg;
        arg = create.Arg;

        CreateOperateArg o;
        o = create.OperateArg;

        int index;
        index = arg.NodeIndex;

        Node node;        
        node = (Node)arg.NodeArray.GetAt(index);

        NodeKind kind;
        kind = o.Kind;

        CreateOperateState state;
        state = kind.CreateOperateState;
        state.Node = node;
        state.Arg = o;
        state.Execute();

        state.Node = null;
        state.Arg = null;

        create.NodeInfo(node, o.Start, o.End);

        index = index + 1;

        arg.NodeIndex = index;
        return node;
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
        return (Array)this.Create.Arg.ListArray.GetAt(index);
    }

    public override bool ExecuteListSetItem(int index, int itemIndex, object item)
    {
        Array array;
        array = (Array)this.Create.Arg.ListArray.GetAt(index);

        array.SetAt(itemIndex, item);
        return true;
    }
    
    public override bool ExecuteError(ErrorKind kind, int start, int end)
    {
        Create create;
        create = this.Create;
        CreateArg arg;
        arg = create.Arg;

        int index;
        index = arg.ErrorIndex;

        Error error;
        error = (Error)arg.ErrorArray.GetAt(index);
        error.Kind = kind;
        error.Range.Start = start;
        error.Range.End = end;
        error.Source = create.SourceItem;

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

        string a;
        a = (string)this.Create.NameValueArray.GetAt(index);

        index = index + 1;
        indexA = indexA + a.Length;

        this.Create.NameValueTotalIndex = indexA;
        this.Create.NameValueIndex = index;
        return a;
    }

    public override string ExecuteStringValue(Text text)
    {
        int index;
        index = this.Create.StringValueIndex;
        int indexA;
        indexA = this.Create.StringValueTotalIndex;

        string a;
        a = (string)this.Create.StringValueArray.GetAt(index);

        index = index + 1;
        indexA = indexA + a.Length;

        this.Create.StringValueTotalIndex = indexA;
        this.Create.StringValueIndex = index;
        return a;
    }
}