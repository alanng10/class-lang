namespace Saber.Console;

public class ClassBaseGen : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        return true;
    }

    public virtual ClassClass Class { get; set; }
    public virtual Array Result { get; set; }
    protected virtual ListInfra ListInfra { get; set; }

    public virtual bool Execute()
    {
        long count;
        count = this.Class.BaseCount;

        Array array;
        array = this.ListInfra.ArrayCreate(count);

        this.Result = array;

        ClassClass varClass;
        varClass = this.Class;

        long i;
        i = 0;
        while (i < count)
        {
            long index;
            index = (count - 1) - i;

            array.SetAt(index, varClass);

            varClass = varClass.Base;

            i = i + 1;
        }

        return true;
    }
}