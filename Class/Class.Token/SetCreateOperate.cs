namespace Class.Token;

public class SetCreateOperate : CreateOperate
{
    public virtual Create Create { get; set; }

    public override bool ExecuteToken()
    {
        long index;
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

    public override bool ExecuteInfo()
    {
        long index;
        index = this.Create.InfoIndex;

        Info info;
        info = (Info)this.Create.InfoArray.GetAt(index);
        info.Row = this.Create.Row;

        Range aa;
        aa = info.Range;
        Range ab;
        ab = this.Create.Range;

        aa.Index = ab.Index;
        aa.Count = ab.Count;

        index = index + 1;

        this.Create.InfoIndex = index;
        return true;
    }
}