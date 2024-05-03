namespace Avalon.Infra;

public class StringCreate : Any
{
    public virtual string Char(char c)
    {
        return c.ToString();
    }

    
}