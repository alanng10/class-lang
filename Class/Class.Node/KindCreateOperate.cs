namespace Class.Node;

public class KindCreateOperate : CreateOperate
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.DataWrite = new DataWrite();
        this.DataWrite.Init();
        this.List = this.ListInfra.ArrayCreate(0);
        this.String = "";
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual DataWrite DataWrite { get; set; }
    protected virtual Array List { get; set; }
    protected virtual string String { get; set; }

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
        this.DataWrite.Data = null;
        return true;
    }

    public override string ExecuteNameValue(TextSpan text)
    {
        int index;
        index = this.Create.NameValueIndex;

        int count;
        count = text.Range.Count;
        this.DataWrite.Data = this.Create.NameValueData;
        long oa;
        oa = index * sizeof(int);
        this.DataWrite.ExecuteInt(oa, count);
        this.DataWrite.Data = null;

        index = index + 1;

        this.Create.NameValueIndex = index;
        return this.String;
    }

    public override string ExecuteStringValue()
    {
        int index;
        index = this.Create.StringValueIndex;

        StringValueWrite write;
        write = this.Create.StringValueWrite;
        write.WriteOperate = write.CountWriteOperate;
        write.Index = 0;
        write.ExecuteValueString(span);
        int count;
        count = write.Index;
        this.DataWrite.Data = this.Create.StringValueData;
        long oa;
        oa = index * sizeof(int);
        this.DataWrite.ExecuteInt(oa, count);
        this.DataWrite.Data = null;

        index = index + 1;

        this.Create.StringValueIndex = index;
        return this.TextSpan;
    }
}