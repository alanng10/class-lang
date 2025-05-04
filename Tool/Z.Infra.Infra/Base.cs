namespace Z.Infra.Infra;

public class Base : TextAdd
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.StorageInfra = StorageInfra.This;
        this.Console = Console.This;
        return true;
    }

    protected virtual ListInfra ListInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual Console Console { get; set; }

    public virtual Array StringLine(Text text)
    {
        Array array;
        array = this.TextLine(text);

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            Text ka;
            ka = array.GetAt(i) as Text;

            String a;
            a = this.StringCreate(ka);

            array.SetAt(i, a);

            i = i + 1;
        }

        return array;
    }

    public virtual Text TextCreateDataRange(Data data, long index, long count)
    {
        Range range;
        range = new Range();
        range.Init();
        range.Index = index;
        range.Count = count;

        Text text;
        text = new Text();
        text.Init();
        text.Data = data;
        text.Range = range;
        return text;
    }

    public virtual Table TableCreateStringLess()
    {
        StringLess less;
        less = this.TextInfra.StringLessCreate();

        Table a;
        a = new Table();
        a.Less = less;
        a.Init();
        return a;
    }

    public virtual Text Place(Text text, string limit, String join)
    {
        return this.TextPlace(text, this.TE(this.S(limit)), this.TF(join));
    }

    public virtual String StorageTextRead(String filePath)
    {
        String a;
        a = this.StorageInfra.TextRead(filePath);

        if (a == null)
        {
            String k;
            k = this.AddClear().AddS("Text File Read Error path: ").Add(filePath).AddLine().AddResult();

            this.Console.Err.Write(k);
            global::System.Environment.Exit(1);
        }
        return a;
    }

    public virtual bool StorageTextWrite(String filePath, String text)
    {
        bool a;
        a = this.StorageInfra.TextWrite(filePath, text);

        if (!a)
        {
            String k;
            k = this.AddClear().AddS("Text File Write Error path: ").Add(filePath).AddLine().AddResult();

            this.Console.Err.Write(k);
            global::System.Environment.Exit(1);
        }
        return a;
    }
}