namespace Saber.Module;

public class Travel : NodeTravel
{
    public override bool Init()
    {
        base.Init();
        this.Count = CountList.This;
        this.ErrorKind = ErrorKindList.This;
        return true;
    }

    public virtual Create Create { get; set; }
    protected virtual CountList Count { get; set; }
    protected virtual ErrorKindList ErrorKind { get; set; }

    protected virtual Info Info(NodeNode node)
    {
        return this.Create.Info(node);
    }

    protected virtual Class Class(String name)
    {
        Class a;
        a = this.Create.Class(name);
        return a;
    }

    protected virtual bool UniqueError(ErrorKind kind, NodeNode node, bool did)
    {
        if (!did)
        {
            this.Error(kind, node);

            did = true;
        }

        return did;
    }

    protected virtual bool Error(ErrorKind kind, NodeNode node)
    {
        this.Create.Error(kind, node, this.Create.SourceIndex);
        return true;
    }
}