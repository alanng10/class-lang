namespace Avalon.Network;

public class Address : Any
{
    public override bool Init()
    {
        base.Init();
        this.Intern = Extern.NetworkAddress_New();
        Extern.NetworkAddress_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.NetworkAddress_Final(this.Intern);
        Extern.NetworkAddress_Delete(this.Intern);
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

        Extern.NetworkAddress_SetKind(this.Intern, kindU);
        Extern.NetworkAddress_SetValueA(this.Intern, valueAU);
        Extern.NetworkAddress_SetValueB(this.Intern, valueBU);
        Extern.NetworkAddress_SetValueC(this.Intern, valueCU);
        Extern.NetworkAddress_Set(this.Intern);
        return true;
    }
}