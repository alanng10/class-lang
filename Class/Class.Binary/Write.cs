namespace Class.Binary;




public class Write : Any
{
    public override bool Init()
    {
        base.Init();


        
        
        this.InfraInfra = InfraInfra.This;


        
        this.CountOperate = new CountWriteOperate();

        this.CountOperate.Init();

        this.CountOperate.Write = this;
        


        this.AddOperate = new AddWriteOperate();

        this.AddOperate.Init();

        this.AddOperate.Write = this;
        

        
        return true;
    }
    
    


    public virtual Module Module { get; set; }
    
    
    public virtual int Index { get; set; }
    
    
    public virtual Data Data { get; set; }

    
    
    protected virtual WriteOperate Operate { get; set; }
    
    
    protected virtual CountWriteOperate CountOperate { get; set; }
    
    
    protected virtual AddWriteOperate AddOperate { get; set; }


    protected virtual InfraInfra InfraInfra { get; set;  }
    
    
    
    
    public virtual bool Execute()
    {
        this.Data = null;
        
        
        
        this.Operate = this.CountOperate;

        this.Index = 0;


        this.ExecuteModule(this.Module);

        

        int count;

        count = this.Index;



        byte[] u;

        u = new byte[count];
        
        

        Data data;

        data = new Data();

        data.Init();

        data.Value = u;


        
        this.Data = data;


        this.Operate = this.AddOperate;

        this.Index = 0;


        this.ExecuteModule(this.Module);



        
        this.Operate = null;
        


        return true;
    }




    protected virtual bool ExecuteModule(Module module)
    {
        this.ExecuteClassArray(module.Class);
        
        
        this.ExecuteImportArray(module.Import);
        
        
        this.ExecuteExportArray(module.Export);
        
        
        this.ExecuteBaseArray(module.Base);
        
        
        this.ExecuteMemberArray(module.Member);
        
        
        this.ExecuteStateArray(module.State);
        

        return true;
    }
    
    
    
    protected virtual bool ExecuteClassArray(Array array)
    {
        int count;

        count = array.Count;
        
        
        this.ExecuteCount(count);
        
        

        int i;

        i = 0;

        while (i < count)
        {
            Class varClass;

            varClass = (Class)array.Get(i);


            this.ExecuteClass(varClass);
            
            
            
            i = i + 1;
        }
        
        
        return true;
    }
    
    
    
    
    protected virtual bool ExecuteClass(Class varClass)
    {
        this.ExecuteIdent(varClass.Ident);


        this.ExecuteName(varClass.Name);


        return true;
    }
    

    
    protected virtual bool ExecuteImportArray(Array array)
    {
        int count;

        count = array.Count;
        
        
        this.ExecuteCount(count);
        
        

        int i;

        i = 0;

        while (i < count)
        {
            Import import;

            import = (Import)array.Get(i);


            this.ExecuteImport(import);
            
            
            
            i = i + 1;
        }
        
        
        return true;
    }
    
    
    

    protected virtual bool ExecuteImport(Import import)
    {
        this.ExecuteModuleRef(import.Module);


        this.ExecuteClassIndex(import.Class);


        return true;
    }
    
    
    
    protected virtual bool ExecuteExportArray(Array array)
    {
        int count;

        count = array.Count;
        
        
        this.ExecuteCount(count);
        
        

        int i;

        i = 0;

        while (i < count)
        {
            Export export;

            export = (Export)array.Get(i);


            this.ExecuteExport(export);
            
            
            
            i = i + 1;
        }
        
        
        return true;
    }
    
    
    
    protected virtual bool ExecuteExport(Export export)
    {
        this.ExecuteClassIndex(export.Class);


        return true;
    }
    
    
    
    protected virtual bool ExecuteBaseArray(Array array)
    {
        int count;

        count = array.Count;
        
        
        this.ExecuteCount(count);
        
        

        int i;

        i = 0;

        while (i < count)
        {
            Base varBase;

            varBase = (Base)array.Get(i);


            this.ExecuteBase(varBase);
            
            
            
            i = i + 1;
        }
        
        
        return true;
    }
    
    
    
    
    protected virtual bool ExecuteBase(Base varBase)
    {
        this.ExecuteClassIndex(varBase.Class);


        return true;
    }
    
    
    
    protected virtual bool ExecuteMemberArray(Array array)
    {
        int count;

        count = array.Count;
        
        
        this.ExecuteCount(count);
        
        

        int i;

        i = 0;

        while (i < count)
        {
            Member member;

            member = (Member)array.Get(i);


            this.ExecuteMember(member);
            
            
            
            i = i + 1;
        }
        
        
        return true;
    }



    protected virtual bool ExecuteMember(Member member)
    {
        this.ExecuteIndex(member.FieldStart);
        
        
        this.ExecuteIndex(member.MethodStart);


        this.ExecuteFieldArray(member.Field);


        this.ExecuteMethodArray(member.Method);
        
        
        
        return true;
    }


    
    
    protected virtual bool ExecuteFieldArray(Array array)
    {
        int count;

        count = array.Count;
        
        
        this.ExecuteCount(count);
        
        

        int i;

        i = 0;

        while (i < count)
        {
            Field field;

            field = (Field)array.Get(i);


            this.ExecuteField(field);
            
            
            
            i = i + 1;
        }
        
        
        return true;
    }
    
    
    
    
    protected virtual bool ExecuteMethodArray(Array array)
    {
        int count;

        count = array.Count;
        
        
        this.ExecuteCount(count);
        
        

        int i;

        i = 0;

        while (i < count)
        {
            Method method;

            method = (Method)array.Get(i);


            this.ExecuteMethod(method);
            
            
            
            i = i + 1;
        }
        
        
        return true;
    }
    
    


    protected virtual bool ExecuteField(Field field)
    {
        this.ExecuteIdent(field.Ident);

        
        this.ExecuteClassIndex(field.Class);

        
        this.ExecuteAccess(field.Access);

        
        this.ExecuteName(field.Name);


        return true;
    }
    
    
    
    protected virtual bool ExecuteMethod(Method method)
    {
        this.ExecuteIdent(method.Ident);

        
        this.ExecuteClassIndex(method.Class);

        
        this.ExecuteAccess(method.Access);

        
        this.ExecuteName(method.Name);


        this.ExecuteParam(method.Param);
        

        return true;
    }

    
    

    protected virtual bool ExecuteParam(Array param)
    {
        int count;

        count = param.Count;
        
        
        this.ExecuteCount(count);
        
        

        int i;

        i = 0;

        while (i < count)
        {
            Var varVar;

            varVar = (Var)param.Get(i);


            this.ExecuteVar(varVar);
            
            
            
            i = i + 1;
        }
        
        
        return true;
    }



    protected virtual bool ExecuteVar(Var varVar)
    {
        this.ExecuteClassIndex(varVar.Class);
        
        
        this.ExecuteName(varVar.Name);


        return true;
    }

    
    
    protected virtual bool ExecuteStateArray(Array array)
    {
        int count;

        count = array.Count;
        
        
        this.ExecuteCount(count);
        
        

        int i;

        i = 0;

        while (i < count)
        {
            State state;

            state = (State)array.Get(i);


            this.ExecuteState(state);
            
            
            
            i = i + 1;
        }
        
        
        return true;
    }
    

    protected virtual bool ExecuteState(State state)
    {
        this.ExecuteSInt32(state.VarCount);


        this.ExecuteOperateArray(state.Operate);
        
        
        return true;
    }
    


    protected virtual bool ExecuteOperateArray(Array array)
    {
        int count;

        count = array.Count;


        this.ExecuteCount(count);


        int i;

        i = 0;

        while (i < count)
        {
            Operate operate;

            operate = (Operate)array.Get(i);


            this.ExecuteOperate(operate);
            
            
            i = i + 1;
        }
        
        
        return true;
    }
    


    protected virtual bool ExecuteOperate(Operate operate)
    {
        this.ExecuteSInt32(operate.Kind);


        bool b;

        b = (operate.AnyArg == null);

        
        if (b)
        {
            this.ExecuteInt(operate.Arg);
        }


        if (!b)
        {
            string k;

            k = (string)operate.AnyArg;


            this.ExecuteString(k);
        }


        return true;
    }

    
    
    protected virtual bool ExecuteModuleRef(ModuleRef a)
    {
        this.ExecuteModuleInt(a.Int);


        this.ExecuteInt(a.Ver);
        
        
        return true;
    }
    

    protected virtual bool ExecuteModuleInt(ModuleInt a)
    {
        this.ExecuteInt(a.Group);

        this.ExecuteInt(a.Value);


        return true;
    }
    
    
    
    protected virtual bool ExecuteName(string a)
    {
        return this.ExecuteString(a);
    }
    
    
    protected virtual bool ExecuteClassIndex(int a)
    {
        return this.ExecuteIndex(a);
    }

    
    protected virtual bool ExecuteAccess(int a)
    {
        return this.ExecuteIndex(a);
    }


    protected virtual bool ExecuteIdent(int a)
    {
        return this.ExecuteIndex(a);
    }

    
    protected virtual bool ExecuteIndex(int a)
    {
        return this.ExecuteSInt32(a);
    }
    

    protected virtual bool ExecuteString(string a)
    {
        int count;

        count = a.Length;


        this.ExecuteCount(count);

        
        int i;

        i = 0;

        while (i < count)
        {
            char oc;

            oc = a[i];


            byte ob;

            ob = (byte)oc;


            this.ExecuteByte(ob);
            
            
            
            i = i + 1;
        }
        
        
        return true;
    }
    


    protected virtual bool ExecuteCount(int a)
    {
        return this.ExecuteSInt32(a);
    }
    



    protected virtual bool ExecuteSInt32(int a)
    {
        long k;
        
        k = a;


        this.ExecuteInt(k);


        return true;
    }
    


    protected virtual bool ExecuteInt(long a)
    {
        int oo;

        oo = this.InfraInfra.ByteBitCount;
        
        
        int shiftCount;

        
        
        int count;

        count = this.InfraInfra.ULongByteCount;

        
        int i;

        i = 0;

        while (i < count)
        {
            shiftCount = i * oo;


            long k;

            k = a;

            k = k >> shiftCount;


            
            byte ob;

            ob = (byte)k;


            
            this.ExecuteByte(ob);
            
            
            
            i = i + 1;
        }


        return true;
    }
    


    protected virtual bool ExecuteByte(byte ob)
    {
        this.Operate.ExecuteByte(ob);
        

        return true;
    }
}