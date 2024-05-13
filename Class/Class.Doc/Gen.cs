namespace Class.Doc;

public class Gen : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.ClassInfra = ClassInfra.This;
        return true;
    }

    public virtual string SourceFoldPath { get; set; }
    public virtual string DestFoldPath { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual Table Root { get; set; }

    public virtual bool Execute()
    {
        return true;
    }

    protected virtual bool ExecuteNode()
    {
        string nodePath;
        nodePath = this.SourceFoldPath;

        Table child;
        child = this.ChildTable(nodePath);

        Iter iter;
        iter = child.IterCreate();
        child.IterSet(iter);

        while (iter.Next())
        {
            string kk;
            kk = (string)iter.Index;

            Node aa;
            aa = this.CreateNode(nodePath, kk);

            child.Set(kk, aa);
        }

        this.Root = child;

        return true;
    }

    protected virtual Node CreateNode(string foldPath, string name)
    {
        Node a;
        a = new Node();
        a.Init();
        a.Name = name;

        string nodePath;
        nodePath = foldPath + this.InfraInfra.PathCombine + name;

        Table child;
        child = this.ChildTable(nodePath);

        Iter iter;
        iter = child.IterCreate();
        child.IterSet(iter);

        while (iter.Next())
        {
            string kk;
            kk = (string)iter.Index;

            Node aa;
            aa = this.CreateNode(nodePath, kk);

            child.Set(kk, aa);
        }

        return a;
    }

    protected virtual Table ChildTable(string foldPath)
    {
        Table child;
        child = this.ClassInfra.TableCreateStringCompare();

        Array array;
        array = this.FoldList(foldPath);

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            string name;
            name = (string)array.Get(i);

            this.ListInfra.TableAdd(child, name, null);

            i = i + 1;
        }
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