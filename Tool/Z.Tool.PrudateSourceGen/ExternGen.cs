namespace Z.Tool.PrudateSourceGen;





class ExternGen : PrudateGen
{
    public override bool Init()
    {
        base.Init();




        this.PrudateFileName = "ToolData/Extern.txt";


        this.OutputFilePath = "../../Avalon/Avalon.Intern/Extern.cs";




        this.IntTypeName = "ulong";




        this.InitClassNewMethodArray();




        return true;
    }




    protected virtual Array ClassNewMethodArray { get; set; }



    protected virtual int ClassNewMethodIndex { get; set; }




    protected virtual bool InitClassNewMethodArray()
    {
        Method newMethod;

        newMethod = new Method();

        newMethod.Init();


        newMethod.Name = "New";

        newMethod.Param = this.CreateClassNewParam();
        
        
        newMethod.Static = true;

        


        Array deleteParam;

        deleteParam = new Array();

        deleteParam.Count = 1;

        deleteParam.Init();


        deleteParam.Set(0, "o");




        Method deleteMethod;

        deleteMethod = new Method();

        deleteMethod.Init();


        deleteMethod.Name = "Delete";

        deleteMethod.Param = deleteParam;


        deleteMethod.Static = true;




        Method initMethod;

        initMethod = this.CreateClassNewInstanceMethod("Init");


        Method finalMethod;

        finalMethod = this.CreateClassNewInstanceMethod("Final");



        Array array;

        array = new Array();

        array.Count = 4;

        array.Init();



        this.ClassNewMethodArray = array;



        this.AddClassNewMethod(newMethod);


        this.AddClassNewMethod(deleteMethod);


        this.AddClassNewMethod(initMethod);


        this.AddClassNewMethod(finalMethod);




        return true;
    }






    protected virtual bool AddClassNewMethod(Method method)
    {
        int index;

        index = this.ClassNewMethodIndex;



        this.ClassNewMethodArray.Set(index, method);



        index = index + 1;



        this.ClassNewMethodIndex = index;



        return true;
    }
    




    protected virtual Method CreateClassNewInstanceMethod(string name)
    {
        Method a;

        a = new Method();

        a.Init();


        a.Name = name;


        a.Param = this.CreateClassNewParam();


        a.Static = false;



        return a;
    }




    protected virtual Array CreateClassNewParam()
    {
        Array a;

        a = new Array();

        a.Count = 0;

        a.Init();



        return a;
    }





    protected override bool AppendFunctionHeader(StringBuilder sb)
    {
        ToolInfra infra;

        infra = ToolInfra.This;


        infra.AppendIndent(sb, 1);



        sb
            .Append("[")
            .Append("DllImport")
            .Append("(").Append("InfraLib").Append(")")
            .Append("]")
            .Append(" ")
            .Append("public").Append(" ").Append("extern").Append(" ").Append("static").Append(" ")
            ;
        


        return true;
    }





    protected override bool AppendDelegate(StringBuilder sb, Class varClass, Delegate varDelegate)
    {
        ToolInfra infra;

        infra = ToolInfra.This;


        infra.AppendIndent(sb, 1);




        sb
            .Append("public").Append(" ").Append("delegate").Append(" ")
            .Append(this.IntTypeName).Append(" ");


        this.AppendDelegateName(sb, varClass, varDelegate);



        sb
            .Append("(");


        this.AppendDelegateParam(sb, varDelegate.Param);


        sb
            .Append(")")
            .Append(";").Append(this.NewLine);




        return true;
    }




    protected override bool AppendClassNew(StringBuilder sb, Class varClass)
    {
        this.AppendMethodArray(sb, varClass, this.ClassNewMethodArray);



        return true;
    }
}