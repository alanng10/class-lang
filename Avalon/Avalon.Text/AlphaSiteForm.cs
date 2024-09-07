namespace Avalon.Text;

public class AlphaSiteForm : Form
{
    public override bool Init()
    {
        base.Init();
        this.FormInfra = FormInfra.This;
        return true;
    }

    internal virtual FormInfra FormInfra { get; set; }

    public override long Execute(long n)
    {
        if (this.FormInfra.Alpha(n, true))
        {
            n = n - 'A' + 'a';
        }
        
        return n;
    }
}