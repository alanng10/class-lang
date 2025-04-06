namespace Saber.Node;

public class KindCreateOperate : CreateOperate
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.List = this.ListInfra.ArrayCreate(0);
        this.String = this.TextInfra.Zero;
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual Array List { get; set; }
    protected virtual String String { get; set; }

    public override Node Execute()
    {
        Create create;
        create = this.Create;

        CreateArg arg;
        arg = create.Arg;

        NodeKind kind;
        kind = create.SetArg.Kind;

        long index;
        index = arg.NodeIndex;

        arg.NodeData.Set(index, kind.Index);

        index = index + 1;

        arg.NodeIndex = index;

        Node a;
        a = kind.Node;
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

    public override bool ExecuteListCount(long index, long count)
    {
        long oa;
        oa = index;
        oa = oa * sizeof(ulong);
        this.InfraInfra.DataIntSet(this.Create.Arg.ListData, oa, count);
        return true;
    }

    public override bool ExecuteError(ErrorKind kind, long start, long end)
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
        index = arg.NameValueIndex;
        long indexA;
        indexA = arg.NameValueTextIndex;

        InfraRange range;
        range = text.Range;

        long count;
        count = range.Count;
        long oa;
        oa = index;
        oa = oa * sizeof(ulong);
        this.InfraInfra.DataIntSet(arg.NameValueCountData, oa, count);

        Data source;
        source = text.Data;
        long sourceIndex;
        sourceIndex = range.Index;
        Data dest;
        dest = arg.NameValueTextData;
        long destIndex;
        destIndex = indexA;

        this.TextInfra.Copy(dest, destIndex, source, sourceIndex, count);

        index = index + 1;
        indexA = indexA + count;

        arg.NameValueTextIndex = indexA;
        arg.NameValueIndex = index;
        return this.String;
    }

    public override String ExecuteStringValue(Text text)
    {
        Create create;
        create = this.Create;
        CreateArg arg;
        arg = create.Arg;

        long index;
        index = arg.StringValueIndex;
        long indexA;
        indexA = arg.StringValueTextIndex;

        long count;
        count = create.StringValueCount(text);
        long ka;
        ka = index;
        ka = ka * sizeof(ulong);
        this.InfraInfra.DataIntSet(arg.StringValueCountData, ka, count);

        create.StringValueSet(text);

        index = index + 1;
        indexA = indexA + count;

        arg.StringValueTextIndex = indexA;
        arg.StringValueIndex = index;
        return this.String;
    }
}