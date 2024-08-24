namespace Class.Node;

public class KindCreateOperate : CreateOperate
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.List = this.ListInfra.ArrayCreate(0);
        this.String = this.TextInfra.Empty;
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
        ulong u;
        u = (ulong)count;
        this.InfraInfra.DataIntSet(this.Create.Arg.ListData, oa, u);
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
        ulong u;
        u = (ulong)count;
        long oa;
        oa = index;
        oa = oa * sizeof(ulong);
        this.InfraInfra.DataIntSet(arg.NameValueCountData, oa, u);

        Data source;
        source = text.Data;
        long sourceIndex;
        sourceIndex = range.Index;
        Data dest;
        dest = arg.NameValueTextData;
        long destIndex;
        destIndex = indexA;

        this.CopyText(dest, destIndex, source, sourceIndex, count);

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

        StringValueWrite write;
        write = create.StringValueWrite;
        write.WriteOperate = write.CountWriteOperate;
        write.Index = 0;
        write.ExecuteValueString(text);
        long count;
        count = write.Index;
        ulong u;
        u = (ulong)count;
        long oa;
        oa = index;
        oa = oa * sizeof(ulong);
        this.InfraInfra.DataIntSet(arg.StringValueCountData, oa, u);
        
        write.WriteOperate = write.AddWriteOperate;
        write.Index = indexA;
        write.Data = arg.StringValueTextData;
        write.ExecuteValueString(text);
        write.Data = null;

        index = index + 1;
        indexA = indexA + count;

        arg.StringValueTextIndex = indexA;
        arg.StringValueIndex = index;
        return this.String;
    }

    protected virtual bool CopyText(Data dest, long destIndex, Data source, long sourceIndex, long count)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        long i;
        i = 0;
        while (i < count)
        {
            uint oc;
            oc = textInfra.DataCharGet(source, sourceIndex + i);

            textInfra.DataCharSet(dest, destIndex + i, oc);
            
            i = i + 1;
        }
        return true;
    }
}