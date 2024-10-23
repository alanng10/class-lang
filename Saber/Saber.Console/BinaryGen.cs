namespace Saber.Console;

public class BinaryGen : Any
{
    public virtual ClassModule Module { get; set; }
    public virtual BinaryBinary Result { get; set; }
    protected virtual ListInfra ListInfra { get; set; }

    public virtual bool Execute()
    {
        BinaryBinary binary;
        binary = new BinaryBinary();
        binary.Init();

        this.ExecuteClass(binary);
        return true;
    }

    public virtual bool ExecuteClass(BinaryBinary binary)
    {
        long count;
        count = this.Module.Class.Count;

        Array array;
        array = this.ListInfra.ArrayCreate(count);

        Iter iter;
        iter = this.Module.Class.IterCreate();
        this.Module.Class.IterSet(iter);
        long i;
        i = 0;
        while (i < count)
        {
            iter.Next();

            ClassClass varClass;
            varClass = (ClassClass)iter.Value;

            BinaryClass a;
            a = new BinaryClass();
            a.Init();
            a.Name = varClass.Name;

            array.SetAt(i, a);

            i = i + 1;
        }

        binary.Class = array;

        return true;
    }
}