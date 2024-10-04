namespace Saber.Infra;

public class ErrorKind : Any
{
    public virtual long Index { get; set; }

    public virtual String Text { get; set; }
}