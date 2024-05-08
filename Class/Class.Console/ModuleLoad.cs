namespace Class.Console;

public class ModuleLoad : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.ClassInfra = ClassInfra.This;
        this.CountList = CountList.This;
        return true;
    }

    public virtual Table ModuleTable { get; set; }
    public virtual Table BinaryTable { get; set; }
    public virtual ModuleRef ModuleRef { get; set; }
    public virtual ClassModule Module { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual CountList CountList { get; set; }
    protected virtual BinaryBinary Binary { get; set; }
    protected virtual Array ClassArray { get; set; }
    protected virtual Array ImportArray { get; set; }

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
        ModuleRef o;
        o = this.ModuleRef;

        if (this.ModuleTable.Contain(o))
        {
            return false;
        }

        ClassModule a;
        a = new ClassModule();
        a.Init();
        a.Ref = this.ClassInfra.ModuleRefCreate(o.Name, o.Version);

        this.Module = a;

        BinaryBinary binary;
        binary = (BinaryBinary)this.BinaryTable.Get(this.Module.Ref);
        this.Binary = binary;

        bool b;
        
        this.SetClassList();

        this.SetImportList();

        this.SetBaseList();

        b = this.SetPartList();
        if (!b)
        {
            return false;
        }

        this.SetVirtualList();

        this.SetEntry();
        return true;
    }

    protected virtual bool SetClassList()
    {
        Table classTable;
        classTable = this.ClassInfra.TableCreateStringCompare();
        
        this.Module.Class = classTable;

        Array array;
        array = this.Binary.Class;
        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            BinaryClass o;
            o = (BinaryClass)array.Get(i);

            string name;
            name = o.Name;

            ClassClass a;
            a = new ClassClass();
            a.Init();
            a.Index = classTable.Count;
            a.Name = name;
            a.Module = this.Module;

            this.ListInfra.TableAdd(classTable, a.Name, a); 

            i = i + 1;
        }

        Array classArray;
        classArray = this.ListInfra.ArrayCreate(classTable.Count);

        Iter iter;
        iter = classTable.IterCreate();
        classTable.IterSet(iter);

        count = classArray.Count;
        i = 0;
        while (i < count)
        {
            iter.Next();
            ClassClass oa;
            oa = (ClassClass)iter.Value;

            classArray.Set(i, oa);
            i = i + 1;
        }

        this.ClassArray = classArray;
        return true;
    }
    
    protected virtual bool SetImportList()
    {
        Table importTable;
        importTable = this.ClassInfra.TableCreateModuleRefCompare();

        this.Module.Import = importTable;
        
        int importTotal;
        importTotal = 0;

        Array array;
        array = this.Binary.Import;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            BinaryImport o;
            o = (BinaryImport)array.Get(i);

            ModuleRef moduleRef;
            moduleRef = o.Module;

            Table classTable;
            classTable = this.ClassInfra.TableCreateRefCompare();

            this.ListInfra.TableAdd(importTable, moduleRef, classTable);
            

            ClassModule module;
            module = this.ModuleGet(moduleRef);

            BinaryBinary oo;
            oo = (BinaryBinary)this.BinaryTable.Get(moduleRef);

            Array oa;
            oa = o.Class;
            int countA;
            countA = oa.Count;
            int iA;
            iA = 0;
            while (iA < countA)
            {
                InfraIntValue oe;
                oe = (InfraIntValue)oa.Get(iA);

                BinaryClass of;
                of = (BinaryClass)oo.Class.Get(oe.Value);

                string className;
                className = of.Name;

                ClassClass varClass;
                varClass = this.ModuleClassGet(module, className);

                this.ListInfra.TableAdd(classTable, varClass, varClass);

                iA = iA + 1;
            }

            importTotal = importTotal + countA;

            i = i + 1;
        }

        Array importArray;
        importArray = this.ListInfra.ArrayCreate(importTotal);

        int oi;
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
                ooa = (ClassClass)iterA.Value;

                importArray.Set(oi, ooa);

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
        
        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            ClassClass varClass;
            varClass = (ClassClass)classArray.Get(i);

            InfraIntValue a;
            a = (InfraIntValue)array.Get(i);

            ClassClass baseClass;
            baseClass = this.ClassGetIndex(a.Value);

            if (baseClass == null)
            {
                return false;
            }

            varClass.Base = baseClass;            

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

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            ClassClass varClass;
            varClass = (ClassClass)classArray.Get(i);

            BinaryPart a;
            a = (BinaryPart)array.Get(i);

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
        Table fieldTable;
        fieldTable = this.ClassInfra.TableCreateStringCompare();
        varClass.Field = fieldTable;

        int count;
        count = binaryField.Count;
        int i;
        i = 0;
        while (i < count)
        {
            BinaryField ua;
            ua = (BinaryField)binaryField.Get(i);

            ClassClass c;
            c = this.ClassGetIndex(ua.Class);
            if (c == null)
            {
                return false;
            }

            Field a;
            a = new Field();
            a.Init();
            a.Index = fieldTable.Count;
            a.Name = ua.Name;
            a.Class = c;
            a.SystemInfo = this.SystemInfoCreate(ua.SystemInfo);
            a.Count = this.CountList.Get(ua.Count);
            a.Parent = varClass;

            this.ListInfra.TableAdd(fieldTable, a.Name, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetPartMaide(ClassClass varClass, Array binaryMaide)
    {
        Table maideTable;
        maideTable = this.ClassInfra.TableCreateStringCompare();
        varClass.Maide = maideTable;

        int count;
        count = binaryMaide.Count;
        int i;
        i = 0;
        while (i < count)
        {
            BinaryMaide ua;
            ua = (BinaryMaide)binaryMaide.Get(i);

            ClassClass c;
            c = this.ClassGetIndex(ua.Class);
            if (c == null)
            {
                return false;
            }

            Maide a;
            a = new Maide();
            a.Init();
            a.Index = maideTable.Count;
            a.Name = ua.Name;
            a.Class = c;
            a.SystemInfo = this.SystemInfoCreate(ua.SystemInfo);
            a.Count = this.CountList.Get(ua.Count);
            a.Parent = varClass;

            bool b;
            b = this.SetPartParam(a, ua.Param);
            if (!b)
            {
                return false;
            }

            this.ListInfra.TableAdd(maideTable, a.Name, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetPartParam(Maide maide, Array binaryVar)
    {
        Table varTable;
        varTable = this.ClassInfra.TableCreateStringCompare();
        maide.Param = varTable;

        int count;
        count = binaryVar.Count;
        int i;
        i = 0;
        while (i < count)
        {
            BinaryVar ua;
            ua = (BinaryVar)binaryVar.Get(i);

            ClassClass c;
            c = this.ClassGetIndex(ua.Class);
            if (c == null)
            {
                return false;
            }
            
            Var a;
            a = new Var();
            a.Init();
            a.Name = ua.Name;
            a.Class = c;
            a.SystemInfo = this.SystemInfoCreate(ua.SystemInfo);
            
            this.ListInfra.TableAdd(varTable, a.Name, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetVirtualList()
    {
        Array array;
        array = this.Binary.Part;

        Array classArray;
        classArray = this.ClassArray;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            ClassClass varClass;
            varClass = (ClassClass)classArray.Get(i);

            BinaryPart a;
            a = (BinaryPart)array.Get(i);

            this.SetVirtual(varClass, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetVirtual(ClassClass varClass, BinaryPart part)
    {
        this.SetVirtualField(varClass, part.Field);
        this.SetVirtualMaide(varClass, part.Maide);
        return true;
    }

    protected virtual bool SetVirtualField(ClassClass varClass, Array binaryField)
    {
        Iter iter;
        iter = varClass.Field.IterCreate();
        varClass.Field.IterSet(iter);

        while (iter.Next())
        {
            Field a;
            a = (Field)iter.Value;

            BinaryField ae;
            ae = (BinaryField)binaryField.Get(a.Index);

            Field aa;
            aa = null;
            ClassClass af;
            af = this.VirtualDefineClass(ae.Virtual);
            if (!(af == null))
            {
                aa = (Field)af.Field.Get(a.Name);
            }

            a.Virtual = aa;
        }
        return true;
    }

    protected virtual bool SetVirtualMaide(ClassClass varClass, Array binaryMaide)
    {
        Iter iter;
        iter = varClass.Maide.IterCreate();
        varClass.Maide.IterSet(iter);

        while (iter.Next())
        {
            Maide a;
            a = (Maide)iter.Value;

            BinaryMaide ae;
            ae = (BinaryMaide)binaryMaide.Get(a.Index);

            Maide aa;
            aa = null;
            ClassClass af;
            af = this.VirtualDefineClass(ae.Virtual);
            if (!(af == null))
            {
                aa = (Maide)af.Maide.Get(a.Name);
            }

            a.Virtual = aa;
        }
        return true;
    }
    
    protected virtual bool SetEntry()
    {
        string entry;
        entry = null;

        int f;
        f = this.Binary.Entry;
        if (!(f == -1))
        {
            ClassClass a;
            a = (ClassClass)this.ClassArray.Get(f);
            if (!(a == null))
            {
                entry = a.Name;
            }
        }

        this.Module.Entry = entry;
        return true;
    }

    protected virtual ClassClass VirtualDefineClass(int classIndex)
    {
        if (classIndex == -1)
        {
            return null;
        }

        ClassClass a;
        a = this.ClassGetIndex(classIndex);
        return a;
    }

    protected virtual SystemInfo SystemInfoCreate(int binaryValue)
    {
        SystemInfo a;
        a = new SystemInfo();
        a.Init();
        a.Value = binaryValue;
        return a;
    }

    protected virtual ClassClass ClassGetIndex(int index)
    {
        Array classArray;
        classArray = this.ClassArray;

        ClassClass a;
        a = null;
        bool b;
        b = (classArray.Contain(index));
        if (b)
        {
            a = (ClassClass)classArray.Get(index);
        }
        if (!b)
        {
            int oa;
            oa = index - classArray.Count;
            if (!this.ImportArray.Contain(oa))
            {
                return null;
            }
            a = (ClassClass)this.ImportArray.Get(oa);
        }
        return a;
    }

    protected virtual ClassModule ModuleGet(ModuleRef moduleRef)
    {
        ClassModule a;
        a = (ClassModule)this.ModuleTable.Get(moduleRef);
        return a;
    }

    protected virtual ClassClass ModuleClassGet(ClassModule module, string className)
    {
        ClassClass a;
        a = (ClassClass)module.Class.Get(className);
        return a;
    }

    protected virtual ClassClass ClassGet(ModuleRef moduleRef, string className)
    {
        ClassModule ae;
        ae = this.ModuleGet(moduleRef);
        ClassClass a;
        a = this.ModuleClassGet(ae, className);
        return a;
    }
}