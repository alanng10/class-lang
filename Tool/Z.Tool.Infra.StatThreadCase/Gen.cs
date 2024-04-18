namespace Z.Tool.StatThreadCaseSourceGen;





class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "ThreadCase";



        this.ScopeName = "";



        this.ScopeSeparator = "";
        



        this.ItemListFileName = "ItemListThreadCase.txt";


        this.MethodFileName = "MethodThreadCase.txt";




        int o;
        
        o = base.Execute();


        return o;
    }




    protected override string GetItemMethod(string method, Iter iter, int index)
    {
        return base.GetItemMethod(method, iter, index + 1);
    }




    protected override string GetShareVarList()
    {
        return "";
    }
}