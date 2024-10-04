namespace Saber.Token;

public class SetCreateOperate : CreateOperate
{
    public virtual Create Create { get; set; }

    public override bool ExecuteToken()
    {
        CreateArg arg;
        arg = this.Create.Arg;
        long index;
        index = arg.TokenIndex;

        Token token;
        token = (Token)arg.TokenArray.GetAt(index);
        token.Row = this.Create.Row;

        Range aa;
        aa = token.Range; 
        Range ab;
        ab = this.Create.LineRange;
        
        aa.Index = ab.Index;
        aa.Count = ab.Count;

        index = index + 1;

        arg.TokenIndex = index;
        return true;
    }

    public override bool ExecuteInfo()
    {
        CreateArg arg;
        arg = this.Create.Arg;
        long index;
        index = arg.InfoIndex;

        Info info;
        info = (Info)arg.InfoArray.GetAt(index);
        info.Row = this.Create.Row;

        Range aa;
        aa = info.Range;
        Range ab;
        ab = this.Create.LineRange;

        aa.Index = ab.Index;
        aa.Count = ab.Count;

        index = index + 1;

        arg.InfoIndex = index;
        return true;
    }
}