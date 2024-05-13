namespace Class.Doc;

public class Gen : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        return true;
    }

    public virtual string SourceFoldPath { get; set; }
    public virtual string DestFoldPath { get; set; }
    protected virtual ListInfra ListInfra { get; set; }

    public virtual bool Execute()
    {
        return true;
    }

    protected virtual Table ChildList(string foldPath)
    {
        return null;
    }

    protected virtual Array FoldList(string foldPath)
    {
        string[] u;
        u = Directory.GetDirectories(foldPath);

        int count;
        count = u.Length;
        int i;
        i = 0;
        while (i < count)
        {
            string path;
            path = u[i];

            string name;
            name = Path.GetFileName(path);

            u[i] = name;
            i = i + 1;
        }

        Array array;
        array = this.ListInfra.ArrayCreate(count);

        i = 0;
        while (i < count)
        {
            string k;
            k = u[i];

            array.Set(i, k);
            i = i + 1;
        }

        Range range;
        range = new Range();
        range.Init();
        range.Count = count;

        StringCompare compare;
        compare = new StringCompare();
        compare.Init();

        array.Sort(range, compare);

        return array;
    }
}