namespace Avalon.Text;

public class SiteCharForm : Form
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
        if (this.CharFormInfra.Alpha(n, true))
        {
            n = n - 'A' + 'a';
        }
        
        return n;
    }
}