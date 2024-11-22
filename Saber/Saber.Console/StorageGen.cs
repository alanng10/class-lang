namespace Saber.Console;

public class StorageGen : ClassBase
{
    public override bool Init()
    {
        base.Init();
        this.StorageInfra = StorageInfra.This;
        this.StorageComp = StorageComp.This;
        this.SData = this.S("data");
        return true;
    }

    public virtual ClassModule Module { get; set; }
    public virtual String ModuleRefString { get; set; }
    public virtual String ClassPath { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual StorageComp StorageComp { get; set; }
    protected virtual String SData { get; set; }

    public virtual bool Execute()
    {
        String dataFoldPath;
        dataFoldPath = this.AddClear().Add(this.ClassPath)
            .Add(this.TextInfra.PathCombine)
            .Add(this.ModuleRefString).Add(this.ClassInfra.Dot).Add(this.SData).AddResult();

        this.StorageComp.FoldDelete(dataFoldPath);

        Iter iter;
        iter = this.Module.Storage.IterCreate();
        this.Module.Storage.IterSet(iter);

        while (iter.Next())
        {
            String destPath;
            String sourcePath;
            destPath = iter.Index as String;
            sourcePath = iter.Value as String;

            long combine;
            combine = this.StorageInfra.EntryPathNameCombine(this.TA(destPath), this.TLess);

            String destFoldPath;
            destFoldPath = this.StringCreateRange(destPath, 0, combine);

            this.StorageComp.FoldCreate(destFoldPath);

            bool fold;
            fold = this.StorageComp.Fold(sourcePath);

            if (fold)
            {
                bool ba;
                ba = this.StorageComp.FoldCopy(sourcePath, destPath);

                if (!ba)
                {
                    return false;
                }
            }

            if (!fold)
            {
                bool ba;
                ba = this.StorageComp.FileCopy(sourcePath, destPath);

                if (!ba)
                {
                    return false;
                }
            }
        }

        return true;
    }
}