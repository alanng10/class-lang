namespace Class.Console;

public class ModuleString : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        return true;
    }

    public virtual string Path { get; set; }
    public virtual ModuleResult ModuleResult { get; set; }
    public virtual NodeResult NodeResult { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual StringJoin StringJoin { get; set; }
    protected virtual ModuleInfo Info { get; set; }
    protected virtual NodeNode ClassNode { get; set; }
    protected virtual NodeNode Node { get; set; }
    protected virtual NodeNode CurrentNode { get; set; }
    protected virtual int CurrentIndex { get; set; }
    protected virtual string Field { get; set; }
    protected virtual string FieldName { get; set; }
    protected virtual int Index { get; set; }

    public virtual bool Execute()
    {
        bool b;
        b = this.ExecuteAll();

        this.StringJoin = null;
        this.Info = null;
        this.ClassNode = null;
        this.Node = null;

        return b;
    }

    protected virtual bool ExecuteAll()
    {
        this.StringJoin = new StringJoin();
        this.StringJoin.Init();
        
        this.SetClassNode();
        
        this.SetNode();

        if (this.Node == null)
        {
            return true;
        }

        this.Info = (ModuleInfo)this.Node.NodeAny;

        this.NodeInfoString();
        return true;
    }

    protected virtual bool SetClassNode()
    {
        Array rootArray;
        rootArray = this.NodeResult.Root;
        if (rootArray.Count == 0)
        {
            return false;
        }

        NodeNode root;
        root = (NodeNode)rootArray.Get(0);
        this.ClassNode = root;
        return true;
    }

    protected virtual bool SetNode()
    {
        NodeNode t;
        t = this.ClassNode;

        this.CurrentNode = t;

        this.CurrentIndex = 0;

        while (!(this.CurrentNode == null) & this.CurrentIndex < this.Path.Length)
        {
            this.GetFieldNode();
        }

        this.Node = this.CurrentNode;
        return true;
    }

    protected virtual bool GetFieldNode()
    {
        this.SetField();

        this.SetFieldNameIndex();

        this.GetFieldValue();




        this.CurrentIndex = this.CurrentIndex + this.Field.Length + 1;





        this.Field = null;




        this.FieldName = null;




        this.Index = -1;
        return true;
    }




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
        if (varClass == null)
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
        if (field == null)
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
        if (method == null)
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
        if (varVar == null)
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
        this.StringJoin.Append("<Null>");


        return true;
    }


    protected virtual bool Append(string s)
    {
        this.StringJoin.Append(s);


        return true;
    }

    public virtual string Result()
    {
        string ret;

        ret = this.StringJoin.Result();



        return ret;
    }

    protected virtual bool GetFieldValue()
    {
        return true;
    }

    protected virtual bool SetField()
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

    protected virtual bool SetFieldNameIndex()
    {
        int u;
        u = this.LeftSquareIndex(this.Field);        

        bool b;
        b = u < 0;

        if (!b)
        {
            int leftSquareIndex;
            leftSquareIndex = u;

            this.Index = this.GetIndex(this.Field, leftSquareIndex);

            this.FieldName = this.Field.Substring(0, leftSquareIndex);
        }

        if (b)
        {
            this.Index = -1;

            this.FieldName = this.Field;
        }
        return true;
    }

    protected virtual int LeftSquareIndex(string field)
    {
        int a;
        a = field.IndexOf('[');

        return a;
    }

    protected virtual int GetIndex(string field, int leftSquareIndex)
    {
        if (field.Length < 1)
        {
            return -1;
        }

        int lastIndex;
        lastIndex = field.Length - 1;
        
        char lastChar;
        lastChar = field[lastIndex];

        bool b;
        b =  (lastChar == ']');
        
        if (!b)
        {
            return -1;
        }

        int t;
        t = leftSquareIndex + 1;

        int count;
        count = lastIndex - t;

        string s;
        s = field.Substring(t, count);

        bool parse;
        int n;
        parse = int.TryParse(s, out n);

        if (!parse)
        {
            return -1;
        }

        return n;
    }
}