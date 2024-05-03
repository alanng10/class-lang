namespace Avalon.Network;

public class Port : Any
{
    public override bool Init()
    {
        base.Init();
        this.Intern = Extern.NetworkPort_New();
        Extern.NetworkPort_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.NetworkPort_Final(this.Intern);
        Extern.NetworkPort_Delete(this.Intern);
        return true;
    }

    public virtual PortKind Kind { get; set; }
    public virtual long ValueA { get; set; }
    public virtual long ValueB { get; set; }
    public virtual long ValueC { get; set; }
    public virtual int Server { get; set; }

    internal virtual ulong Intern { get; set; }

    public virtual bool Set()
    {
        ulong kindU;
        kindU = this.Kind.Intern;
        ulong valueAU;
        ulong valueBU;
        ulong valueCU;
        ulong serverU;
        valueAU = (ulong)this.ValueA;
        valueBU = (ulong)this.ValueB;
        valueCU = (ulong)this.ValueC;
        serverU = (ulong)this.Server;
        Extern.NetworkPort_KindSet(this.Intern, kindU);
        Extern.NetworkPort_ValueASet(this.Intern, valueAU);
        Extern.NetworkPort_ValueBSet(this.Intern, valueBU);
        Extern.NetworkPort_ValueCSet(this.Intern, valueCU);
        Extern.NetworkPort_ServerSet(this.Intern, serverU);
        Extern.NetworkPort_Set(this.Intern);
        return true;
    }
}