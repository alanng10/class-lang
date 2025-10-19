namespace Saber.Test;

class Case : Any
{
    public virtual Seer Seer { get; set; }
    public virtual String Kind { get; set; }
    public virtual String Name { get; set; }
    public virtual String Expect { get; set; }
    public virtual String Actual { get; set; }
    public virtual String Path { get; set; }
}