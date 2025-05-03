namespace Avalon.Text;

public class Code : Any
{
    public static Code This { get; } = ShareCreate();

    private static Code ShareCreate()
    {
        Code share;
        share = new Code();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }

    public virtual Data Execute(CodeKind innKind, CodeKind outKind, Data data, Range range)
    {
        if (!this.ValidKind(innKind, outKind))
        {
            return null;
        }
        return null;
    }

    public virtual bool ValidKind(CodeKind innKind, CodeKind outKind)
    {
        if (innKind == outKind)
        {
            return false;
        }
        return true;
    }
}