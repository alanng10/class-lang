namespace Class.Refer;




public class InitTraverse : Traverse
{
    protected override bool ExecuteNode(NodeNode node)
    {
        Info check;



        check = this.Create.CreateCheck();





        TableEntry entry;


        entry = new TableEntry();


        entry.Init();


        entry.Index = node;


        entry.Value = check;




        this.Create.Check.Add(entry);




        return true;
    }
}