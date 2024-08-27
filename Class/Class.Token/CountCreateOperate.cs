namespace Class.Token;

public class CountCreateOperate : CreateOperate
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        return true;
    }

    public virtual Create Create { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual long CodeTokenStart { get; set; }
    protected virtual long CodeCommentStart { get; set; }

    public override bool ExecuteToken()
    {
        long index;
        index = this.Create.TokenIndex;
        index = index + 1;
        this.Create.TokenIndex = index;
        return true;
    }

    public override bool ExecuteComment()
    {
        long index;
        index = this.Create.InfoIndex;
        index = index + 1;
        this.Create.InfoIndex = index;
        return true;
    }

    public override bool ExecuteCodeStart(long index)
    {
        this.CodeTokenStart = this.Create.TokenIndex;
        this.CodeCommentStart = this.Create.InfoIndex;
        return true;
    }

    public override bool ExecuteCodeEnd(long index)
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;

        long tokenCount;
        long commentCount;
        tokenCount = this.Create.TokenIndex - this.CodeTokenStart;
        commentCount = this.Create.InfoIndex - this.CodeCommentStart;

        Data codeCountData;
        codeCountData = this.Create.CodeCountData;
        long oa;
        oa = sizeof(ulong);
        long ob;
        ob = index;
        ob = ob * 2;
        long oe;
        oe = ob * oa;
        long of;
        of = (ob + 1) * oa;
        infraInfra.DataIntSet(codeCountData, oe, tokenCount);
        infraInfra.DataIntSet(codeCountData, of, commentCount);

        this.CodeTokenStart = 0;
        this.CodeCommentStart = 0;
        return true;
    }
}