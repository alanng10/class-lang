namespace Class.Token;

public class SetCreateOperate : CreateOperate
{
    public virtual Create Create { get; set; }

    public override bool ExecuteToken()
    {
        int index;
        index = this.Create.TokenIndex;

        Token token;
        token = (Token)this.Create.TokenArray.Get(index);
        token.Row = this.Create.Row;

        InfraRange aa;
        aa = token.Range; 
        InfraRange ab;
        ab = this.Create.Range;
        
        aa.Index = ab.Index;
        aa.Count = ab.Count;

        index = index + 1;

        this.Create.TokenIndex = index;
        return true;
    }

    public override bool ExecuteComment()
    {
        int index;
        index = this.Create.CommentIndex;

        Comment comment;
        comment = (Comment)this.Create.CommentArray.Get(index);
        comment.Row = this.Create.Row;

        InfraRange aa;
        aa = comment.Range;
        InfraRange ab;
        ab = this.Create.Range;

        aa.Index = ab.Index;
        aa.Count = ab.Count;

        index = index + 1;

        this.Create.CommentIndex = index;
        return true;
    }
}