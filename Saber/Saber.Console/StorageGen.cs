namespace Saber.Console;

public class StorageGen : TextAdd
{
    public override bool Init()
    {
        base.Init();
        this.StorageInfra = StorageInfra.This;
        this.ClassInfra = ClassInfra.This;
        this.StorageComp = StorageComp.This;
        this.SData = this.S("Data");
        return true;
    }

    public virtual ClassModule Module { get; set; }
    public virtual String ModuleRefString { get; set; }
    public virtual String ClassPath { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual StorageComp StorageComp { get; set; }
    protected virtual String SData { get; set; }

    public virtual bool Execute()
    {
        String dataFoldPath;
        dataFoldPath = this.AddClear().Add(this.ClassInfra.ClassModulePath(this.ClassPath))
            .Add(this.TextInfra.PathCombine)
            .Add(this.ModuleRefString).Add(this.TextInfra.PathCombine).Add(this.SData).AddResult();

        this.StorageComp.FoldDelete(dataFoldPath);

        this.StorageComp.FoldCreate(dataFoldPath);

        bool ba;

        ba = this.StorageComp.Exist(dataFoldPath);
        if (!ba)
        {
            return false;
        }

        ba = this.StorageComp.Fold(dataFoldPath);
        if (!ba)
        {
            return false;
        }

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

            String pathA;
            pathA = null;

            if (!(combine == -1))
            {
                pathA = this.StringCreateRange(destPath, 0, combine);
            }
            
            if (!(pathA == null))
            {
                String destFoldPath;
                destFoldPath = this.AddClear().Add(dataFoldPath).Add(this.TextInfra.PathCombine).Add(pathA).AddResult();

                this.StorageComp.FoldCreate(destFoldPath);

                bool bb;

                bb = this.StorageComp.Exist(destFoldPath);
                if (!bb)
                {
                    return false;
                }

                bb = this.StorageComp.Fold(destFoldPath);
                if (!bb)
                {
                    return false;
                }
            }

            String finalDestPath;
            finalDestPath = this.AddClear().Add(dataFoldPath).Add(this.TextInfra.PathCombine).Add(destPath).AddResult();

            bool fold;
            fold = this.StorageComp.Fold(sourcePath);

            if (fold)
            {
                bool bc;
                bc = this.StorageComp.FoldCopy(sourcePath, finalDestPath);

                if (!bc)
                {
                    return false;
                }
            }

            if (!fold)
            {
                bool bd;
                bd = this.StorageComp.FileCopy(sourcePath, finalDestPath);

                if (!bd)
                {
                    return false;
                }
            }
        }

        return true;
    }
}