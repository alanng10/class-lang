namespace Saber.Token;

public class CreateCountOperate : CreateOperate
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual long TokenStart { get; set; }
    protected virtual long CommentStart { get; set; }

    public override bool ExecuteToken(long row, Range range)
    {
        CreateArg arg;
        arg = this.Create.Arg;
        long index;
        index = arg.TokenIndex;
        index = index + 1;
        arg.TokenIndex = index;
        return true;
    }

    public override bool ExecuteComment(long row, Range range)
    {
        CreateArg arg;
        arg = this.Create.Arg;
        long index;
        index = arg.CommentIndex;
        index = index + 1;
        arg.CommentIndex = index;
        return true;
    }

    public override bool ExecuteCodeStart(long index)
    {
        CreateArg arg;
        arg = this.Create.Arg;
        this.TokenStart = arg.TokenIndex;
        this.CommentStart = arg.CommentIndex;
        return true;
    }

    public override bool ExecuteCodeEnd(long index)
    {
        CreateArg arg;
        arg = this.Create.Arg;

        long tokenCount;
        long commentCount;
        tokenCount = arg.TokenIndex - this.TokenStart;
        commentCount = arg.CommentIndex - this.CommentStart;

        Data data;
        data = arg.CodeCountData;
        long kd;
        kd = sizeof(ulong);

        long kk;
        kk = index;
        kk = kk * 2;

        long ka;
        ka = kk * kd;
        this.InfraInfra.DataIntSet(data, ka, tokenCount);

        ka = (kk + 1) * kd;
        this.InfraInfra.DataIntSet(data, ka, commentCount);

        this.TokenStart = 0;
        this.CommentStart = 0;
        return true;
    }
}