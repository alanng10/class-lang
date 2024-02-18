namespace Class.Check;





public class Traverse : NodeTraverse
{
    public override bool Init()
    {
        base.Init();




        this.Refer = this.Create.Refer;




        this.ErrorKind = this.Create.ErrorKind;



        this.Access = this.Create.Access;




        return true;
    }





    public virtual Create Create { get; set; }




    protected Refer Refer { get; set; }





    protected ErrorKindList ErrorKind { get; set; }





    protected AccessList Access { get; set; }





    public SourceItem SourceItem { get; set; }









    protected virtual Check Check(NodeNode node)
    {
        return (Check)this.Create.Check.Get(node);
    }




    protected InfraClass Class(string name)
    {
        InfraClass ret;


        ret = this.Create.Class(name);


        return ret;
    }




    protected Access GetAccess(NodeAccess nodeAccess)
    {
        Access t;


        t = null;




        if (nodeAccess is PrudateAccess)
        {
            t = this.Access.Prudate;
        }


        if (nodeAccess is ProbateAccess)
        {
            t = this.Access.Probate;
        }


        if (nodeAccess is PrecateAccess)
        {
            t = this.Access.Precate;
        }


        if (nodeAccess is PrivateAccess)
        {
            t = this.Access.Private;
        }




        Access ret;


        ret = t;


        return ret;
    }






    protected bool UniqueError(ErrorKind kind, NodeNode node, bool hasAdded)
    {
        if (!hasAdded)
        {
            this.Error(kind, node);


            hasAdded = true;
        }



        return hasAdded;
    }





    protected bool Error(ErrorKind kind, NodeNode node)
    {
        this.Create.Error(kind, node, this.SourceItem);



        return true;
    }
}