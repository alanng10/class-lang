namespace Avalon.Text;

public class Create : Any
{
    public static Create This { get; } = ShareCreate();

    private static Create ShareCreate()
    {
        Create share;
        share = new Create();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public virtual TextAdd Add()
    {
        TextAdd a;
        a = new TextAdd();
        a.Init();
        return a;
    }
}