namespace Z.Tool.SourceSpace;

public class SourceSpace : Base
{
    public override bool Init()
    {
        base.Init();
        this.StorageComp = StorageComp.This;

        this.SActual = this.S("Actual");
        return true;
    }

    public virtual String Path { get; set; }
    protected virtual StorageComp StorageComp { get; set; }
    protected virtual String SActual { get; set; }

    public virtual long Execute()
    {
        
        return 0;
    }

    protected virtual bool ExecuteFileList(String path, Array array)
    {
        long count;
        count = array.Count;

        long i;
        i = 0;
        while (i < count)
        {
            String name;
            name = array.GetAt(i) as String;

            bool b;
            b = false;
            if (this.TextSame(this.TA(name), this.TB(this.SActual)))
            {
                b = true;
            }

            if (!b)
            {
                String ka;
                ka = this.AddClear().Add(path).Add(this.TextInfra.PathCombine).Add(name).AddResult();

                String kk;
                kk = this.StorageTextRead(ka);

                this.ExecuteText(ka, kk);
            }
        }

        return true;
    }

    protected virtual bool ExecuteText(String path, String text)
    {
        Text ka;
        ka = this.TextCreate(text);

        Array array;
        array = this.TextLine(ka);

        long count;
        count = array.Count;

        long i;
        i = 0;
        while (i < count)
        {
            Text kk;
            kk = array.GetAt(i) as Text;

            if (this.TextEnd(kk, this.TA(this.SSpace)))
            {
                this.Console.Out.Write(this.AddClear().Add(path).AddS(" : ").Add(this.StringInt(i + 1)).AddLine().AddResult());
            }

            i = i + 1;
        }

        return true;
    }
}