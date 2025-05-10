namespace Avalon.Storage;

public class NameForm : Any
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;

        ulong ka;
        ka = Extern.Environ_BinarySystem();

        long k;
        k = (long)ka;

        bool b;
        b = (2 < k & k < 5);

        if (b)
        {
            this.Form = this.TextInfra.AlphaSiteForm;
        }

        if (!b)
        {
            this.Form = new TextForm();
            this.Form.Init();
        }

        return true;
    }

    protected virtual TextInfra TextInfra { get; set; }
    protected virtual TextForm Form { get; set; }

    public virtual long Execute(long n)
    {
        return this.Form.Execute(n);
    }
}