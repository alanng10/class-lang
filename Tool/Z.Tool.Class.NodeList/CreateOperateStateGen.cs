namespace Z.Tool.Class.NodeList;






public class CreateOperateStateGen : Any
{
    public override bool Init()
    {
        base.Init();




        this.ToolInfra = ToolInfra.This;




        return true;
    }




    public virtual Array ClassArray { get; set; }




    protected virtual ToolInfra ToolInfra { get; set; }



    protected virtual string OutputFoldPath { get; set; }



    protected virtual string SourceFileName { get; set; }






    public virtual int Execute()
    {
        this.SourceFileName = "ToolData/CreateOperateStateSource.txt";



        this.OutputFoldPath = "../../Class/Class.Node";





        string kk;

        kk = this.ToolInfra.StorageTextRead(this.SourceFileName);




        int count;

        count = this.ClassArray.Count;


        int i;

        i = 0;


        while (i < count)
        {
            Class varClass;

            varClass = (Class)this.ClassArray.Get(i);


            
            string kind;

            kind = varClass.Name;




            string fieldSetListString;

            fieldSetListString = this.GetFieldSetListString(varClass.Field);




            StringBuilder sb;


            sb = new StringBuilder();



            sb.Append(kk);



            sb.Replace("#NodeKind#", kind);


            sb.Replace("#FieldSetList#", fieldSetListString);




            string k;

            k = sb.ToString();




            string path;

            path = this.GetOutputFilePath(kind);




            this.ToolInfra.StorageTextWrite(path, k);



            i = i + 1;
        }





        return 0;
    }





    protected virtual string GetFieldSetListString(Array fieldList)
    {
        StringBuilder sb;
        sb = new StringBuilder();

        int count;
        count = fieldList.Count;
        Field field;
        int i;
        i = 0;
        while (i < count)
        {
            field = (Field)fieldList.Get(i);

            this.AppendFieldSet(sb, field, i);

            i = i + 1;
        }
        string k;
        k = sb.ToString();
        return k;
    }






    protected virtual bool AppendFieldSet(StringBuilder sb, Field field, int index)
    {
        string className;

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
            .Append("this").Append(".").Append("Arg").Append(".").Append(argFieldName)
            .Append(";")
            .Append(this.ToolInfra.NewLine)
            ;




        return true;
    }





    protected virtual bool IsFieldValueClass(string className)
    {
        bool b;

        b = false;


        if (!b & className == "Bool")
        {
            b = true;
        }



        if (!b & className == "Int")
        {
            b = true;
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





    protected virtual string GetOutputFilePath(string kind)
    {
        string fileName;

        fileName = "Z_CreateOperateState_" + kind + ".cs";



        string filePath;

        filePath = this.OutputFoldPath + "/" + fileName;



        return filePath;
    }
}