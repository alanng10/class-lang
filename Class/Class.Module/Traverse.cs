namespace Class.Module;

public class Traverse : NodeTraverse
{
    public override bool Init()
    {
        base.Init();
        this.Count = this.Create.Count;
        this.ErrorKind = this.Create.ErrorKind;
        this.Module = this.Create.Module;
        return true;
    }

    public virtual Create Create { get; set; }
    public virtual Source Source { get; set; }
    protected virtual CountList Count { get; set; }
    protected virtual ErrorKindList ErrorKind { get; set; }
    protected virtual ClassModule Module { get; set; }

    protected virtual Info Info(NodeNode node)
    {
        return (Info)node.NodeAny;
    }

    protected virtual ClassClass Class(string name)
    {
        ClassClass a;
        a = (ClassClass)this.Module.Class.Get(name);
        return a;
    }

    protected virtual Count GetCount(NodeCount nodeCount)
    {
        Count a;
        a = null;

        if ((a == null) & (nodeCount is PrudateAccess))
        {
            a = this.Count.Prudate;
        }
        if ((a == null) & (nodeCount is ProbateAccess))
        {
            a = this.Count.Probate;
        }
        if ((a == null) & (nodeCount is PrecateAccess))
        {
            a = this.Count.Precate;
        }
        if ((a == null) & (nodeCount is PrivateAccess))
        {
            a = this.Count.Private;
        }
        return a;
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
        this.Create.Error(kind, node, this.Source);



        return true;
    }
}