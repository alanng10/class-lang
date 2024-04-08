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
        token.Range.Row = this.Create.Range.Row;

        InfraRange aa;
        aa = token.Range.Col; 
        InfraRange ab;
        ab = this.Create.Range.Col;
        
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
        comment.Range.Row = this.Create.Range.Row;

        InfraRange aa;
        aa = comment.Range.Col;
        InfraRange ab;
        ab = this.Create.Range.Col;

        aa.Index = ab.Index;
        aa.Count = ab.Count;

        index = index + 1;

        this.Create.CommentIndex = index;
        return true;
    }
}