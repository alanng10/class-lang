namespace Z.Tool.Class.NodeList;

public class CreateOperateStateGen : ToolGen
{
    public override bool Init()
    {
        base.Init();
        this.BoolClass = this.TextCreate(this.S("Bool"));
        this.IntClass = this.TextCreate(this.S("Int"));
        return true;
    }

    public virtual Table ClassTable { get; set; }
    protected virtual String OutputFoldPath { get; set; }
    protected virtual String SourceFileName { get; set; }
    protected virtual Text BoolClass { get; set; }
    protected virtual Text IntClass { get; set; }

    public virtual long Execute()
    {
        this.SourceFileName = this.S("ToolData/Class/CreateOperateStateSource.txt");
        this.OutputFoldPath = this.S("../../Class/Class.Node");

        String kk;
        kk = this.ToolInfra.StorageTextRead(this.SourceFileName);

        Table table;
        table = this.ClassTable;
        
        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);

        while (iter.Next())
        {
            Class varClass;
            varClass = (Class)iter.Value;

            String kind;
            kind = varClass.Name;

            String fieldSetListString;
            fieldSetListString = this.GetFieldSetListString(varClass.Field);

            Text k;
            k = this.TextCreate(kk);
            k = this.Replace(k, "#NodeKind#", kind);
            k = this.Replace(k, "#FieldSetList#", fieldSetListString);

            String a;
            a = this.StringCreate(k);

            String path;
            path = this.GetOutputFilePath(kind);

            this.ToolInfra.StorageTextWrite(path, a);
        }
        return 0;
    }

    protected virtual String GetFieldSetListString(Table fieldList)
    {
        this.AddClear();

        Iter iter;
        iter = fieldList.IterCreate();
        fieldList.IterSet(iter);

        long i;
        i = 0;
        while (iter.Next())
        {
            Field field;
            field = (Field)iter.Value;

            this.AddFieldSet(field, i);

            i = i + 1;
        }

        String a;
        a = this.AddResult();
        return a;
    }

    protected virtual bool AddFieldSet(Field field, long index)
    {
        String className;
        className = field.Class;

        bool isValueClass;
        isValueClass = this.IsFieldValueClass(className);

        string argFieldName;
        argFieldName = null;

        if (isValueClass)
        {
            argFieldName = this.GetArgFieldNameValue(index, className);
        }
        if (!isValueClass)
        {
            argFieldName = this.GetArgFieldName(index, className);
        }


        this.ToolInfra.AppendIndent(sb, 2);
        sb
            .Append("node").Append(".").Append(field.Name)
            .Append(" ").Append("=").Append(" ");

        if (!isValueClass)
        {
            string castClassName;
            castClassName = this.GetCastClassName(className);
            sb.Append("(").Append(castClassName).Append(")");
        }

        sb
            .Append("arg").Append(".").Append(argFieldName)
            .Append(";")
            .Append(this.ToolInfra.NewLine)
            ;
        return true;
    }

    protected virtual bool IsFieldValueClass(String className)
    {
        Text k;
        k = this.TextCreate(className);

        bool b;
        b = false;
        if (!b)
        {
            if (this.TextSame(k, this.BoolClass))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextSame(k, this.IntClass))
            {
                b = true;
            }
        }
        return b;
    }

    protected virtual string GetArgFieldNameValue(int index, string className)
    {
        return "Field" + className;
    }

    protected virtual string GetArgFieldName(int index, string className)
    {
        string fieldIndex;
        fieldIndex = index.ToString("x2");
        string k;
        k = "Field" + fieldIndex;
        return k;
    }

    protected virtual string GetCastClassName(string className)
    {
        string k;
        k = className;
        if (k == "String")
        {
            k = "string";
        }
        return k;
    }

    protected virtual String GetOutputFilePath(String kind)
    {
        String fileName;
        fileName = this.AddClear().AddS("Z_CreateOperateState_").Add(kind).AddS(".cs").AddResult();

        String filePath;
        filePath = this.AddClear().Add(this.OutputFoldPath).AddS("/").Add(fileName).AddResult();
        return filePath;
    }
}