namespace Avalon.Infra;

public class StringJoin : Any
{
    public override bool Init()
    {
        base.Init();
        this.Builder = new StringBuilder();
        return true;
    }

    private StringBuilder Builder { get; set; }

    public virtual string Result()
    {
        return this.Builder.ToString();
    }

    public virtual bool Clear()
    {
        this.Builder.Clear();
        return true;
    }

    public virtual bool Append(string a)
    {
        this.Builder.Append(a);
        return true;
    }

    public virtual bool AppendChar(char a)
    {
        this.Builder.Append(a);
        return true;
    }
}