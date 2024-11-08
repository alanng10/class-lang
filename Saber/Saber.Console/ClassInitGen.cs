namespace Saber.Console;

public class ClassInitGen : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.ClassInfra = ClassInfra.This;
        return true;
    }

    public virtual ClassModule Module { get; set; }
    public virtual ClassClass AnyClass { get; set; }
    public virtual Array Result { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual Table ClassTable { get; set; }
    protected virtual long Count { get; set; }

    public virtual bool Execute()
    {
        this.ClassTable = this.ClassInfra.TableCreateRefLess();

        this.Count = 0;

        this.Result = this.ListInfra.ArrayCreate(this.Module.Class.Count);

        Iter iter;
        iter = this.Module.Class.IterCreate();

        this.Module.Class.IterSet(iter);

        while (iter.Next())
        {
            ClassClass varClass;
            varClass = iter.Value as ClassClass;

            this.ClassOne(varClass);
        }

        this.ClassTable = null;
        this.Count = 0;
        return true;
    }

    protected virtual bool ClassOne(ClassClass varClass)
    {
        if (this.ClassTable.Valid(varClass))
        {
            return true;
        }

        if (!(varClass.Module == this.Module))
        {
            return true;
        }

        ClassClass ka;
        ka = null;
        if (!(varClass == this.AnyClass))
        {
            ka = varClass.Base;
        }

        if (!(ka == null))
        {
            this.ClassOne(ka);
        }

        this.Result.SetAt(this.Count, varClass);

        this.Count = this.Count + 1;

        this.ListInfra.TableAdd(this.ClassTable, varClass, varClass);

        return true;
    }
}