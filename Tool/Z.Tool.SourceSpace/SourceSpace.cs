namespace Z.Tool.SourceSpace;

public class SourceSpace : Base
{
    public override bool Init()
    {
        base.Init();
        this.StorageComp = StorageComp.This;

        this.NameLess = new TextLess();
        this.NameLess.CharLess = this.ILess;
        this.NameLess.LiteForm = this.TextInfra.AlphaSiteForm;
        this.NameLess.RiteForm = this.TextInfra.AlphaSiteForm;
        this.NameLess.Init();

        this.SActual = this.S("Actual");
        this.SOut = this.S("Out");
        this.SBin = this.S("bin");
        this.SObj = this.S("obj");
        this.SDotVSCode = this.S(".vscode");
        return true;
    }

    public virtual String Path { get; set; }
    protected virtual StorageComp StorageComp { get; set; }
    protected virtual TextLess NameLess { get; set; }
    protected virtual String SActual { get; set; }
    protected virtual String SOut { get; set; }
    protected virtual String SBin { get; set; }
    protected virtual String SObj { get; set; }
    protected virtual String SDotVSCode { get; set; }

    public virtual long Execute()
    {
        this.ExecuteFold(this.Path);
        return 0;
    }

    protected virtual bool ExecuteFold(String path)
    {
        Array entryList;
        entryList = this.StorageComp.EntryList(path, true, true);

        List foldList;
        foldList = new List();
        foldList.Init();

        List fileList;
        fileList = new List();
        fileList.Init();

        long count;
        count = entryList.Count;

        long i;
        i = 0;
        while (i < count)
        {
            StorageEntry entry;
            entry = entryList.GetAt(i) as StorageEntry;

            bool b;
            b = entry.Fold;

            if (b)
            {
                foldList.Add(entry);
            }

            if (!b)
            {
                fileList.Add(entry);
            }

            i = i + 1;
        }

        Array foldArray;
        Array fileArray;
        foldArray = this.ListInfra.ArrayCreateList(foldList);
        fileArray = this.ListInfra.ArrayCreateList(fileList);

        this.ExecuteFoldList(path, foldArray);

        this.ExecuteFileList(path, fileArray);

        return true;
    }

    protected virtual bool ExecuteFoldList(String path, Array array)
    {
        long count;
        count = array.Count;

        long i;
        i = 0;
        while (i < count)
        {
            StorageEntry entry;
            entry = array.GetAt(i) as StorageEntry;

            String name;
            name = entry.Name;

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
                if (this.NameSame(name, this.SDotVSCode))
                {
                    b = true;
                }
            }

            if (!b)
            {
                String ka;
                ka = this.AddClear().Add(path).Add(this.TextInfra.PathCombine).Add(name).AddResult();

                this.ExecuteFold(ka);
            }

            i = i + 1;
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
            StorageEntry entry;
            entry = array.GetAt(i) as StorageEntry;

            String name;
            name = entry.Name;

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

            i = i + 1;
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
        a = this.TextInfra.Same(this.TA(lite), this.TB(rite), this.NameLess);
        return a;
    }
}