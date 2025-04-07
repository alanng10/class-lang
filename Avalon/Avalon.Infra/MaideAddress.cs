namespace Avalon.Infra;

public class MaideAddress : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = Intern.This;

        this.Value = this.InternIntern.MaidePointer(this.Delegate);
        return true;
    }

    public virtual ulong Value { get; set; }

    public virtual SystemDelegate Delegate { get; set; }

    protected virtual Intern InternIntern { get; set; }
}