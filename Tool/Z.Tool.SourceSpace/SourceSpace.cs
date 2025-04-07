namespace Z.Tool.SourceSpace;

public class SourceSpace : Base
{
    public override bool Init()
    {
        base.Init();
        this.StorageComp = StorageComp.This;

        this.SActual = this.S("Actual");
        this.SOut = this.S("Out");
        this.SBin = this.S("bin");
        this.SObj = this.S("obj");
        return true;
    }

    public virtual String Path { get; set; }
    protected virtual StorageComp StorageComp { get; set; }
    protected virtual String SActual { get; set; }
    protected virtual String SOut { get; set; }
    protected virtual String SBin { get; set; }
    protected virtual String SObj { get; set; }

    public virtual long Execute()
    {
        
        return 0;
    }

    protected virtual bool ExecuteFoldList(String path, Array array)
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
            if (!b)
            {
                if (this.NameSame(name, this.SOut))
                {
                    b = true;
                }
            }
            if (!b)
            {
                if (this.NameSame(name, this.SBin))
                {
                    b = true;
                }
            }
            if (!b)
            {
                if (this.NameSame(name, this.SObj))
                {
                    b = true;
                }
            }

            if (!b)
            {
                
            }
        }

        return true;
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

    protected virtual bool NameSame(String lite, String rite)
    {
        bool a;
        a = this.TextSame(this.TextForm(this.TA(lite), this.TextInfra.AlphaSiteForm), this.TextForm(this.TB(rite), this.TextInfra.AlphaSiteForm));
        return a;
    }
}