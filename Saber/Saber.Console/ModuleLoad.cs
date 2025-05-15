namespace Saber.Console;

public class ModuleLoad : TextAdd
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
    public virtual ClassModule Module { get; set; }
    public virtual long Status { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual CountList CountList { get; set; }
    protected virtual BinaryBinary Binary { get; set; }
    protected virtual Array ClassArray { get; set; }
    protected virtual Array ImportArray { get; set; }
    protected virtual Table VirtualClassTable { get; set; }
    protected virtual ClassClass AnyClass { get; set; }
    protected virtual String SSystemDotInfra { get; set; }
    protected virtual String SAny { get; set; }

    public virtual bool Execute()
    {
        bool b;
        b = this.ExecuteAll();

        this.Binary = null;
        this.ClassArray = null;
        this.ImportArray = null;

        if (!b)
        {
            this.Module = null;
            return false;
        }

        return true;
    }

    protected virtual bool ExecuteAll()
    {
        this.Status = 0;

        ModuleRef o;
        o = this.ModuleRef;

        if (this.ModuleTable.Valid(o))
        {
            this.Status = 1;
            return false;
        }

        ClassModule a;
        a = new ClassModule();
        a.Init();
        a.Ref = this.ClassInfra.ModuleRefCreate(o.Name, o.Ver);

        this.Module = a;

        BinaryBinary binary;
        binary = this.BinaryTable.Get(this.Module.Ref) as BinaryBinary;
        this.Binary = binary;

        bool b;
        
        b = this.SetClassList();
        if (!b)
        {
            return false;
        }

        b = this.SetImportList();
        if (!b)
        {
            return false;
        }

        b = this.SetBaseList();
        if (!b)
        {
            return false;
        }

        b = this.SetBaseCount();
        if (!b)
        {
            return false;
        }

        b = this.SetPartList();
        if (!b)
        {
            return false;
        }

        b = this.SetVirtualList();
        if (!b)
        {
            return false;
        }

        b = this.SetEntry();
        if (!b)
        {
            return false;
        }
        return true;
    }

    protected virtual bool SetClassList()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        Table classTable;
        classTable = this.ClassInfra.TableCreateStringLess();
        
        this.Module.Class = classTable;

        Array array;
        array = this.Binary.Class;
        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            BinaryClass o;
            o = array.GetAt(i) as BinaryClass;

            String name;
            name = o.Name;

            if (classTable.Valid(name))
            {
                this.Status = 11;
                return false;
            }

            ClassClass a;
            a = new ClassClass();
            a.Init();
            a.Index = classTable.Count;
            a.Name = name;
            a.Module = this.Module;

            listInfra.TableAdd(classTable, name, a); 

            i = i + 1;
        }

        if (this.TextSame(this.TA(this.Module.Ref.Name), this.TB(this.SSystemDotInfra)))
        {
            ClassClass oo;
            oo = classTable.Get(this.SAny) as ClassClass;
            if (oo == null)
            {
                this.Status = 12;
                return false;
            }
            this.AnyClass = oo;
        }

        Array classArray;
        classArray = listInfra.ArrayCreate(classTable.Count);

        Iter iter;
        iter = classTable.IterCreate();
        classTable.IterSet(iter);

        count = classArray.Count;
        i = 0;
        while (i < count)
        {
            iter.Next();
            ClassClass oa;
            oa = iter.Value as ClassClass;

            classArray.SetAt(i, oa);
            i = i + 1;
        }

        this.ClassArray = classArray;
        return true;
    }
    
    protected virtual bool SetImportList()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;
        ClassInfra classInfra;
        classInfra = this.ClassInfra;

        Table binaryTable;
        binaryTable = this.BinaryTable;

        Table importTable;
        importTable = classInfra.TableCreateModuleRefLess();

        this.Module.Import = importTable;
        
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
            BinaryImport o;
            o = (BinaryImport)array.GetAt(i);

            ModuleRef moduleRef;
            moduleRef = o.Module;

            if (importTable.Valid(moduleRef))
            {
                this.Status = 20;
                return false;
            }

            Table classTable;
            classTable = classInfra.TableCreateRefLess();

            listInfra.TableAdd(importTable, moduleRef, classTable);
            
            ClassModule module;
            module = this.ModuleGet(moduleRef);
            if (module == null)
            {
                this.Status = 21;
                return false;
            }

            BinaryBinary oo;
            oo = binaryTable.Get(moduleRef) as BinaryBinary;
            if (oo == null)
            {
                this.Status = 22;
                return false;
            }

            Array oa;
            oa = o.Class;
            long countA;
            countA = oa.Count;
            long iA;
            iA = 0;
            while (iA < countA)
            {
                InfraValue oe;
                oe = (InfraValue)oa.GetAt(iA);

                BinaryClass of;
                of = oo.Class.GetAt(oe.Int) as BinaryClass;
                if (of == null)
                {
                    this.Status = 23;
                    return false;
                }

                String className;
                className = of.Name;

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

                listInfra.TableAdd(classTable, varClass, varClass);

                iA = iA + 1;
            }

            importTotal = importTotal + countA;

            i = i + 1;
        }

        Array importArray;
        importArray = listInfra.ArrayCreate(importTotal);

        long oi;
        oi = 0;
        Iter iter;
        iter = importTable.IterCreate();
        importTable.IterSet(iter);
        while (iter.Next())
        {
            Table ooo;
            ooo = (Table)iter.Value;

            Iter iterA;
            iterA = ooo.IterCreate();
            ooo.IterSet(iterA);
            while(iterA.Next())
            {
                ClassClass ooa;
                ooa = iterA.Value as ClassClass;

                importArray.SetAt(oi, ooa);

                oi = oi + 1;
            }
        }

        this.ImportArray = importArray;
        return true;
    }

    protected virtual bool SetBaseList()
    {
        Array array;
        array = this.Binary.Base;

        Array classArray;
        classArray = this.ClassArray;

        long count;
        count = array.Count;
        if (!(count == classArray.Count))
        {
            this.Status = 30;
            return false;
        }

        long i;
        i = 0;
        while (i < count)
        {
            ClassClass varClass;
            varClass = classArray.GetAt(i) as ClassClass;

            InfraValue a;
            a = array.GetAt(i) as InfraValue;

            ClassClass baseClass;
            baseClass = this.ClassGetIndex(a.Int);

            if (baseClass == null)
            {
                this.Status = 31;
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

    protected virtual bool SetPartList()
    {
        Array array;
        array = this.Binary.Part;

        Array classArray;
        classArray = this.ClassArray;

        long count;
        count = array.Count;
        if (!(count == classArray.Count))
        {
            this.Status = 40;
            return false;
        }

        long i;
        i = 0;
        while (i < count)
        {
            ClassClass varClass;
            varClass = (ClassClass)classArray.GetAt(i);

            BinaryPart a;
            a = (BinaryPart)array.GetAt(i);

            bool b;
            b = this.SetPart(varClass, a);
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
        ListInfra listInfra;
        listInfra = this.ListInfra;

        Table fieldTable;
        fieldTable = this.ClassInfra.TableCreateStringLess();

        varClass.Field = fieldTable;

        long count;
        count = binaryField.Count;
        int i;
        i = 0;
        while (i < count)
        {
            BinaryField ua;
            ua = (BinaryField)binaryField.GetAt(i);

            ClassClass c;
            c = this.ClassGetIndex(ua.Class);
            if (c == null)
            {
                return false;
            }

            String name;
            name = ua.Name;

            Field a;
            a = new Field();
            a.Init();
            a.Index = i;
            a.Name = name;
            a.Class = c;
            a.Count = this.CountList.Get(ua.Count);
            a.Parent = varClass;

            listInfra.TableAdd(fieldTable, a.Name, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetPartMaide(ClassClass varClass, Array binaryMaide)
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        Table maideTable;
        maideTable = this.ClassInfra.TableCreateStringLess();
        
        varClass.Maide = maideTable;

        long count;
        count = binaryMaide.Count;
        long i;
        i = 0;
        while (i < count)
        {
            BinaryMaide ua;
            ua = (BinaryMaide)binaryMaide.GetAt(i);

            ClassClass c;
            c = this.ClassGetIndex(ua.Class);
            if (c == null)
            {
                return false;
            }

            String name;
            name = ua.Name;

            Maide a;
            a = new Maide();
            a.Init();
            a.Index = i;
            a.Name = name;
            a.Class = c;
            a.Count = this.CountList.Get(ua.Count);
            a.Parent = varClass;

            bool b;
            b = this.SetPartParam(a, ua.Param);
            if (!b)
            {
                return false;
            }

            listInfra.TableAdd(maideTable, a.Name, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetPartParam(Maide varMaide, Array binaryVar)
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        Table varTable;
        varTable = this.ClassInfra.TableCreateStringLess();
        
        varMaide.Param = varTable;

        long count;
        count = binaryVar.Count;
        long i;
        i = 0;
        while (i < count)
        {
            BinaryVar ua;
            ua = (BinaryVar)binaryVar.GetAt(i);

            ClassClass c;
            c = this.ClassGetIndex(ua.Class);
            if (c == null)
            {
                return false;
            }

            String name;
            name = ua.Name;
            
            Var a;
            a = new Var();
            a.Init();
            a.Name = name;
            a.Class = c;

            listInfra.TableAdd(varTable, a.Name, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetVirtualList()
    {
        this.VirtualClassTable = this.ClassInfra.TableCreateRefLess();

        Array classArray;
        classArray = this.ClassArray;

        long count;
        count = classArray.Count;
        long i;
        i = 0;
        while (i < count)
        {
            ClassClass varClass;
            varClass = classArray.GetAt(i) as ClassClass;

            bool b;
            b = this.VirtualClassSet(varClass);
            if (!b)
            {
                return false;
            }

            i = i + 1;
        }

        this.VirtualClassTable = null;
        return true;
    }

    protected virtual bool VirtualClassSet(ClassClass varClass)
    {
        if (this.VirtualClassTable.Valid(varClass))
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

        this.ListInfra.TableAdd(this.VirtualClassTable, varClass, varClass);

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
        Iter iter;
        iter = varClass.Maide.IterCreate();
        varClass.Maide.IterSet(iter);

        while (iter.Next())
        {
            Maide a;
            a = iter.Value as Maide;

            this.ClassInfra.VirtualMaide(a, this.AnyClass);
        }
        return true;
    }
    
    protected virtual bool SetEntry()
    {
        String entry;
        entry = null;

        long f;
        f = this.Binary.Entry;
        if (!(f == -1))
        {
            ClassClass a;
            a = (ClassClass)this.ClassArray.GetAt(f);
            if (a == null)
            {
                return false;
            }

            entry = a.Name;
        }

        this.Module.Entry = entry;
        return true;
    }

    protected virtual ClassClass ClassGetIndex(long index)
    {
        Array classArray;
        classArray = this.ClassArray;

        ClassClass a;
        a = null;
        bool b;
        b = (classArray.ValidAt(index));
        if (b)
        {
            a = classArray.GetAt(index) as ClassClass;
        }
        if (!b)
        {
            long oa;
            oa = index - classArray.Count;
            if (!this.ImportArray.ValidAt(oa))
            {
                return null;
            }
            a = this.ImportArray.GetAt(oa) as ClassClass;
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

    protected virtual ClassClass ClassGet(ModuleRef moduleRef, String className)
    {
        ClassModule ae;
        ae = this.ModuleGet(moduleRef);
        ClassClass a;
        a = this.ModuleClassGet(ae, className);
        return a;
    }
}