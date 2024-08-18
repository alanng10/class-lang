namespace Z.Tool.PrusateGen;

class PrusateGen : ToolGen
{
    public override bool Init()
    {
        base.Init();

        this.NewLine = this.S("\n");
        this.IntTypeName = this.S("Int");
        this.Combine = this.S("_");

        this.FieldGetFunctionOperate = new FieldGetFunctionOperate();
        this.FieldGetFunctionOperate.Init();
        this.FieldGetFunctionOperate.Gen = this;

        this.FieldSetFunctionOperate = new FieldSetFunctionOperate();
        this.FieldSetFunctionOperate.Init();
        this.FieldSetFunctionOperate.Gen = this;

        this.MethodCallFunctionOperate = new MaideCallFunctionOperate();
        this.MethodCallFunctionOperate.Init();
        this.MethodCallFunctionOperate.Gen = this;

        this.PrudateFileName = this.S("ToolData/Prusate/Prusate.txt");

        this.OutputFilePath = this.S("../../Infra/Infra/Prusate.h");

        return true;
    }
    




    public virtual bool Execute()
    {
        String classListString;
        classListString = this.GetClassListString();

        String methodListString;

        methodListString = this.GetMethodListString();




        ToolInfra infra;

        infra = ToolInfra.This;



        string ka;

        ka = infra.StorageTextRead(this.PrudateFileName);


        StringBuilder sb;

        sb = new StringBuilder();


        sb.Append(ka);


        sb.Replace("#ClassList#", classListString);


        sb.Replace("#MethodList#", methodListString);




        string k;

        k = sb.ToString();



        infra.StorageTextWrite(this.OutputFilePath, k);




        return true;
    }
    




    public virtual ReadResult ReadResult { get; set; }
    public virtual String NewLine { get; set; }
    public virtual String IntTypeName { get; set; }
    public virtual String Combine { get; set; }
    protected virtual String PrudateFileName { get; set; }
    protected virtual String OutputFilePath { get; set; }






    protected virtual FieldGetFunctionOperate FieldGetFunctionOperate { get; set; }



    protected virtual FieldSetFunctionOperate FieldSetFunctionOperate { get; set; }



    protected virtual MaideCallFunctionOperate MethodCallFunctionOperate { get; set; }





    protected virtual String GetClassListString()
    {
        this.AddClear();

        Table table;
        table = this.ReadResult.Class;
        
        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);
        
        while (iter.Next())
        {
            Class varClass;
            varClass = (Class)iter.Value;

            this.AddClass(varClass);
        }

        string o;
        o = sb.ToString();
        return o;
    }





    protected virtual bool AddClass(Class varClass)
    {
        if (varClass.HasNew)
        {
            this.AppendClassNew(varClass);
        }

        this.AppendFieldArray(sb, varClass, varClass.Field);

        this.AddNewLineIfNotEmpty(varClass.Field);

        this.AppendMethodArray(sb, varClass, varClass.Maide);

        this.AddNewLineIfNotEmpty(varClass.Maide);

        this.AppendFieldArray(sb, varClass, varClass.StaticField);

        this.AddNewLineIfNotEmpty(varClass.StaticField);

        this.AppendMethodArray(sb, varClass, varClass.StaticMaide);

        this.AddNewLineIfNotEmpty(varClass.StaticMaide);

        this.AppendDelegateArray(sb, varClass, varClass.Delegate);

        this.AddNewLineIfNotEmpty(varClass.Delegate);
        return true;
    }

    protected virtual bool AddFieldArray(Class varClass, Array fieldArray)
    {
        long count;
        count = fieldArray.Count;
        long i;
        i = 0;
        while (i < count)
        {
            Field field;

            field = (Field)fieldArray.GetAt(i);


            this.AppendField(sb, varClass, field);



            i = i + 1;
        }



        return true;
    }





    protected virtual bool AppendMethodArray(StringBuilder sb, Class varClass, Array methodArray)
    {
        int count;

        count = methodArray.Count;


        int i;

        i = 0;


        while (i < count)
        {
            Maide method;

            method = (Maide)methodArray.GetAt(i);


            this.AppendMethod(sb, varClass, method);


            i = i + 1;
        }



        return true;
    }





    protected virtual bool AppendDelegateArray(StringBuilder sb, Class varClass, Array delegateArray)
    {
        int count;

        count = delegateArray.Count;


        int i;

        i = 0;


        while (i < count)
        {
            Delegate varDelegate;

            varDelegate = (Delegate)delegateArray.GetAt(i);



            this.AppendDelegate(sb, varClass, varDelegate);



            i = i + 1;
        }



        return true;
    }






    protected virtual bool AddField(Class varClass, Field field)
    {
        this.FieldGetFunctionOperate.Class = varClass;
        this.FieldGetFunctionOperate.Field = field;

        this.FieldSetFunctionOperate.Class = varClass;
        this.FieldSetFunctionOperate.Field = field;

        this.AddFunction(this.FieldGetFunctionOperate);

        this.AddFunction(this.FieldSetFunctionOperate);
        return true;
    }

    protected virtual bool AddMethod(Class varClass, Maide method)
    {
        this.MethodCallFunctionOperate.Class = varClass;

        this.MethodCallFunctionOperate.Method = method;

        this.AddFunction(this.MethodCallFunctionOperate);
        return true;
    }

    protected virtual bool AddFunction(FunctionOperate functionOperate)
    {
        this.AddFunctionHeader();

        this.Add(this.IntTypeName).AddS(" ");

        functionOperate.ExecuteName();

        this.AddS("(");

        functionOperate.ExecuteParam();

        this.AddS(")").AddS(";").Add(this.NewLine);
        return true;
    }

    protected virtual bool AddFunctionHeader()
    {
        this.AddS("Infra_Api").AddS(" ");
        return true;
    }





    protected virtual bool AppendDelegate(StringBuilder sb, Class varClass, Delegate varDelegate)
    {
        sb
            .Append("typedef").Append(" ")
            .Append(this.IntTypeName).Append(" ")
            .Append("(").Append("*");


        this.AppendDelegateName(sb, varClass, varDelegate);


        sb
            .Append(")");



        sb
            .Append("(");



        this.AppendDelegateParam(sb, varDelegate.Param);


    
        sb
            .Append(")")
            .Append(";").Append(this.NewLine);




        return true;
    }





    protected virtual bool AppendDelegateName(StringBuilder sb, Class varClass, Delegate varDelegate)
    {
        sb.Append(varClass.Name).Append(this.Combine).Append(varDelegate.Name).Append(this.Combine).Append("Maide");


        return true;
    }





    protected virtual bool AppendDelegateParam(StringBuilder sb, Array param)
    {
        bool b;

        b = (param.Count == 0);


        if (!b)
        {
            string oa;

            oa = this.GetParamItem(param, 0);



            this.AppendVarDeclare(sb, oa);



            this.AppendParamWithOffset(sb, param, 1);
        }



        return true;
    }





    protected virtual string GetMethodListString()
    {
        StringBuilder sb;

        sb = new StringBuilder();



        int count;

        count = this.ReadResult.Maide.Count;


        int i;

        i = 0;


        while (i < count)
        {
            Maide method;

            method = (Maide)this.ReadResult.Maide.GetAt(i);



            this.AppendMethod(sb, null, method);



            i = i + 1;
        }



        string o;

        o = sb.ToString();



        return o;
    }

    public virtual bool AddParamWithOffset(Array param, long offset)
    {
        long count;
        count = param.Count - offset;

        long i;
        i = 0;
        while (i < count)
        {
            long ia;
            ia = i + offset;

            String ka;
            ka = this.GetParamItem(param, ia);

            this.AddParamCombine();

            this.AddVarDeclare(ka);

            i = i + 1;
        }

        return true;
    }

    public virtual bool AddVarDeclare(String varName)
    {
        this.Add(this.IntTypeName).AddS(" ").Add(varName);
        return true;
    }

    public virtual bool AddParamCombine()
    {
        this.AddS(",").AddS(" ");
        return true;
    }

    protected virtual bool AddNewLineIfNotEmpty(Array array)
    {
        if (array.Count == 0)
        {
            return true;
        }

        this.Add(this.NewLine);
        return true;
    }

    public virtual String GetParamItem(Array param, long index)
    {
        return (String)param.GetAt(index);
    }

    protected virtual bool AppendClassNew(StringBuilder sb, Class varClass)
    {
        sb.Append("InfraApiNew").Append("(").Append(varClass.Name).Append(")").Append(this.NewLine);
        return true;
    }
}