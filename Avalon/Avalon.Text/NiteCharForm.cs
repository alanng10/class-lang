namespace Avalon.Text;

public class NiteCharForm : CharForm
{
    public override bool Init()
    {
        base.Init();
        this.CharFormInfra = CharFormInfra.This;
        return true;
    }

    internal virtual CharFormInfra CharFormInfra { get; set; }

    public override long Execute(long n)
    {
        if (this.CharFormInfra.Alpha(n, false))
        {
            n = n - 'a' + 'A';
        }
        
        return n;
    }
}