namespace Saber.Node;

public class CreateCountOperate : CreateOperate
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;

        this.List = this.CreateList();
        this.String = this.CreateString();
        return true;
    }

    protected virtual Array CreateList()
    {
        return this.ListInfra.ArrayCreate(0);
    }

    protected virtual String CreateString()
    {
        return this.TextInfra.Zero;
    }

    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual Array List { get; set; }
    protected virtual String String { get; set; }

    public override Node ExecuteNode()
    {
        CreateArg arg;
        arg = this.Create.Arg;

        long index;
        index = arg.NodeIndex;

        index = index + 1;

        arg.NodeIndex = index;

        Node a;
        a = this.Create.SetArg.Kind.Node;
        return a;
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
        return this.List;
    }

    public override bool ExecuteError(ErrorKind kind, Range range)
    {
        CreateArg arg;
        arg = this.Create.Arg;

        long index;
        index = arg.ErrorIndex;

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

        index = index + 1;
        indexA = indexA + text.Range.Count;

        arg.NameValueTextIndex = indexA;
        arg.NameValueIndex = index;
        return this.String;
    }

    public override String ExecuteStringValue(Text text)
    {
        CreateArg arg;
        arg = this.Create.Arg;

        long index;
        long indexA;
        index = arg.StringValueIndex;
        indexA = arg.StringValueTextIndex;

        long count;
        count = this.Create.StringValueCount(text);

        index = index + 1;
        indexA = indexA + count;

        arg.StringValueTextIndex = indexA;
        arg.StringValueIndex = index;
        return this.String;
    }
}