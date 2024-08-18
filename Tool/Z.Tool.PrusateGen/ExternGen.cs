namespace Z.Tool.PrusateGen;

class ExternGen : PrusateGen
{
    public override bool Init()
    {
        base.Init();

        this.PrusateFileName = this.S("ToolData/Prusate/Extern.txt");

        this.OutputFilePath = this.S("../../Avalon/Avalon.Intern/Extern.cs");

        this.IntTypeName = this.S("ulong");

        this.InitClassNewMethodArray();
        return true;
    }

    protected virtual Array ClassNewMethodArray { get; set; }
    protected virtual long ArrayIndex { get; set; }

    protected virtual bool InitClassNewMethodArray()
    {
        Maide newMethod;
        newMethod = new Maide();
        newMethod.Init();
        newMethod.Name = this.S("New");
        newMethod.Param = this.CreateClassNewParam();
        newMethod.Static = true;

        Array deleteParam;
        deleteParam = this.ListInfra.ArrayCreate(1);

        deleteParam.SetAt(0, this.S("o"));

        Maide deleteMethod;
        deleteMethod = new Maide();
        deleteMethod.Init();
        deleteMethod.Name = this.S("Delete");
        deleteMethod.Param = deleteParam;
        deleteMethod.Static = true;

        Maide initMethod;
        initMethod = this.CreateClassNewInstanceMethod("Init");
        Maide finalMethod;
        finalMethod = this.CreateClassNewInstanceMethod("Final");

        Array array;
        array = this.ListInfra.ArrayCreate(4);

        this.ClassNewMethodArray = array;

        this.ArrayIndex = 0;

        this.AddClassNewMethod(newMethod);
        this.AddClassNewMethod(deleteMethod);
        this.AddClassNewMethod(initMethod);
        this.AddClassNewMethod(finalMethod);
        return true;
    }

    protected virtual bool AddClassNewMethod(Maide maide)
    {
        long index;
        index = this.ArrayIndex;

        this.ClassNewMethodArray.SetAt(index, maide);

        index = index + 1;

        this.ArrayIndex = index;
        return true;
    }

    protected virtual Maide CreateClassNewInstanceMethod(string name)
    {
        Maide a;
        a = new Maide();
        a.Init();
        a.Name = this.S(name);
        a.Param = this.CreateClassNewParam();
        a.Static = false;
        return a;
    }

    protected virtual Array CreateClassNewParam()
    {
        Array a;
        a = this.ListInfra.ArrayCreate(0);
        return a;
    }

    protected override bool AddFunctionHeader()
    {
        this.ToolInfra.AddIndent(1);

        this
            .AddS("[")
            .AddS("DllImport")
            .AddS("(").AddS("InfraLib").AddS(")")
            .AddS("]")
            .AddS(" ")
            .AddS("public").AddS(" ").AddS("extern").AddS(" ").AddS("static").AddS(" ")
            ;
        return true;
    }

    protected override bool AddDelegate(Class varClass, Delegate varDelegate)
    {
        this.AddIndent(1);

        this.AddS("public").AddS(" ").AddS("delegate").AddS(" ")
            .Add(this.IntTypeName).AddS(" ");

        this.AddDelegateName(varClass, varDelegate);

        this.AddS("(");

        this.AddDelegateParam(varDelegate.Param);

        this.AddS(")")
            .AddS(";").Add(this.NewLine);
        return true;
    }

    protected override bool AddClassNew(Class varClass)
    {
        this.AddMaideArray(varClass, this.ClassNewMethodArray);
        return true;
    }
}