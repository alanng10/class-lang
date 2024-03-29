namespace Class.Token;

public class CountCreateOperate : CreateOperate
{
    public virtual Create Create { get; set; }

    public override bool ExecuteToken()
    {
        int index;
        int codeIndex;
        index = this.Create.TokenIndex;
        codeIndex = this.Create.CodeTokenIndex;

        index = index + 1;
        codeIndex = codeIndex + 1;

        this.Create.CodeTokenIndex = codeIndex;
        this.Create.TokenIndex = index;
        return true;
    }

    public override bool ExecuteComment()
    {
        int index;
        int codeIndex;
        index = this.Create.CommentIndex;
        codeIndex = this.Create.CodeCommentIndex;

        index = index + 1;
        codeIndex = codeIndex + 1;

        this.Create.CodeCommentIndex = codeIndex;
        this.Create.CommentIndex = index;
        return true;
    }
}