namespace Saber.Console;

public class ModulePort : TextAdd
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.ClassInfra = ClassInfra.This;
        this.CountList = CountList.This;

        this.SSystemDotInfra = this.S("System.Infra");
        this.SAny = this.S("Any");
        return true;
    }

    public virtual Table ModuleTable { get; set; }
    public virtual Table BinaryTable { get; set; }
    public virtual ModuleRef ModuleRef { get; set; }
    public virtual ClassModule Result { get; set; }
    public virtual long Status { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual CountList CountList { get; set; }
    protected virtual ClassModule Module { get; set; }
    protected virtual BinaryBinary Binary { get; set; }
    protected virtual Array ClassArray { get; set; }
    protected virtual Array ImportArray { get; set; }
    protected virtual Table VirtualTable { get; set; }
    protected virtual ClassClass AnyClass { get; set; }
    protected virtual String SSystemDotInfra { get; set; }
    protected virtual String SAny { get; set; }

    public virtual bool Execute()
    {
        bool b;
        b = this.ExecuteAll();

        this.Module = null;
        this.Binary = null;
        this.ClassArray = null;
        this.ImportArray = null;

        if (!b)
        {
            return false;
        }

        return true;
    }

    protected virtual bool ExecuteAll()
    {
        this.Status = 0;
        this.Result = null;

        if (this.ModuleTable.Valid(this.ModuleRef))
        {
            this.Status = 1;
            return false;
        }

        ClassModule a;
        a = new ClassModule();
        a.Init();
        a.Ref = this.ClassInfra.ModuleRefCreate(this.ModuleRef.Name, this.ModuleRef.Ver);

        this.Module = a;

        this.Binary = this.BinaryTable.Get(this.Module.Ref) as BinaryBinary;

        bool b;

        b = this.ExecuteClass();
        if (!b)
        {
            return false;
        }

        b = this.ExecuteImport();
        if (!b)
        {
            return false;
        }

        b = this.ExecuteExport();
        if (!b)
        {
            return false;
        }

        b = this.ExecuteBase();
        if (!b)
        {
            return false;
        }

        b = this.ExecutePart();
        if (!b)
        {
            return false;
        }

        b = this.ExecuteVirtual();
        if (!b)
        {
            return false;
        }

        b = this.ExecuteEntry();
        if (!b)
        {
            return false;
        }

        this.Result = this.Module;
        return true;
    }

    protected virtual bool ExecuteClass()
    {
        this.Module.Class = this.ClassInfra.TableCreateStringLess();

        Array array;
        array = this.Binary.Class;

        long count;
        count = array.Count;

        long i;
        i = 0;
        while (i < count)
        {
            BinaryClass binaryClass;
            binaryClass = array.GetAt(i) as BinaryClass;

            String name;
            name = binaryClass.Name;

            if (this.Module.Class.Valid(name))
            {
                this.Status = 11;
                return false;
            }

            ClassClass a;
            a = new ClassClass();
            a.Init();
            a.Name = name;
            a.Module = this.Module;
            a.Index = this.Module.Class.Count;

            this.ListInfra.TableAdd(this.Module.Class, a.Name, a);

            i = i + 1;
        }

        if (this.TextSame(this.TA(this.Module.Ref.Name), this.TB(this.SSystemDotInfra)))
        {
            ClassClass ka;
            ka = this.Module.Class.Get(this.SAny) as ClassClass;
            if (ka == null)
            {
                this.Status = 12;
                return false;
            }
            this.AnyClass = ka;
        }

        this.ClassArray = this.ListInfra.ArrayCreate(this.Module.Class.Count);

        Iter iter;
        iter = this.Module.Class.IterCreate();
        this.Module.Class.IterSet(iter);

        count = this.ClassArray.Count;
        i = 0;
        while (i < count)
        {
            iter.Next();

            ClassClass varClass;
            varClass = iter.Value as ClassClass;

            this.ClassArray.SetAt(i, varClass);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteImport()
    {
        this.Module.Import = this.ClassInfra.TableCreateModuleRefLess();

        long importTotal;
        importTotal = 0;

        Array array;
        array = this.Binary.Import;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            BinaryImport binaryImport;
            binaryImport = array.GetAt(i) as BinaryImport;

            ModuleRef moduleRef;
            moduleRef = binaryImport.Module;

            if (this.Module.Import.Valid(moduleRef))
            {
                this.Status = 20;
                return false;
            }

            Table classTable;
            classTable = this.ClassInfra.TableCreateRefLess();

            this.ListInfra.TableAdd(this.Module.Import, moduleRef, classTable);

            ClassModule module;
            module = this.ModuleGet(moduleRef);
            if (module == null)
            {
                this.Status = 21;
                return false;
            }

            BinaryBinary binary;
            binary = this.BinaryTable.Get(moduleRef) as BinaryBinary;
            if (binary == null)
            {
                this.Status = 22;
                return false;
            }

            long countA;
            countA = binaryImport.Class.Count;
            long iA;
            iA = 0;
            while (iA < countA)
            {
                InfraValue ke;
                ke = binaryImport.Class.GetAt(iA) as InfraValue;

                BinaryClass binaryClass;
                binaryClass = binary.Class.GetAt(ke.Int) as BinaryClass;
                if (binaryClass == null)
                {
                    this.Status = 23;
                    return false;
                }

                String className;
                className = binaryClass.Name;

                ClassClass varClass;
                varClass = this.ModuleClassGet(module, className);
                if (varClass == null)
                {
                    this.Status = 24;
                    return false;
                }

                if (classTable.Valid(varClass))
                {
                    this.Status = 25;
                    return false;
                }

                this.ListInfra.TableAdd(classTable, varClass, varClass);

                iA = iA + 1;
            }

            importTotal = importTotal + countA;

            i = i + 1;
        }

        this.ImportArray = this.ListInfra.ArrayCreate(importTotal);

        long importIndex;
        importIndex = 0;

        Iter iter;
        iter = this.Module.Import.IterCreate();
        this.Module.Import.IterSet(iter);

        while (iter.Next())
        {
            Table kd;
            kd = iter.Value as Table;

            Iter iterA;
            iterA = kd.IterCreate();
            kd.IterSet(iterA);
            while (iterA.Next())
            {
                ClassClass ka;
                ka = iterA.Value as ClassClass;

                this.ImportArray.SetAt(importIndex, ka);

                importIndex = importIndex + 1;
            }
        }

        return true;
    }

    protected virtual bool ExecuteExport()
    {
        this.Module.Export = this.ClassInfra.TableCreateStringLess();

        Array array;
        array = this.Binary.Export;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            InfraValue ka;
            ka = array.GetAt(i) as InfraValue;

            long k;
            k = ka.Int;

            ClassClass varClass;
            varClass = this.ClassGet(k);

            if (varClass == null)
            {
                this.Status = 30;
                return false;
            }

            this.ListInfra.TableAdd(this.Module.Export, varClass.Name, varClass);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteBase()
    {
        this.SetBaseList();

        this.SetBaseCount();
        return true;
    }

    protected virtual bool SetBaseList()
    {
        Array array;
        array = this.Binary.Base;

        long count;
        count = array.Count;
        if (!(count == this.ClassArray.Count))
        {
            this.Status = 40;
            return false;
        }

        long i;
        i = 0;
        while (i < count)
        {
            ClassClass varClass;
            varClass = this.ClassArray.GetAt(i) as ClassClass;

            InfraValue k;
            k = array.GetAt(i) as InfraValue;

            ClassClass baseClass;
            baseClass = this.ClassGet(k.Int);

            if (baseClass == null)
            {
                this.Status = 41;
                return false;
            }

            varClass.Base = baseClass;

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetBaseCount()
    {
        Array array;
        array = this.ClassArray;

        long count;
        count = array.Count;

        long i;
        i = 0;
        while (i < count)
        {
            ClassClass varClass;
            varClass = array.GetAt(i) as ClassClass;

            varClass.BaseCount = this.ClassInfra.BaseCount(varClass, this.AnyClass);

            i = i + 1;
        }

        return true;
    }

    protected virtual bool ExecutePart()
    {
        Array array;
        array = this.Binary.Part;

        long count;
        count = array.Count;
        if (!(count == this.ClassArray.Count))
        {
            this.Status = 50;
            return false;
        }

        long i;
        i = 0;
        while (i < count)
        {
            ClassClass varClass;
            varClass = this.ClassArray.GetAt(i) as ClassClass;

            BinaryPart k;
            k = array.GetAt(i) as BinaryPart;

            bool b;
            b = this.SetPart(varClass, k);
            if (!b)
            {
                return false;
            }

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetPart(ClassClass varClass, BinaryPart part)
    {
        varClass.FieldStart = part.FieldStart;

        varClass.MaideStart = part.MaideStart;

        bool b;

        b = this.SetPartField(varClass, part.Field);
        if (!b)
        {
            return false;
        }
        b = this.SetPartMaide(varClass, part.Maide);
        if (!b)
        {
            return false;
        }

        return true;
    }

    protected virtual bool SetPartField(ClassClass varClass, Array binaryField)
    {
        varClass.Field = this.ClassInfra.TableCreateStringLess();

        long count;
        count = binaryField.Count;
        long i;
        i = 0;
        while (i < count)
        {
            BinaryField ka;
            ka = binaryField.GetAt(i) as BinaryField;

            ClassClass k;
            k = this.ClassGet(ka.Class);
            if (k == null)
            {
                return false;
            }

            Field a;
            a = new Field();
            a.Init();
            a.Index = i;
            a.Name = ka.Name;
            a.Class = k;
            a.Count = this.CountList.Get(ka.Count);
            a.Parent = varClass;

            this.ListInfra.TableAdd(varClass.Field, a.Name, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetPartMaide(ClassClass varClass, Array binaryMaide)
    {
        varClass.Maide = this.ClassInfra.TableCreateStringLess();

        long count;
        count = binaryMaide.Count;
        long i;
        i = 0;
        while (i < count)
        {
            BinaryMaide ka;
            ka = binaryMaide.GetAt(i) as BinaryMaide;

            ClassClass k;
            k = this.ClassGet(ka.Class);
            if (k == null)
            {
                return false;
            }

            Maide a;
            a = new Maide();
            a.Init();
            a.Index = i;
            a.Name = ka.Name;
            a.Class = k;
            a.Count = this.CountList.Get(ka.Count);
            a.Parent = varClass;

            bool b;
            b = this.SetPartParam(a, ka.Param);
            if (!b)
            {
                return false;
            }

            this.ListInfra.TableAdd(varClass.Maide, a.Name, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetPartParam(Maide varMaide, Array binaryVar)
    {
        varMaide.Param = this.ClassInfra.TableCreateStringLess();

        long count;
        count = binaryVar.Count;
        long i;
        i = 0;
        while (i < count)
        {
            BinaryVar ka;
            ka = binaryVar.GetAt(i) as BinaryVar;

            ClassClass k;
            k = this.ClassGet(ka.Class);
            if (k == null)
            {
                return false;
            }

            Var a;
            a = new Var();
            a.Init();
            a.Name = ka.Name;
            a.Class = k;

            this.ListInfra.TableAdd(varMaide.Param, a.Name, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteVirtual()
    {
        this.VirtualTable = this.ClassInfra.TableCreateRefLess();

        long count;
        count = this.ClassArray.Count;
        long i;
        i = 0;
        while (i < count)
        {
            ClassClass varClass;
            varClass = this.ClassArray.GetAt(i) as ClassClass;

            bool b;
            b = this.VirtualClassSet(varClass);
            if (!b)
            {
                return false;
            }

            i = i + 1;
        }

        this.VirtualTable = null;
        return true;
    }

    protected virtual bool VirtualClassSet(ClassClass varClass)
    {
        if (this.VirtualTable.Valid(varClass))
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
            bool ba;
            ba = this.VirtualClassSet(ka);

            if (!ba)
            {
                return false;
            }
        }

        bool b;
        b = this.VirtualClassPartSet(varClass);

        if (!b)
        {
            return false;
        }

        this.ListInfra.TableAdd(this.VirtualTable, varClass, varClass);

        return true;
    }

    protected virtual bool VirtualClassPartSet(ClassClass varClass)
    {
        bool b;
        b = this.VirtualClassFieldSet(varClass);
        if (!b)
        {
            return false;
        }
        b = this.VirtualClassMaideSet(varClass);
        if (!b)
        {
            return false;
        }
        return true;
    }

    protected virtual bool VirtualClassFieldSet(ClassClass varClass)
    {
        Iter iter;
        iter = varClass.Field.IterCreate();
        varClass.Field.IterSet(iter);

        while (iter.Next())
        {
            Field a;
            a = iter.Value as Field;

            this.ClassInfra.VirtualField(a, this.AnyClass);
        }
        return true;
    }

    protected virtual bool VirtualClassMaideSet(ClassClass varClass)
    {
        Iter iterA;
        iterA = new TableIter();
        iterA.Init();

        Iter iterB;
        iterB = new TableIter();
        iterB.Init();

        Iter iter;
        iter = varClass.Maide.IterCreate();
        varClass.Maide.IterSet(iter);

        while (iter.Next())
        {
            Maide a;
            a = iter.Value as Maide;

            this.ClassInfra.VirtualMaide(a, this.AnyClass, iterA, iterB);
        }
        return true;
    }

    protected virtual bool ExecuteEntry()
    {
        String entry;
        entry = null;

        long k;
        k = this.Binary.Entry.Class;
        if (!(k == -1))
        {
            ClassClass a;
            a = this.ClassArray.GetAt(k) as ClassClass;
            if (a == null)
            {
                return false;
            }

            entry = a.Name;
        }

        this.Module.Entry = entry;
        return true;
    }

    protected virtual ClassClass ClassGet(long index)
    {
        ClassClass a;
        a = null;

        bool b;
        b = this.ClassArray.ValidAt(index);

        if (b)
        {
            a = this.ClassArray.GetAt(index) as ClassClass;
        }
        if (!b)
        {
            long ka;
            ka = index - this.ClassArray.Count;
            if (!this.ImportArray.ValidAt(ka))
            {
                return null;
            }
            a = this.ImportArray.GetAt(ka) as ClassClass;
        }
        return a;
    }

    protected virtual ClassModule ModuleGet(ModuleRef moduleRef)
    {
        ClassModule a;
        a = this.ModuleTable.Get(moduleRef) as ClassModule;
        return a;
    }

    protected virtual ClassClass ModuleClassGet(ClassModule module, String className)
    {
        ClassClass a;
        a = module.Class.Get(className) as ClassClass;
        return a;
    }
}