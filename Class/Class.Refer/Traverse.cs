namespace Class.Refer;





public class Traverse : NodeTraverse
{
    public override bool Init()
    {
        base.Init();




        this.Refer = this.Create.Refer;




        this.ErrorKind = this.Create.ErrorKind;



        this.Count = this.Create.Access;




        return true;
    }





    public virtual Create Create { get; set; }




    protected virtual ClassRefer Refer { get; set; }





    protected virtual ErrorKindList ErrorKind { get; set; }





    protected virtual CountList Count { get; set; }





    public virtual SourceItem SourceItem { get; set; }









    protected virtual Check Check(NodeNode node)
    {
        return (Check)this.Create.Check.Get(node);
    }




    protected virtual InfraClass Class(string name)
    {
        InfraClass ret;


        ret = this.Create.Class(name);


        return ret;
    }




    protected virtual Count GetAccess(NodeCount nodeCount)
    {
        Count t;


        t = null;




        if (nodeCount is PrudateAccess)
        {
            t = this.Count.Prudate;
        }


        if (nodeCount is ProbateAccess)
        {
            t = this.Count.Probate;
        }


        if (nodeCount is PrecateAccess)
        {
            t = this.Count.Precate;
        }


        if (nodeCount is PrivateAccess)
        {
            t = this.Count.Private;
        }




        Count ret;


        ret = t;


        return ret;
    }






    protected virtual bool UniqueError(ErrorKind kind, NodeNode node, bool hasAdded)
    {
        if (!hasAdded)
        {
            this.Error(kind, node);


            hasAdded = true;
        }



        return hasAdded;
    }





    protected virtual bool Error(ErrorKind kind, NodeNode node)
    {
        this.Create.Error(kind, node, this.SourceItem);



        return true;
    }
}