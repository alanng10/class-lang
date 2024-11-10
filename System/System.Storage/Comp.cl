class Comp : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;
        this.InternInfra : share InternInfra;
        this.ListInfra : share ListInfra;
        
        this.ModuleFoldPath : this.InternInfra.ModuleFoldPath;
        
        var Extern extern;
        extern : this.Extern;
        
        this.Intern : extern.StorageComp_New();
        extern.StorageComp_Init(this.Intern);
        return true;
    }

    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        extern.StorageComp_Final(this.Intern);
        extern.StorageComp_Delete(this.Intern);
        return true;
    }
    
    field prusate String ModuleFoldPath { get { return data; } set { data : value; } }
    field private Extern Extern { get { return data; } set { data : value; } }
    field private InternInfra InternInfra { get { return data; } set { data : value; } }
    field precate ListInfra ListInfra { get { return data; } set { data : value; } }
    field private Int Intern { get { return data; } set { data : value; } }
    
    maide prusate Bool Rename(var String path, var String destPath)
    {
        var Int pathU;
        pathU : this.InternInfra.StringCreate(path);
        var Int destPathU;
        destPathU : this.InternInfra.StringCreate(destPath);

        var Int k;
        k : this.Extern.StorageComp_Rename(this.Intern, pathU, destPathU);

        this.InternInfra.StringDelete(destPathU);
        this.InternInfra.StringDelete(pathU);

        var Bool a;
        a : ~(k = 0);
        return a;
    }
    
    maide prusate Bool FileCopy(var String path, var String destPath)
    {
        var Int pathU;
        pathU : this.InternInfra.StringCreate(path);
        var Int destPathU;
        destPathU : this.InternInfra.StringCreate(destPath);

        var Int k;
        k : this.Extern.StorageComp_FileCopy(this.Intern, pathU, destPathU);

        this.InternInfra.StringDelete(destPathU);
        this.InternInfra.StringDelete(pathU);

        var Bool a;
        a : ~(k = 0);
        return a;
    }
    
    maide prusate Bool FileDelete(var String path)
    {
        var Int pathU;
        pathU : this.InternInfra.StringCreate(path);

        var Int k;
        k : this.Extern.StorageComp_FileDelete(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        var Bool a;
        a : ~(k = 0);
        return a;
    }
    
    maide prusate Bool FoldCreate(var String path)
    {
        var Int pathU;
        pathU : this.InternInfra.StringCreate(path);

        var Int k;
        k : this.Extern.StorageComp_FoldCreate(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        var Bool a;
        a : ~(k = 0);
        return a;
    }
    
    maide prusate Bool FoldCopy(var String path, var String destPath)
    {
        var Int pathU;
        pathU : this.InternInfra.StringCreate(path);
        var Int destPathU;
        destPathU : this.InternInfra.StringCreate(destPath);

        var Int k;
        k : this.Extern.StorageComp_FoldCopy(this.Intern, pathU, destPathU);

        this.InternInfra.StringDelete(destPathU);
        this.InternInfra.StringDelete(pathU);

        var Bool a;
        a : ~(k = 0);
        return a;
    }
    
    maide prusate Bool FoldDelete(var String path)
    {
        var Int pathU;
        pathU : this.InternInfra.StringCreate(path);

        var Int k;
        k : this.Extern.StorageComp_FoldDelete(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        var Bool a;
        a : ~(k = 0);
        return a;
    }
}