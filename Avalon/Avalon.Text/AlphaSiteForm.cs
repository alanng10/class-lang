namespace Avalon.Text;

public class AlphaSiteForm : Form
{
    public override bool Init()
    {
        base.Init();
        this.CharFormInfra = FormInfra.This;
        return true;
    }

    internal virtual FormInfra CharFormInfra { get; set; }

    public override long Execute(long n)
    {
        if (this.CharFormInfra.Alpha(n, true))
        {
            n = n - 'A' + 'a';
        }
        
        return n;
    }
}