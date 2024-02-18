namespace Z.Tool.SystemModuleGen;




public class Create : Any
{
    public virtual Module Module { get; set; }
    
    
    protected virtual int ClassCount
    {
        get { return 4; }
    }
    
    
    public virtual bool Execute()
    {
        Module module;

        module = this.ExecuteModule();


        this.Module = module;


        return true;
    }



    protected virtual Module ExecuteModule()
    {
        Module module;

        module = new Module();

        module.Init();


        
        module.Class = this.ExecuteClassArray();

        module.Import = this.ExecuteImportArray();

        module.Export = this.ExecuteExportArray();

        module.Base = this.ExecuteBaseArray();

        module.Member = this.ExecuteMemberArray();
        
        module.State = this.ExecuteStateArray();
        
        

        return module;
    }


    
    
    protected virtual Array ExecuteClassArray()
    {
        Array array;

        array = new Array();

        array.Count = this.ClassCount;

        array.Init();


        
        this.ClassArray = array;

        this.ClassIndex = 0;
        


        this.AddClass(0, "Any");
        
        this.AddClass(1, "Bool");
        
        this.AddClass(1, "Int");
        
        this.AddClass(1, "String");
        
        

        return array;
    }
    
    
    private Array ClassArray { get; set; }
    
    
    private int ClassIndex { get; set; }
    


    private bool AddClass(int ident, string name)
    {
        int index;

        index = this.ClassIndex;
        
        
        
        BinaryClass varClass;

        varClass = new BinaryClass();

        varClass.Init();

        varClass.Ident = ident;

        varClass.Name = name;
        
        
        
        this.ClassArray.Set(index, varClass);
        


        index = index + 1;

        
        this.ClassIndex = index;
        

        return true;
    }
    



    protected virtual Array ExecuteImportArray()
    {
        return this.ExecuteEmptyArray();
    }
    
    
    
    
    protected virtual Array ExecuteExportArray()
    {
        Array array;

        array = new Array();

        array.Count = this.ClassCount;

        array.Init();



        this.ExportArray = array;

        this.ExportIndex = 0;
        
        
        
        this.AddExport();
        
        this.AddExport();
        
        this.AddExport();
        
        this.AddExport();
        
        

        return array;
    }
    
    
    
    
    private Array ExportArray { get; set; }
    
    
    private int ExportIndex { get; set; }
    
    
    
    private bool AddExport()
    {
        int index;

        index = this.ExportIndex;
        
        
        
        Export export;

        export = new Export();

        export.Init();

        export.Class = index;

        
        
        this.ExportArray.Set(index, export);
        


        index = index + 1;
        

        
        this.ExportIndex = index;
        
        

        return true;
    }
    
    
    
    
    protected virtual Array ExecuteBaseArray()
    {
        Array array;

        array = new Array();

        array.Count = this.ClassCount;

        array.Init();


        
        this.BaseArray = array;

        this.BaseIndex = 0;
        
        
        
        this.AddBase(0);
        
        this.AddBase(1);
        
        this.AddBase(1);
        
        this.AddBase(1);
        

        return array;
    }
    

    
    
    private Array BaseArray { get; set; }
    
    
    private int BaseIndex { get; set; }
    
    


    private bool AddBase(int varClass)
    {
        int index;

        index = this.BaseIndex;
        
        
        
        Base varBase;

        varBase = new Base();

        varBase.Init();

        varBase.Class = varClass;
        
        
        
        this.BaseArray.Set(index, varBase);
        


        index = index + 1;

        
        this.BaseIndex = index;
        

        return true;
    }

    
    
    
    protected virtual Array ExecuteMemberArray()
    {
        Array array;

        array = new Array();

        array.Count = this.ClassCount;

        array.Init();



        Member anyMember;

        anyMember = this.ExecuteAnyMember();
        
        
        array.Set(0, anyMember);
        
        
        
        
        this.MemberArray = array;

        this.MemberIndex = 1;
        
        
        
        this.AddMember();
        
        this.AddMember();
        
        this.AddMember();
        
        

        return array;
    }



    private Member ExecuteAnyMember()
    {
        Member member;

        member = new Member();

        member.Init();

        member.FieldStart = 0;

        member.MethodStart = 0;

        member.Field = this.ExecuteEmptyArray();

        member.Method = this.ExecuteAnyMemberMethodArray();


        return member;
    }
    
    


    private Array ExecuteAnyMemberMethodArray()
    {
        Array array;

        array = new Array();

        array.Count = 1;

        array.Init();


        
        Method initMethod;

        initMethod = this.ExecuteAnyInitMethod();


        array.Set(0, initMethod);
        

        return array;
    }

    

    private Method ExecuteAnyInitMethod()
    {
        Method method;

        method = new Method();

        method.Init();

        method.Ident = 0;

        method.Class = 1;

        method.Access = 0;

        method.Name = "Init";

        method.Param = this.ExecuteEmptyArray();


        return method;
    }
    
    
    
    private Array MemberArray { get; set; }
    
    
    private int MemberIndex { get; set; }
    
    

    private bool AddMember()
    {
        int index;

        index = this.MemberIndex;
        
        
        
        Member member;

        member = new Member();

        member.Init();

        member.FieldStart = 0;

        member.MethodStart = 1;

        member.Field = this.ExecuteEmptyArray();

        member.Method = this.ExecuteEmptyArray();
        
        
        
        this.MemberArray.Set(index, member);
        


        index = index + 1;

        
        this.MemberIndex = index;
        
        

        return true;
    }

    
    
    protected virtual Array ExecuteStateArray()
    {
        Array array;

        array = new Array();

        array.Count = 1;

        array.Init();



        State state;

        state = this.ExecuteEmptyState();
        
        
        array.Set(0, state);
        
        

        return array;
    }


    
    private State ExecuteEmptyState()
    {
        State state;

        state = new State();

        state.Init();

        state.VarCount = 0;

        state.Operate = this.ExecuteEmptyArray();

        

        return state;
    }
    
    

    private Array ExecuteEmptyArray()
    {
        Array array;

        array = new Array();

        array.Count = 0;

        array.Init();


        return array;
    }
}