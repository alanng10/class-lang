namespace Class.Token;

public class SetCreateOperate : CreateOperate
{
    public virtual Create Create { get; set; }

    public override bool ExecuteToken()
    {
        int index;
        index = this.Create.TokenIndex;

        Token token;
        token = (Token)this.Create.TokenArray.GetAt(index);
        token.Row = this.Create.Row;

        Range aa;
        aa = token.Range; 
        Range ab;
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
        index = this.Create.InfoIndex;

        Info comment;
        comment = (Info)this.Create.InfoArray.GetAt(index);
        comment.Row = this.Create.Row;

        Range aa;
        aa = comment.Range;
        Range ab;
        ab = this.Create.Range;

        aa.Index = ab.Index;
        aa.Count = ab.Count;

        index = index + 1;

        this.Create.InfoIndex = index;
        return true;
    }
}