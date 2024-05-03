namespace Avalon.Network;

public class Address : Any
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

    public virtual AddressKind Kind { get; set; }
    public virtual long ValueA { get; set; }
    public virtual long ValueB { get; set; }
    public virtual long ValueC { get; set; }

    internal virtual ulong Intern { get; set; }

    public virtual bool Set()
    {
        ulong kindU;
        kindU = this.Kind.Intern;
        ulong valueAU;
        ulong valueBU;
        ulong valueCU;
        valueAU = (ulong)this.ValueA;
        valueBU = (ulong)this.ValueB;
        valueCU = (ulong)this.ValueC;

        Extern.NetworkPort_KindSet(this.Intern, kindU);
        Extern.NetworkPort_ValueASet(this.Intern, valueAU);
        Extern.NetworkPort_ValueBSet(this.Intern, valueBU);
        Extern.NetworkPort_ValueCSet(this.Intern, valueCU);
        Extern.NetworkPort_Set(this.Intern);
        return true;
    }
}