namespace Saber.Token;

public class CreateSetOperate : CreateOperate
{
    public override bool ExecuteToken(long row, Range range)
    {
        CreateArg arg;
        arg = this.Create.Arg;
        long index;
        index = arg.TokenIndex;

        Token token;
        token = arg.TokenArray.GetAt(index) as Token;
        token.Row = row;
        token.Range.Index = range.Index;
        token.Range.Count = range.Count;

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

        Comment comment;
        comment = arg.CommentArray.GetAt(index) as Comment;
        comment.Row = row;
        comment.Range.Index = range.Index;
        comment.Range.Count = range.Count;

        index = index + 1;

        arg.CommentIndex = index;
        return true;
    }
}