namespace Class.Console;




public class ModuleString : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        return true;
    }


    private StringBuilder Builder { get; set; }




    public virtual ModuleResult CheckResult { get; set; }




    public virtual NodeResult NodeResult { get; set; }




    public virtual string Path { get; set; }

    protected virtual InfraInfra InfraInfra { get; set; }





    public virtual bool Execute()
    {
        this.Builder = new StringBuilder();
        




        this.GetClassNode();
        




        this.GetNode();




        if (this.Node == null)
        {
            return true;
        }






        this.Info = (ModuleInfo)this.Node.NodeAny;





        this.NodeInfoString();





        return true;
    }




    private NodeNode ClassNode { get; set; }




    private NodeNode Node { get; set; }





    private NodeNode CurrentNode { get; set; }




    private int CurrentIndex { get; set; }




    private string Field { get; set; }




    private string FieldName { get; set; }




    private ulong? Index { get; set; }






    private bool GetClassNode()
    {
        Array rootArray;



        rootArray = this.NodeResult.Root;




        if (rootArray.Count == 0)
        {
            return true;
        }




        NodeNode root;


        root = (NodeNode)rootArray.Get(0);




        this.ClassNode = root;



        return true;
    }




    protected virtual ModuleInfo Info { get; set; }




    protected virtual bool NodeInfoString()
    {
        this.AppendClass(this.Info.Class);


        this.AppendLine();




        this.AppendField(this.Info.Field);


        this.AppendLine();




        this.AppendMethod(this.Info.Maide);


        this.AppendLine();




        this.AppendVar(this.Info.Var);


        this.AppendLine();






        this.AppendClass(this.Info.OperateClass);


        this.AppendLine();





        this.AppendClass(this.Info.TargetClass);


        this.AppendLine();




        this.AppendField(this.Info.GetField);


        this.AppendLine();




        this.AppendField(this.Info.SetField);


        this.AppendLine();




        this.AppendMethod(this.Info.CallMaide);


        this.AppendLine();




        return true;
    }




    protected virtual bool AppendClass(ClassClass varClass)
    {
        if (this.Null(varClass))
        {
            this.AppendNull();



            return true;
        }




        bool b;


        b = (varClass.Name == null);




        if (b)
        {
            this.Append("<NullClass>");



            return true;
        }





        this.Append("");



        this.Append(":");



        this.Append(varClass.Name);



        return true;
    }



    protected virtual bool AppendField(Field field)
    {
        if (this.Null(field))
        {
            this.AppendNull();



            return true;
        }





        ClassClass varClass;



        varClass = field.Parent;




        this.AppendClass(varClass);




        this.Append(".");




        this.Append(field.Name);




        return true;
    }




    protected virtual bool AppendMethod(Maide method)
    {
        if (this.Null(method))
        {
            this.AppendNull();



            return true;
        }





        ClassClass varClass;



        varClass = method.Parent;




        this.AppendClass(varClass);




        this.Append(".");




        this.Append(method.Name);




        return true;
    }




    protected virtual bool AppendVar(Var varVar)
    {
        if (this.Null(varVar))
        {
            this.AppendNull();



            return true;
        }




        this.Append(varVar.Name);



        return true;
    }




    protected virtual bool AppendLine()
    {
        this.Append("\n");


        return true;
    }



    protected virtual bool AppendNull()
    {
        this.Builder.Append("<Null>");


        return true;
    }


    protected virtual bool Append(string s)
    {
        this.Builder.Append(s);


        return true;
    }





    protected virtual bool Null(object o)
    {
        return o == null;
    }





    public virtual string Result()
    {
        string ret;

        ret = this.Builder.ToString();



        return ret;
    }





    private bool GetNode()
    {
        NodeNode t;



        t = this.ClassNode;


        

        this.CurrentNode = t;




        this.CurrentIndex = 0;




        while (!this.Null(this.CurrentNode) & this.CurrentIndex < this.Path.Length)
        {
            this.GetFieldNode();
        }




        this.Node = this.CurrentNode;




        return true;
    }






    private bool GetFieldNode()
    {
        this.GetField();




        this.GetFieldNameIndex();




        this.GetFieldValue();




        this.CurrentIndex = this.CurrentIndex + this.Field.Length + 1;





        this.Field = null;




        this.FieldName = null;




        this.Index = null;




        return true;
    }





    private bool GetFieldValue()
    {
        return true;
    }




    private bool FailGetFieldValue()
    {
        this.CurrentNode = null;


        return true;
    }




    private bool GetField()
    {
        int startIndex;



        startIndex = this.CurrentIndex;




        int endIndex;



        endIndex = 0;





        int u;



        u = this.Path.IndexOf('.', startIndex);





        bool b;



        b = (u < 0);




        if (b)
        {
            endIndex = this.Path.Length;
        }



        if (!b)
        {
            endIndex = u;
        }





        int count;


        count = endIndex - startIndex;





        string s;



        s = this.Path.Substring(startIndex, count);




        this.Field = s;




        return true;
    }





    private bool GetFieldNameIndex()
    {
        int? u;


        u = this.LeftSquareIndex(this.Field);        





        if (u.HasValue)
        {
            int leftSquareIndex;



            leftSquareIndex = u.Value;




            this.Index = this.GetIndex(this.Field, leftSquareIndex);





            this.FieldName = this.Field.Substring(0, leftSquareIndex);
        }




        if (!u.HasValue)
        {
            this.Index = null;





            this.FieldName = this.Field;
        }




        return true;
    }

    




    private int? LeftSquareIndex(string field)
    {
        int t;



        t = field.IndexOf('[');




        if (t < 0)
        {
            return null;
        }




        int ret;


        ret = t;



        return ret;
    }





    private ulong? GetIndex(string field, int leftSquareIndex)
    {
        if (field.Length < 1)
        {
            return null;
        }





        int lastIndex;



        lastIndex = field.Length - 1;




        char lastChar;


        lastChar = field[lastIndex];




        bool b;



        b =  (lastChar == ']');
        



        if (!b)
        {
            return null;
        }





        int t;


        t = leftSquareIndex + 1;





        int count;


        count = lastIndex - t;





        string s;



        s = field.Substring(t, count);





        bool parse;




        ulong n;



        parse = ulong.TryParse(s, out n);




        if (!parse)
        {
            return null;
        }



        return n;
    }
}