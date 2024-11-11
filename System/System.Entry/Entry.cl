class Entry : Any
{
    maide prusate Int Execute()
    {
        this.MainBefore();

        var Int a;
        a : this.ExecuteMain();

        this.MainAfter();

        return a;
    }

    maide prusate Bool Init()
    {
        base.Init();
        this.InternIntern : share Intern;
        this.InternInfra : share InternInfra;
        return true;
    }

    field prusate Array Arg { get { return data; } set { data : value; } }
    field private InternIntern Intern { get { return data; } set { data : value; } }
    field private InternInfra InternInfra { get { return data; } set { data : value; } }
    field private StorageComp StorageComp { get { return data; } set { data : value; } }

    maide precate Bool MainBefore()
    {
        var Thread ka;
        ka : new Thread;
        ka.InitMainThread();

        this.StorageComp : share StorageComp;

        var String k;
        k : this.StorageComp.ThisFoldGet();

        this.InternInfra.ModuleFoldPath : k;

        this.StorageComp.ModuleFoldPath : k;

        this.ArrayArg();
        return true;
    }

    maide precate Bool MainAfter()
    {
        return true;
    }

    maide precate Int ExecuteMain()
    {
        return 0;
    }

    maide precate Bool ArrayArg()
    {
        var Int count;
        count : this.InternIntern.ArgCount();

        var Array array;
        array : new Array;
        array.Count : count;
        array.Init();

        var Int i;
        i : 0;
        while (i < count)
        {
            var String k;
            k : this.InternIntern.Arg(i);
            
            array.Set(i, k);

            i : i + 1;
        }

        this.Arg : array;
        return true;        
    }
}