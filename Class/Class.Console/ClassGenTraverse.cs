namespace Class.Console;

public class ClassGenTraverse : Traverse
{
    public virtual ClassGen Gen { get; set; }

    protected virtual bool Text(string text)
    {
        ClassGenOperate o;
        o = this.Gen.Operate;
        
        int count;
        count = text.Length;
        int i;
        i = 0;
        while (i < count)
        {
            char oc;
            oc = text[i];

            o.ExecuteChar(oc);

            i = i + 1;
        }
        return true;
    }
}