namespace Class.Check;





class ClassTraverse : Traverse
{
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



        map = this.Create.Refer.Class;




        
        if (! (map.Get(className) == null))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeClass);


            return true;
        }










        InfraClass varClass;



        varClass = new InfraClass();



        varClass.Name = className;



        varClass.Base = null;



        varClass.Field = new Table();

        varClass.Field.Compare = new StringCompare();

        varClass.Field.Compare.Init();


        varClass.Field.Init();



        varClass.Mield = new Table();

        varClass.Mield.Compare = new StringCompare();

        varClass.Mield.Compare.Init();



        varClass.Mield.Init();



        varClass.Module = null;



        varClass.Source = this.SourceItem;



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