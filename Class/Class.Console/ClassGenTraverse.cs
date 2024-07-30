namespace Class.Console;

public class ClassGenTraverse : Traverse
{
    public virtual ClassGen Gen { get; set; }

    protected virtual bool Text(string text)
    {
        return this.Gen.Text(text);
    }
}