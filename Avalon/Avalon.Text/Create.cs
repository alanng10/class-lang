namespace Avalon.Text;

public class Create : Any
{
    public virtual TextAdd Add()
    {
        TextAdd a;
        a = new TextAdd();
        a.Init();
        return a;
    }
}