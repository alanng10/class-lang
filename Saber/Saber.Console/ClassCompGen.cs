namespace Saber.Console;

public class ClassCompGen : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;

        this.TableIter = this.CreateTableIter();
        return true;
    }

    protected virtual TableIter CreateTableIter()
    {
        TableIter a;
        a = new TableIter();
        a.Init();
        return a;
    }

    public virtual ClassClass Class { get; set; }
    public virtual Array BaseArray { get; set; }
    public virtual ClassComp Result { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TableIter TableIter { get; set; }

    public virtual bool Execute()
    {
        long fieldCount;
        fieldCount = this.Class.FieldStart + this.Class.Field.Count;
        long maideCount;
        maideCount = this.Class.MaideStart + this.Class.Maide.Count;

        ClassComp k;
        k = new ClassComp();
        k.Init();
        this.Result = k;

        k.Field = this.ListInfra.ArrayCreate(fieldCount);
        k.Maide = this.ListInfra.ArrayCreate(maideCount);

        Array array;
        array = this.BaseArray;

        long count;
        count = array.Count;

        long i;
        i = 0;
        while (i < count)
        {
            ClassClass kk;
            kk = array.GetAt(i) as ClassClass;

            this.ExecuteSetClass(k, kk);

            i = i + 1;
        }

        return true;
    }

    public virtual bool ExecuteSetClass(ClassComp classComp, ClassClass varClass)
    {
        this.ExecuteSetClassField(classComp.Field, varClass);

        this.ExecuteSetClassMaide(classComp.Maide, varClass);
        return true;
    }

    public virtual bool ExecuteSetClassField(Array array, ClassClass varClass)
    {
        Iter iter;
        iter = this.TableIter;

        varClass.Field.IterSet(iter);

        while (iter.Next())
        {
            Field varField;
            varField = iter.Value as Field;

            Field k;
            k = varField;

            if (!(varField.Virtual == null))
            {
                k = varField.Virtual;
            }

            ClassClass ka;
            ka = k.Parent;

            long kk;
            kk = ka.FieldStart;
            kk = kk + k.Index;

            array.SetAt(kk, varField);
        }

        iter.Clear();

        return true;
    }

    public virtual bool ExecuteSetClassMaide(Array array, ClassClass varClass)
    {
        Iter iter;
        iter = this.TableIter;

        varClass.Maide.IterSet(iter);

        while (iter.Next())
        {
            Maide maide;
            maide = iter.Value as Maide;

            Maide k;
            k = maide;

            if (!(maide.Virtual == null))
            {
                k = maide.Virtual;
            }

            ClassClass ka;
            ka = k.Parent;

            long kk;
            kk = ka.MaideStart;
            kk = kk + k.Index;

            array.SetAt(kk, maide);
        }

        iter.Clear();

        return true;
    }
}