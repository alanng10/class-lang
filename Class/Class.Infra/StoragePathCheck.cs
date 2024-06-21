namespace Class.Infra;

public class StoragePathCheck : Any
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;

        IntCompare charCompare;
        charCompare = new IntCompare();
        charCompare.Init();
        this.TextCompare = new TextCompare();
        this.TextCompare.CharCompare = charCompare;
        this.TextCompare.Init();

        this.BackSlash = this.TextInfra.TextCreateStringData("\\", null);
        return true;
    }

    protected virtual TextInfra TextInfra { get; set; }
    protected virtual TextCompare TextCompare { get; set; }
    protected virtual Text BackSlash { get; set; }

    public virtual bool IsValid(Text text)
    {
        int k;
        k = this.TextInfra.Index(text, this.BackSlash, this.TextCompare);

        if (!(k == -1))
        {
            return false;
        }

        return true;
    }
}