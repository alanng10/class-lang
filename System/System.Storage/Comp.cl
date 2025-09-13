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
    
    maide prusate Bool Exist(var String path)
    {
        var Int pathU;
        pathU : this.InternInfra.StringCreate(path);

        var Extern extern;
        extern : this.Extern;

        var Int ka;
        ka : extern.StorageEntry_New();
        extern.StorageEntry_Init(ka);

        extern.StorageComp_Entry(this.Intern, ka, pathU);

        var Int k;
        k : extern.StorageEntry_ExistGet(ka);

        extern.StorageEntry_Final(ka);
        extern.StorageEntry_Delete(ka);

        this.InternInfra.StringDelete(pathU);

        var Bool a;
        a : ~(k = 0);
        return a;
    }
    
    maide prusate Bool Fold(var String path)
    {
        var Int pathU;
        pathU : this.InternInfra.StringCreate(path);

        var Int k;
        k : this.Extern.StorageComp_Fold(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        var Bool a;
        a : ~(k = 0);
        return a;
    }
    
    maide prusate String ThisFoldGet()
    {
        var Int k;
        k : this.Extern.StorageComp_ThisFoldGet(this.Intern);
        
        var String a;
        a : this.InternInfra.StringCreateIntern(k);
        
        this.InternInfra.StringDelete(k);
        
        return a;
    }
    
    maide prusate Bool ThisFoldSet(var String path)
    {
        var Int pathU;
        pathU : this.InternInfra.StringCreate(path);

        var Int k;
        k : this.Extern.StorageComp_ThisFoldSet(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        var Bool a;
        a : ~(k = 0);
        return a;
    }
    
    maide prusate Array EntryList(var String path, var Bool fold)
    {
        var Int pathU;
        pathU : this.InternInfra.StringCreate(path);

        var Int foldU;
        foldU : 0;
        inf (fold)
        {
            foldU : 1;
        }

        var Extern extern;
        extern : this.Extern;

        var Int k;
        k : extern.StorageComp_EntryList(this.Intern, pathU, foldU);
        
        this.InternInfra.StringDelete(pathU);

        var Int count;
        count : extern.Array_CountGet(k);

        var Array array;
        array : this.ListInfra.ArrayCreate(count);

        var Int i;
        i : 0;
        while (i < count)
        {
            var Int u;
            u : extern.Array_ItemGet(k, i);

            var String a;
            a : this.InternInfra.StringCreateIntern(u);

            array.Set(i, a);

            i : i + 1;
        }

        i : 0;
        while (i < count)
        {
            var Int indexA;
            indexA : (count - 1) - i;

            var Int ua;
            ua : extern.Array_ItemGet(k, indexA);

            this.InternInfra.StringDelete(ua);

            i : i + 1;
        }

        extern.Array_Final(k);
        extern.Array_Delete(k);

        return array;
    }
}