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

        this.MaideCallFunctionOperate = new MaideCallFunctionOperate();
        this.MaideCallFunctionOperate.Init();
        this.MaideCallFunctionOperate.Gen = this;

        this.PrusateFileName = this.S("ToolData/Prusate/Prusate.txt");

        this.OutputFilePath = this.S("../../Infra/Infra/Prusate.h");
        return true;
    }

    public virtual ReadResult ReadResult { get; set; }
    public virtual String NewLine { get; set; }
    public virtual String IntTypeName { get; set; }
    public virtual String Combine { get; set; }
    protected virtual String PrusateFileName { get; set; }
    protected virtual String OutputFilePath { get; set; }
    protected virtual FieldGetFunctionOperate FieldGetFunctionOperate { get; set; }
    protected virtual FieldSetFunctionOperate FieldSetFunctionOperate { get; set; }
    protected virtual MaideCallFunctionOperate MaideCallFunctionOperate { get; set; }

    public virtual bool Execute()
    {
        String classListString;
        classListString = this.GetClassListString();

        String maideListString;
        maideListString = this.GetMaideListString();

        ToolInfra toolInfra;
        toolInfra = ToolInfra.This;

        String ka;
        ka = toolInfra.StorageTextRead(this.PrusateFileName);

        Text k;
        k = this.TextCreate(ka);
        k = this.Replace(k, "#ClassList#", classListString);
        k = this.Replace(k, "#MaideList#", maideListString);

        String a;
        a = this.StringCreate(k);

        toolInfra.StorageTextWrite(this.OutputFilePath, a);
        return true;
    }

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

        String a;
        a = this.AddRet();
        return a;
    }

    protected virtual bool AddClass(Class varClass)
    {
        if (varClass.HasNew)
        {
            this.AddClassNew(varClass);
        }

        this.AddFieldArray(varClass, varClass.Field);

        this.AddNewLineIfNotEmpty(varClass.Field);

        this.AddMaideArray(varClass, varClass.Maide);

        this.AddNewLineIfNotEmpty(varClass.Maide);

        this.AddFieldArray(varClass, varClass.StaticField);

        this.AddNewLineIfNotEmpty(varClass.StaticField);

        this.AddMaideArray(varClass, varClass.StaticMaide);

        this.AddNewLineIfNotEmpty(varClass.StaticMaide);

        this.AddDelegateArray(varClass, varClass.Delegate);

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

            this.AddField(varClass, field);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool AddMaideArray(Class varClass, Array maideArray)
    {
        long count;
        count = maideArray.Count;
        long i;
        i = 0;
        while (i < count)
        {
            Maide maide;
            maide = (Maide)maideArray.GetAt(i);

            this.AddMaide(varClass, maide);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool AddDelegateArray(Class varClass, Array delegateArray)
    {
        long count;
        count = delegateArray.Count;
        long i;
        i = 0;
        while (i < count)
        {
            Delegate varDelegate;
            varDelegate = (Delegate)delegateArray.GetAt(i);

            this.AddDelegate(varClass, varDelegate);

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

    protected virtual bool AddMaide(Class varClass, Maide maide)
    {
        this.MaideCallFunctionOperate.Class = varClass;

        this.MaideCallFunctionOperate.Maide = maide;

        this.AddFunction(this.MaideCallFunctionOperate);
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

    protected virtual bool AddDelegate(Class varClass, Delegate varDelegate)
    {
        this.AddS("typedef").AddS(" ").Add(this.IntTypeName).AddS(" ")
            .AddS("(").AddS("*");

        this.AddDelegateName(varClass, varDelegate);

        this.AddS(")");

        this.AddS("(");

        this.AddDelegateParam(varDelegate.Param);

        this.AddS(")").AddS(";").Add(this.NewLine);
        return true;
    }

    protected virtual bool AddDelegateName(Class varClass, Delegate varDelegate)
    {
        this.Add(varClass.Name).Add(this.Combine).Add(varDelegate.Name).Add(this.Combine).AddS("Maide");
        return true;
    }

    protected virtual bool AddDelegateParam(Array param)
    {
        bool b;
        b = (param.Count == 0);

        if (!b)
        {
            String oa;
            oa = this.GetParamItem(param, 0);

            this.AddVarDeclare(oa);

            this.AddParamWithOffset(param, 1);
        }
        return true;
    }

    protected virtual String GetMaideListString()
    {
        this.AddClear();

        long count;
        count = this.ReadResult.Maide.Count;

        long i;
        i = 0;
        while (i < count)
        {
            Maide maide;
            maide = (Maide)this.ReadResult.Maide.GetAt(i);

            this.AddMaide(null, maide);

            i = i + 1;
        }

        String a;
        a = this.AddRet();
        return a;
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

    protected virtual bool AddClassNew(Class varClass)
    {
        this.AddS("InfraApiNew").AddS("(").Add(varClass.Name).AddS(")").Add(this.NewLine);
        return true;
    }
}