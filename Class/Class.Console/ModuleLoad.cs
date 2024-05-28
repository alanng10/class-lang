namespace Class.Console;

public class ModuleLoad : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.ClassInfra = ClassInfra.This;
        this.CountList = CountList.This;

        this.NameCheck = new NameCheck();
        this.NameCheck.Init();

        this.StringData = new StringData();
        this.StringData.Init();

        this.Text = new Text();
        this.Text.Data = this.StringData;
        this.Text.Range = new InfraRange();
        this.Text.Range.Init();
        return true;
    }

    public virtual Table ModuleTable { get; set; }
    public virtual Table BinaryTable { get; set; }
    public virtual ModuleRef ModuleRef { get; set; }
    public virtual ClassModule Module { get; set; }
    public virtual int Status { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual CountList CountList { get; set; }
    protected virtual NameCheck NameCheck { get; set; }
    protected virtual BinaryBinary Binary { get; set; }
    protected virtual Array ClassArray { get; set; }
    protected virtual Array ImportArray { get; set; }
    protected virtual Text Text { get; set; }
    protected virtual StringData StringData { get; set; }

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

        if (this.ModuleTable.Contain(o))
        {
            this.Status = 1;
            return false;
        }

        this.TextGet(o.Name);
        if (!this.ClassInfra.IsModuleName(this.NameCheck, this.Text))
        {
            this.Status = 2;
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

            if (!this.CheckName(name))
            {
                this.Status = 10;
                return false;
            }

            if (classTable.Contain(name))
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

            listInfra.TableAdd(classTable, a.Name, a); 

            i = i + 1;
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
            oa = (ClassClass)iter.Value;

            classArray.Set(i, oa);
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
        importTable = classInfra.TableCreateModuleRefCompare();

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
            classTable = classInfra.TableCreateRefCompare();

            listInfra.TableAdd(importTable, moduleRef, classTable);
            
            ClassModule module;
            module = this.ModuleGet(moduleRef);

            BinaryBinary oo;
            oo = (BinaryBinary)binaryTable.Get(moduleRef);

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

                listInfra.TableAdd(classTable, varClass, varClass);

                iA = iA + 1;
            }

            importTotal = importTotal + countA;

            i = i + 1;
        }

        Array importArray;
        importArray = listInfra.ArrayCreate(importTotal);

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
        varClass.Field = this.ClassInfra.TableCreateStringCompare();

        varClass.Maide = this.ClassInfra.TableCreateStringCompare();

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
        fieldTable = varClass.Field;

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

            string name;
            name = ua.Name;
            if (!this.CheckName(name))
            {
                return false;
            }

            if (this.MemberNameDefined(varClass, name))
            {
                return false;
            }

            Field a;
            a = new Field();
            a.Init();
            a.Index = fieldTable.Count;
            a.Name = name;
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
        maideTable = varClass.Maide;

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

            string name;
            name = ua.Name;
            if (!this.CheckName(name))
            {
                return false;
            }

            if (this.MemberNameDefined(varClass, name))
            {
                return false;
            }

            Maide a;
            a = new Maide();
            a.Init();
            a.Index = maideTable.Count;
            a.Name = name;
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

            string name;
            name = ua.Name;
            if (!this.CheckName(name))
            {
                return false;
            }

            if (varTable.Contain(name))
            {
                return false;
            }
            
            Var a;
            a = new Var();
            a.Init();
            a.Name = name;
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

            bool b;
            b = this.SetVirtual(varClass, a);
            if (!b)
            {
                return false;
            }

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetVirtual(ClassClass varClass, BinaryPart part)
    {
        bool b;
        b = this.SetVirtualField(varClass, part.Field);
        if (!b)
        {
            return false;
        }
        b = this.SetVirtualMaide(varClass, part.Maide);
        if (!b)
        {
            return false;
        }
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

            if (!(ae.Virtual == -1))
            {
                ClassClass af;
                af = this.ClassGetIndex(ae.Virtual);
                
                if (af == null)
                {
                    return false;
                }
                
                aa = (Field)af.Field.Get(a.Name);
                if (aa == null)
                {
                    return false;
                }

                if (!(a.Count == aa.Count))
                {
                    return false;
                }

                if (!(a.Class == aa.Class))
                {
                    return false;
                }

                if (!(a.SystemInfo.Value == aa.SystemInfo.Value))
                {
                    return false;
                }
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

            if (!(ae.Virtual == -1))
            {
                ClassClass af;
                af = this.ClassGetIndex(ae.Virtual);

                if (af == null)
                {
                    return false;
                }

                aa = (Maide)af.Maide.Get(a.Name);
                if (aa == null)
                {
                    return false;
                }

                if (!(a.Count == aa.Count))
                {
                    return false;
                }

                if (!(a.Class == aa.Class))
                {
                    return false;
                }

                if (!(a.SystemInfo.Value == aa.SystemInfo.Value))
                {
                    return false;
                }

                if (!this.CheckVirtualMaideParam(a.Param, aa.Param))
                {
                    return false;
                }
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
            if (a == null)
            {
                return false;
            }

            entry = a.Name;
        }

        this.Module.Entry = entry;
        return true;
    }

    protected virtual bool MemberNameDefined(ClassClass varClass, string name)
    {
        return (varClass.Field.Contain(name) | varClass.Maide.Contain(name));
    }

    protected virtual bool CheckVirtualMaideParam(Table param, Table virtualParam)
    {
        int count;
        count = param.Count;

        if (!(count == virtualParam.Count))
        {
            return false;
        }

        Iter iter;
        iter = param.IterCreate();
        param.IterSet(iter);

        Iter iterA;
        iterA = virtualParam.IterCreate();
        virtualParam.IterSet(iterA);

        int i;
        i = 0;
        while (i < count)
        {
            iter.Next();
            iterA.Next();

            Var varVar;
            varVar = (Var)iter.Value;

            Var varA;
            varA = (Var)iterA.Value;

            if (!(varVar.Class == varA.Class))
            {
                return false;
            }

            if (!(varVar.SystemInfo.Value == varA.SystemInfo.Value))
            {
                return false;
            }

            i = i + 1;
        }
        return true;
    }

    protected virtual bool CheckName(string o)
    {
        this.TextGet(o);
        return this.NameCheck.IsName(this.Text);
    }

    protected virtual bool TextGet(string o)
    {
        this.StringData.Value = o;

        this.Text.Range.Count = o.Length;

        return true;
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