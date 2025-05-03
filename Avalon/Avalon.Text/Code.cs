namespace Avalon.Text;

public class Code : Any
{
    public static Code This { get; } = ShareCreate();

    private static Code ShareCreate()
    {
        Code share;
        share = new Code();
        Any a;
        a = share;
        a.Init();
        return share;
    }
}