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
    protected virtual int CodeTokenStart { get; set; }
    protected virtual int CodeCommentStart { get; set; }

    public override bool ExecuteToken()
    {
        int index;
        index = this.Create.TokenIndex;
        index = index + 1;
        this.Create.TokenIndex = index;
        return true;
    }

    public override bool ExecuteComment()
    {
        int index;
        index = this.Create.CommentIndex;
        index = index + 1;
        this.Create.CommentIndex = index;
        return true;
    }

    public override bool ExecuteCodeStart(int index)
    {
        this.CodeTokenStart = this.Create.TokenIndex;
        this.CodeCommentStart = this.Create.CommentIndex;
        return true;
    }

    public override bool ExecuteCodeEnd(int index)
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;

        int tokenCount;
        int commentCount;
        tokenCount = this.Create.TokenIndex - this.CodeTokenStart;
        commentCount = this.Create.CommentIndex - this.CodeCommentStart;

        Data codeCountData;
        codeCountData = this.Create.CodeCountData;
        int oa;
        oa = sizeof(uint);
        long ob;
        ob = index * 2;
        long oe;
        oe = ob * oa;
        long of;
        of = (ob + 1) * oa;
        infraInfra.DataMidSet(codeCountData, oe, (uint)tokenCount);
        infraInfra.DataMidSet(codeCountData, of, (uint)commentCount);

        this.CodeTokenStart = 0;
        this.CodeCommentStart = 0;
        return true;
    }
}