namespace Class.Module;





class ClassTraverse : Traverse
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;
        return true;
    }


    protected virtual TextInfra TextInfra { get; set; }

    public override bool ExecuteClass(NodeClass nodeClass)
    {
        if (nodeClass == null)
        {
            return true;
        }
        



        ClassName name;
            

        name = nodeClass.Name;




        string className;


        className = name.Value;







        Table map;



        map = this.Create.Refer.Module.Class;




        
        if (!(map.Get(className) == null))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeClass);


            return true;
        }










        ClassClass varClass;



        varClass = new ClassClass();



        varClass.Name = className;



        varClass.Base = null;



        varClass.Field = new Table();

        varClass.Field.Compare = new StringCompare();

        varClass.Field.Compare.Init();


        varClass.Field.Init();



        varClass.Maide = new Table();

        varClass.Maide.Compare = new StringCompare();

        varClass.Maide.Compare.Init();



        varClass.Maide.Init();



        varClass.Module = null;



        varClass.Index = this.SourceItem.Index;







        TableEntry kk;


        kk = new TableEntry();


        kk.Init();


        kk.Index = className;


        kk.Value = varClass;



        map.Add(kk);






        this.Create.Module.Class.Set(varClass.Index, varClass);
        




        this.Check(nodeClass).Class = varClass;




        return true;
    }
}