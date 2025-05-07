namespace Saber.Node;

public class CreateSetOperate : CreateOperate
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

    public override Node ExecuteNode()
    {
        Create create;
        create = this.Create;

        CreateArg arg;
        arg = create.Arg;

        CreateSetArg ka;
        ka = create.SetArg;

        long index;
        index = arg.NodeIndex;

        Node node;
        node = arg.NodeArray.GetAt(index) as Node;

        CreateSetState state;
        state = ka.Kind.CreateSetState;

        CreateSetStateArg stateArg;
        stateArg = state.Arg as CreateSetStateArg;
        stateArg.Node = node;
        stateArg.SetArg = ka;

        state.Execute();

        stateArg.SetArg = null;
        stateArg.Node = null;

        create.NodeInfo(node, ka.Range);

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
        return this.Create.Arg.ListArray.GetAt(index) as Array;
    }

    public override bool ExecuteListItemSet(long index, long itemIndex, object value)
    {
        Array array;
        array = this.Create.Arg.ListArray.GetAt(index) as Array;

        array.SetAt(itemIndex, value);
        return true;
    }

    public override bool ExecuteError(ErrorKind kind, Range range)
    {
        Create create;
        create = this.Create;
        CreateArg arg;
        arg = create.Arg;

        long index;
        index = arg.ErrorIndex;

        Error error;
        error = arg.ErrorArray.GetAt(index) as Error;
        error.Kind = kind;
        error.Range.Start = range.Start;
        error.Range.End = range.End;
        error.Source = create.SourceIndex;

        index = index + 1;

        arg.ErrorIndex = index;
        return true;
    }

    public override String ExecuteNameValue(Text text)
    {
        CreateArg arg;
        arg = this.Create.Arg;

        long index;
        long indexA;
        index = arg.NameValueIndex;
        indexA = arg.NameValueTextIndex;

        String a;
        a = arg.NameValueArray.GetAt(index) as String;

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
        long indexA;
        index = arg.StringValueIndex;
        indexA = arg.StringValueTextIndex;

        String a;
        a = arg.StringValueArray.GetAt(index) as String;

        index = index + 1;
        indexA = indexA + this.StringComp.Count(a);

        arg.StringValueTextIndex = indexA;
        arg.StringValueIndex = index;
        return a;
    }
}