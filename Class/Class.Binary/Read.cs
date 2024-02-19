namespace Class.Binary;




public class Read : Any
{
    public override bool Init()
    {
        base.Init();


        
        this.InfraInfra = InfraInfra.This;


        this.OperateKindList = OperateKindList.This;
        
        
        
        return true;
    }
    

    
    
    public virtual Module Module { get; set; }
    
    
    public virtual int Index { get; set; }
    
    
    public virtual Data Data { get; set; }


    public virtual bool State { get; set; }
    


    protected virtual InfraInfra InfraInfra { get; set;  }

    
    protected virtual OperateKindList OperateKindList { get; set; }
    


    
    public virtual bool Execute()
    {
        return true;
    }



    protected virtual Module ExecuteModule()
    {
        Array varClass;
        
        varClass = this.ExecuteClassArray();

        if (varClass == null)
        {
            return null;
        }


        Array import;
        
        import = this.ExecuteImportArray();

        if (import == null)
        {
            return null;
        }


        Array export;
        
        export = this.ExecuteExportArray();

        if (export == null)
        {
            return null;
        }


        Array varBase;
        
        varBase = this.ExecuteBaseArray();

        if (varBase == null)
        {
            return null;
        }


        Array member;
        
        member = this.ExecuteMemberArray();

        if (member == null)
        {
            return null;
        }
        
        
        Module module;

        module = new Module();

        module.Init();

        module.Class = varClass;

        module.Import = import;

        module.Export = export;

        module.Base = varBase;

        return module;
    }



    protected virtual Array ExecuteClassArray()
    {
        int count;

        count = this.ExecuteCount();

        
        if (count == -1)
        {
            return null;
        }


        
        Array array;

        array = new Array();

        array.Count = count;
        
        array.Init();


        int i;

        i = 0;


        while (i < count)
        {
            Class varClass;

            varClass = this.ExecuteClass();


            if (varClass == null)
            {
                return null;
            }


            array.Set(i, varClass);
            
            
            i = i + 1;
        }


        return array;
    }
    
    
    
    protected virtual Class ExecuteClass()
    {
        int ident;

        ident = this.ExecuteIdent();


        if (ident == -1)
        {
            return null;
        }


        
        string name;

        name = this.ExecuteName();


        if (name == null)
        {
            return null;
        }


        
        Class a;

        a = new Class();

        a.Init();

        a.Ident = ident;

        a.Name = name;

        return a;
    }
    

    
    
    protected virtual Array ExecuteImportArray()
    {
        int count;

        count = this.ExecuteCount();

        
        if (count == -1)
        {
            return null;
        }


        
        Array array;

        array = new Array();

        array.Count = count;
        
        array.Init();


        int i;

        i = 0;


        while (i < count)
        {
            Import import;

            import = this.ExecuteImport();


            if (import == null)
            {
                return null;
            }


            array.Set(i, import);
            
            
            i = i + 1;
        }


        return array;
    }
    
    

    protected virtual Import ExecuteImport()
    {
        ModuleRef module;

        module = this.ExecuteModuleRef();


        if (module == null)
        {
            return null;
        }
        
        
        
        int varClass;

        varClass = this.ExecuteClassIndex();


        if (varClass == -1)
        {
            return null;
        }


        
        Import a;

        a = new Import();

        a.Init();

        a.Module = module;

        a.Class = varClass;

        return a;
    }
    
    
    
    
    protected virtual Array ExecuteExportArray()
    {
        int count;

        count = this.ExecuteCount();

        
        if (count == -1)
        {
            return null;
        }


        
        Array array;

        array = new Array();

        array.Count = count;
        
        array.Init();


        int i;

        i = 0;


        while (i < count)
        {
            Export export;

            export = this.ExecuteExport();


            if (export == null)
            {
                return null;
            }


            array.Set(i, export);
            
            
            i = i + 1;
        }


        return array;
    }
    
    
    
    
    protected virtual Export ExecuteExport()
    {
        int varClass;

        varClass = this.ExecuteClassIndex();


        if (varClass == -1)
        {
            return null;
        }


        
        Export a;

        a = new Export();

        a.Init();

        a.Class = varClass;

        return a;
    }
    
    
    
    
    protected virtual Array ExecuteBaseArray()
    {
        int count;

        count = this.ExecuteCount();

        
        if (count == -1)
        {
            return null;
        }


        
        Array array;

        array = new Array();

        array.Count = count;
        
        array.Init();


        int i;

        i = 0;


        while (i < count)
        {
            Base varBase;

            varBase = this.ExecuteBase();


            if (varBase == null)
            {
                return null;
            }


            array.Set(i, varBase);
            
            
            i = i + 1;
        }


        return array;
    }
    
    
    
    
    protected virtual Base ExecuteBase()
    {
        int varClass;

        varClass = this.ExecuteClassIndex();


        if (varClass == -1)
        {
            return null;
        }


        
        Base a;

        a = new Base();

        a.Init();

        a.Class = varClass;

        return a;
    }

    
    
    
    protected virtual Array ExecuteMemberArray()
    {
        int count;

        count = this.ExecuteCount();

        
        if (count == -1)
        {
            return null;
        }


        
        Array array;

        array = new Array();

        array.Count = count;
        
        array.Init();


        int i;

        i = 0;


        while (i < count)
        {
            Member member;

            member = this.ExecuteMember();


            if (member == null)
            {
                return null;
            }


            array.Set(i, member);
            
            
            i = i + 1;
        }


        return array;
    }
    

    
    
    protected virtual Member ExecuteMember()
    {
        int fieldStart;

        fieldStart = this.ExecuteIndex();


        if (fieldStart == -1)
        {
            return null;
        }
        
        
        int methodStart;

        methodStart = this.ExecuteIndex();


        if (methodStart == -1)
        {
            return null;
        }


        Array field;

        field = this.ExecuteFieldArray();


        if (field == null)
        {
            return null;
        }
        
        
        Array method;

        method = this.ExecuteMethodArray();


        if (method == null)
        {
            return null;
        }


        
        Member member;

        member = new Member();

        member.Init();

        member.FieldStart = fieldStart;

        member.MethodStart = methodStart;

        member.Field = field;

        member.Method = method;

        return member;
    }
    
    
    
    protected virtual Array ExecuteFieldArray()
    {
        int count;

        count = this.ExecuteCount();

        
        if (count == -1)
        {
            return null;
        }


        
        Array array;

        array = new Array();

        array.Count = count;
        
        array.Init();


        int i;

        i = 0;


        while (i < count)
        {
            Field field;

            field = this.ExecuteField();


            if (field == null)
            {
                return null;
            }


            array.Set(i, field);
            
            
            i = i + 1;
        }


        return array;
    }
    
    


    protected virtual Field ExecuteField()
    {
        int ident;

        ident = this.ExecuteIdent();


        if (ident == -1)
        {
            return null;
        }


        int varClass;

        varClass = this.ExecuteClassIndex();


        if (varClass == -1)
        {
            return null;
        }


        int access;

        access = this.ExecuteAccess();


        if (access == -1)
        {
            return null;
        }


        string name;

        name = this.ExecuteName();


        if (name == null)
        {
            return null;
        }



        Field field;

        field = new Field();

        field.Init();

        field.Ident = ident;

        field.Class = varClass;

        field.Access = access;

        field.Name = name;

        return field;
    }
    
    
    
    
    protected virtual Array ExecuteMethodArray()
    {
        int count;

        count = this.ExecuteCount();

        
        if (count == -1)
        {
            return null;
        }


        
        Array array;

        array = new Array();

        array.Count = count;
        
        array.Init();


        int i;

        i = 0;


        while (i < count)
        {
            Method method;

            method = this.ExecuteMethod();


            if (method == null)
            {
                return null;
            }


            array.Set(i, method);
            
            
            i = i + 1;
        }


        return array;
    }
    
    
    
    
    protected virtual Method ExecuteMethod()
    {
        int ident;

        ident = this.ExecuteIdent();


        if (ident == -1)
        {
            return null;
        }


        int varClass;

        varClass = this.ExecuteClassIndex();


        if (varClass == -1)
        {
            return null;
        }


        int access;

        access = this.ExecuteAccess();


        if (access == -1)
        {
            return null;
        }


        string name;

        name = this.ExecuteName();


        if (name == null)
        {
            return null;
        }

        

        Array param;

        param = this.ExecuteParam();


        if (param == null)
        {
            return null;
        }
        


        Method method;

        method = new Method();

        method.Init();

        method.Ident = ident;

        method.Class = varClass;

        method.Access = access;

        method.Name = name;

        method.Param = param;

        return method;
    }

    

    protected virtual Array ExecuteParam()
    {
        int count;

        count = this.ExecuteCount();

        
        if (count == -1)
        {
            return null;
        }


        
        Array array;

        array = new Array();

        array.Count = count;
        
        array.Init();


        int i;

        i = 0;


        while (i < count)
        {
            Var varVar;

            varVar = this.ExecuteVar();


            if (varVar == null)
            {
                return null;
            }


            array.Set(i, varVar);
            
            
            i = i + 1;
        }


        return array;
    }
    
    


    protected virtual Var ExecuteVar()
    {
        int varClass;

        varClass = this.ExecuteClassIndex();


        if (varClass == -1)
        {
            return null;
        }


        string name;

        name = this.ExecuteName();


        if (name == null)
        {
            return null;
        }


        Var varVar;

        varVar = new Var();

        varVar.Init();

        varVar.Class = varClass;

        varVar.Name = name;

        return varVar;
    }





    protected virtual State ExecuteState()
    {
        int varCount;

        varCount = this.ExecuteCount();


        if (varCount == -1)
        {
            return null;
        }



        Array operate;

        operate = this.ExecuteOperateArray();


        if (operate == null)
        {
            return null;
        }


        State state;

        state = new State();

        state.Init();

        state.VarCount = varCount;

        state.Operate = operate;

        return state;
    }

    
    
    
    
    protected virtual Array ExecuteOperateArray()
    {
        int count;

        count = this.ExecuteCount();

        
        if (count == -1)
        {
            return null;
        }


        
        Array array;

        array = new Array();

        array.Count = count;
        
        array.Init();


        int i;

        i = 0;


        while (i < count)
        {
            Operate operate;

            operate = this.ExecuteOperate();


            if (operate == null)
            {
                return null;
            }


            array.Set(i, operate);
            
            
            i = i + 1;
        }


        return array;
    }
    



    protected virtual Operate ExecuteOperate()
    {
        int kind;

        kind = this.ExecuteIndex();

        if (kind == -1)
        {
            return null;
        }


        OperateKind ok;

        ok = this.OperateKindList.Get(kind);


        if (ok == null)
        {
            return null;
        }



        long arg;

        arg = -1;


        object anyArg;

        anyArg = null;
        

        bool b;

        b = ok.AnyArg;


        if (b)
        {
            string ak;

            ak = this.ExecuteString();


            if (ak == null)
            {
                return null;
            }

            
            anyArg = ak;
        }

        if (!b)
        {
            arg = this.ExecuteInt();


            if (arg == -1)
            {
                return null;
            }
        }



        Operate a;

        a = new Operate();

        a.Init();

        a.Kind = kind;

        a.Arg = arg;
        
        a.AnyArg = anyArg;
        
        return a;
    }

    


    protected virtual ModuleRef ExecuteModuleRef()
    {
        ModuleInt varInt;

        varInt = this.ExecuteModuleInt();


        if (varInt == null)
        {
            return null;
        }


        long ver;

        ver = this.ExecuteInt();

        if (ver == -1)
        {
            return null;
        }
        


        ModuleRef a;

        a = new ModuleRef();

        a.Init();

        a.Int = varInt;

        a.Ver = ver;

        return a;
    }
    
    

    
    protected virtual ModuleInt ExecuteModuleInt()
    {
        long group;

        group = this.ExecuteInt();

        if (group == -1)
        {
            return null;
        }
        
        
        long value;

        value = this.ExecuteInt();

        if (value == -1)
        {
            return null;
        }


        
        ModuleInt a;

        a = new ModuleInt();

        a.Init();

        a.Group = group;

        a.Value = value;

        return a;
    }



    
    protected virtual string ExecuteName()
    {
        return this.ExecuteString();
    }
    
    
    protected virtual int ExecuteAccess()
    {
        return this.ExecuteIndex();
    }
    
    
    
    protected virtual int ExecuteIdent()
    {
        return this.ExecuteIndex();
    }
    
    
    
    protected virtual int ExecuteClassIndex()
    {
        return this.ExecuteIndex();
    }
    
    


    protected virtual string ExecuteString()
    {
        int count;

        count = this.ExecuteCount();


        if (count == -1)
        {
            return null;
        }


        
        int end;

        end = this.Index + count;


        if (this.Data.Count < end)
        {
            return null;
        }



        char[] array;

        array = new char[count];
        


        int i;

        i = 0;


        while (i < count)
        {
            byte ob;

            ob = this.ExecuteByte();


            char oc;

            oc = (char)ob;


            array[i] = oc;
            
            
            i = i + 1;
        }
        

        
        string k;

        k = new string(array);
        

        return k;
    }
    
    
    
    
    protected virtual int ExecuteIndex()
    {
        return this.ExecuteSInt32();
    }



    protected virtual int ExecuteCount()
    {
        return this.ExecuteSInt32();
    }



    protected virtual int ExecuteSInt32()
    {
        long k;

        k = this.ExecuteInt();


        if (k == -1)
        {
            return -1;
        }
        
        

        int o;

        o = (int)k;


        return o;
    }
    


    protected virtual long ExecuteInt()
    {
        int end;
        
        end = this.Index + this.InfraInfra.ULongByteCount;


        if (this.Data.Count < end)
        {
            return -1;
        }
        
        
        
        ulong k;
        
        k = this.InfraInfra.ByteListULong(this.Data.Value, this.Index);



        this.Index = end;
        

        
        long o;

        o = (long)k;
        
        
        return o;
    }
    


    
    protected virtual byte ExecuteByte()
    {
        byte ob;

        ob = this.Data.Value[this.Index];


        
        this.Index = this.Index + 1;
        
        

        return ob;
    }
}