namespace Class.Node;

public class SetCreateOperate : CreateOperate
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.StringComp = StringComp.This;
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual StringComp StringComp { get; set; }

    public override Node Execute()
    {
        Create create;
        create = this.Create;

        CreateArg arg;
        arg = create.Arg;

        CreateOperateArg o;
        o = create.OperateArg;

        long index;
        index = arg.NodeIndex;

        Node node;        
        node = (Node)arg.NodeArray.GetAt(index);

        NodeKind kind;
        kind = o.Kind;

        CreateOperateState state;
        state = kind.CreateOperateState;

        CreateOperateStateArg stateArg;
        stateArg = (CreateOperateStateArg)state.Arg;
        stateArg.Node = node;
        stateArg.OperateArg = o;

        state.Execute();

        stateArg.OperateArg = null;
        stateArg.Node = null;

        create.NodeInfo(node, o.Start, o.End);

        index = index + 1;

        arg.NodeIndex = index;
        return node;
    }

    public override long ExecuteListNew()
    {
        CreateArg arg;
        arg = this.Create.Arg;

        long index;
        index = arg.ListIndex;

        long a;
        a = index;

        index = index + 1;

        arg.ListIndex = index;
        return a;
    }

    public override Array ExecuteListGet(long index)
    {
        return (Array)this.Create.Arg.ListArray.GetAt(index);
    }

    public override bool ExecuteListSetItem(long index, long itemIndex, object item)
    {
        Array array;
        array = (Array)this.Create.Arg.ListArray.GetAt(index);

        array.SetAt(itemIndex, item);
        return true;
    }
    
    public override bool ExecuteError(ErrorKind kind, long start, long end)
    {
        Create create;
        create = this.Create;
        CreateArg arg;
        arg = create.Arg;

        long index;
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

    public override String ExecuteNameValue(Text text)
    {
        CreateArg arg;
        arg = this.Create.Arg;

        long index;
        index = arg.NameValueIndex;
        long indexA;
        indexA = arg.NameValueTextIndex;

        String a;
        a = (String)arg.NameValueArray.GetAt(index);

        index = index + 1;
        indexA = indexA + this.StringComp.Count(a);

        arg.NameValueTextIndex = indexA;
        arg.NameValueIndex = index;
        return a;
    }

    public override String ExecuteStringValue(Text text)
    {
        CreateArg arg;
        arg = this.Create.Arg;

        long index;
        index = arg.StringValueIndex;
        long indexA;
        indexA = arg.StringValueTextIndex;

        String a;
        a = (String)arg.StringValueArray.GetAt(index);

        index = index + 1;
        indexA = indexA + this.StringComp.Count(a);

        arg.StringValueTextIndex = indexA;
        arg.StringValueIndex = index;
        return a;
    }
}